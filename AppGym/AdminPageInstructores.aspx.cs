using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminPageInstructores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegProfesor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminRegistrarInstructor.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateInstructor.aspx");
        }
    }
}