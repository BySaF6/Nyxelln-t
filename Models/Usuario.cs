using System;
using Spectre.Console;

namespace Nyxellnt.Models
{
    class Usuario
    {
        public int idUsuario { get; set; }
        public static int accountNumber = 1;
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Operacion> eventosComprados { get; set; }

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

        public void listarInformacionUsuario()
        {
            AnsiConsole.MarkupLine("[bold #13D7F6]Id: [/]" + idUsuario);
            AnsiConsole.MarkupLine("[bold #13D7F6]Nombre: [/]" + nombre);
            AnsiConsole.MarkupLine("[bold #13D7F6]Apellido: [/]" + apellido);
            AnsiConsole.MarkupLine("[bold #13D7F6]Email: [/]" + email);
            AnsiConsole.MarkupLine("[bold #13D7F6]Contraseña: [/]*********");
        }
    }
}