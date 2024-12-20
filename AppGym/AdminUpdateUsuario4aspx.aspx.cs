using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminUpdateUsuario4aspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUserId.Text = Request.QueryString["id"];
                lblUsuario.Text = Request.QueryString["user"];
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageInicio.aspx");
        }
    }
}