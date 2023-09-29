<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Presentacion.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="Estilos.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <br />
    </div>
    <div class="col-12">   
        <%if (ListaArticulos.Count == 0)
            {%>
                <h5>No hay artículos seleccionados como favoritos</h5>
            <%} %>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4">
        
        <asp:Repeater runat="server" id="Reptarjeta">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("imagen")%>" onerror="this.onerror=null; this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740'"  class="logos"  alt="Sin Foto">
                        <div class="card-body">
                            <h5 class="titulo" ><%#Eval("nombre")%></h5>
                            <p class="card-text">Marca: <%#Eval("marca")%></p>
                            <p class="card-text">Categoría: <%#Eval("categoria")%></p>
                            <p class="Precio">Precio: $ <%#Eval("precio")%></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("id")%>" id="link" class="btn btn-primary btn-sm botones">Ver Detalle</a>
                            <%if (Session["usuarioLogueado"] != null)
                                { %>
                            <asp:Button ID="BtnFavorito" OnClick="BtnFavorito_Click" 
                                CssClass='<%# Eval("favorito").ToString() == "1" ? "btn btn-danger btn-sm" : "btn btn-success btn-sm" %>' 
                                CommandArgument='<%#Eval("id")%>' commandName="ArticuloId" runat="server" 
                                Text='<%# Eval("favorito").ToString() == "1" ? "Quitar de Favorito" : "Agregar a Favorito" %>'/>                         
                            <%} %>

                        </div>
                    </div>
                </div>
            </ItemTemplate>      

        </asp:Repeater>


    </div>
</asp:Content>
