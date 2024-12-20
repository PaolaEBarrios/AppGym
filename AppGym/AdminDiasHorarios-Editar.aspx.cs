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
    public partial class AdminDiasHorarios_Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDiasHorarios();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }


        public void cargarDiasHorarios() {

            try
            {

                GimnasioNegocio negocio = new GimnasioNegocio();
                List<Gimnasio> listaGimnasio = new List<Gimnasio>();

                listaGimnasio = negocio.getAllDiasHorarios();

                if (listaGimnasio.Count > 0) {

                    gvDiasHorarios.DataSource = listaGimnasio;
                    gvDiasHorarios.DataBind();
                }
                
            }
            catch (Exception ex)
            {

                lblError.Text = "Ocurrio una excepcion al querer cargar los datos " + ex.Message;
            }
            finally
            {

            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDiasHorarios.aspx");
        }

        protected void gvDiasHorarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string diaSeleccionado = gvDiasHorarios.Rows[index].Cells[0].Text;

                Session["DiaSeleccionado"] = diaSeleccionado;
                Response.Redirect("AdminDiasHorarios-Editar2.aspx");

            }
        }
    }
}