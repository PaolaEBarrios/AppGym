using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Gimnasio
    {

        public Gimnasio() { }
        //public Dictionary<string, string> HorariosPorDia { get; set; }//mapa para que la llave sea el dia y el valor sean los horarios
        
        public string dia { get; set; }
        public string horaInicio { get; set; }

        public string horaFin {  get; set; }

        public string minuto { get; set; }
        public string hora { get; set; }

        Salon salon { get; set; }


    }
}
