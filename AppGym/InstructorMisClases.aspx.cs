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
    public partial class InstructorMisClases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                cargarClases();
            }
        }

        void cargarClases()
        {
            try
            {

                if (Session["InstructorId"] == null)
                {
                    lblError.Text = "No se pudo obtener el ID del instructor logueado.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string instructorIdLogueado = Session["InstructorId"].ToString();

                List<Clase> listaClases = new List<Clase>();
                ClaseNegocio negocio = new ClaseNegocio();

                listaClases = negocio.getClases();

                List<Clase> clasesDelInstructorActivas = listaClases.Where(c => c.InstructorId == instructorIdLogueado && c.estado == true).ToList();

                if (clasesDelInstructorActivas.Count > 0)
                {
                    gvClases.DataSource = clasesDelInstructorActivas;
                    gvClases.DataBind();
                }
                else
                {
                    lblError.Text = "No se encontraron clases activas asignadas al instructor logueado";
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