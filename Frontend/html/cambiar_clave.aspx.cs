using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyPark.Backend.Negocio;

namespace EasyPark.Frontend.html
{
    public partial class cambiar_clave : System.Web.UI.Page
    {
        nUsuario voNUsuario = new nUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            string nuevaClave = txtNuevaClave.Text;

            if (nuevaClave == "Ulacit123")
            {
                lblMensaje.Text = "No puede usar la contraseña predeterminada.";
                lblMensaje.CssClass = "alert alert-danger";
                return;
            }

            string numeroIdentificacion = Session["numeroIdentificacion"].ToString();
            voNUsuario.n_cambiarContrasena(numeroIdentificacion, nuevaClave);

            lblMensaje.Text = "Contraseña actualizada correctamente.";
            lblMensaje.CssClass = "alert alert-success";

            Response.Redirect("login.aspx");
        }
    }
}