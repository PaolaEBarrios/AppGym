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
    public partial class AdminUpdateInstructor2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["Id"];
                if (!string.IsNullOrEmpty(id))
                {
                    cargarInstructor(id);
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            InstructorNegocio negocio = new InstructorNegocio();
            Teacher teacher = new Teacher();

            try
            {
                string id = Request.QueryString["Id"];

                if(txtNombre.Text != "" && txtApellido.Text != "" && txtDni.Text != "")
                {
                    //contruir el instructor
                    teacher.Id = int.Parse(id);
                    teacher.Name = txtNombre.Text;
                    teacher.LastName = txtApellido.Text;
                    teacher.Dni = txtDni.Text;


                    var respuesta = negocio.modificarInstructor(teacher);

                    lblError.Text = respuesta.ToString();
                }
                else {

                    lblError.Text = "LOS CAMPOS SON OBLIGATORIOS Y NO DEBEN ESTAR VACIOS";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { }

        }

    

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            InstructorNegocio negocio = new InstructorNegocio();
            Teacher teacher = new Teacher();
            try
            {
                string id = Request.QueryString["Id"];
                teacher.Id = int.Parse(id);
                teacher.Name = txtNombre.Text;
                teacher.LastName = txtApellido.Text;
                teacher.Dni = txtDni.Text;
                teacher.State = false;

                string respuesta = negocio.eliminarInstructor(teacher);


                if (respuesta != "")
                {
                    Session["Instructor"] = teacher;
                    Response.Redirect("AdminUpdateInstructor4.aspx");
                }
                else
                {
                    lblError.Text = respuesta;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { }
            



        }


        void cargarInstructor(string id) {

            Teacher teacher = new Teacher();
            InstructorNegocio instructorNegocio = new InstructorNegocio();

            try
            {
                teacher = instructorNegocio.getInstructorPorId(id);

                if(teacher != null)
                {
                    lblId.Text = "Instructor Id: "+id;
                    txtApellido.Text = teacher.LastName;
                    txtNombre.Text = teacher.Name;
                    txtDni.Text = teacher.Dni;
                    
                }

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