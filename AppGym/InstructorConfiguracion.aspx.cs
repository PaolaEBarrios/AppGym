using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class InstructorConfiguracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = (Usuario)Session["UsuarioLogueado"];

                string passNuevo = txtPassNueva.Text;
                string passNuevo2 = txtPassNueva2.Text;
                string passActual = txtPass.Text;

                if (passNuevo != "" && passNuevo2 != "")
                {
                    bool bandera = verificarPassNuevo(passNuevo, passNuevo2);

                    bool coincidePassactual = verificarPassActual(passActual);

                    if (bandera != true || coincidePassactual != true)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "La nueva contraseña o la actual no coincide, verifique el ingreso ";
                        return;
                    }
                    else
                    {
                        UsuarioNegocio negocio = new UsuarioNegocio();

                        string respuesta = negocio.cambiarPassword(usuario, passNuevo);

                        //verificar antes que sea correcto
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = respuesta;
                    }
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "El formulario no debe estar vacio ";
                    return;
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        bool verificarPassNuevo(string pass, string pass2)
        {

            if (pass == pass2)
            {
                return true;
            }
            return false;

        }

        bool verificarPassActual(string passActual)
        {

            UsuarioNegocio negocio = new UsuarioNegocio();

            Usuario usuario = (Usuario)Session["UsuarioLogueado"];

            if (usuario.Password == passActual)
            {

                return true;
            }
            return false;

        }
    }
}