using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminUpdateCliente4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cliente cliente = new Cliente();
                cliente = (Cliente)Session["Cliente"];

                lblContentApellido.Text = cliente.LastName;
                lblContentDni.Text = cliente.Dni;
                lblContentId.Text = cliente.Id.ToString();
                lblContentNombre.Text = cliente.Name;

                Session.Remove("Cliente");
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageInicio.aspx");
        }
    }
}