<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registro_Usuario.aspx.cs" Inherits="EasyPark.Frontend.html.registro_Usuario" %>
<%@ Register Src="Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    <h2 class="text-center">Gestión de Usuarios</h2>

    <div class="row justify-content-center">
        <div class="col-md-6">
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert d-none" EnableViewState="false" />

            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control mb-3" placeholder="Nombre Completo" />
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control mb-3" placeholder="Correo Electrónico" />
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control mb-3" TextMode="Date" />
            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control mb-3" placeholder="Cédula" MaxLength="9" />
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control mb-3" AppendDataBoundItems="true">
                <asp:ListItem Text="Seleccione un rol" Value="" />
            </asp:DropDownList>

            <div class="d-flex justify-content-between mt-4">
                <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-warning" OnClick="btnNuevo_Click" Text="Nuevo"/>
                <asp:Button ID="btnAbrirBuscarUsuario" runat="server" CssClass="btn btn-primary" Text="Buscar Usuario" OnClick="btnAbrirBuscarUsuario_Click" />
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>

            <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary mt-3" Text="Volver" PostBackUrl="admin_Dashboard.aspx" />
        </div>
    </div>
</div>

     <%-- message and search panel --%>
 <uc1:mensaje runat="server" ID="Mensaje" />

 <asp:Panel ID="pnlSearchClients" runat="server" Visible="false">
     <div class="modalsForm" style="padding-top:80px">
         <div class="modals-contenidoForm w-50">
             <div class="encabezadoForm">
                 <h2>
                     <asp:Button ID="btnCloseMsg" runat="server" Text="" CssClass="float-end btn-close btn-danger" OnClick="btnCloseMsg_Click" />

                     <asp:Label ID="header" runat="server" Text="Busca a un Usuario"></asp:Label>
                 </h2>
             </div>
             <div class="contenido m-5">
                 <div class="d-flex">
                     <asp:TextBox ID="txtSearchClient" type="number" CssClass="form-control w-75" runat="server"></asp:TextBox>
                     <asp:LinkButton ID="btnSearchClient" runat="server" CssClass="btn btn-primary w-bg-opacity-25 mx-3" style="padding-left:25px; padding-right:25px" OnClick="btnSearchClient_Click"><i class="bi-search"></i></asp:LinkButton>
                 </div>
                 <br />

                 <%-- GridView --%>
                 <asp:GridView ID="gvSearchData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvSearchData_RowCommand">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:LinkButton ID="btnSelect" CssClass="btn btn-success" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Select"><i class="bi-check"></i></asp:LinkButton>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                     <EditRowStyle BackColor="#2461BF" />
                     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                     <RowStyle BackColor="#EFF3FB" />
                     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     <SortedAscendingCellStyle BackColor="#F5F7FB" />
                     <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                     <SortedDescendingCellStyle BackColor="#E9EBEF" />
                     <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 </asp:GridView>
             </div>
         </div>
     </div>
 </asp:Panel>

</asp:Content>
