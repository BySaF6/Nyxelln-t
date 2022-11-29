using System;

namespace Nyxellnt.Models
{
    class Operacion
    {
        public int idOperacion {get;set;}
        public static int operationNumber = 1;
        public Evento eventoComprado {get;set;}
        public int numEntradasCompradas {get;set;}
        public decimal precioTotal {get;set;}
        public DateTime fechaCompra {get;set;}

        //Constructor
        public Operacion(Evento eventoComprado, int numEntradasCompradas)
        {
            this.idOperacion = operationNumber;
            operationNumber++;
            this.eventoComprado = eventoComprado;
            this.numEntradasCompradas = numEntradasCompradas;
            this.precioTotal = numEntradasCompradas * eventoComprado.precioEntrada;
            //this.fechaCompra = new DateTime.Now();
        }

        public void mostrarOperacion(){
            Console.WriteLine(idOperacion+" "+eventoComprado.nombre+" "+eventoComprado.cantante+" "+eventoComprado.localidad+" "+eventoComprado.categoria+" "+eventoComprado.fecha+" "+numEntradasCompradas+" "+precioTotal+" "+fechaCompra);
        }
    }
}