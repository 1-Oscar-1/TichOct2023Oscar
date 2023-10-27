<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Presentacion.Alumnos.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Actualizar Alumno</h1>
    <hr />
    <div class="container">
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>ID</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxId" runat="server" Enabled="false"></asp:TextBox><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Nombre</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxtNombre" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Primer Apellido</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxPrimerApe" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Segundo Apellido</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxSegunApe" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Fecha Nacimiento</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxFecha" runat="server" placeholder="From" type="date" CssClass="w-100"></asp:TextBox><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>CURP</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxCurp" runat="server"></asp:TextBox><br />
                <asp:CustomValidator ID="cvCurp" runat="server" ErrorMessage="La CURP no coincide con los datos ingresados" CssClass="text-danger" Display="Dynamic" OnServerValidate="cvCurp_ServerValidate"></asp:CustomValidator>
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Correo</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxCorreo" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Telefono</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxTelefono" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Sueldo Mensual</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxSueldo" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Estado</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:DropDownList ID="tbxEstado" runat="server" CssClass="w-100"></asp:DropDownList><br />
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Estatus</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:DropDownList ID="tbxEstatus" runat="server" CssClass="w-100"></asp:DropDownList><br />
            </div>
        </div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /><br />
        <a href="Index">Regresar a Lista</a>
    </div>
</asp:Content>
