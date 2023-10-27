<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ADOWebForms.forms.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar</h1>
    <hr />
    <p><b>Id</b></p>
    <asp:TextBox ID="tbxId" runat="server"></asp:TextBox><br />
    <p><b>Nombre</b></p>
    <asp:TextBox ID="tbxNombre" runat="server"></asp:TextBox><br />
    <p><b>Clave</b></p>
    <asp:TextBox ID="tbxClave" runat="server"></asp:TextBox><br />
    <a href="Index">Regresar a la lista</a>
    <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" /><br />
</asp:Content>
