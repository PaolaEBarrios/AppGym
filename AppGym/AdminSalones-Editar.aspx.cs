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
    public partial class AdminSalones_Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["SalonEditar"] != null)
            {
                Salon salon = new Salon();

                salon = (Salon)Session["SalonEditar"];

                lblIdSalon.Text = salon.IdSalon.ToString();
                txtNombreSalon.Text = salon.Name;


            }
            else if(IsPostBack)
            {
                lblMensaje.Text = "NO HAY NADA QUE MOSTRAR";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            SalonNegocio negocio = new SalonNegocio();
            Salon salon = new Salon();

            salon = (Salon)Session["SalonEditar"];


            string respuesta = negocio.editarNombreSalon(salon, txtNombreSalon.Text);

            if(respuesta == "Exito al editar el nombre del salon")
            {
                lblMensaje.ForeColor=System.Drawing.Color.Green;
                lblMensaje.Text = respuesta;
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = respuesta;
            }


        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSalones-EditarEliminar.aspx");
        }
    }
}