using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyPark.Backend.Datos;
using EasyPark.Backend.Entidad;
using EasyPark.Backend.Negocio;

namespace EasyPark.Frontend.html
{
    public partial class registro_Usuario : System.Web.UI.Page
    {
        //objetos
        eUsuario voEUsuario = new eUsuario();
        nUsuario voNUsuario = new nUsuario();

        static bool isNew = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarRoles();
                disable();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            bool emailIsValid = txtCorreo.Text.Contains("@ulacit.ed.cr");

            if (emailIsValid)
            {
                if (!isNew)
                {
                    // Modificar usuario
                    voEUsuario.NumeroIdentificacion = cedula;
                    voEUsuario.NombreCompleto = txtNombre.Text;
                    voEUsuario.Correo = correo;
                    voEUsuario.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                    voEUsuario.IdRol = Convert.ToInt32(ddlRol.SelectedValue);

                    voNUsuario.n_editarUsuario(voEUsuario);

                    //pop up
                    Mensaje.Title("Mensaje");
                    Mensaje.ContentMsg("Usuario modificado correctamente!");
                }
                else
                {
                    // Verificar duplicados
                    if (voNUsuario.n_existeUsuario(cedula, correo))
                    {
                        lblMensaje.Text = "El usuario con esta cédula o correo ya existe.";
                        lblMensaje.CssClass = "alert alert-danger";
                        return;
                    }
                    else
                    {
                        // guardar Nuevo
                        voEUsuario.NombreCompleto = txtNombre.Text;
                        voEUsuario.NumeroIdentificacion = cedula;
                        voEUsuario.Correo = correo;
                        voEUsuario.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                        voEUsuario.IdRol = Convert.ToInt32(ddlRol.SelectedValue);

                        voNUsuario.n_insertUsuario(voEUsuario);

                        //pop up
                        Mensaje.Title("Mensaje");
                        Mensaje.ContentMsg("Usuario registrado correctamente!");
                    }
                }

                limpiarTxt();
                isNew = true;
                disable();
            }
            else
            {
                Mensaje.Title("Alert");
                Mensaje.ContentMsg("Formato inválido del correo");
                txtCorreo.Text = "";
            }
        }

        private void cargarRoles()
        {
            try
            {
                nRol voRol = new nRol();
                List<eRol> listaRoles = voRol.obtenerRoles();

                ddlRol.DataSource = listaRoles;
                ddlRol.DataTextField = "NombreRol";
                ddlRol.DataValueField = "IdRol";
                ddlRol.DataBind();

                ddlRol.Items.Insert(0, new ListItem("Seleccione un rol", ""));
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnSearchClient_Click(object sender, EventArgs e)
        {
            
                //validates if exists
                if (voNUsuario.n_existeUsuario(txtSearchClient.Text, txtSearchClient.Text))
                {
                    //load data
                    gvSearchData.DataSource = voNUsuario.n_buscarUsuarioPorCedula(txtSearchClient.Text);
                    gvSearchData.DataBind();
                }
                else
                {
                    pnlSearchClients.Visible = false;
                    txtSearchClient.Text = "";
                    Mensaje.Title("Alert");
                    Mensaje.ContentMsg("El usuario no existe");
                }
        }

        protected void gvSearchData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Select")
            {
                GridViewRow row = gvSearchData.Rows[index];
                txtCedula.Text = row.Cells[1].Text;
                txtNombre.Text = row.Cells[2].Text;
                txtCorreo.Text = row.Cells[3].Text;
                txtFechaNacimiento.Text = Convert.ToDateTime(row.Cells[4].Text).ToString("yyyy-MM-dd");
                ddlRol.SelectedValue = row.Cells[5].Text;
                
                pnlSearchClients.Visible = false;
                txtSearchClient.Text = "";
                gvSearchData.DataBind();
                enable();
                txtCedula.Enabled = false;

                isNew = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            disable();
            limpiarTxt();
        }

        public void enable()
        {
            txtCedula.Enabled = true;
            txtCorreo.Enabled = true;
            txtFechaNacimiento.Enabled = true;
            ddlRol.Enabled = true;
            txtNombre.Enabled = true;

            btnCancelar.Enabled = true;
            btnRegistrar.Enabled = true;
            btnAbrirBuscarUsuario.Enabled = false;
            btnNuevo.Enabled = false;
        }

        public void disable()
        {
            txtCedula.Enabled = false;
            txtCorreo.Enabled = false;
            txtFechaNacimiento.Enabled = false;
            ddlRol.Enabled = false;
            txtNombre.Enabled = false;

            btnCancelar.Enabled = false;
            btnRegistrar.Enabled = false;
            btnAbrirBuscarUsuario.Enabled = true;
            btnNuevo.Enabled = true;
        }

        private void limpiarTxt()
        {
            txtNombre.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            ddlRol.SelectedIndex = 0;
        }

        protected void btnAbrirBuscarUsuario_Click(object sender, EventArgs e)
        {
            pnlSearchClients.Visible = true;
        }

        protected void btnCloseMsg_Click(object sender, EventArgs e)
        {
            pnlSearchClients.Visible = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            enable();
            isNew = true;
        }
    }
}