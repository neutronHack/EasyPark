<%@ Page Title="Semáforo" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Semaforo.aspx.cs" Inherits="EasyPark.Frontend.Semaforo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="card">
            <div class="card-header bg-primary text-white">
                <h4>Control de Acceso Vehicular</h4>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Número de Placa:</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label class="col-sm-3 col-form-label">Parqueo:</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlParqueo" runat="server" CssClass="form-control">
                            <asp:ListItem Value="1">Parqueo A</asp:ListItem>
                            <asp:ListItem Value="2">Parqueo B</asp:ListItem>
                            <asp:ListItem Value="3">Parqueo C</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                
                <div class="form-group row">
                    <div class="col-sm-12 text-center">
                        <asp:Button ID="btnValidar" runat="server" Text="Validar Acceso" 
                            CssClass="btn btn-primary" OnClick="btnValidar_Click" />
                    </div>
                </div>
                
                <div class="text-center mt-4">
                    <div id="luzSemaforo" runat="server" class="semaforo-luz"></div>
                    <div id="mensajeResultado" runat="server" class="mt-3 font-weight-bold"></div>
                </div>
            </div>
        </div>
    </div>

    <style>
        .semaforo-luz {
            width: 120px;
            height: 120px;
            border-radius: 50%;
            margin: 0 auto;
            border: 4px solid #333;
            background-color: #ddd;
            transition: all 0.3s ease;
        }
        
        .semaforo-luz.verde {
            background-color: #28a745;
            box-shadow: 0 0 25px #28a745;
        }
        
        .semaforo-luz.rojo {
            background-color: #dc3545;
            box-shadow: 0 0 25px #dc3545;
        }
    </style>
</asp:Content>