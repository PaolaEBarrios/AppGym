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
    public partial class AdminReactivar_Instructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarInstructores();
            }
        }

        protected void gvInstructor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName  == "Activar")
            {
                Teacher teacher = new Teacher();
                InstructorNegocio negocio = new InstructorNegocio(); 

                int index = Convert.ToInt32(e.CommandArgument);
                teacher.Id = int.Parse(gvInstructor.Rows[index].Cells[0].Text);
                teacher.Dni = gvInstructor.Rows[index].Cells[1].Text;
                teacher.Name = gvInstructor.Rows[index].Cells[2].Text;
                teacher.LastName = gvInstructor.Rows[index].Cells[3].Text;
                teacher.State = bool.Parse(gvInstructor.Rows[index].Cells[4].Text);


                string respuesta = negocio.activarInstructor(teacher);


                if (respuesta.Contains("Exito")) {

                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = respuesta;
                    cargarInstructores();
                }
                else
                {

                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = respuesta;
                }

            }


        }

        void cargarInstructores()
        {
            try
            {
                InstructorNegocio negocio = new InstructorNegocio();
                List<Teacher> instructors = negocio.getInstructores();


                List<Teacher> profesoresActivos = instructors.Where(t => t.State == false).ToList();

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