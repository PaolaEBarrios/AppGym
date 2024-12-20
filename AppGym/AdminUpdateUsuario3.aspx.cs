using Dominio;
using Negocio;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminUpdateUsuario3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["Id"];
                if (!string.IsNullOrEmpty(id))
                {
                    cargarUsuario(id);
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            string id = lblIdUsuario.Text;
            string user = lblUserName.Text;

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = negocio.getUsuarioPorID(id);

                negocio.EliminarUsuario(usuario);

                Response.Redirect($"AdminUpdateUsuario4aspx.aspx?id={id}&user={user}");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { 
            
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateUsuario2.aspx");
        }


        public void cargarUsuario(string id)
        {


            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.getUsuarioPorID(id);


            if (usuario != null)
            {
                lblIdUsuario.Text = usuario.Id.ToString();
                lblDni.Text = usuario.Dni;
                lblUserName.Text = usuario.UserName;

                if (usuario.tipo == 1)
                {
                    lbltipo.Text = "Administrador";
                }
                else if (usuario.tipo == 2)
                {
                    lbltipo.Text = "Instructor";
                }
                else {

                    lbltipo.Text = "Cliente";
                }

                 

            }


        }
    }
}