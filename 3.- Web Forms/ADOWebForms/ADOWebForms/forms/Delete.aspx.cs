using ADOWebForms.ADO;
using ADOWebForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOWebForms.forms
{
    public partial class Delete : System.Web.UI.Page
    {
        ADOEstatusAlumno metodos = new ADOEstatusAlumno();
        // id
        int _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se recibe el id
            _id = int.Parse(Request.QueryString["id"]);
            // Se buscan los valores correspondientes al id
            EstatusAlumno estatus = metodos.Consultar(_id);
            // Se actualizan en el html
            idEstatus.Text = estatus.id.ToString();
            nomEstatus.Text = estatus.nombre;
            clavEstatus.Text = estatus.clave;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            metodos.Eliminar(_id);
            Response.Redirect("Index");
        }
    }
}