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
    public partial class AdminClases_Activas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cargarClases();
            }
        }


        void cargarClases()
        {
            try
            {
                List<Clase> listaClases = new List<Clase>();
                ClaseNegocio negocio = new ClaseNegocio();

                listaClases = negocio.getClases();

                List<Clase> clasesActivas = listaClases.Where(c =>  c.estado == true).ToList();

                if (clasesActivas.Count > 0)
                {
                    gvClases.DataSource = clasesActivas;
                    gvClases.DataBind();
                }
                else
                {
                    lblError.Text = "No se encontraron clases activas";
                    lblError.ForeColor = System.Drawing.Color.Orange;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gvClases_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Eliminar")
            {
                Clase clase = new Clase();
                int index = Convert.ToInt32(e.CommandArgument);

                clase.Id = int.Parse(gvClases.Rows[index].Cells[0].Text);

                ClaseNegocio negocio = new ClaseNegocio();


                bool eliminado = negocio.eliminarClase(clase.Id);

                if (eliminado)
                {
                    
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Exito al eliminar la clase: " + clase.Id;
                    cargarClases();
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Ocurrio un error";
                }
            }
        }
    }
}