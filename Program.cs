using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Nyxellnt.Models;
using Spectre.Console;

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
                    AnsiConsole.MarkupLine("[bold #FD0105]--------------[/] [bold #FD0105]Nyxelln't[/] [bold #FD0105]--------------[/]");
                    AnsiConsole.MarkupLine("[bold #FAFA29]1. Iniciar sesión[/]");
                    AnsiConsole.MarkupLine("[bold #FAFA29]2. Registrarse[/]");
                    AnsiConsole.MarkupLine("[bold #FAFA29]3. Ver Eventos[/]");
                    AnsiConsole.MarkupLine("[bold #FAFA29]4. Salir[/]");
                    AnsiConsole.MarkupLine("[bold #FD0105]---------------------------------------[/]");
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
                            AnsiConsole.MarkupLine("Hasta el huevo, vuelve pronto");
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
                AnsiConsole.MarkupLine("InvalidOperationException: " + e.ToString());
            }
            catch (Exception e)
            {
                AnsiConsole.MarkupLine("Exception: " + e.ToString());
            }
        }

        public static void EscribirErrorLog(string msgerror)
        {
            AnsiConsole.MarkupLine("error:" + msgerror);
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
                AnsiConsole.MarkupLine("Nombre: ");
                String nombre = Console.ReadLine();
                AnsiConsole.MarkupLine("Apellido: ");
                String apellido = Console.ReadLine();
                AnsiConsole.MarkupLine("Email: ");

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

                AnsiConsole.MarkupLine("Constraseña: ");
                String password = Console.ReadLine();
                AnsiConsole.MarkupLine("Cuenta creada con exito.");
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
                AnsiConsole.MarkupLine("Email: ");
                String email = Console.ReadLine();
                AnsiConsole.MarkupLine("Constraseña: ");
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
                            AnsiConsole.MarkupLine("Sesión iniciada con éxito");
                        }
                    });
                if (user == null)
                {
                    AnsiConsole.MarkupLine("No estas registrado");
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
                    AnsiConsole.MarkupLine("1. Ver Eventos");
                    AnsiConsole.MarkupLine("2. Información personal");
                    AnsiConsole.MarkupLine("3. Mis Compras");
                    AnsiConsole.MarkupLine("4. Cerrar sesión");
                    AnsiConsole.MarkupLine("----------------------------------");
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
                            AnsiConsole.MarkupLine("Tira coo!");
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
                    AnsiConsole.MarkupLine("1. Volver");
                    AnsiConsole.MarkupLine("----------------------------------");
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
                    AnsiConsole.MarkupLine("0. Buscar por género musical");
                    listaEventos
                        .ForEach(e =>
                        {
                            e.listarEventoLinea();
                        });
                    AnsiConsole.MarkupLine(listaEventos.Count + 1 + ". Volver");
                    AnsiConsole.MarkupLine("----------------------------------");
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
                AnsiConsole.MarkupLine("Opciones disponibles: Rock, Flamenco, Pop, Ópera, Musical, Jazz");
                AnsiConsole.MarkupLine("Introduzca género:");
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
                    AnsiConsole.MarkupLine("-------------- Nyxelln't - Eventos de " + stringBusqueda + " --------------");
                    listaEventos.ForEach(e =>
                        {
                            if (e.categoria.ToLower().Equals(stringBusqueda.ToLower()))
                            {
                                e.listarEventoLinea();
                            }
                        });
                    AnsiConsole.MarkupLine("0. Volver");
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
                    AnsiConsole.MarkupLine("-------------- Nyxelln't - Ver Eventos --------------");
                    evento.listarEventoExtendido();
                    AnsiConsole.MarkupLine("----------------------------------");
                    AnsiConsole.MarkupLine("1. Comprar");
                    AnsiConsole.MarkupLine("2. Volver");
                    AnsiConsole.MarkupLine("----------------------------------");
                    opcion = pedirOpcion();
                    if (opcion.Equals(1) && user != null)
                    {
                        AnsiConsole.MarkupLine("¿Cuantas entradas quieres?: ");
                        int entradas = pedirOpcion();
                        if (entradas < 1)
                        {
                            Console
                                .WriteLine("No seas catalán y compra una entrada");
                        }
                        else if (entradas > evento.stock)
                        {
                            AnsiConsole.MarkupLine("¡Onde vas macarenooo! Compra alguna menos, que tas pasao");
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

                            AnsiConsole.MarkupLine("Entrada comprada");
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
                    AnsiConsole.MarkupLine("1. Volver");
                    AnsiConsole.MarkupLine("----------------------------------");
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
