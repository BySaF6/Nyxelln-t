using System;

namespace Nyxellnt.Models
{
    class Evento
    {
        public int idEvento {get;set;}
        public string nombre {get;set;}
        public string cantante {get;set;}
        public string descripcion {get;set;}
        public string localidad {get;set;}
        public string fecha {get;set;}
        public decimal precioEntrada {get;set;}
        public int stock {get;set;}
        public string categoria {get;set;}

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
            Console.WriteLine(idEvento+". Nombre: "+nombre + ", Cantante: " + cantante + ", Localidad: "+localidad+", Categoría: "+categoria+", Precio: "+precioEntrada+" euros");
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