using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Alumnos
{
    public partial class Details : System.Web.UI.Page
    {
        int _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se toma el id de la url
            _id = int.Parse(Request.QueryString["id"] ?? "3");
            Alumno alumno= NAlumno.Consultar(_id);

            // Se trae el estado
            List<Estado> listEstado = NEstado.Consultar(alumno.idEstado);
            Estado estado = listEstado[0];

            // Se trae el estatus
            List<EstatusAlumno> listEstatus = NEstatusAlumno.Consultar(alumno.idEstatus);
            EstatusAlumno estatus = listEstatus[0];

            // Se llenan los campos
            lblId.Text = alumno.id.ToString();
            lblNombre.Text = alumno.nombre.ToString();
            lblPirmerApe.Text = alumno.primerApellido.ToString();
            lblSegApe.Text = alumno.segundoApellido.ToString();
            lblFechaNaci.Text = alumno.fechaNacimiento.ToString();
            lblCurp.Text = alumno.curp.ToString();
            lblCorr.Text = alumno.correo.ToString();
            lblSueldo.Text = alumno.sueldo.ToString();
            lblEstado.Text = estado.nombre;
            lblEstatus.Text = estatus.nombre;
        }

        protected void btnIMSS_Click(object sender, EventArgs e)
        {
            // Se traen los datos
            AportacionesIMSS aportaciones = NAlumno.CalcularIMSS(_id);

            // Se cargan los datos
            lblTituloModal.Text = "Cálcular IMSS";
            Label1.Text = "Enfermedad y Maternidad";
            Label2.Text = aportaciones.EnfermedadMaternidad.ToString("C2");
            Label3.Text = "Invalidez y Vida";
            Label4.Text = aportaciones.InvalidezVida.ToString("C2");
            Label5.Text = "Retiro";
            Label6.Text = aportaciones.Retiro.ToString("C2");
            Label7.Text = "Cesantia";
            Label8.Text = aportaciones.Censantia.ToString("C2");
            Label9.Text = "Infonavit";
            Label10.Text = aportaciones.Infonavit.ToString("C2");

            string script = "$(document).ready(function() { $('#exampleModal').modal('show'); });";

            // Registra el script con ScriptManager
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", script, true);
        }

        protected void btnISR_Click(object sender, EventArgs e)
        {
            // Se traen los datos
            ItemTablaISR itemIsr = NAlumno.CalcularISR(_id);

            // Se cargan los datos
            lblTituloModal.Text = "Cálcular ISR";
            Label1.Text = "Limite Inferior";
            Label2.Text = itemIsr.LimiteInferior.ToString("C2");
            Label3.Text = "Limite Superior";
            Label4.Text = itemIsr.LimiteSuperior.ToString("C2");
            Label5.Text = "Cuota Fija";
            Label6.Text = itemIsr.CuotaFija.ToString("C2");
            Label7.Text = "Excedente Limite Inferior";
            Label8.Text = itemIsr.Excedente.ToString("C2");
            Label9.Text = "Subsidio";
            Label10.Text = itemIsr.Subsidio.ToString("C2");
            Label9.Text = "Impuesto";
            Label10.Text = itemIsr.ISR.ToString("C2");

            string script = "$(document).ready(function() { $('#exampleModal').modal('show'); });";

            // Registra el script con ScriptManager
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", script, true);
        }
    }
}