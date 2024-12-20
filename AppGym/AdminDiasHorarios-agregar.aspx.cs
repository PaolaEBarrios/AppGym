using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace AppGym
{
    public partial class AdminDiasHorarios_agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDiasHorarios();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDiasHorarios.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //Eliminar este boton


        }

        protected void btnAddDia_Click(object sender, EventArgs e)
        {

            GimnasioNegocio negocio = new GimnasioNegocio();
            Gimnasio gimnasio = new Gimnasio();


            string horaInicio = ddlHoras.SelectedValue + ":" + ddlMinutos.SelectedValue;
            string horaFin = ddlHorasFin.SelectedValue + ":" + ddlMinutosFin.SelectedValue;


            TimeSpan horaInicioTs = TimeSpan.Parse(horaInicio);
            TimeSpan horaFinTs = TimeSpan.Parse(horaFin);

            if (horaInicioTs >= horaFinTs)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "La hora de inicio debe ser anterior a la hora de fin.";
                return;
            }

            gimnasio.dia = ddlDias.SelectedValue;
            gimnasio.horaInicio = horaInicio;
            gimnasio.horaFin = horaFin;
            gimnasio.hora = gimnasio.horaInicio + " a " + gimnasio.horaFin;

            string respuesta = negocio.existeDia(gimnasio);

            if (respuesta == "Existe")
            {
                respuesta = "El dia ya existe en los dias, si quiere modificarlo ir al menu dias y horarios";

                lblError.ForeColor=System.Drawing.Color.Red;
                lblError.Text = respuesta;

            }
            else if (respuesta == "Excepcion")
            {
                respuesta = "Ocurrio una excepcion en el sistema error en GimnasioNegocio(ExisteDia)";

                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = respuesta;
            }
            else
            {

                respuesta = negocio.agregarDiasHorarios(gimnasio);
                cargarDiasHorarios();
                lblError.Text = respuesta;
            }
            
        }


        public void cargarDiasHorarios()
        {
            try
            {

                GimnasioNegocio negocio = new GimnasioNegocio();
                List<Gimnasio> listaGimnasio = new List<Gimnasio>();

                listaGimnasio = negocio.getAllDiasHorarios();

                gvDiasHorarios.DataSource = listaGimnasio;
                gvDiasHorarios.DataBind();
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