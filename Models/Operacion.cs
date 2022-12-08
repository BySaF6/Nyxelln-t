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

        public void mostrarOperacion(){
            Console.WriteLine("Nombre: "+eventoComprado.nombre+", Cantante: "+eventoComprado.cantante+", Localidad: "+eventoComprado.localidad+", Categoría: "+eventoComprado.categoria+", Fecha: "+eventoComprado.fecha+", Entradas compradas: "+numEntradasCompradas+", Precio total: "+precioTotal+", Fecha de compra: "+fechaCompra);
        }
    }
}