<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Presentacion.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style> 
        .Validacion{
            color:red;
            font-size:12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registrá tu perfil:</h2>
    <hr />
    <div class="row">
        
        <div class="col-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>  
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>  
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click"  Text="Aceptar" />
                <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" runat="server" OnClick="btnCancelar_Click" Text="Cancelar"/>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="mb-3">
            <asp:Label ID="lblExiste" runat="server" Font-Bold="true" ForeColor="Red" BorderColor="Red" Text="El e-mail ya se encuentra registrado"></asp:Label>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblCodigo" class="form-label" runat="server" Text="Ingrese su Código"></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <asp:Button ID="btnVerificar" CssClass="btn btn-info btn-sm" runat="server" OnClick="btnVerificar_Click" Text="Verificar Mail" />
        </div>

    </div>
</asp:Content>
