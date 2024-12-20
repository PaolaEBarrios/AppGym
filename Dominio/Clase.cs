using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Clase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacidad { get; set; }
        Teacher Teacher { get; set; }
        public string InstructorId { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Dia { get; set; }

        public int idSalon {  get; set; } 

        public bool estado { get; set; }    
        public Clase() { }

        public int Inscriptos {  get; set; }
        public Teacher instructor { get; set; }

        public string detalle {  get; set; }
      
    }
}
