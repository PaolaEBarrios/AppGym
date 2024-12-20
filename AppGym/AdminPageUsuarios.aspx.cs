using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminPageUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy"); 
            }
        }

        protected void btnRegUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminRegistrarUsuario.aspx");
        }

        protected void btnRegCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminRegistrarCliente.aspx");
        }

        protected void btnAdmiUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateUsuario2.aspx");
        }

        protected void btnAdmiCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateCliente.aspx");
        }


    }
}