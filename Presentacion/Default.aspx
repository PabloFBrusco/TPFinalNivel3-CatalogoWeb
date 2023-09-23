﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Precio {
    color: black;
    font-size: 16px;
    font-weight:bold;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <div class="row">
            <div class="col-9">
                    <div class="mb-3">
                        <asp:Label ID="lblCampo" runat="server" Text="Filtrar Por:"></asp:Label>
                        <asp:DropDownList ID="ddlCampo" CssClass="btn btn-primary btn-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                        <asp:ListItem Text="Categoría" />
                        <asp:ListItem Text="Marca" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                         <asp:Label ID="lblCriterio" runat="server" Text="Que sea:"></asp:Label>
                        <asp:DropDownList ID="ddlCriterio" CssClass="btn btn-primary btn-sm dropdown-toggle" runat="server">
                        <asp:ListItem Text="Empieza con" />
                        <asp:ListItem Text="Termina con" />
                        <asp:ListItem Text="Contiene" />
                    </asp:DropDownList>
                         <asp:Label ID="lblFiltroA" CssClass="col-form-label" runat="server" Text="Filtro"></asp:Label>
                        <asp:TextBox ID="txtParametroFiltro" runat="server"></asp:TextBox>
                        <asp:Button ID="btnFiltrar" CssClass="btn btn-primary btn-sm" OnClick="btnFiltrar_Click" runat="server" Text="Filtrar" />
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-primary btn-sm" OnClick="btnLimpiar_Click"  runat="server" Text="Limpiar Filtro" />
                    </div>  
             </div>

        <div class="col-3">
            <asp:Label ID="Label1" runat="server" Text="Ordenar por:"></asp:Label>
            <asp:DropDownList ID="ddlOrden" CssClass="btn btn-sm btn-secondary dropdown-toggle dropdown-toggle-split" OnTextChanged="ddlOrden_TextChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4">
        <asp:Repeater runat="server" id="Reptarjeta">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("imagen")%>"  class="logos"  alt="Sin Foto">
                        <div class="card-body">
                            <h5 class="titulo" ><%#Eval("nombre")%></h5>
                            <p class="card-text"><%#Eval("descripcion")%></p>
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
