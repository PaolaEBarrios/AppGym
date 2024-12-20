using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace AppGym
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InicieSesion_Click(object sender, EventArgs e)
        {


            LoginNegocio loginNegocio = new LoginNegocio();

            string username = txtBoxUser.Text;
            string password = txtBoxPass.Text;

            Console.WriteLine($"Username: {username}, Password: {password}");

            bool esValido = loginNegocio.ValidarUsuario(username, password);

            if (esValido)
            {
                //Si es valido guardo los datos uno el user para dar la bienvenida
                //busco el tipo de usuario que se logueo si se logueo un instructor redirigir al menu instructor
                //buscar en la base de datos el dni de ese usuario en instructor


                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                usuario = usuarioNegocio.getUsuarioXuserName(username);
                //ME FALTA VERIFICAR Y VALIDAR
                //si agrego un instructor que le cree un usuario con su dni y un pass con su dni
                //si doy de baja un instructor tambien su usuario

                if (usuario.tipo == 1)
                {
                    Session["UsuarioLogueado"] = usuario;
                    Session["InicioSesion"] = usuario.UserName;

                    Response.Redirect("AdminPageInicio.aspx");
                }
                else if (usuario.tipo == 2)
                {
                    Teacher teacher = new Teacher();
                    InstructorNegocio negocio = new InstructorNegocio();
                    teacher = negocio.getInstructorXdni(usuario.Dni);

                    
                        if (teacher != null && teacher.State != false)
                        {

                            Session["UsuarioLogueado"] = usuario;

                            Session["InstructorLogueado"] = teacher;

                            var nombreCompleto = teacher.Name + " " + teacher.LastName;
                            Session["InicioSesion"] = nombreCompleto;


                            Session["InstructorId"] = teacher.Id;

                            Response.Redirect("InstructorPageInicio.aspx");

                        }
                        else
                        {
                        lblMensajeError.Text = "ERROR, INSTRUCTOR DADO DE BAJA";
                        }

                    

                }



            }
            else
            {
                lblMensajeError.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}