<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ADOWebForms.forms.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalles</h1>
    <hr />
    <p><b>Id </b><asp:Label ID="idEstatus" runat="server" Text="Label"></asp:Label></p>
    <p><b>Nombre </b><asp:Label ID="nomEstatus" runat="server" Text="Label"></asp:Label></p>
    <p><b>Clave </b><asp:Label ID="clavEstatus" runat="server" Text="Label"></asp:Label></p>
    <a href="Index">Regresar a la lista</a>
</asp:Content>
