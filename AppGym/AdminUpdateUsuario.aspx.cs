using Dominio;
using Negocio;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace AppGym
{
    public partial class AdminUpdateUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dni = Request.QueryString["DNI"];
                if (!string.IsNullOrEmpty(dni))
                {
                    cargarUsuario(dni);
                }
            }



        }

        private void cargarUsuario(string dni)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.getUsuarioPorDNI(dni);

            if (usuario != null)
            {
                lblId.Text = usuario.Id.ToString();
                txtdni.Text = usuario.Dni;
                txtUserName.Text = usuario.UserName;
                txtPass.Text = usuario.Password;
                radiobtnTipoUser.Text = usuario.tipo.ToString();

            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            //modificar y update tabla de user
            //si es admin principal no dejar borrar
            //
            try
            {
             
                    if (txtdni.Text != "" && txtUserName.Text != "" && txtPass.Text != "")
                    {
                        usuario.Id = int.Parse(lblId.Text);
                        usuario.Dni = txtdni.Text;
                        usuario.UserName = txtUserName.Text;
                        usuario.tipo = int.Parse(radiobtnTipoUser.Text);
                        usuario.Password = txtPass.Text;

                        string respuesta = negocio.modificarUsuario(usuario);
                        lblError.Text = respuesta;
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Los campos dni, password y username no deben ser vacios";
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = lblId.Text;
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            try
            {

                if (txtdni.Text != "" && txtUserName.Text != "" && txtPass.Text != "")
                {
                    usuario.Id = int.Parse(lblId.Text);
                    usuario.Dni = txtdni.Text;
                    usuario.UserName = txtUserName.Text;
                    usuario.tipo = int.Parse(radiobtnTipoUser.Text);
                    usuario.Password = txtPass.Text;

                    string respuesta = negocio.EliminarUsuario(usuario);

                    Response.Redirect($"AdminUpdateUsuario3.aspx?respuesta={respuesta}");
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Los campos dni, password y username no deben ser vacios";
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { 
            
            }

        }
    }
}