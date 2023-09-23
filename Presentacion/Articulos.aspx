<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Presentacion.Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Panel de Administración</h1>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label1" runat="server" Text="Administrar"></asp:Label>
            <asp:DropDownList ID="ddlTabla" OnTextChanged="ddlTabla_TextChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row"> 
        <div class="col">
        <asp:GridView ID="dgvArticulos" runat="server" CssClass="table table-warning table-striped" DataKeyNames="id" 
                      AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
        <Columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" />
                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderStyle-HorizontalAlign ="Center" HeaderText="Acción" />
        </Columns>
        </asp:GridView>
        <asp:GridView ID="dgvCategorias" runat="server" CssClass="table table-warning table-striped" DataKeyNames="id" 
                      AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged">
        <Columns>
                <asp:BoundField HeaderText="Código" DataField="Id" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderStyle-HorizontalAlign ="Center" HeaderText="Acción" />
        </Columns>
        </asp:GridView>
        <asp:GridView ID="dgvMarcas" runat="server" CssClass="table table-warning table-striped" DataKeyNames="id" 
                      AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" >
        <Columns>
                <asp:BoundField HeaderText="Código" DataField="Id" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderStyle-HorizontalAlign ="Center" HeaderText="Acción" />
        </Columns>
        </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-12 ">
        <asp:Button ID="btnAgregar" cssclass="btn btn-primary" runat="server" OnClick="btnAgregar_Click" Text="Agregar Item" />
    </div>
    </div>
</asp:Content>
