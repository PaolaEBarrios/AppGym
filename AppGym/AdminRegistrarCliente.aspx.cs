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
    public partial class AdminRegistrarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddCliente_Click(object sender, EventArgs e)
        {
            try
            {
               
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                if (txtApellido.Text != "" && txtNombre.Text != "" && txtDNI.Text != "") {

                    var apellido = txtApellido.Text;
                    var dni = txtDNI.Text;
                    var nombre = txtNombre.Text;
                    var tipo=  int.Parse(radiobtnPase.Text); 


                    if (radiobtnPase.Text != "" && tipo != 0)
                    {
                        string respuesta = clienteNegocio.registrarCliente(apellido, dni, nombre, tipo);

                        lblError.Text = respuesta;
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Error, DEBE SELECCIONAR UN TIPO DE MEMBRESIA";
                        return;
                    }
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Error, NO DEJAR LOS CAMPOS VACIOS";
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