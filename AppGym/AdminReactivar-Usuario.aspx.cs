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
    public partial class AdminReactivar_Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarUsuarios();
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if(e.CommandName == "Activar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Usuario usuario = new Usuario();

                usuario.Id = int.Parse(gvUsuarios.Rows[index].Cells[0].Text);
                usuario.Dni = gvUsuarios.Rows[index].Cells[1].Text;
                usuario.UserName =gvUsuarios.Rows[index].Cells[2].Text;
                usuario.State = bool.Parse(gvUsuarios.Rows[index].Cells[3].Text);

                UsuarioNegocio negocio = new UsuarioNegocio();

                int respuesta = negocio.activarUsuario(usuario.Dni);

                if (respuesta > 0)
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Exito, se reactivo el usuario correctamente";

                    cargarUsuarios();
                }
                else {

                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Ocurrio un error al intentar reactivar el usuario";
                }
                
            }
            
        }


        void cargarUsuarios()
        {
            try
            {

                UsuarioNegocio negocio = new UsuarioNegocio();
                List<Usuario> usuarios = negocio.getUsuarios();
                
                List<Usuario> usuariosActivos = usuarios.Where(u => u.State == false).ToList();

                gvUsuarios.DataSource = usuariosActivos;
                gvUsuarios.DataBind();
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