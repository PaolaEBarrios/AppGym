using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminSalones_EditarEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarSalones();
            }
        }

        protected void gvSalones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Editar")
            {

                //se obtiene el indice de la fila para luego usarse para buscar dentro de gv algun dato de alguna casilla 
                int index = Convert.ToInt32(e.CommandArgument);
                Salon salon = new Salon();

                 salon.IdSalon = int.Parse(gvSalones.Rows[index].Cells[0].Text);
                 salon.Name = gvSalones.Rows[index].Cells[1].Text;

                Session["SalonEditar"]= salon;

                Response.Redirect($"AdminSalones-Editar.aspx");
            }
            else if(e.CommandName == "Eliminar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                Salon salon = new Salon();

                salon.IdSalon = int.Parse(gvSalones.Rows[index].Cells[0].Text);
                salon.Name = gvSalones.Rows[index].Cells[1].Text;

                Session["SalonEliminar"] = salon;

                Response.Redirect($"AdminSalones-Eliminar.aspx");
            }
        }


        public void cargarSalones() {

            try
            {
                List<Salon> listaSalones = new List<Salon>();
                SalonNegocio negocio = new SalonNegocio();

                listaSalones = negocio.getSalones();

                if(listaSalones.Count > 0)
                {
                    lblCantSalones.Text =listaSalones.Count.ToString();
                    gvSalones.DataSource = listaSalones;
                    gvSalones.DataBind();
                }
                else if(listaSalones != null)
                {
                    lblError.Text = "OCURRIO UN ERROR AL TRAER LOS SALONES O NO EXISTEN SALONES CARGADOS";
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblError.Text = "NO HAY SALONES CARGADOS EN EL SISTEMA";
                    lblError.ForeColor = System.Drawing.Color.Orange;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        
        }
    }
}