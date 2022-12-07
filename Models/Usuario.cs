using System;

namespace Nyxellnt.Models
{
    class Usuario
    {
        public int idUsuario {get;set;}
        public static int accountNumber = 1;
        public string nombre {get;set;}
        public string apellido {get;set;}
        public string email {get;set;}
        public string password {get;set;}
        public List<Operacion> eventosComprados {get;set;}

        //Constructor
        public Usuario(string nombre, string apellido, string email, string password)
        {
            this.idUsuario = accountNumber;
            accountNumber++;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
            this.eventosComprados = new List<Operacion>();
        }

        public void listarInformacionUsuario(){
            Console.WriteLine("Id: "+idUsuario);
            Console.WriteLine("Nombre: "+nombre);
            Console.WriteLine("Apellido: "+apellido);
            Console.WriteLine("Email: "+email);
            Console.WriteLine("Contraseña: *********");
        }
    }
}