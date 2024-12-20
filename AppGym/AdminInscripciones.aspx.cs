using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminInscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIrInscripcion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInscripciones-add.aspx");
        }

        protected void btnEliminarInscripcion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInscripciones-eliminar.aspx");
        }
    }
}