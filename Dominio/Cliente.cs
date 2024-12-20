using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Persona
    {
        public string Email { get ; set; } 
        public string Observacion{ get; set;  }
        public int Pase { get; set ;  }

        public int Tipo { get; set ; }
        public Cliente(string name, string lastname, string dni, string Obser, int idMembresia ) : base(name, lastname, dni)
        {
            Name = name;
            LastName = lastname;
            Dni = dni;
            Observacion= Obser;
            Pase = idMembresia;
        }

        public Cliente()
        {
        }

        Clase clases { get; set; }

    }
}
