<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <br />
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4">
        <%foreach (Modelo.Articulo articulo in ListaArticulos)
          { %>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%: articulo.imagen %>" class="logos"  alt="Sin Foto">
                        <div class="card-body">
                            <h5 class="titulo" ><%: articulo.nombre %></h5>
                            <p class="card-text"><%: articulo.descripcion %></p>
                            <a href="DetalleArticulo.aspx?id=<%:articulo.id %>" class="btn btn-primary btn-sm botones">Ver Detalle</a>
                        </div>
                    </div>
                </div>
            <% } %>
    </div>
</asp:Content>
