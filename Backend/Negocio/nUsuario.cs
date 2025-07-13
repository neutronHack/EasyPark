using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using EasyPark.Backend.Datos;
using EasyPark.Backend.Entidad;

namespace EasyPark.Backend.Negocio
{
    public class nUsuario
    {
        //object
        dUsuario voUsuario = new dUsuario();

        public void n_insertUsuario(eUsuario Usuario)
        {
            voUsuario.insertUsuario(Usuario);

        }

        public bool n_existUsuarioLogin(string numeroIdentificacion, string contrasena)
        {
            return voUsuario.existUsuarioLogin(numeroIdentificacion, contrasena);
        }

        public string n_editarUsuario(eUsuario Usuario)
        {
            if (string.IsNullOrWhiteSpace(Usuario.NombreCompleto) || string.IsNullOrWhiteSpace(Usuario.Correo))
                return "Nombre y correo son obligatorios.";

            return voUsuario.editarUsuario(Usuario);
        }

        public DataTable n_buscarUsuarioPorCedula(string cedula)
        {
            return voUsuario.buscarPorCedula(cedula);
        }

        public bool n_existeUsuario(string cedula, string correo)
        {
            return voUsuario.existeUsuario(cedula, correo);
        }

        public void n_cambiarContrasena(string idUsuario, string nuevaClave)
        {
            voUsuario.cambiarContrasena(idUsuario, nuevaClave);
        }

        public eUsuario n_obtenerUsuarioLogin(string numeroIdentificacion, string contrasena)
        {
            DataTable dt = voUsuario.obtenerUsuarioLogin(numeroIdentificacion, contrasena);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                return new eUsuario
                {
                    IdUsuario = Convert.ToInt32(row["id_usuario"]),
                    NumeroIdentificacion = row["numero_identificacion"].ToString(),
                    NombreCompleto = row["nombre_completo"].ToString(),
                    Correo = row["correo"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]),
                    IdRol = Convert.ToInt32(row["id_rol"]),
                    DebeCambiarClave = Convert.ToBoolean(row["DebeCambiarClave"])
                };
            }

            return null; // No encontrado
        }

    }
}