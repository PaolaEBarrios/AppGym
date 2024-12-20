using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class InstructorEditarClases : System.Web.UI.Page
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
            if (e.CommandName == "Editar")
            {
                Clase clase = new Clase();
                int index = Convert.ToInt32(e.CommandArgument);

                clase.Id = int.Parse(gvClases.Rows[index].Cells[0].Text);
                clase.Name = gvClases.Rows[index].Cells[1].Text;
                clase.InstructorId = gvClases.Rows[index].Cells[2].Text;
                clase.Capacidad = int.Parse(gvClases.Rows[index].Cells[3].Text);
                clase.Dia = gvClases.Rows[index].Cells[4].Text;
                clase.HoraInicio = gvClases.Rows[index].Cells[5].Text;
                clase.HoraFin = gvClases.Rows[index].Cells[6].Text;
                clase.idSalon = int.Parse(gvClases.Rows[index].Cells[7].Text);

                Session["Clase"] = clase;


                Response.Redirect("InstructorEditarClases-clase.aspx");

            }
            else if (e.CommandName == "Eliminar")
            {
                Clase clase = new Clase();
                int index = Convert.ToInt32(e.CommandArgument);

                clase.Id = int.Parse(gvClases.Rows[index].Cells[0].Text);
                clase.Name = gvClases.Rows[index].Cells[1].Text;
                clase.InstructorId = gvClases.Rows[index].Cells[2].Text;
                clase.Capacidad = int.Parse(gvClases.Rows[index].Cells[3].Text);
                clase.Dia = gvClases.Rows[index].Cells[4].Text;
                clase.HoraInicio = gvClases.Rows[index].Cells[5].Text;
                clase.HoraFin = gvClases.Rows[index].Cells[6].Text;
                clase.idSalon = int.Parse(gvClases.Rows[index].Cells[7].Text);

                Session["Clase"] = clase;


                Response.Redirect("InstructorEliminarSolicitud.aspx");
            }
        }

        void cargarClases() {

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

                List<Clase> clasesDelInstructorActivas = listaClases.Where(c => c.InstructorId == instructorIdLogueado && c.estado == false).ToList();

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