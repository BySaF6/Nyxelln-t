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
            AnsiConsole.MarkupLine("[bold #13D7F6]Id de la operación: [/]"+idOperacion);
            AnsiConsole.MarkupLine("[bold #13D7F6]Nombre: [/]" + eventoComprado.nombre);
            AnsiConsole.MarkupLine("[bold #13D7F6]Cantante: [/]" + eventoComprado.cantante);
            AnsiConsole.MarkupLine("[bold #13D7F6]Localidad: [/]" + eventoComprado.localidad);
            AnsiConsole.MarkupLine("[bold #13D7F6]Categoría: [/]" + eventoComprado.categoria);
            AnsiConsole.MarkupLine("[bold #13D7F6]Fecha: [/]" + eventoComprado.fecha);
            AnsiConsole.MarkupLine("[bold #13D7F6]Entradas compradas: [/]" + numEntradasCompradas);
            AnsiConsole.MarkupLine("[bold #13D7F6]Precio total: [/]" + precioTotal);
            AnsiConsole.MarkupLine("[bold #13D7F6]Fecha de compra: [/]" + fechaCompra);
            Console.WriteLine(" ");
        }
    }
}