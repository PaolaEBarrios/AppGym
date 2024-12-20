using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminDiasHorarios_Editar2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["DiaSeleccionado"] != null )
            {
                lblDia.Text = (string)Session["DiaSeleccionado"];
                cargarHorarioDia();
            }
            else if(IsPostBack && Session["DiaSeleccionado"] == null)
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdmindiasHorarios-Editar.aspx");
        }

        protected void btnAddHora_Click(object sender, EventArgs e)
        {
            GimnasioNegocio negocio = new GimnasioNegocio();
            Gimnasio gimnasio = new Gimnasio();


            string dia = lblDia.Text;

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

            gimnasio.horaInicio = horaInicio;
            gimnasio.horaFin = horaFin;

            gimnasio.dia = dia;
            gimnasio.hora = gimnasio.horaInicio + " a " + gimnasio.horaFin;
            
            string respuesta = negocio.editarHorarioxDia(gimnasio);

            if(respuesta == "Exito")
            {
                cargarHorarioDia();
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Exito al editar la fecha del dia: " + dia;
            }
            else if(respuesta == "Exepcion")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Ocurrio una excepcion al querer editar la hora(EditarHorarioxDia)";
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Ocurrio un error al querer editar la hora(EditarHorarioxDia)";
            }
        }

        public void cargarHorarioDia()
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