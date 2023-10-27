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
    public partial class Edit : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                // Se actualizan en el html
                tbxId.Text = estatus.id.ToString();
                tbxNombre.Text = estatus.nombre.Trim();
                tbxClave.Text = estatus.clave.Trim();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Se traen los datos
            string clave = tbxClave.Text.Trim();
            string nombre = tbxNombre.Text.Trim();
            // Se crea el objeto
            EstatusAlumno estatus = new EstatusAlumno(_id, clave, nombre);
            // Se ejecuta el metodo
            metodos.Actualizar(estatus);

            Response.Redirect("Index");
        }
    }
}