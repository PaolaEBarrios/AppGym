using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class InstructorClases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblFechaInicio.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");

                

            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorCrearClase.aspx");
        }

        protected void btnMisClases_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorMisClases.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorEditarClases.aspx");
        }
    }
}