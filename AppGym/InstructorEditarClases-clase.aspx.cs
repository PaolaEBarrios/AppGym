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
    public partial class InstructorEditarClases_clase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Clase"] != null)
            {
                cargarSalones();

                Clase clase = new Clase();
                clase = (Clase)Session["Clase"];

                txtCapacidad.Text = clase.Capacidad.ToString();
                txtClase.Text = clase.Name;
                ddlDias.Text = clase.Dia;
                ddlHoras.Text = clase.HoraInicio;
                ddlHorasFin.Text = clase.HoraFin;
                lblId.Text=clase.Id.ToString();

            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Clase clase = new Clase();


            string horaInicio = ddlHoras.Text + ":" + ddlMinutos.Text;

            string horaFin = ddlHorasFin.Text + ":" + ddlMinutosFin.Text;

            TimeSpan horaInicioTs = TimeSpan.Parse(horaInicio);
            TimeSpan horaFinTs = TimeSpan.Parse(horaFin);

            if (horaInicioTs >= horaFinTs)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "La hora de inicio debe ser anterior a la hora de fin.";
                return;
            }

            if (txtClase.Text != "" && txtCapacidad.Text != "")
            {
                clase.Id = int.Parse(lblId.Text);
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
                    string respuesta = negocio.editarClase(clase);

                    if (respuesta.Contains("Exito"))
                    {
                        btnEditar.Visible = false;
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = respuesta;

                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = respuesta;
                    }
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Por favor llenar el campo nombre y capacidad";
                }

            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorEditarClases.aspx");
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
    }
}