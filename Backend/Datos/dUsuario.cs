using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using EasyPark.Backend.Entidad;
using EasyPark.Backend.Negocio;
using System.Web.Services.Description;

namespace EasyPark.Backend.Datos
{
    public class dUsuario
    {
        //connection string to sql
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        DataTable dt;
        SqlDataAdapter da;


        // Insertar
        public void insertUsuario(eUsuario Usuario)
        {
            SqlCommand cmd = new SqlCommand("insertar_usuario", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = Usuario.NombreCompleto;
            cmd.Parameters.Add("@NumeroIdentificacion", SqlDbType.VarChar).Value = Usuario.NumeroIdentificacion;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Usuario.Correo;
            cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = "Ulacit123";
            cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = Usuario.FechaNacimiento;
            cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = Usuario.IdRol;
            cmd.Parameters.Add("@DebeCambiarClave", SqlDbType.Bit).Value = true;


            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Modificar
        public string editarUsuario(eUsuario Usuario)
        {
            SqlCommand cmd = new SqlCommand("editar_usuario", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@numero_identificacion", SqlDbType.Int).Value = Usuario.NumeroIdentificacion;
            cmd.Parameters.Add("@nombre_completo", SqlDbType.VarChar).Value = Usuario.NombreCompleto;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = Usuario.Correo;
            cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.Date).Value = Usuario.FechaNacimiento;
            cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = Usuario.IdRol;

            cmd.ExecuteNonQuery();
            con.Close();

            return "Usuario editado correctamente";
        }

        // Buscar por cedula
        public DataTable buscarPorCedula(string cedula)
        {
            SqlCommand cmd = new SqlCommand("buscar_usuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@buscador", SqlDbType.Int).Value = cedula;

            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        // Verificar duplicado
        public bool existeUsuario(string cedula, string correo)
        {
            SqlCommand cmd = new SqlCommand("verificar_usuario_existente", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero_identificacion", cedula);
            cmd.Parameters.AddWithValue("@correo", correo);

            bool existe = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            con.Close();
            return existe;
        }

        // Cambiar contraseña
        public void cambiarContrasena(string idUsuario, string nuevaClave)
        {
            SqlCommand cmd = new SqlCommand("cambiar_contrasena", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero_identificacion", idUsuario);
            cmd.Parameters.AddWithValue("@nueva_contrasena", nuevaClave);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Login
        public bool existUsuarioLogin(string numeroIdentificacion, string contrasena)
        {
            SqlCommand cmd = new SqlCommand("login_usuario", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@numero_identificacion", SqlDbType.VarChar).Value = numeroIdentificacion;
            cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena;

            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count > 0;
        }

        public DataTable obtenerUsuarioLogin(string numeroIdentificacion, string contrasena)
        {
            SqlCommand cmd = new SqlCommand("login_contrasena", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@numero_identificacion", SqlDbType.VarChar).Value = numeroIdentificacion;
            cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }


    }
}