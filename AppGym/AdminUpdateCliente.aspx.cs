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
    public partial class AdminUpdateCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        protected void gvClient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                // indice de la fila seleccionada
                
                int index = Convert.ToInt32(e.CommandArgument);
         

                Cliente cliente = new Cliente();
                cliente.Id = int.Parse(gvClient.Rows[index].Cells[0].Text);
                cliente.Dni = gvClient.Rows[index].Cells[1].Text;
                cliente.Name = gvClient.Rows[index].Cells[2].Text;
                cliente.LastName = gvClient.Rows[index].Cells[3].Text;
                
                Session["Cliente"] = cliente;

                Response.Redirect($"AdminUpdateCliente2.aspx");

            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // id de la fila seleccionada
                string id = gvClient.Rows[index].Cells[0].Text;
                if (e.CommandName == "Eliminar")
                {

                    Cliente cliente = new Cliente();
                    cliente.Id = int.Parse(gvClient.Rows[index].Cells[0].Text);
                    cliente.Dni = gvClient.Rows[index].Cells[1].Text;
                    cliente.Name = gvClient.Rows[index].Cells[2].Text;
                    cliente.LastName = gvClient.Rows[index].Cells[3].Text;

                    Session["Cliente"] = cliente;

                    Response.Redirect($"AdminUpdateCliente3.aspx?Id={id}");
                }
            }
        }


        void CargarClientes()
        {
            try
            {

                ClienteNegocio negocio = new ClienteNegocio();
                List<Cliente> clientes = negocio.getClientes();
                //se usa un filtro para solo guardar en la lista los usuarios en true o 1
                List<Cliente> clientesActivos = clientes.Where(u => u.State == true).ToList();

                gvClient.DataSource = clientesActivos;
                gvClient.DataBind();
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