using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace AppGym
{
    public partial class AdminRegistrarInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            Teacher teacher = new Teacher();




            try
            {

                if (txtDNI.Text != "" && txtNombre.Text != "" && txtApellido.Text != "")
                {
                    teacher.Dni = txtDNI.Text;
                    teacher.Name = txtNombre.Text;
                    teacher.LastName = txtApellido.Text;
                    teacher.detalle = txtDetalle.Text;
                    teacher.State = true;
                    InstructorNegocio instructorNegocio = new InstructorNegocio();




                     string respuesta = instructorNegocio.registrarInstructor(teacher);

                    if(respuesta == "Instructor cargado en sistema")
                    {
                        //crear el usuario y mostrarlo en pantalla
                        //al crear el usuario sera tipo 2
                        //dni sera el password
                        //y el username sera las dos primeras letras de apellido + nombre

                        //tomar las dos primeras letras de apellido y nombre
                        string nombreUsuario = txtNombre.Text.Substring(0, Math.Min(2, txtNombre.Text.Length)).ToLower(); 
                        string apellidoUsuario = txtApellido.Text.Substring(0, Math.Min(2, txtApellido.Text.Length)).ToLower(); 
                        
                        Usuario usuario = new Usuario();
                        UsuarioNegocio negocio = new UsuarioNegocio();

                        usuario.UserName = apellidoUsuario + nombreUsuario + txtDNI.Text;
                        usuario.Password = txtDNI.Text;
                        usuario.Dni = txtDNI.Text;
                        usuario.tipo = 2;

                        string respUsuario = negocio.registrarUsuario(usuario);

                        if(respUsuario == "Se registro el usuario correctamente")
                        {
                            //si se registro correctamente traer el user id de la tabla users

                           int userid = negocio.getUserIdxDni(usuario.Dni);

                            //si es distinto de cero es que devolvio el userid
                            //actualizar el userId en tabla instructors enviando dni

                            if(userid != 0)
                            {
                                bool bandera = instructorNegocio.actualizarUserId(userid, usuario.Dni);

                                if(bandera == true)
                                {
                                    lblError.Text = respuesta + " Usuario : " + usuario.UserName + " Password: " + usuario.Dni;
                                }
                                else
                                {
                                    lblError.ForeColor = System.Drawing.Color.Red;
                                    lblError.Text = respuesta + " Usuario : " + usuario.UserName + " Password: " + usuario.Dni +" HUBO UN ERROR AL ACTUALIZAR EL USERID EN INSTRUCTORES";
                                }

                            }
                            else
                            {
                                lblError.ForeColor = System.Drawing.Color.Red;
                                lblError.Text = respuesta + " Usuario : " + usuario.UserName + " Password: " + usuario.Dni + " HUBO UN ERROR NO SE LOGRO ENCONTRAR EL USERID EN TABLA USERS";
                            }

                            

                            
                        }
                        else
                        {
                            lblError.Text = respuesta + " pero no se logro crear el usuario";
                        }
                        
                    }

                     

                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Los campos Nombre, Apellido y Dni no pueden ser vacios";
                }


                
            }
            catch (Exception ex){
                
                Console.WriteLine(ex.ToString());
            
            }



        }
    }
}