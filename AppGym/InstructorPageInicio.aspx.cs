using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class InstructorPageInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblFechaInicio.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                if (Session["InicioSesion"] != null)
                {
                    lblBienvenida.Text = Session["InicioSesion"].ToString();
                }
                else
                {
                    lblBienvenida.Text = "ERROR NO HAY USUARIO LOGUEADO";
                    Response.Redirect("Default.aspx");
                }

            }
        }
    }
}