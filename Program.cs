

using System;
using Nyxellnt.Models;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace Nyxellnt
{
    class Program
    {
        static void Main(string[] args)
        {
            registrarse();
            iniciarSesion();
            //     Console.WriteLine("Bienvenido a Nyxelln't");

            //     try
            //     {
            //         Boolean exit = false;
            //         Boolean userAccessed = false;

            //         //
            //         List<Evento> listaEventos = new List<Evento>();

            //         // Usuario de prueba
            //         Usuario user = new Usuario("email", "nombre", "password");


            //         int opcion1 = 0;
            //         while(opcion1 != 4){
            //             userAccessed = false;

            //             Console.WriteLine("-------------- Menu --------------");
            //             Console.WriteLine("1. Iniciar sesión");
            //             Console.WriteLine("2. Registrarse");
            //             Console.WriteLine("3. Ver Eventos (sin opción a compra)");
            //             Console.WriteLine("4. Salir");
            //             Console.WriteLine("----------------------------------");
            //             opcion1 = pedirOpcion(1,4);
            //             switch(opcion1){
            //                 case 1:
            //                     userAccessed = true;
            //                     break;
            //                 case 2:
            //                     userAccessed = true;
            //                     break;
            //                 case 3:
            //                     userAccessed = false;
            //                     break;
            //                 case 4:
            //                     Console.WriteLine("¡Adiós!\n");
            //                     userAccessed = false;
            //                     break;
            //                 default:
            //                     Console.WriteLine("Elige una opción del 1 al 4");
            //                     break;
            //             }


            //             if(userAccessed){
            //                 int opcion2 = 0;
            //                 while(opcion2 != 3){
            //                     Console.WriteLine("\n---------- Usuario "+user.nombre+" ----------");
            //                     Console.WriteLine("1. Ver eventos comprados");
            //                     Console.WriteLine("2. Lista de eventos");
            //                     Console.WriteLine("3. Cerrar sesión");
            //                     Console.WriteLine("------------------------------\n");
            //                     opcion2 = pedirOpcion(1,3);

            //                     switch(opcion2){
            //                         case 1:
            //                             break;
            //                         case 2:
            //                             int opcion3 = 0;
            //                             while(opcion3 != listaEventos.length+1){
            //                                 Console.WriteLine("\n---------- Lista de eventos ----------");
            //                                 Console.WriteLine("1. Evento 1");
            //                                 Console.WriteLine("2. Evento 2");
            //                                 //
            //                                 for(int i=0; i<listaEventos.length; i++){
            //                                     listaEventos[i].listarEventoLinea();
            //                                 }
            //                                 //
            //                                 Console.WriteLine("n. Atrás");
            //                                 Console.WriteLine("-------------------------------------\n");
            //                                 opcion3 = pedirOpcion(1,listaEventos.length+1);

            //                                 if(opcion3 >= 1 && opcion3 <= listaEventos.length){
            //                                     Console.WriteLine("\n--------- "+listaEventos[opcion3-1].nombre+" ---------");
            //                                     listaEventos[opcion3-1].listarEventoExtendido();
            //                                     Console.WriteLine("-------------------------------------");
            //                                     Console.WriteLine("1. Comprar Evento");
            //                                     Console.WriteLine("2. Atrás");
            //                                     Console.WriteLine("-------------------------------------\n");

            //                                 }
            //                             }
            //                             break;
            //                         case 3:
            //                             Console.WriteLine("¡Hasta luego!\n");
            //                             exit = true;
            //                             break;
            //                         default:
            //                             Console.WriteLine("Elige una opción del 1 al 4");
            //                             break;
            //                     }


            //                 }
            //             }
            //         }











            //     }
            //     catch (ArgumentOutOfRangeException e)
            //     {
            //         Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
            //     }
            //     catch (InvalidOperationException e)
            //     {
            //         Console.WriteLine("InvalidOperationException: " + e.ToString());
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine("Exception: " + e.ToString());
            //     }



            //     static Boolean isNumeric(String cadena){
            //         try {
            //             Convert.ToInt32(cadena);
            //             return true;
            //         } catch (Exception nfe){
            //             return false;
            //         }
            //     }
            //     static int pedirOpcion(int limitMin, int limitMax){
            //         int opcion = 0;
            //         String opcionString;
            //         Boolean datoValido = false;
            //         while(datoValido == false){
            //             opcionString = Console.ReadLine();
            //             if(isNumeric(opcionString) == true){
            //                 if(Convert.ToInt32(opcionString) >= limitMin && Convert.ToInt32(opcionString) <= limitMax){
            //                     opcion = Convert.ToInt32(opcionString);
            //                     datoValido = true;
            //                 }
            //             }
            //         }
            //         return opcion;
            //     }

        }

        static Usuario user = null;
        public static List<Usuario> usuarios = new List<Usuario>();
        //Deserializar
        // public static List<Usuario>? usuarios = JsonConvert.DeserializeObject<List<Usuario>>("usuarios.json");
        // usuarios.ForEach(e => Console.WriteLine(e));
        public static void registrarse()
        {
            Console.WriteLine("Nombre: ");
            String nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            String apellido = Console.ReadLine();
            Console.WriteLine("Email: ");
            String email = Console.ReadLine();
            Console.WriteLine("Constraseña: ");
            String password = Console.ReadLine();
            Console.WriteLine("Cuenta creada con exito.");
            user = new Usuario(nombre, apellido, email, password);

            //Serializar listaUsuarios
            usuarios.Add(user);
            string fileName = "usuarios.json";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(usuarios, new JsonSerializerOptions());
            File.WriteAllText(fileName, jsonString);
        }

        public static void iniciarSesion()
        {
            Console.WriteLine("Email: ");
            String email = Console.ReadLine();
            Console.WriteLine("Constraseña: ");
            String password = Console.ReadLine();

            usuarios.ForEach(usuario =>{
                if(usuario.email.Equals(email) && usuario.password.Equals(password)){
                    user = usuario;
                    Console.WriteLine("gucci");
                }
            });
        }

        
    }
}
