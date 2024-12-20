using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; }
        public string Dni {  get; set; }
        public bool State { get; set; }

        public Persona() { }
        public Persona(string name, string lastname, string dni) {
            
            Name = name;
            LastName = lastname;
            Dni = dni;
            State = true;

        }

    }
}
