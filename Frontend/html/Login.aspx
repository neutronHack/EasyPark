<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EasyPark.Frontend.html.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-lg-4 col-md-6 col-sm-12">
                <div class="card shadow-sm border-0 rounded-4">
                    <div class="card-header text-center bg-light">
                        <img src="~/images/ulacit_logo.png" class="img-fluid" alt="ULACIT" style="max-height: 50px;">
                        <h4 class="mt-2 titulo_inicio_sesion">Iniciar Sesión</h4>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <asp:TextBox ID="txtCedulaLogin" runat="server"
                                CssClass="form-control input_inicio_sesion"
                                MaxLength="9"
                                placeholder="Cédula" />
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtPasswordLogin" runat="server"
                                CssClass="form-control input_inicio_sesion"
                                placeholder="Contraseña"
                                TextMode="Password" />
                        </div>
                        <div id="error_sms" runat="server"></div>
                        <div class="d-grid gap-2">
                            <asp:Button ID="btnLogin" runat="server"
                                Text="Iniciar Sesión"
                                CssClass="btn btn-primary btn_inicio_sesion"
                                OnClick="btnLogin_Click" />
                            <asp:Button ID="btnIrRegistro" runat="server"
                                Text="Ir a Registro"
                                CssClass="btn btn-secondary btn_inicio_sesion"
                                PostBackUrl="~/Registro.aspx" />
                        </div>
                        <div class="mt-3 text-center">
                            <a href="#" style="font-size: 13px; color: #707c97;">¿Olvidaste tu contraseña?</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
