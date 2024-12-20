using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminSalones_Eliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["SalonEliminar"] != null )
            {
                Salon salon = new Salon();

                salon = (Salon)Session["SalonEliminar"];

                lblCartelId.Text = salon.IdSalon.ToString();
                lblNombre.Text = salon.Name;
            }
            else
            {
                lblError.Text = "No hay nada que mostrar";
                btnEliminar.Visible = false;
                btnEliminar.Enabled = false;

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Salon salon = new Salon();
            SalonNegocio negocio = new SalonNegocio();


            salon = (Salon)Session["SalonEliminar"];

            string respuesta  =  negocio.eliminarSalon(salon);

            if(respuesta != null && respuesta == "Exito al eliminar el salon")
            {
                btnEliminar.Visible = false;
                btnEliminar.Enabled = false;
                lblPregunta.Visible = false;

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = respuesta.ToUpper();


            }
            else
            {

                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = respuesta.ToUpper();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSalones-EditarEliminar.aspx");
        }
    }
}