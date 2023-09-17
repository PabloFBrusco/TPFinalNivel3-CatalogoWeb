<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Presentacion.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row row-cols-2">
            <div class="col-4">
                <asp:Image id="imgFoto" alt="Sin Foto" class="imagen" runat="server"></asp:Image>
            </div> 
            <div class="col-8">
                <div>
                    <asp:Label id="LblTitulo" class="tituloDetalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="lblCodigo" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="LblDescripcion" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="lblMarca" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="lblCategoria" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="lblPrecio" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <a href="Default.aspx" class="btn btn-primary btn-sm botones">Volver</a>
                </div>
                               
            </div>
        </div>

</asp:Content>
