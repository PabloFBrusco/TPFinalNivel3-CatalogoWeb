<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Presentacion.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style> 
        .Validacion{
            color:red;
            font-size:12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Contactame:</h1>
    <div class="row">
        <div class="col-3">

        </div>
        <div class="col-6">
            <div class="mb-3">
                <asp:Label runat="server" cssClass="form-label" Text="Nombre y Apellido:"></asp:Label>
                <asp:TextBox runat="server" cssClass="form-control" id="txtNombre"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar el nombre" CssClass="Validacion" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label runat="server" cssClass="form-label" Text="Empresa:"></asp:Label>
                <asp:TextBox runat="server" cssClass="form-control" id="TxtEmpresa"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" cssClass="form-label" Text="Teléfono:"></asp:Label>
                <asp:TextBox runat="server" cssClass="form-control" id="txtTelefono"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" cssClass="form-label" Text="Ciudad:"></asp:Label>
                <asp:TextBox runat="server" cssClass="form-control" id="txtCiudad"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" cssClass="form-label" Text="e-mail:"></asp:Label>
                <asp:TextBox runat="server" cssClass="form-control" id="txtemail"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar el correo" CssClass="Validacion" ControlToValidate="txtemail" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Debe ingresar un correo válido" CssClass="Validacion" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label runat="server" cssClass="form-label" Text="Motivo del Contacto:"></asp:Label>
                <asp:TextBox runat="server" cssClass="form-control" id="txtAsunto"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" cssClass="form-label" Text="Mensaje:"></asp:Label>
                <asp:TextBox runat="server" cssClass="form-control" id="txtMensaje" textMode="MultiLine"></asp:TextBox>
            </div>

            <div class="row">   
                <div class="col-5"></div>
                <div class ="col-2">
                    <div>
                        <asp:Button runat="server" id="btnEnviar" OnClick="btnEnviar_Click" cssClass="btn btn-primary" Text="Enviar" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-3">

        </div>
    </div>
</asp:Content>
