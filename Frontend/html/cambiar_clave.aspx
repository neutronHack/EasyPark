<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cambiar_clave.aspx.cs" Inherits="EasyPark.Frontend.html.cambiar_clave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
    <h2 class="text-center">Cambio de Contraseña</h2>

    <div class="row justify-content-center">
        <div class="col-md-6">
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert d-none" EnableViewState="false" />

            <asp:TextBox ID="txtNuevaClave" runat="server" CssClass="form-control mb-3" TextMode="Password" placeholder="Nueva contraseña" />

            <asp:Button ID="btnCambiar" runat="server" CssClass="btn btn-primary" Text="Cambiar Contraseña" OnClick="btnCambiar_Click" />
        </div>
    </div>
</div>

</asp:Content>
