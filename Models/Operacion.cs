using System;

namespace Nyxellnt.Models
{
    class Operacion
    {
        public string idOperacion;
        public static int operationNumber = 1;
        public Evento eventoComprado;
        public int numEntradasCompradas;
        public decimal precioTotal;
        public DateTime fechaCompra;

        //Constructor
        public Operacion(Evento eventoComprado, int numEntradasCompradas)
        {
            this.idOperacion = operationNumber.ToString();
            operationNumber++;
            this.eventoComprado = eventoComprado;
            this.numEntradasCompradas = numEntradasCompradas;
            this.precioTotal = numEntradasCompradas * eventoComprado.precioEntrada;
            this.fechaCompra = new DateTime.Now();
        }

        public void mostrarOperacion(){
            Console.WriteLine(idOperacion+" "+eventoComprado.nombre+" "+eventoComprado.cantante+" "+eventoComprado.localidad+" "+eventoComprado.categoria+" "+eventoComprado.fecha+" "+numEntradasCompradas+" "+precioTotal+" "+fechaCompra);
        }
    }
}