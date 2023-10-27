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
    public partial class Delete : System.Web.UI.Page
    {
        int _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se toma el id de la url
            _id = int.Parse(Request.QueryString["id"] ?? "3");
            //NAlumno.Eliminar(_id);
            Alumno alumno = NAlumno.Consultar(_id);

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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            NAlumno.Eliminar(_id);
            Response.Redirect("Index");
        }
    }
}