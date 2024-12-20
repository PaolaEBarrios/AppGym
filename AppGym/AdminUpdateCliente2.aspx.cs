using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminUpdateCliente2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {


                Cliente cliente = new Cliente();
                cliente = (Cliente)Session["Cliente"];

                cargarCliente(cliente);

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                if(txtDNI.Text != "" && txtApellido.Text != "" && txtNombre.Text != "")
                {
                    cliente.Id = int.Parse(lblId.Text);
                    cliente.Dni = txtDNI.Text;
                    cliente.LastName = txtApellido.Text;
                    cliente.Name = txtNombre.Text;

                    if (cliente != null)
                    {
                        lblError.Text = negocio.modificarCliente(cliente);
                        Session.Remove("Cliente");

                    }
                    else
                    {
                        lblError.Text = "Error vuelva al inicio y vuelva a intentar";
                    }
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Error los campos no pueden estar vacios";
                }

            }
            catch (Exception ex)
            {

                lblError.Text = ex.ToString();
            }
            finally
            {

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {


                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = new Cliente();

                cliente.Id = int.Parse(lblId.Text);
                cliente.Dni = txtDNI.Text;
                cliente.LastName = txtApellido.Text;
                cliente.Name = txtNombre.Text;


                if (cliente != null)
                {
                    lblError.Text = negocio.eliminarCliente(cliente);

                    Response.Redirect("AdminUpdateCliente3.aspx");

                 

                }
                else
                {
                    lblError.Text = "Error vuelva al inicio y vuelva a intentar";
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }




        }


        void cargarCliente(Cliente cliente)
        {

            try
            {
                if (cliente != null)
                {
                    ClienteNegocio negocio = new ClienteNegocio();

                    lblId.Text = cliente.Id.ToString();
                    txtApellido.Text = cliente.LastName;
                    txtNombre.Text = cliente.Name;
                    txtDNI.Text = cliente.Dni;

                }
                else
                {
                    lblError.Text = "Error, no se selecciono ningun cliente para modificar ";
                }

            }
            catch (Exception ex)
            {

                lblError.Text = "Error, excepcion:  "+  ex.ToString();
            }


        }

        
    }
}