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
    public partial class InstructorCrearClase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarSalones();

            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            Clase clase = new Clase();

            string horaInicio = ddlHoras.Text +":"+ ddlMinutos.Text;
            
            string horaFin = ddlHorasFin.Text+ ":" + ddlMinutosFin.Text;

            TimeSpan horaInicioTs = TimeSpan.Parse(horaInicio);
            TimeSpan horaFinTs = TimeSpan.Parse(horaFin);

            if (horaInicioTs >= horaFinTs)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "La hora de inicio debe ser anterior a la hora de fin.";
                return;
            }



            //para ahorrar trabajo al admin
            //verificar si para ese dia en ese rango horario y para ese salon existe alguna clase - salon no disponible
            //verificar si el instructor ya tiene otra clase en ese dia en ese rango horario -instructor no disponible por superposicion


            if (txtCapacidad.Text != "" && txtClase.Text != "")
            {
                clase.Name = txtClase.Text;
                clase.Capacidad = int.Parse(txtCapacidad.Text);
                clase.Dia = ddlDias.Text;
                clase.HoraInicio = horaInicio;
                clase.HoraFin = horaFin;
                //se selecciona el valor de ddlSalones para recuperar el id de salon
                clase.idSalon = int.Parse(ddlSalones.SelectedValue);

                //recuperamos el usuario de la sesion
                Teacher teacher = (Teacher)Session["InstructorLogueado"];
                InstructorNegocio negocioInstructor = new InstructorNegocio();
                
                ClaseNegocio negocio = new ClaseNegocio();
                //con el usuario vamos a buscar el id de instructor
                

                //primero comprobar si el salon esta ocupado - para ese dia y horario 

                bool banderaSalon = negocio.disponibidadSalon(clase);
                //segundo comprobar que el instructor no tenga clases -para ese dia y horario

                bool banderaInstructor = negocio.disponibidadInstructor(teacher.Id, clase);



                if (banderaInstructor == true && banderaSalon == true)
                {
                   
                    //noo olvidar inicializar el instructor 
                    clase.instructor = new Teacher();

                    clase.instructor.Id = teacher.Id;

                    //si esta disponibilidad
                    //cargarla en sistema con estado 0 o false
                    string respuesta = negocio.cargarClase(clase);

                    if (respuesta.Contains("Exito"))
                    {
                        btnEnviar.Visible = false;  
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = respuesta;

                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = respuesta;
                    }
                
                }
                else if(banderaInstructor == true && banderaSalon == false)
                {
                    //salon no disponible
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "El salon no esta disponible para ese día y horario";
                    
                }
                else if(banderaInstructor == false && banderaSalon == true)
                {
                    //instructor no disponible
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Ya reservaste en este dia y horario, pero en otro salon buscar en Mis clases";
                }
                else
                {
                    //instructor no disponible y salon no disponible

                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Ya reservaste en este dia y horario y salon";

                }

            }

        }

        void cargarSalones()
        {
            List<Salon> listaSalones = new List<Salon>();
            SalonNegocio negocio = new SalonNegocio();

            listaSalones = negocio.getSalones();
            ddlSalones.Items.Clear();

            foreach (Salon salon in listaSalones)
            {
                ListItem listItem = new ListItem(salon.Name, salon.IdSalon.ToString());
                ddlSalones.Items.Add(listItem);

            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorClases.aspx");
        }
    }
}