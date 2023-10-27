<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentacion.Alumnos.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Eliminar Alumno</h1>
    <h3>¿Esta seguro que desea eliminar al Alumno?</h3>
    <div class="d-flex gap-4">
        <div class="text-end">
            <p><b>ID</b></p>
            <p><b>Nombre</b></p>
            <p><b>Primer Apellido</b></p>
            <p><b>Segundo Apellido</b></p>
            <p><b>Fecha Nacimiento</b></p>
            <p><b>CURP</b></p>
            <p><b>Correo</b></p>
            <p><b>Sueldo Mensual</b></p>
            <p><b>Estado</b></p>
            <p><b>Estatus</b></p>
        </div>
        <div class="text-start m-l">
            <p><asp:Label ID="lblId" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblPirmerApe" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblSegApe" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblFechaNaci" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblCurp" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblCorr" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblSueldo" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblEstado" runat="server" Text="Label"></asp:Label></p>
            <p><asp:Label ID="lblEstatus" runat="server" Text="Label"></asp:Label></p>
        </div>
    </div>
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" /><br />
    <a href="Index">Regresar a Lista</a>
</asp:Content>
