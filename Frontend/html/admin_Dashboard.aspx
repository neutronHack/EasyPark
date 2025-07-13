<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin_Dashboard.aspx.cs" Inherits="EasyPark.Frontend.html.admin_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-end m-3">
        <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-danger" Text="Cerrar sesión" />
    </div>

    <div class="container text-center mt-5">
        <h2>Dashboard Administrador</h2>
        <p class="lead">Bienvenido al panel de control de EasyParking.</p>
        <asp:Button ID="btnRegistrarUsuario" runat="server" CssClass="btn btn-primary mt-3" Text="Registrar Usuario" PostBackUrl="registro_Usuario.aspx"/>
    </div>

</asp:Content>

