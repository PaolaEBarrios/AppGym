using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace AppGym
{
    public partial class AdminInscripciones_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvClasesDisponibles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Inscribir")
            {
                //para inscribir 
                //guardar el id de la clase y el nombre
                //verificar que el cliente no tengas clases para ese dia y horario
                //verificar que la clase tenga cupos 
                //Si no tiene conflictos de reservas y hay cupos - seguir adelante
                //y por ultimo aumentar en uno los inscriptos en classes
                // Obtener el índice de la fila seleccionada


                int index = Convert.ToInt32(e.CommandArgument);


                Clase clase = new Clase();
                clase.Id = int.Parse(gvClasesDisponibles.Rows[index].Cells[0].Text);
                clase.Name = gvClasesDisponibles.Rows[index].Cells[1].Text;
                clase.Dia = gvClasesDisponibles.Rows[index].Cells[2].Text;
                clase.HoraInicio = gvClasesDisponibles.Rows[index].Cells[3].Text;
                clase.HoraFin = gvClasesDisponibles.Rows[index].Cells[4].Text;
                clase.Capacidad = int.Parse(gvClasesDisponibles.Rows[index].Cells[5].Text);
                clase.Inscriptos = int.Parse( gvClasesDisponibles.Rows[index].Cells[6].Text);
                //clase.idSalon = int.Parse(gvClasesDisponibles.Rows[index].Cells[7].Text);

                
                string clienteDni = lblDniExtraido.Text;
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                //traigo al cliente para usarlo
                Cliente cliente = clienteNegocio.buscarClientexDni(clienteDni);

                ReservaNegocio reservacionNegocio = new ReservaNegocio();

                //verificar el dia y hoarrio para el cliente
                bool tieneConflictos = reservacionNegocio.verificarSuperposicion(cliente.Id, clase.Dia, TimeSpan.Parse(clase.HoraInicio), TimeSpan.Parse(clase.HoraFin));

                if (tieneConflictos == true)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "EL CLIENTE YA TIENE UNA CLASE EN ESTE HORARIO";
                    return;
                }

                //verificar el cupo
                ClaseNegocio claseNegocio = new ClaseNegocio();
                bool hayCupos = claseNegocio.verificarDisponibilidad(clase.Id);

                if (hayCupos == false)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "LA CLASE SELECCIONADA NO TIENE CUPOS DISPONIBLES";
                    return;
                }

                //insertar en la tabla
                string resultado = reservacionNegocio.registrarInscripcion(cliente.Id, clase.Id, clase.Dia, TimeSpan.Parse(clase.HoraInicio), TimeSpan.Parse(clase.HoraFin), clase.Name);

                if (resultado.Contains("éxito"))
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Inscripción registrada exitosamente.";
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = resultado;
                }
            }


        }



        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (!string.IsNullOrEmpty(dni))
            {


                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = negocio.buscarClientexDni(dni);


                if (cliente != null)
                {
                    lblDniExtraido.Text = cliente.Dni;
                    lblNombre.Text = cliente.Name;
                    lblApellido.Text = cliente.LastName;
                    lblEstado.Text = cliente.State == true ? "Activo" : "Inactivo";

                    if (cliente.State != false)
                    {
                        ClaseNegocio claseNegocio = new ClaseNegocio();

                        List<Clase> listaClases = new List<Clase>();
                        listaClases = claseNegocio.getClases();


                        List<Clase> clasesActivas = listaClases.Where(c => c.estado == true).ToList();
                        if (clasesActivas.Count > 0) {
                            gvClasesDisponibles.DataSource = clasesActivas;
                            gvClasesDisponibles.DataBind();
                        }
                        else
                        {
                            lblError.ForeColor = System.Drawing.Color.Red;
                            lblError.Text = "NO HAY CLASES ACTIVAS";
                        }
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "EL CLIENTE ESTA DADO DE BAJA, SE ENCUENTRA INACTIVO";
                    }
                    
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "NO EXISTE EL CLIENTE, O NO SE ENCONTRO";
                }
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "POR FAVOR, INGRESE UN DNI VALIDO";
            }
        }




        
    }
}