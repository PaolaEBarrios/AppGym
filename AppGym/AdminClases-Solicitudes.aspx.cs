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
    public partial class AdminClases_Solicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClases();
            }
        }

        protected void gvClases_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Aceptar")
            {
                Clase clase = new Clase();
                int index = Convert.ToInt32(e.CommandArgument);

                clase.Id = int.Parse(gvClases.Rows[index].Cells[0].Text);

                ClaseNegocio negocio = new ClaseNegocio();


                string respuesta = negocio.activarClase(clase.Id);

                if(respuesta.Length > 0)
                {
                    if (respuesta.Contains("Exito"))
                    {

                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "EXITO, SE CONFIRMO LA CLASE Y PASO A ACTIVA";
                        cargarClases();
                    }
                    else if (respuesta.Contains("Excepcion"))
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = respuesta;                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = respuesta;
                    }
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Ocurrio un error";
                }

            }
            //RechazAR
            else
            {
                Clase clase = new Clase();
                int index = Convert.ToInt32(e.CommandArgument);

                clase.Id = int.Parse(gvClases.Rows[index].Cells[0].Text);

                ClaseNegocio negocio = new ClaseNegocio();


                string respuesta = negocio.rechazarClase(clase.Id);

                if (respuesta.Length > 0)
                {
                    if (respuesta.Contains("Exito"))
                    {

                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "EXITO, SE RECHAZO LA CLASE";
                        cargarClases();
                    }
                    else if (respuesta.Contains("Excepcion"))
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = respuesta;
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = respuesta;
                    }
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Ocurrio un error";
                }

            }
        }

        void cargarClases()
        {
            try
            {
                List<Clase> listaClases = new List<Clase>();
                ClaseNegocio negocio = new ClaseNegocio();

                listaClases = negocio.getClases();

                List<Clase> clasesActivas = listaClases.Where(c => c.estado == false && c.detalle != "Rechazado").ToList();

                if (clasesActivas.Count > 0)
                {
                    gvClases.DataSource = clasesActivas;
                    gvClases.DataBind();
                }
                else
                {
                    lblError.Text = "No se encontraron clases activas";
                    lblError.ForeColor = System.Drawing.Color.Orange;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}