using System;

namespace Nyxellnt.Models
{
    class Usuario
    {
        public string idUsuario;
        public static int accountNumber = 1;
        public string nombre;
        public string email;
        public string password;
        public string localidad;
        public string cuentaBancaria;
        public List<Evento> eventosComprados = new List<Evento>();

        //Constructor
        public Usuario(string email, string nombre, string password, string localidad, string cuentaBancaria)
        {
            this.idUsuario = accountNumber.ToString();
            accountNumber++;
            this.email = email;
            this.nombre = nombre;
            this.password = password;
            this.localidad = localidad;
            this.cuentaBancaria = cuentaBancaria;
        }

        public void crearUsuario (){
            
        }
        public void comprarEntrada(Evento evento){
            // int numEntradas = 0;


            // Operacion operacion = new Operacion();
            // eventosComprados.add();
        }
    }
}