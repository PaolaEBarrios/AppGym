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
    public partial class InstructorEliminarSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clase clase = (Clase)Session["Clase"];

                lblCapacidad.Text=clase.Capacidad.ToString();
                lblDia.Text=clase.Dia;
                lblHoraFin.Text=clase.HoraFin;
                lblHoraInicio.Text=clase.HoraInicio;
                lblNombre.Text = clase.Name;
                lblSalon.Text =clase.idSalon.ToString();
                lblId.Text = clase.Id.ToString();

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int claseId = int.Parse(lblId.Text);

                
                ClaseNegocio negocio = new ClaseNegocio();

                
                bool bandera = negocio.eliminarClase(claseId);

                if (bandera == true)
                {
                    lblPregunta.Text = "";
                    lblPregunta.Text = "Exito al eliminar la clase";
                    lblPregunta.ForeColor = System.Drawing.Color.Green;

                    btnEliminar.Visible = false;
                    btnEliminar.Enabled = false;
                    
                }
                else
                {
                    lblPregunta.Text = "";
                    lblPregunta.Text = "Exito al eliminar la clase";
                    lblPregunta.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblPregunta.Text = "";
                lblPregunta.Text = "Ocurrio un error excepcion: " + ex.Message;
                lblPregunta.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorEditarClase.aspx");
        }
    }
}