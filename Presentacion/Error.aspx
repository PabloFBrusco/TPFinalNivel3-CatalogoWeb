<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTPFinal.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Presentacion.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div claas="content">
        <h1>Se ha producido un error</h1>
        <br />
        <div class="col">
            <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button ID="btnVolver" OnClick="btnVolver_Click" runat="server" CssClass="btn btn-primary" Text="Volver" />
        </div>
        
    </div>
</asp:Content>
