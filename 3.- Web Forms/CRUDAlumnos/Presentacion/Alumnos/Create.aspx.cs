using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Alumnos
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno(12, tbxtNombre.Text, tbxPrimerApe.Text, tbxSegunApe.Text, tbxCorreo.Text, tbxTelefono.Text, Convert.ToDateTime(tbxFecha.Text.ToString()), tbxCurp.Text, decimal.Parse(tbxSueldo.Text), int.Parse(tbxEstado.SelectedValue), int.Parse(tbxEstatus.SelectedValue));
            NAlumno.Agregar(alumno);
            Response.Redirect("Index");
        }
    }
}