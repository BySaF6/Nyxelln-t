using System;
using Spectre.Console;

namespace Nyxellnt.Models
{
    class Evento
    {
        public int idEvento { get; set; }
        public string nombre { get; set; }
        public string cantante { get; set; }
        public string descripcion { get; set; }
        public string localidad { get; set; }
        public string fecha { get; set; }
        public decimal precioEntrada { get; set; }
        public int stock { get; set; }
        public string categoria { get; set; }

        //Constructor
        public Evento(int idEvento, string nombre, string cantante, string descripcion, string localidad, string fecha, decimal precioEntrada, int stock, string categoria)
        {
            this.idEvento = idEvento;
            this.nombre = nombre;
            this.cantante = cantante;
            this.descripcion = descripcion;
            this.localidad = localidad;
            this.fecha = fecha;
            this.precioEntrada = precioEntrada;
            this.stock = stock;
            this.categoria = categoria;
        }

        public void listarEventoLinea()
        {
            AnsiConsole.MarkupLine(idEvento + ". [bold #13D7F6]Nombre: [/]" + nombre + ", [bold #13D7F6]Cantante: [/]" + cantante + ", [bold #13D7F6]Localidad: [/]" + localidad + ", [bold #13D7F6]Categoría: [/]" + categoria + ", [bold #13D7F6]Precio: [/]" + precioEntrada + " euros");
        }

        public void listarEventoExtendido()
        {

            AnsiConsole.MarkupLine("[bold #13D7F6]Evento: [/]" + nombre);
            AnsiConsole.MarkupLine("[bold #13D7F6]Arista: [/]" + cantante);
            AnsiConsole.MarkupLine("[bold #13D7F6]\nDescripción:[/]");
            AnsiConsole.MarkupLine(descripcion);
            AnsiConsole.MarkupLine("[bold #13D7F6]\nLocalidad: [/]" + localidad);
            AnsiConsole.MarkupLine("[bold #13D7F6]Estilo: [/]" + categoria);
            AnsiConsole.MarkupLine("[bold #13D7F6]Fecha: [/]" + fecha);
            AnsiConsole.MarkupLine("[bold #13D7F6]Precio: [/]" + precioEntrada + "euros");
            AnsiConsole.MarkupLine("[bold #13D7F6]Entradas restantes: [/]" + stock);
        }
    }
}