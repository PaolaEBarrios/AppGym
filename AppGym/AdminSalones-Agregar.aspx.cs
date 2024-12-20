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
    public partial class AdminSalones_Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Salon salon = new Salon();



            if (txtNombreDelSalon.Text != null && txtNombreDelSalon.Text != "")
            {
                salon.Name = txtNombreDelSalon.Text;
                SalonNegocio negocio = new SalonNegocio();




                string respuesta = negocio.agregarSalon(salon);



                if (respuesta != "Ocurrio un error al cargar el salon a la tabla salones" && respuesta != "Ya existe ese nombre en la base de datos") { 
                    

                    lblError.Text = respuesta;
                    lblError.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblError.Text = respuesta.ToUpper();
                    lblError.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblError.Text = "El campo nombre no debe ser vacio".ToUpper();
                lblError.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSalones.aspx");
        }
    }
}