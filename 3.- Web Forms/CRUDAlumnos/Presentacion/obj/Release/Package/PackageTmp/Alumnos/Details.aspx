<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Presentacion.Alumnos.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Datos del Alumno</h1>
    <hr />
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

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel"><asp:Label ID="lblTituloModal" runat="server"></asp:Label></h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label1" runat="server"></asp:Label><br />
                    <asp:Label ID="Label2" runat="server"></asp:Label><br />
                    <asp:Label ID="Label3" runat="server"></asp:Label><br />
                    <asp:Label ID="Label4" runat="server"></asp:Label><br />
                    <asp:Label ID="Label5" runat="server"></asp:Label><br />
                    <asp:Label ID="Label6" runat="server"></asp:Label><br />
                    <asp:Label ID="Label7" runat="server"></asp:Label><br />
                    <asp:Label ID="Label8" runat="server"></asp:Label><br />
                    <asp:Label ID="Label9" runat="server"></asp:Label><br />
                    <asp:Label ID="Label10" runat="server"></asp:Label><br />
                    <asp:Label ID="Label11" runat="server"></asp:Label><br />
                    <asp:Label ID="Label12" runat="server"></asp:Label><br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <button type="button" class="btn btn-primary" onclick="pasarId()">Calcular IMSS</button>
    <%--<asp:Button ID="btnIMSS" runat="server" Text="Calcular IMSS" CssClass="btn btn-primary" OnClick="btnIMSS_Click" />--%>
    <asp:Button ID="btnISR" runat="server" Text="Calcular ISR" CssClass="btn btn-primary" OnClick="btnISR_Click" /><br />
    <a href="Index">Regresar a Lista</a>

    <script type="text/javascript">
        function pasarId() {
            $.ajax({
                type: 'POST',
                url: "http://localhost:53001/WSAlumnos.asmx/CalcularIMSS",
                data: JSON.stringify({ id: <%= lblId.Text %> }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: funcExito,
                error: errorGenerico
            });
        }

        function funcExito(resultado, estatus, jqXHR) {
            var oRespuesta = resultado.d;
            try {
                if (oRespuesta != null) {
                    //alert('Transacción efectuada con éxito' + oRespuesta.Censantia);
                    $('#<%= lblTituloModal.ClientID %>').text("Cálcular IMSS");
                    $('#<%= Label1.ClientID %>').text("Enfermedad y Maternidad");
                    $('#<%= Label2.ClientID %>').text(oRespuesta.EnfermedadMaternidad);
                    $('#<%= Label3.ClientID %>').text("Invalidez y Vida");
                    $('#<%= Label4.ClientID %>').text(oRespuesta.InvalidezVida);
                    $('#<%= Label5.ClientID %>').text("Retiro");
                    $('#<%= Label6.ClientID %>').text(oRespuesta.Retiro);
                    $('#<%= Label7.ClientID %>').text("Cesantia");
                    $('#<%= Label8.ClientID %>').text(oRespuesta.Censantia);
                    $('#<%= Label9.ClientID %>').text("Infonavit");
                    $('#<%= Label10.ClientID %>').text(oRespuesta.Infonavit
);
                    $('#exampleModal').modal('show');
                }
                else {
                    alert('La respuesta recibida del Web Service es incorrecta ' + resultado.d);
                }
            }
            catch (ex) {
                alert('Error al recibir los datos');
            }
        }

        function errorGenerico() {
            alert("Ocurrio un error");
        }
    </script>

</asp:Content>
