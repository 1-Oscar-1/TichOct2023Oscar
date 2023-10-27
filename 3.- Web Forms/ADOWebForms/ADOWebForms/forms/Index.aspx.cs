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
    public partial class Index : System.Web.UI.Page
    {
        // Se traen los metodos
        ADOEstatusAlumno metodos = new ADOEstatusAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlEstatus.DataSource = metodos.Consultar();
                ddlEstatus.DataTextField = "nombre";
                ddlEstatus.DataValueField = "id";
                ddlEstatus.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create");
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEstatus.SelectedValue);
            Response.Redirect($"Details?id={id}");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEstatus.SelectedValue);
            Response.Redirect($"Edit?id={id}");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEstatus.SelectedValue);
            Response.Redirect($"Delete?id={id}");
        }
    }
}