using Dominio;
using Negocio;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminRegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNeg = new UsuarioNegocio();
                Usuario usuario = new Usuario();

                if (!(txtDNI.Text == "" || txtUserName.Text == "" || txtPass.Text == "" || radiobtnTipoUser.Text == ""))
                {
                    usuario.Dni = txtDNI.Text;
                    usuario.UserName = txtUserName.Text;
                    usuario.Password = txtPass.Text;
                    usuario.tipo = int.Parse(radiobtnTipoUser.Text);


                    

                    string respuesta = usuarioNeg.registrarUsuario(usuario);

                    lblError.Text = respuesta;
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;

                    lblError.Text = "Los campos no pueden estar vacios";
                }

                
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                
            }
            

        }
    }
}