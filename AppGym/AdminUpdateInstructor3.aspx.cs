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
    public partial class AdminUpdateInstructor3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Session["Instructor"] != null)
            {
                Teacher teacher = new Teacher();

                teacher = (Teacher)Session["Instructor"];

                lblApellido.Text = teacher.LastName;
                lblDni.Text = teacher.Dni;
                lblId.Text = teacher.Id.ToString();
                lblNombre.Text = teacher.Name;

            }
            else
            {
                lblError.Text = " No hay nada que mostrar";
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            InstructorNegocio negocio = new InstructorNegocio();
            Teacher teacher = new Teacher();

            teacher = (Teacher)Session["Instructor"];


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
            Response.Redirect("AdminUpdateInstructor4.aspx");
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateInstructor.aspx");
        }
    }
}