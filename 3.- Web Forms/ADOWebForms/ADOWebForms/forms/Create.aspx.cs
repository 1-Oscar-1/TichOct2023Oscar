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
    public partial class Create : System.Web.UI.Page
    {
        // Se crea un objeto con los metodos
        ADOEstatusAlumno metodos = new ADOEstatusAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Se traen los valores del form
            int id = int.Parse(tbxId.Text);
            string clave = tbxClave.Text.ToUpper();
            string nombre = tbxNombre.Text;
            // Se crea un nuevo objeto
            EstatusAlumno estatus = new EstatusAlumno(id, clave, nombre);
            // Se llama al metodo para crear
            metodos.Agregar(estatus);

            Response.Redirect("Index");
        }
    }
}