using System;

namespace Nexyll.Models
{
    class Operacion
    {
        public Evento eventoComprado;
        public int numEntradasCompradas;
        public decimal precioTotal;
        public DateTime fechaCompra;
        public string localidad;

        //Constructor
        public Operacion(Evento eventoComprado, int numEntradasCompradas, string localidad)
        {
            this.eventoComprado = eventoComprado;
            this.numEntradasCompradas = numEntradasCompradas;
            this.precioTotal = numEntradasCompradas*eventoComprado.precioEntrada;
            // this.fechaCompra = new DateTime.Now();
            this.localidad = localidad;
        }
    }
}