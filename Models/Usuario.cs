using System;

namespace Nyxellnt.Models
{
    class Usuario
    {
        public string idUsuario {get;set;}
        public static int accountNumber = 1;
        public string nombre {get;set;}
        public string apellido {get;set;}
        public string email {get;set;}
        public string password {get;set;}
        public List<Operacion> eventosComprados = new List<Operacion>();

        //Constructor
        public Usuario(string nombre, string apellido, string email, string password)
        {
            this.idUsuario = accountNumber.ToString();
            accountNumber++;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
        }
    }
}