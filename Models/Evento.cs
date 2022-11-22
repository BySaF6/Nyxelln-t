using System;

namespace Nexyll.Models
{
    class Evento
    {
        public int idEvento = 0;
        public string nombre;
        public string cantante;
        public string descripcion;
        public string localidad;
        public decimal precioEntrada;
        public int stock;

        //Constructor
        public Evento(int idEvento, string nombre, string cantante, string descripcion, string localidad, decimal precioEntrada, int stock)
        {
            this.idEvento = idEvento;
            this.nombre = nombre;
            this.cantante = cantante;
            this.descripcion = descripcion;
            this.localidad = localidad;
            this.precioEntrada = precioEntrada;
            this.stock = stock;
        }
    }
}