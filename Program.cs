using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Nyxellnt.Models;

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
                    opcion1 = pedirOpcion();
                    switch (opcion1)
                    {
                        case 1:
                            iniciarSesion();
                            menuUsuario();
                            break;
                        case 2:
                            registrarse();
                            menuUsuario();
                            break;
                        case 3:
                            verEventos();
                            break;
                        case 4:
                            Console.WriteLine("Hasta el huevo, vuelve pronto");
                            break;
                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console
                    .WriteLine("ArgumentOutOfRangeException: " + e.ToString());
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

        public static void EscribirErrorLog(string msgerror)
        {
            Console.WriteLine("error:" + msgerror);
            string fileName = "LogError.txt";
            File.WriteAllText(fileName, msgerror);
        }

        public static List<Evento> listaEventos = new List<Evento>();

        static Usuario user = null;

        public static List<Usuario> usuarios = new List<Usuario>();

        public static void cargarJsonInicial()
        {
            try
            {
                listaEventos = JsonConvert.DeserializeObject<List<Evento>>(File.ReadAllText("./Models/Json/evento.json"));
                usuarios = JsonConvert.DeserializeObject<List<Usuario>>(File.ReadAllText("./Models/Json/usuarios.json"));
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: Cargar Json Inicial " +
                e.ToString());
            }
        }

        static Boolean isNumeric(String cadena)
        {
            try
            {
                Convert.ToInt32(cadena);
                return true;
            }
            catch (Exception nfe)
            {
                return false;
            }
        }

        static int pedirOpcion()
        {
            int opcion = 0;
            String opcionString;
            Boolean datoValido = false;
            while (datoValido == false)
            {
                opcionString = Console.ReadLine();
                if (isNumeric(opcionString) == true)
                {
                    opcion = Convert.ToInt32(opcionString);
                    datoValido = true;
                }
            }
            return opcion;
        }

        public static void registrarse()
        {
            try
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
                    usuarios
                        .ForEach(item =>
                        {
                            if (item.email.Equals(email))
                            {
                                usuarioRepetido = true;
                                Console
                                    .WriteLine("Ese email ya esta registrado, vuelva a escribirlo");
                            }
                        });
                }
                while (usuarioRepetido == true);

                Console.WriteLine("Constraseña: ");
                String password = Console.ReadLine();
                Console.WriteLine("Cuenta creada con exito.");
                user = new Usuario(nombre, apellido, email, password);

                //Serializar listaUsuarios
                usuarios.Add(user);
                string fileName = "./Models/Json/usuarios.json";
                var options =
                    new JsonSerializerOptions { WriteIndented = true };
                string jsonString =
                    System
                        .Text
                        .Json
                        .JsonSerializer
                        .Serialize(usuarios, options);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: Registrarse " + e.ToString());
            }
        }

        public static void iniciarSesion()
        {
            try
            {
                Console.WriteLine("Email: ");
                String email = Console.ReadLine();
                Console.WriteLine("Constraseña: ");
                String password = Console.ReadLine();

                usuarios
                    .ForEach(usuario =>
                    {
                        if (
                            usuario.email.Equals(email) &&
                            usuario.password.Equals(password)
                        )
                        {
                            user = usuario;
                            Console.WriteLine("Sesión iniciada con éxito");
                        }
                    });
                if (user == null)
                {
                    Console.WriteLine("No estas registrado");
                }
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: Iniciar sesión " + e.ToString());
            }
        }

        public static void menuUsuario()
        {
            try
            {
                int opcion = 0;
                while (opcion != 4)
                {
                    Console
                        .WriteLine("-------------- Nyxelln't - " +
                        user.nombre +
                        " --------------");
                    Console.WriteLine("1. Ver Eventos");
                    Console.WriteLine("2. Información personal");
                    Console.WriteLine("3. Mis Compras");
                    Console.WriteLine("4. Cerrar sesión");
                    Console.WriteLine("----------------------------------");
                    opcion = pedirOpcion();
                    switch (opcion)
                    {
                        case 1:
                            verEventos();
                            break;
                        case 2:
                            listarInformacionUsuario();
                            break;
                        case 3:
                            misCompras();
                            break;
                        case 4:
                            Console.WriteLine("Tira coo!");
                            user = null;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: Menu Usuario " + e.ToString());
            }
        }

        public static void listarInformacionUsuario()
        {
            try
            {
                int opcion = 0;
                while (opcion != 1)
                {
                    Console
                        .WriteLine("-------------- Nyxelln't - Mi Cuenta --------------");
                    user.listarInformacionUsuario();
                    Console.WriteLine("1. Volver");
                    Console.WriteLine("----------------------------------");
                    opcion = pedirOpcion();
                }
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: Listar información Usuario " + e.ToString());
            }
        }

        public static void verEventos()
        {
            try
            {
                int opcion = 0;
                while (opcion != listaEventos.Count + 1)
                {
                    Console
                        .WriteLine("-------------- Nyxelln't - Ver Eventos --------------");
                    Console.WriteLine("0. Buscar por género musical");
                    listaEventos
                        .ForEach(e =>
                        {
                            e.listarEventoLinea();
                        });
                    Console.WriteLine(listaEventos.Count + 1 + ". Volver");
                    Console.WriteLine("----------------------------------");
                    opcion = pedirOpcion();

                    if (opcion == 0)
                    {
                        buscador();
                    }
                    listaEventos
                        .ForEach(e =>
                        {
                            if (e.idEvento.Equals(opcion))
                            {
                                verEventoExtendido(e);
                            }
                        });
                }
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: ver eventos " + e.ToString());
            }
        }

        public static void buscador()
        {
            try
            {
                Console
                    .WriteLine("-------------- Nyxelln't - Buscador de Eventos --------------");
                Console.WriteLine("Opciones disponibles: Rock, Flamenco, Pop, Ópera, Musical, Jazz");
                Console.WriteLine("Introduzca género:");
                string stringBusqueda = Console.ReadLine();
                verEventosBuscados(stringBusqueda);
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: buscador " + e.ToString());
            }
        }

        public static void verEventosBuscados(string stringBusqueda)
        {
            try
            {
                int opcion = 1;
                while (opcion != 0)
                {
                    Console.WriteLine("-------------- Nyxelln't - Eventos de " + stringBusqueda + " --------------");
                    listaEventos.ForEach(e =>
                        {
                            if (e.categoria.ToLower().Equals(stringBusqueda.ToLower()))
                            {
                                e.listarEventoLinea();
                            }
                        });
                    Console.WriteLine("0. Volver");
                    opcion = pedirOpcion();
                    listaEventos.ForEach(e =>
                        {
                            if (e.idEvento.Equals(opcion))
                            {
                                verEventoExtendido(e);
                            }
                        });
                }
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: ver eventos buscados " +
                e.ToString());
            }
        }

        public static void verEventoExtendido(Evento evento)
        {
            try
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
                    opcion = pedirOpcion();
                    if (opcion.Equals(1) && user != null)
                    {
                        Console.WriteLine("¿Cuantas entradas quieres?: ");
                        int entradas = pedirOpcion();
                        if (entradas < 1)
                        {
                            Console
                                .WriteLine("No seas catalán y compra una entrada");
                        }
                        else if (entradas > evento.stock)
                        {
                            Console.WriteLine("¡Onde vas macarenooo! Compra alguna menos, que tas pasao");
                        }
                        else
                        {
                            evento.stock -= entradas;
                            Operacion operacion = new Operacion(evento, entradas);
                            user.eventosComprados.Add(operacion);

                            var options =
                                new JsonSerializerOptions { WriteIndented = true };
                            string jsonStringUsuarios =
                                System
                                    .Text
                                    .Json
                                    .JsonSerializer
                                    .Serialize(usuarios, options);
                            string jsonStringEventos =
                                System
                                    .Text
                                    .Json
                                    .JsonSerializer
                                    .Serialize(listaEventos, options);
                            File
                                .WriteAllText("./Models/Json/usuarios.json",
                                jsonStringUsuarios);
                            File
                                .WriteAllText("./Models/Json/evento.json",
                                jsonStringEventos);

                            Console.WriteLine("Entrada comprada");
                        }
                    }
                    else if (user == null)
                    {
                        Console
                            .WriteLine("Inicia sesión para poder comprar entradas");
                    }
                }
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: ver evento extendido " +
                e.ToString());
            }
        }

        public static void misCompras()
        {
            try
            {
                int opcion = 0;
                while (opcion != 1)
                {
                    Console
                        .WriteLine("-------------- Nyxelln't - Mis Compras --------------");
                    user
                        .eventosComprados
                        .ForEach(e =>
                        {
                            e.mostrarOperacion();
                        });
                    Console.WriteLine("1. Volver");
                    Console.WriteLine("----------------------------------");
                    opcion = pedirOpcion();
                }
            }
            catch (Exception e)
            {
                EscribirErrorLog("Exception: ver mis compras " +
                e.ToString());
            }
        }
    }
}
