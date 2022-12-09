using System;
using Spectre.Console;

namespace Nyxellnt.Models
{
    class Operacion
    {
        public int idOperacion { get; set; }
        public static int operationNumber = 1;
        public Evento eventoComprado { get; set; }
        public int numEntradasCompradas { get; set; }
        public decimal precioTotal { get; set; }
        public string fechaCompra = DateTime.Now.ToString("dd-MM-yyyy");

        //Constructor
        public Operacion(Evento eventoComprado, int numEntradasCompradas)
        {
            this.idOperacion = operationNumber;
            operationNumber++;
            this.eventoComprado = eventoComprado;
            this.numEntradasCompradas = numEntradasCompradas;
            this.precioTotal = numEntradasCompradas * eventoComprado.precioEntrada;
            this.fechaCompra = fechaCompra;
        }

        public void mostrarOperacion()
        {
            AnsiConsole.MarkupLine("[bold #13D7F6]Id de la operación: [/][bold white]"+idOperacion+"[/]");
            AnsiConsole.MarkupLine("[bold #13D7F6]Nombre: [/][bold white]" + eventoComprado.nombre+"[/]");
            AnsiConsole.MarkupLine("[bold #13D7F6]Cantante: [/][bold white]" + eventoComprado.cantante+"[/]");
            AnsiConsole.MarkupLine("[bold #13D7F6]Localidad: [/][bold white]" + eventoComprado.localidad+"[/]");
            AnsiConsole.MarkupLine("[bold #13D7F6]Categoría: [/][bold white]" + eventoComprado.categoria+"[/]");
            AnsiConsole.MarkupLine("[bold #13D7F6]Fecha: [/][bold white]" + eventoComprado.fecha+"[/]");
            AnsiConsole.MarkupLine("[bold #13D7F6]Entradas compradas: [/][bold white]" + numEntradasCompradas+"[/]");
            AnsiConsole.MarkupLine("[bold #13D7F6]Precio total: [/][bold white]" + precioTotal+"[/]");
            AnsiConsole.MarkupLine("[bold #13D7F6]Fecha de compra: [/][bold white]" + fechaCompra+"[/]");
            Console.WriteLine(" ");
        }
    }
}