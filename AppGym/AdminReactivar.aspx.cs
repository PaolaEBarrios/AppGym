using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminReactivar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReactivarUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminReactivar-UsuarioInstructor.aspx");

        }

        protected void btnReactivarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminReactivar-Cliente.aspx");
        }
    }
}