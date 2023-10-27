<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Presentacion.Alumnos.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Alumno</h1>
    <hr />
    <div class="container">
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Nombre</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxtNombre" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="El Nombre es obligatorio" ControlToValidate="tbxtNombre" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="El nombre solo puede tener letras y espacios" ControlToValidate="tbxtNombre" CssClass="text-danger" ValidationExpression="^[a-zA-Z\\s]+$" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Primer Apellido</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxPrimerApe" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvPrimerApe" runat="server" ErrorMessage="El Apellido es obligatorio" ControlToValidate="tbxPrimerApe" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPrimerApe" runat="server" ErrorMessage="El Apellido solo puede tener letras y espacios" ControlToValidate="tbxPrimerApe" CssClass="text-danger" ValidationExpression="^[a-zA-Z\\s]+$" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Segundo Apellido</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxSegunApe" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvSegunApe" runat="server" ErrorMessage="El Apellido es obligatorio" ControlToValidate="tbxPrimerApe" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revSegunApe" runat="server" ErrorMessage="El Apellido solo puede tener letras y espacios" ControlToValidate="tbxSegunApe" CssClass="text-danger" ValidationExpression="^[a-zA-Z\\s]+$" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Fecha Nacimiento</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxFecha" runat="server" placeholder="From" type="date" CssClass="w-100"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="La Fecha de Nacimiento es obligatoria" ControlToValidate="tbxFecha" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvFecha" runat="server" ErrorMessage="lA Fecha de nacimiento debe ser entre el 01-ene-1990 y el 31- dic -2000" ControlToValidate="tbxFecha" Type="Date" MinimumValue="1990-01-01" MaximumValue="2000-12-31" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>CURP</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxCurp" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvCurp" runat="server" ErrorMessage="La CURP es obligatoria" ControlToValidate="tbxCurp" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvCurp" runat="server" ErrorMessage="La CURP no coincide con los datos ingresados" CssClass="text-danger" Display="Dynamic" ClientValidationFunction="validarCurp"></asp:CustomValidator>
            </div>
        </div>
        <div class="d-flex gap-4">
            <div class="col-2 text-end">
                <p><b>Correo</b></p>
            </div>
            <div class="col-2 text-start">
                <asp:TextBox ID="tbxCorreo" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ErrorMessage="El Correo es obligatorio" ControlToValidate="tbxCorreo" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
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
                <asp:RangeValidator ID="rvSueldo" runat="server" ErrorMessage="El Sueldo debe ser entre 10,000 y 40,000" ControlToValidate="tbxSueldo" Type="Currency" MinimumValue="10000.00" MaximumValue="40000.00" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
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
    </div>
    <asp:Button ID="Button2" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /><br />
    <a href="Index">Regresar a Lista</a>

    <script type="text/javascript">
        function validarCurp(sender, args) {
            let fechaNacimiento = document.getElementById('<%= tbxFecha.ClientID %>').value;
            let fechaNacimientoCompar = fechaNacimiento.substr(2)
            let fechaCurp = document.getElementById('<%= tbxCurp.ClientID %>').value;
            let fechaFinalCurp = `${fechaCurp.substr(4, 2)}-${fechaCurp.substr(6, 2)}-${fechaCurp.substr(8, 2)}`;
            args.IsValid = fechaNacimientoCompar == fechaFinalCurp;
        }
    </script>
</asp:Content>
