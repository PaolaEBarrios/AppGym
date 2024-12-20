using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Teacher : Persona
    {

        public string detalle { get; set; }
        public Teacher(string name, string lastname, string dni) : base(name, lastname, dni)
        {
        }

        public Teacher() { }

        Usuario Usuario { get; set; }

    }
}
