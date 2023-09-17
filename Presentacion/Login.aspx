<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-6">   
        <h1>Ingrese su usuario y contraseña</h1>
        <div class="mb-3">
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtUSer" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe ingresar el correo" CssClass="Validacion" ControlToValidate="txtUser" runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Debe ingresar un correo válido" CssClass="Validacion" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtUser" runat="server" />
        </div>
        <div  class="mb-3">
            <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div  class="mb-3">
            <asp:Button ID="btnAcceder" runat="server" OnClick="btnAcceder_Click" CssClass="btn btn-primary" Text="Aceptar" />
            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" Text="Cancelar" />
        </div>
        <div  class="mb-3">
            <a href="Registro.aspx">No tengo usuario. Registrarme</a>
        </div>
    </div>
</asp:Content>
