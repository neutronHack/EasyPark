using System;
using System.Data;
using System.Data.SqlClient;

namespace EasyPark.Backend
{
    public class Semaforo    {
        private readonly string _connectionString;

        public Semaforo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ResultadoValidacion ValidarAcceso(string placa, int parqueoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // 1. Verificar si el vehículo está registrado
                var vehiculo = VerificarVehiculoRegistrado(placa, connection);

                if (vehiculo.Existe && !vehiculo.Activo)
                    return new ResultadoValidacion(false, "Vehículo inactivo");

                if (!vehiculo.Existe)
                {
                    // Verificar primer ingreso
                    var temporal = VerificarVehiculoTemporal(placa, connection);
                    if (temporal.Ingresos >= 1)
                        return new ResultadoValidacion(false, "Debe registrar el vehículo");

                    if (temporal.Ingresos == 0)
                        RegistrarPrimerIngreso(placa, connection);
                }

                // 2. Verificar disponibilidad en parqueo
                if (!VerificarDisponibilidadParqueo(parqueoId, connection))
                    return new ResultadoValidacion(false, "Parqueo lleno");

                return new ResultadoValidacion(true, "Acceso autorizado");
            }
        }

        private (bool Existe, bool Activo) VerificarVehiculoRegistrado(string placa, SqlConnection connection)
        {
            var cmd = new SqlCommand(
                "SELECT activo FROM vehiculo WHERE numero_placa = @placa", connection);
            cmd.Parameters.AddWithValue("@placa", placa);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return (true, Convert.ToBoolean(reader["activo"]));
                return (false, false);
            }
        }

        private (int Ingresos, bool Existe) VerificarVehiculoTemporal(string placa, SqlConnection connection)
        {
            var cmd = new SqlCommand(
                "SELECT cantidad_ingresos FROM vehiculo_temporal WHERE numero_placa = @placa",
                connection);
            cmd.Parameters.AddWithValue("@placa", placa);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return (Convert.ToInt32(reader["cantidad_ingresos"]), true);
                return (0, false);
            }
        }

        private void RegistrarPrimerIngreso(string placa, SqlConnection connection)
        {
            var cmd = new SqlCommand(
                "INSERT INTO vehiculo_temporal (numero_placa, fecha_primer_ingreso, cantidad_ingresos) " +
                "VALUES (@placa, @fecha, 1)", connection);
            cmd.Parameters.AddWithValue("@placa", placa);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
            cmd.ExecuteNonQuery();
        }

        private bool VerificarDisponibilidadParqueo(int parqueoId, SqlConnection connection)
        {
            var cmd = new SqlCommand(
                "SELECT (capacidad_regulares - capacidad_regulares_ocupados) as disponibles " +
                "FROM parqueo WHERE id_parqueo = @parqueoId", connection);
            cmd.Parameters.AddWithValue("@parqueoId", parqueoId);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return Convert.ToInt32(reader["disponibles"]) > 0;
                return false;
            }
        }
    }

    public class ResultadoValidacion
    {
        public bool Autorizado { get; }
        public string Mensaje { get; }

        public ResultadoValidacion(bool autorizado, string mensaje)
        {
            Autorizado = autorizado;
            Mensaje = mensaje;
        }
    }
}