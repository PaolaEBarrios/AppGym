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
    public partial class AdminUpdateInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarInstructores();
            }
        }

        protected void gvInstructor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                // indice de la fila seleccionada
                int index = Convert.ToInt32(e.CommandArgument);
                // dni de la fila seleccionada
                string id = gvInstructor.Rows[index].Cells[0].Text;


                Response.Redirect($"AdminUpdateInstructor2.aspx?ID={id}");

            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // id de la fila seleccionada
                Teacher teacher = new Teacher();
                if (e.CommandName == "Eliminar")
                {
                    teacher.Id = int.Parse(gvInstructor.Rows[index].Cells[0].Text);
                    teacher.Dni = gvInstructor.Rows[index].Cells[1].Text;
                    teacher.Name = gvInstructor.Rows[index].Cells[2].Text;
                    teacher.LastName = gvInstructor.Rows[index].Cells[3].Text;

                    Session["Instructor"] = teacher;

                    Response.Redirect($"AdminUpdateInstructor3.aspx?");
                }
            }
        }


        void cargarInstructores()
        {
            try
            {
                InstructorNegocio negocio = new InstructorNegocio();
                List<Teacher> instructors = negocio.getInstructores();


                List<Teacher> profesoresActivos = instructors.Where(t => t.State == true).ToList();

                gvInstructor.DataSource = profesoresActivos;
                gvInstructor.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

    }
}