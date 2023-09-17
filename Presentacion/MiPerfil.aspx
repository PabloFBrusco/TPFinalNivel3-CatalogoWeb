<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Presentacion.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style> 
        .Validacion{
            color:red;
            font-size:12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi Perfil</h1>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar el nombre" CssClass="Validacion" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
            <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click"  CssClass="btn btn-primary" Text="Guardar" />
            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click"  CssClass="btn btn-secondary" Text="Cancelar" />
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label ID="Label5" runat="server" Text="Imagen Perfil"></asp:Label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <asp:Image ID="imgPerfil" ImageUrl="https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg"
                    runat="server" CssClass="img-fluid mb-3" />
            </div>

        </div>
    </div>

</asp:Content>
