using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminSalones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSalones-Agregar.aspx");
        }

        protected void btnEditarEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSalones-EditarEliminar.aspx");
        }
    }
}