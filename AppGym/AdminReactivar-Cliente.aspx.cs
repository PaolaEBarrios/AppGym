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
    public partial class AdminReactivar_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
            }
        }

        protected void gvClient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Activar")
            {
                //recuperar la fila
                //preguntar si desea activarlo?
                //activarlo y actualizar el gv

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = new Cliente();

                int index = Convert.ToInt32(e.CommandArgument);


                
                cliente.Id = int.Parse(gvClient.Rows[index].Cells[0].Text);
                cliente.Dni = gvClient.Rows[index].Cells[1].Text;
                cliente.Name = gvClient.Rows[index].Cells[2].Text;
                cliente.LastName = gvClient.Rows[index].Cells[3].Text;
                cliente.State = bool.Parse(gvClient.Rows[index].Cells[4].Text);

                string respuesta = negocio.activarCliente(cliente);

                if (respuesta.Contains("Exito"))
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = respuesta;
                    cargarClientes();
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = respuesta;
                }

            }
        }


        public void cargarClientes()
        {
            
                try
                {

                    ClienteNegocio negocio = new ClienteNegocio();
                    List<Cliente> clientes = negocio.getClientes();
                    //se usa un filtro para solo guardar en la lista los usuarios en false o 0
                    List<Cliente> clientesInactivos = clientes.Where(u => u.State == false).ToList();

                        

                    gvClient.DataSource = clientesInactivos;
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