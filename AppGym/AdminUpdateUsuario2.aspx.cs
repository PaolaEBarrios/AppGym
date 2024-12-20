using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminUpdateUsuario2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //El valor de IsPostBack es

            //false cuando la página se carga por primera vez.
            //true cuando la página se está recargando debido a un postback.
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }


        void CargarUsuarios()
        {
            try
            {

                UsuarioNegocio negocio = new UsuarioNegocio();
                List<Usuario> usuarios = negocio.getUsuarios();
                //se usa un filtro para solo guardar en la lista los usuarios en true o 1
                List<Usuario> usuariosActivos = usuarios.Where(u => u.State == true && u.UserName != "Admingym").ToList();

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

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar" )
            {
                // indice de la fila seleccionada
                int index = Convert.ToInt32(e.CommandArgument);
                // dni de la fila seleccionada
                string dni = gvUsuarios.Rows[index].Cells[1].Text;

               
                Response.Redirect($"AdminUpdateUsuario.aspx?DNI={dni}");
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // id de la fila seleccionada
                string id = gvUsuarios.Rows[index].Cells[0].Text;
                if (e.CommandName == "Eliminar")
                {
                    Response.Redirect($"AdminUpdateUsuario3.aspx?Id={id}");
                }
            }
        }
    }
}