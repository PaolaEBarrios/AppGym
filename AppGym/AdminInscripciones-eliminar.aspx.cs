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
    public partial class AdminInscripciones_eliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvReservas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
               

                int reservaId = int.Parse(gvReservas.Rows[index].Cells[0].Text); 
                int claseId = int.Parse(gvReservas.Rows[index].Cells[1].Text);
                
                ReservaNegocio reservacionNegocio = new ReservaNegocio();
                ClaseNegocio claseNegocio = new ClaseNegocio();

                string resultado = reservacionNegocio.eliminarReserva(reservaId);

                if (resultado.Contains("Exito"))
                {
                    
                    claseNegocio.decrementarInscriptos(claseId);

                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Reserva eliminada exitosamente.";

                    
                    string dni = lblDniExtraido.Text;
                    Cliente cliente = new ClienteNegocio().buscarClientexDni(dni);


                    List<Reserva> listaReserva = reservacionNegocio.getReservasXcliente(cliente.Id);
                    gvReservas.DataSource = listaReserva;
                    gvReservas.DataBind();
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Error al eliminar la reserva.";
                }
            }
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (dni != null && dni != "")
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = clienteNegocio.buscarClientexDni(dni);

                if (cliente != null)
                {
                    lblDniExtraido.Text = cliente.Dni;
                    lblNombre.Text = cliente.Name;
                    lblApellido.Text = cliente.LastName;
                    lblEstado.Text = cliente.State ? "Activo" : "Inactivo";

                    if (cliente.State)
                    {
                        ReservaNegocio reservacionNegocio = new ReservaNegocio();
                        List<Reserva> listaReserva= reservacionNegocio.getReservasXcliente(cliente.Id);

                        if (listaReserva != null && listaReserva.Count > 0)
                        {
                            gvReservas.DataSource = listaReserva;
                            gvReservas.DataBind();
                            lblError.Text = "";
                        }
                        else
                        {
                            lblError.ForeColor = System.Drawing.Color.Red;
                            lblError.Text = "NO SE ENCONTRARON RESERVAS PARA EL CLIENTE";
                        }
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "EL CLIENTE ESTA INACTIVO";
                    }
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "CLIENTE NO ENCONTRADO";
                }
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "POR FAVOR, COMPLETE EL CAMPO DNI";
            }
        }
    }
}