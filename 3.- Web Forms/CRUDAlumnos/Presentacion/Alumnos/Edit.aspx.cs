using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Alumnos
{
    public partial class Edit : System.Web.UI.Page
    {
        int _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se toma el id de la url
            _id = int.Parse(Request.QueryString["id"] ?? "3");

            if (!IsPostBack)
            {
                tbxEstado.DataSource = NEstado.Consultar(-3);
                tbxEstado.DataTextField = "nombre";
                tbxEstado.DataValueField = "id";
                tbxEstado.DataBind();

                tbxEstatus.DataSource = NEstatusAlumno.Consultar(-3);
                tbxEstatus.DataTextField = "nombre";
                tbxEstatus.DataValueField = "id";
                tbxEstatus.DataBind();

                // Se traen los datos
                Alumno alumno = NAlumno.Consultar(_id);
                List<Estado> listEstado = NEstado.Consultar(alumno.idEstado);
                Estado estado = listEstado[0];
                List<EstatusAlumno> listEstatus = NEstatusAlumno.Consultar(alumno.idEstatus);
                EstatusAlumno estatus = listEstatus[0];

                // Se cargan los datos
                tbxId.Text = _id.ToString();
                tbxtNombre.Text = alumno.nombre;
                tbxPrimerApe.Text = alumno.primerApellido;
                tbxSegunApe.Text = alumno.segundoApellido;
                tbxFecha.Text = alumno.fechaNacimiento.ToString("yyyy-MM-dd");
                tbxCurp.Text = alumno.curp;
                tbxCorreo.Text = alumno.correo;
                tbxTelefono.Text = alumno.telefono;
                tbxSueldo.Text = alumno.sueldo.ToString();
                tbxEstado.SelectedValue = alumno.idEstado.ToString();
                tbxEstatus.SelectedValue = alumno.idEstatus.ToString();
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                NAlumno.Actualizar(new Alumno(_id, tbxtNombre.Text, tbxPrimerApe.Text, tbxSegunApe.Text, tbxCorreo.Text, tbxTelefono.Text, Convert.ToDateTime(tbxFecha.Text), tbxCurp.Text, decimal.Parse(tbxSueldo.Text), int.Parse(tbxEstado.SelectedValue), int.Parse(tbxEstatus.SelectedValue)));
                Response.Redirect("Index");
            }

        }

        protected void cvCurp_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fechaCompleta = tbxFecha.Text;
            string fechaCompara = fechaCompleta.Substring(2);
            string fechaCurp = tbxCurp.Text;
            string fechaFianlCurp = $"{fechaCurp.Substring(4,2)}-{fechaCurp.Substring(6, 2)}-{fechaCurp.Substring(8, 2)}";
            args.IsValid = fechaCompara == fechaFianlCurp;
        }
    }
}