using System;

namespace Nyxellnt.Models
{
    class Evento
    {
        public int idEvento;
        public string nombre;
        public string cantante;
        public string descripcion;
        public string localidad;
        public string fecha;
        public decimal precioEntrada;
        public int stock;
        public string categoria;

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

        public void listarEventoLinea(){
            Console.WriteLine(idEvento+". "+nombre + " " + cantante + " "+localidad+" "+categoria+" "+precioEntrada);
        }

        public void listarEventoExtendido(){

            Console.WriteLine("Evento: "+nombre);
            Console.WriteLine("Arista: "+cantante);
            Console.WriteLine("\nDescripción:");
            Console.WriteLine(descripcion);
            Console.WriteLine("\nLocalidad: "+localidad);
            Console.WriteLine("Estilo: "+categoria);
            Console.WriteLine("Fecha: "+fecha);
            Console.WriteLine("Precio: "+precioEntrada+"€");
            Console.WriteLine("Entradas restantes: "+stock);
        }
    }
}