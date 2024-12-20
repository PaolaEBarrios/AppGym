using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGym
{
    public partial class AdminReactivar_UsuarioInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReactivarInstructor_Click(object sender, EventArgs e)
        {
            //LO VA A LLEVAR A UNA PAGE DONDE SE VEA UN GV Y SE ACTIVE SOLAMENTE Y DE CARTEL DE ACTIVADO EN LA MISMA

            Response.Redirect("AdminReactivar-Instructor.aspx");

        }

        protected void btnReactivarUser_Click(object sender, EventArgs e)
        {
            //LO VA A LLEVAR A UNA PAGE DONDE SE VEA UN GV Y SE ACTIVE SOLAMENTE Y DE CARTEL DE ACTIVADO EN LA MISMA
            Response.Redirect("AdminReactivar-Usuario.aspx");
        }


    }
}