using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminConfiguracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalon_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSalones.aspx");
        }

        protected void btnDiaHorarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDiasHorarios.aspx");
        }

        protected void btnContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPassword.aspx");
        }

        protected void btnReactivar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminReactivar.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
     

            Session.RemoveAll();

            Response.Redirect("Default.aspx");

            
        }
    }
}