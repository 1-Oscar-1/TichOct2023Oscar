<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Alumnos.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Listado Alumnos</h1>
    <hr />
    <asp:HyperLink ID="lnkEditar" runat="server" NavigateUrl="Create" CssClass="btn btn-primary my-2" Text="Agregar" />
    <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAlumnos_PageIndexChanging" CssClass="table" >
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido" />
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido" />
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            
            <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:HyperLink ID="lnkDetalle" runat="server" NavigateUrl='<%# "Details?id=" + Eval("id") %>' CssClass="btn btn-warning" Text="Detalles" />
                <asp:HyperLink ID="lnkEditar" runat="server" NavigateUrl='<%# "Edit?id=" + Eval("id") %>' CssClass="btn btn-success" Text="Editar" />
                <asp:HyperLink ID="lnkEliminar" runat="server" NavigateUrl='<%# "Delete?id=" + Eval("id") %>' CssClass="btn btn-danger" Text="Eliminar" />
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
