using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reserva
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Clase Clase { get; set; }

        public int ClaseId { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public bool estado { get; set; }
        public string nombreClase { get; set; }
        public Reserva() { }
    }
}
