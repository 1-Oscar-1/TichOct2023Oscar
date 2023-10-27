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
    public partial class Details : System.Web.UI.Page
    {
        ADOEstatusAlumno metodos = new ADOEstatusAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se recibe el id
            int id = int.Parse(Request.QueryString["id"]);
            // Se buscan los valores correspondientes al id
            EstatusAlumno estatus = metodos.Consultar(id);
            // Se actualizan en el html
            idEstatus.Text = estatus.id.ToString();
            nomEstatus.Text = estatus.nombre;
            clavEstatus.Text = estatus.clave;
        }
    }
}