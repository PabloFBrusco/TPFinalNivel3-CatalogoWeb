<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="ABMMarcas.aspx.cs" Inherits="Presentacion.ABMMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-2">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtID" class="form-label">ID</label>
                <asp:TextBox ID="txtID" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Nombre</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row row-cols-2">
        <div class="col-6">
            <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary" Text="Aceptar" />
            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" CssClass="btn btn-primary" Text="Aceptar Cambios" />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" CssClass="btn btn-danger" Text="Eliminar" />
            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-primary" Text="Cancelar" />
        </div>
        <div class="col-6">   
            <asp:Label ID="LblExiste" runat="server" Text="No se puede Eliminar la marca porque está usada"></asp:Label>
        </div>
        <divclass="col-6">
           <asp:CheckBox ID="chkEliminar" runat="server" /><asp:Label ID="lblEliminar" runat="server" Text="Realmente desea Eliminar?"></asp:Label>
           <asp:Button ID="btnEliminarDef" runat="server" OnClick="btnEliminarDef_Click"  Text="Eliminar" CssClass="btn btn-danger" />
        </divclass>
    
</asp:Content>
