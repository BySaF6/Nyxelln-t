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
                    AnsiConsole.MarkupLine("[bold #27B2F8]--------------[/] [bold #27B2F8]Nyxelln't[/] [bold #27B2F8]--------------[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]1.[/] [bold white]Iniciar sesión[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]2.[/] [bold white]Registrarse[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]3.[/] [bold white]Ver Eventos[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]4.[/] [bold white]Salir[/]");
                    AnsiConsole.MarkupLine("[bold #27B2F8]---------------------------------------[/]");
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
                            AnsiConsole.MarkupLine("[bold #13D7F6]Hasta el huevo, vuelve pronto[/]");
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
                AnsiConsole.MarkupLine("[bold #13D7F6]Nombre: [/]");
                String nombre = Console.ReadLine();
                AnsiConsole.MarkupLine("[bold #13D7F6]Apellido: [/]");
                String apellido = Console.ReadLine();
                AnsiConsole.MarkupLine("[bold #13D7F6]Email: [/]");

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
                                AnsiConsole.MarkupLine("[bold #FC0206]Ese email ya esta registrado, vuelva a escribirlo[/]");
                            }
                        });
                }
                while (usuarioRepetido == true);

                AnsiConsole.MarkupLine("[bold #13D7F6]Constraseña: [/]");
                String password = Console.ReadLine();
                AnsiConsole.MarkupLine("[bold green]Cuenta creada con exito.[/]");
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
                AnsiConsole.MarkupLine("[bold #13D7F6]Email: [/]");
                String email = Console.ReadLine();
                AnsiConsole.MarkupLine("[bold #13D7F6]Constraseña: [/]");
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
                            AnsiConsole.MarkupLine("[bold green]Sesión iniciada con éxito[/]");
                        }
                    });
                if (user == null)
                {
                    AnsiConsole.MarkupLine("[bold #FC0206]No estas registrado[/]");
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
                    AnsiConsole.MarkupLine("[bold #27B2F8]------- Nyxelln't - [/]" + user.nombre + " [bold #27B2F8]--------[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]1.[/] [bold white]Ver Eventos[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]2.[/] [bold white]Información personal[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]3.[/] [bold white]Mis Compras[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]4.[/] [bold white]Cerrar sesión[/]");
                    AnsiConsole.MarkupLine("[bold #27B2F8]----------------------------------[/]");
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
                            AnsiConsole.MarkupLine("[bold #13D7F6]Tira coo![/]");
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
                    AnsiConsole.MarkupLine("[bold #27B2F8]----- Nyxelln't - Mi Cuenta ------[/]");
                    user.listarInformacionUsuario();
                    AnsiConsole.MarkupLine("[bold #13D7F6]1.[/] [bold white]Volver[/]");
                    AnsiConsole.MarkupLine("[bold #27B2F8]----------------------------------[/]");
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
                    AnsiConsole.MarkupLine("[bold #27B2F8]------------------------------------------------------------- Nyxelln't - Ver Eventos --------------------------------------------------------------------------[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]0.[/] [bold white]Buscar por género musical[/]");
                    listaEventos
                        .ForEach(e =>
                        {
                            e.listarEventoLinea();
                        });
                    AnsiConsole.MarkupLine(listaEventos.Count + 1 + ". [bold white]Volver[/]");
                    AnsiConsole.MarkupLine("[bold #27B2F8]-----------------------------------------------------------------------------------------------------------------------------------------------------------------[/]");
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
                AnsiConsole.MarkupLine("[bold #27B2F8]---------------- Nyxelln't - Buscador de Eventos ----------------[/]");
                AnsiConsole.MarkupLine("[bold #13D7F6]Opciones disponibles:[/] [bold white]Rock, Flamenco, Pop, Ópera, Musical, Jazz[/]");
                AnsiConsole.MarkupLine("[bold #13D7F6]Introduzca género:[/]");
                AnsiConsole.MarkupLine("[bold #27B2F8]-----------------------------------------------------------------[/]");
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
                    AnsiConsole.MarkupLine("[bold #27B2F8]---------------------------------------------------- Nyxelln't - Eventos de [/]" + stringBusqueda + " [bold #27B2F8]----------------------------------------------------[/]");
                    listaEventos.ForEach(e =>
                        {
                            if (e.categoria.ToLower().Equals(stringBusqueda.ToLower()))
                            {
                                e.listarEventoLinea();
                            }
                        });
                    AnsiConsole.MarkupLine("[bold #13D7F6]0.[/] [bold white]Volver[/]");
                    AnsiConsole.MarkupLine("[bold #27B2F8]------------------------------------------------------------------------------------------------------------------------------------[/]");
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
                    AnsiConsole.MarkupLine("[bold #27B2F8]------------------------ Nyxelln't - Ver Eventos -------------------------[/]");
                    evento.listarEventoExtendido();
                    AnsiConsole.MarkupLine("[bold #27B2F8]--------------------------------------------------------------------------[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]1.[/] [bold white]Comprar[/]");
                    AnsiConsole.MarkupLine("[bold #13D7F6]2.[/] [bold white]Volver[/]");
                    AnsiConsole.MarkupLine("[bold #27B2F8]--------------------------------------------------------------------------[/]");
                    opcion = pedirOpcion();
                    if (opcion.Equals(1) && user != null)
                    {
                        AnsiConsole.MarkupLine("[bold #13D7F6]¿Cuantas entradas quieres?: [/]");
                        int entradas = pedirOpcion();
                        if (entradas < 1)
                        {
                            AnsiConsole.MarkupLine("[bold #FC0206]No seas catalán y compra una entrada[/]");
                        }
                        else if (entradas > evento.stock)
                        {
                            AnsiConsole.MarkupLine("[bold #FC0206]¡Onde vas macarenooo! Compra alguna menos, que tas pasao[/]");
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
                        AnsiConsole.MarkupLine("[bold #FC0206]Inicia sesión para poder comprar entradas[/]");
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
                    AnsiConsole.MarkupLine("[bold #27B2F8]-------------- Nyxelln't - Mis Compras --------------[/]");
                    user
                        .eventosComprados
                        .ForEach(e =>
                        {
                            e.mostrarOperacion();
                        });
                    AnsiConsole.MarkupLine("[bold #13D7F6]1.[/] [bold white]Volver[/]");
                    AnsiConsole.MarkupLine("[bold #27B2F8]-----------------------------------------------------[/]");
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
