using System;

namespace Nyxellnt.Models
{
    class Evento
    {
        public string idEvento;
        public static int eventNumber = 1;
        public string nombre;
        public string cantante;
        public string descripcion;
        public string localidad;
        public DateTime fecha;
        public decimal precioEntrada;
        public int stock;

        //Constructor
        public Evento(int idEvento, string nombre, string cantante, string descripcion, string localidad, DateTime fecha, decimal precioEntrada, int stock)
        {
            this.idEvento = eventNumber.ToString();
            eventNumber++;
            this.nombre = nombre;
            this.cantante = cantante;
            this.descripcion = descripcion;
            this.localidad = localidad;
            this.fecha = fecha;
            this.precioEntrada = precioEntrada;
            this.stock = stock;
        }

        public void listarEventoLinea(){
            Console.WriteLine(idEvento+" "+nombre + " " + cantante + " "+localidad+" "+precioEntrada);
        }

        public void listarEventoExtendido(){
            Console.WriteLine(nombre);
            Console.WriteLine(cantante);
            Console.WriteLine(descripcion);
            Console.WriteLine(localidad);
            Console.WriteLine(fecha);
            Console.WriteLine(precioEntrada);
            Console.WriteLine(stock);
        }
    }
}