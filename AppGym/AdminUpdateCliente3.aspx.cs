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
    public partial class AdminUpdateCliente3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Cliente cliente = new Cliente();

                cliente = (Cliente)Session["Cliente"];

                lblContentId.Text = cliente.Id.ToString();
                lblContentDni.Text = cliente.Dni;
                lblContentNombre.Text = cliente.Name;
                lblContentApellido.Text = cliente.LastName;

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                Cliente cliente = new Cliente();

                cliente = (Cliente)Session["Cliente"];
                ClienteNegocio negocio = new ClienteNegocio();

                string respuesta = negocio.eliminarCliente(cliente);
                Response.Redirect("AdminUpdateCliente4.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateCliente.aspx");
        }
    }
}