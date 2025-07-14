using EasyPark.Backend;
using System;
using System.Web.UI;
using EasyPark.Frontend;



namespace EasyPark.Frontend
{
    public partial class Semaforo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicialización si es necesaria
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MostrarResultado(false, "Ingrese un número de placa");
                return;
            }

            try
            {
                // Cambiar la instancia de Semaforo a un servicio adecuado
                var servicio = new EasyPark.Backend.Semaforo(
                    System.Configuration.ConfigurationManager.ConnectionStrings["ParqueoConnection"].ConnectionString);

                var resultado = servicio.ValidarAcceso(
                    txtPlaca.Text.Trim(),
                    int.Parse(ddlParqueo.SelectedValue));

                MostrarResultado(resultado.Autorizado, resultado.Mensaje);
                RegistrarBitacora(resultado.Autorizado, resultado.Mensaje);
            }
            catch (Exception ex)
            {
                MostrarResultado(false, "Error: " + ex.Message);
            }
        }

        private void MostrarResultado(bool autorizado, string mensaje)
        {
            luzSemaforo.Attributes["class"] = autorizado ? "semaforo-luz verde" : "semaforo-luz rojo";
            mensajeResultado.InnerText = mensaje;
            mensajeResultado.Style["color"] = autorizado ? "#28a745" : "#dc3545";
        }

        private void RegistrarBitacora(bool autorizado, string motivo)
        {
            // Implementar registro en bitácora
            // Ejemplo básico:
            /*
            string placa = txtPlaca.Text.Trim();
            int parqueoId = int.Parse(ddlParqueo.SelectedValue);
            int usuarioId = Convert.ToInt32(Session["UsuarioId"]);
            
            using (var connection = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["ParqueoConnection"].ConnectionString))
            {
                var cmd = new SqlCommand(
                    "INSERT INTO bitacora (numero_placa, id_parqueo, id_oficial, tipo_evento, autorizado, motivo_rechazo) " +
                    "VALUES (@placa, @parqueoId, @oficialId, 'ingreso', @autorizado, @motivo)", connection);
                
                cmd.Parameters.AddWithValue("@placa", placa);
                cmd.Parameters.AddWithValue("@parqueoId", parqueoId);
                cmd.Parameters.AddWithValue("@oficialId", usuarioId);
                cmd.Parameters.AddWithValue("@autorizado", autorizado);
                cmd.Parameters.AddWithValue("@motivo", autorizado ? DBNull.Value : (object)motivo);
                
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            */
        }
    }
}