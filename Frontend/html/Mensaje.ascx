<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensaje.ascx.cs" Inherits="EasyPark.Frontend.html.WebUserControl1" %>

<asp:Panel ID="pnlMessage" runat="server" Visible="false">
    <div class="modalsForm" style="padding-top:80px">
        <div class="modals-contenidoForm w-50">
            <div class="encabezadoForm">
                <h2>
                    <asp:Button ID="btnCloseMsg" runat="server" Text="" CssClass="float-end btn-close btn-danger" OnClick="btnCloseMsg_Click" />

                    <asp:Label ID="Header" runat="server" Text="Label"></asp:Label>
                </h2>
            </div>
            <div class="contenido m-5">
                <asp:Label ID="Content" runat="server" Text="Label" CssClass="h4"></asp:Label>
            </div>

        </div>
    </div>
</asp:Panel>
