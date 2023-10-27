using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundoWFDOS.PageEstados
{
    public partial class Indexaspx : System.Web.UI.Page
    {
        CrudAdo oCurdAdo = new CrudAdo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListEstados.DataSource = oCurdAdo.Consultar();
                DropDownListEstados.DataTextField = "nombre";
                DropDownListEstados.DataBind();
            }
        }
    }
}