using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyPark.Backend.Datos;
using EasyPark.Backend.Entidad;
using EasyPark.Backend.Negocio;

namespace EasyPark.Frontend.html
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        nUsuario voNUsuario = new nUsuario();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //string numeroIdentificacion = txtCedulaLogin.Text.Trim();
            //string contrasena = txtPasswordLogin.Text.Trim();

            //var usuario = voNUsuario.n_existeUsuario(numeroIdentificacion, contrasena);

            //if (!string.IsNullOrEmpty(numeroIdentificacion) && !string.IsNullOrEmpty(contrasena))
            //{
            //    if (voNUsuario.n_existUsuarioLogin(numeroIdentificacion, contrasena))
            //    {
            //        // Login exitoso
            //        Session["numeroIdentificacion"] = numeroIdentificacion;

            //        // Mensaje o redirección
            //        Response.Redirect("admin_Dashboard.aspx");
            //    }
            //    else
            //    {
            //        // Usuario no encontrado o contraseña incorrecta
            //        error_sms.InnerHtml = "<span style='color:red;'>Usuario o contraseña incorrectos.</span>";
            //    }
            //}
            //else
            //{
            //    // Campos vacíos
            //    error_sms.InnerHtml = "<span style='color:red;'>Debe completar todos los campos.</span>";
            //}


            string numeroIdentificacion = txtCedulaLogin.Text.Trim();
            string contrasena = txtPasswordLogin.Text.Trim();

            if (!string.IsNullOrEmpty(numeroIdentificacion) && !string.IsNullOrEmpty(contrasena))
            {
                eUsuario usuario = voNUsuario.n_obtenerUsuarioLogin(numeroIdentificacion, contrasena);

                if (usuario != null)
                {
                    Session["usuarioId"] = usuario.IdUsuario;
                    Session["numeroIdentificacion"] = usuario.NumeroIdentificacion;

                    if (usuario.DebeCambiarClave)
                    {
                        Response.Redirect("cambiar_clave.aspx");
                    }
                    else
                    {
                        Response.Redirect("admin_Dashboard.aspx");
                    }
                }
                else
                {
                    error_sms.InnerHtml = "<span style='color:red;'>Usuario o contraseña incorrectos.</span>";
                }
            }
            else
            {
                error_sms.InnerHtml = "<span style='color:red;'>Debe completar todos los campos.</span>";
            }

        }
    }
}