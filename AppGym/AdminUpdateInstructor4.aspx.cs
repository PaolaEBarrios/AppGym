using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminUpdateInstructor4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Session["Instructor"] != null)
            {
                Teacher teacher = new Teacher();

                teacher = (Teacher)Session["Instructor"];

                lblApellido.Text = teacher.LastName;
                lblDni.Text = teacher.Dni;
                lblNombre.Text = teacher.Name;
                lblId.Text = teacher.Id.ToString();

                Session.Remove("Instructor");

            }
            else
            {
                
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageInicio.aspx");
        }
    }
}