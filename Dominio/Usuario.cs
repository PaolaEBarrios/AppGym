using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario : Persona
    {


        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public int tipo {  get; set; }


        public Usuario() { }
        public Usuario(string username, string pass, string name, string lastname, string dni) : base(name, lastname, dni)
        {
            Name = name;
            LastName = lastname;
            Dni = dni;
            UserName = username;
            Password = pass;
            State = true;
        }



    }
}
