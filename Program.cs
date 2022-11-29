﻿

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

            try
            {

                cargarJsonInicial();
                int opcion1 = 0;
                while (opcion1 != 4)
                {

                    Console.WriteLine("-------------- Nyxelln't --------------");
                    Console.WriteLine("1. Iniciar sesión");
                    Console.WriteLine("2. Registrarse");
                    Console.WriteLine("3. Ver Eventos");
                    Console.WriteLine("4. Salir");
                    Console.WriteLine("----------------------------------");
                    // opcion1 = pedirOpcion(1, 4);
                    opcion1 = int.Parse(Console.ReadLine());
                    switch (opcion1)
                    {
                        case 1:
                            iniciarSesion();
                            menuUsuario();
                            break;
                        case 2:
                            registrarse();
                            break;
                        case 3:
                            verEventos();
                            break;
                        case 4:
                            Console.WriteLine("De momento no pongas nada");
                            break;
                    }


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
                }











            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("InvalidOperationException: " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }






        }

        public static List<Evento> listaEventos = new List<Evento>();
        static Usuario user = null;
        public static List<Usuario> usuarios = new List<Usuario>();
        public static void cargarJsonInicial()
        {
            listaEventos = JsonConvert.DeserializeObject<List<Evento>>(File.ReadAllText("./Models/Json/evento.json"));
            usuarios = JsonConvert.DeserializeObject<List<Usuario>>(File.ReadAllText("./Models/Json/usuarios.json"));
        }

        // static Boolean isNumeric(String cadena)
        // {
        //     try
        //     {
        //         Convert.ToInt32(cadena);
        //         return true;
        //     }
        //     catch (Exception nfe)
        //     {
        //         return false;
        //     }
        // }
        // static int pedirOpcion(int limitMin, int limitMax)
        // {
        //     int opcion = 0;
        //     String opcionString;
        //     Boolean datoValido = false;
        //     while (datoValido == false)
        //     {
        //         opcionString = Console.ReadLine();
        //         if (isNumeric(opcionString) == true)
        //         {
        //             if (Convert.ToInt32(opcionString) >= limitMin && Convert.ToInt32(opcionString) <= limitMax)
        //             {
        //                 opcion = Convert.ToInt32(opcionString);
        //                 datoValido = true;
        //             }
        //         }
        //     }
        //     return opcion;
        // }

        public static void registrarse()
        {
            Console.WriteLine("Nombre: ");
            String nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            String apellido = Console.ReadLine();
            Console.WriteLine("Email: ");

            // comprobar que no haya otro email igual
            Boolean usuarioRepetido = false;
            String email = "";
            do
            {
                usuarioRepetido = false;
                email = Console.ReadLine();
                usuarios.ForEach(item =>
                {
                    if (item.email.Equals(email))
                    {
                        usuarioRepetido = true;
                        Console.WriteLine("Ese email ya esta registrado, vuelva a escribirlo");
                    }
                });
            } while (usuarioRepetido == true);

            Console.WriteLine("Constraseña: ");
            String password = Console.ReadLine();
            Console.WriteLine("Cuenta creada con exito.");
            user = new Usuario(nombre, apellido, email, password);

            //Serializar listaUsuarios
            usuarios.Add(user);
            string fileName = "./Models/Json/usuarios.json";
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(usuarios, options);
            File.WriteAllText(fileName, jsonString);
        }

        public static void iniciarSesion()
        {
            Console.WriteLine("Email: ");
            String email = Console.ReadLine();
            Console.WriteLine("Constraseña: ");
            String password = Console.ReadLine();

            usuarios.ForEach(usuario =>
            {
                if (usuario.email.Equals(email) && usuario.password.Equals(password))
                {
                    user = usuario;
                    Console.WriteLine("Sesión iniciada con éxito");
                }
                else
                {
                    Console.WriteLine("No estas registrado");
                }
            });
        }

        public static void menuUsuario()
        {
            int opcion = 0;
            while (opcion != 4)
            {

                Console.WriteLine("-------------- Nyxelln't - " + user.nombre + " --------------");
                Console.WriteLine("1. Ver Eventos");
                Console.WriteLine("2. Información personal");
                Console.WriteLine("3. Mis Compras");
                Console.WriteLine("4. Cerrar sesión");
                Console.WriteLine("----------------------------------");
                // opcion1 = pedirOpcion(1, 4);
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        verEventos();
                        break;
                    case 2:
                        registrarse();
                        break;
                    case 3:
                        verEventos();
                        break;
                    case 4:
                        Console.WriteLine("De momento no pongas nada");
                        break;
                }
            }

        }

        public static void verEventos()
        {
            int opcion = 0;
            while (opcion != listaEventos.Count+1)
            {
                Console.WriteLine("-------------- Nyxelln't - Ver Eventos --------------");
                listaEventos.ForEach(e =>
                            {
                                e.listarEventoLinea();
                            });
                Console.WriteLine(listaEventos.Count+1+". Volver");
                Console.WriteLine("----------------------------------");
                opcion = int.Parse(Console.ReadLine());

                listaEventos.ForEach(e =>
                {
                    if (e.idEvento.Equals(opcion))
                    {
                        verEventoExtendido(e);
                    }
                });
            }
        }

        public static void verEventoExtendido(Evento evento)
        {
            int opcion = 0;
            while (opcion != 2)
            {
                Console.WriteLine("-------------- Nyxelln't - Ver Eventos --------------");
                evento.listarEventoExtendido();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1. Comprar");
                Console.WriteLine("2. Volver");
                Console.WriteLine("----------------------------------");
                opcion = int.Parse(Console.ReadLine());
            }

        }



    }
}
