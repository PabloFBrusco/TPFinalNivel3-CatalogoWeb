<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="ABMArticulos.aspx.cs" Inherits="Presentacion.ABMArticulos" %>
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
                <label for="txtCodigo" class="form-label">Nombre</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="btn btn-sm btn-secondary dropdown-toggle dropdown-toggle-split" runat="server"></asp:DropDownList>
                <label for="ddlCategoria" class="form-label">    Categoria</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="btn btn-sm btn-secondary dropdown-toggle dropdown-toggle-split" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-4">
            <asp:updatepanel>
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagen" class="form-label">URL Imagen</label>
                        <asp:TextBox ID="txtImagen" CssClass="form-control form-control-sm" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" runat="server"></asp:TextBox>
                    </div>
                        <asp:Image id="imgFoto" ImageUrl="https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740" alt="Sin Foto" class="imagen" runat="server"></asp:Image>
                    </ContentTemplate>
            </asp:updatepanel>
            
        </div> 
    </div>
    <div class="row row-cols-2">
        <div class="col-6">
            <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" Text="Aceptar" />
            <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-primary" OnClick="btnModificar_Click" Text="Aceptar Cambios" />
            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" Text="Eliminar" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-primary" OnClick="btnCancelar_Click"  Text="Cancelar" />
        </div>
        <divclass="col-6">
           <asp:CheckBox ID="chkEliminar" runat="server" /><asp:Label ID="lblEliminar" runat="server" Text="Realmente desea Eliminar?"></asp:Label>
           <asp:Button ID="btnEliminarDef" runat="server" Text="Eliminar" OnClick="btnEliminarDef_Click" CssClass="btn btn-danger" />
        </divclass>
        
    </div>
    
</asp:Content>
