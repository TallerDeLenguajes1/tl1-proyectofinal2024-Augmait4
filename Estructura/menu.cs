using System;
using Interfaz;
using Rutas;
using Combate;
using FabricaDePersonajes;
using CrearPersonajes;
namespace menuSeleccionable
{
    public static class menuu
    {
        public static void menu()
        {
            MostrarMenuConTituloCentrado();
        }

        public static void MostrarMenuConTituloCentrado()
        {
            MostrarMenuCentrado();
        }

        public static void MostrarMenuCentrado()
        {
            int opcionSeleccionada = 0;
            int anchoTerminal = Console.WindowWidth;
            // Mostrar el título una sola vez
            Console.Clear();
            Cartel.TituloJuegoRapido(0, Cartel.letraASCII);
            Console.ResetColor();
            ConsoleKey tecla;
            do
            {
                // Posicionar el cursor donde comienza el menú para no recargar el título
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);

                for (int i = 0; i < Ruta.menuInicial.Length; i++)
                {
                    string opcion = Ruta.menuInicial[i];
                    int padding = (anchoTerminal - opcion.Length) / 2;
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(new string(' ', padding) + ">> " + opcion);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(new string(' ', padding) + "   " + opcion);
                    }
                }

                tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        opcionSeleccionada = (opcionSeleccionada == 0) ? Ruta.menuInicial.Length - 1 : opcionSeleccionada - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        opcionSeleccionada = (opcionSeleccionada == Ruta.menuInicial.Length - 1) ? 0 : opcionSeleccionada + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (opcionSeleccionada)
                        {
                            case 0:
                                MostrarDificultad();
                                break;
                            case 1:
                            List<CrearPersonajes.Personaje> ganadores = CrearPersonaje.LeerPersonajes(@"resources\json\Ganadores.json");
                            Cartel.MostrarGanadores(ganadores);
                                break;
                            case 2:
                                break;
                        }
                        break;
                }
                // Volver a colocar el cursor en la posición inicial para sobreescribir solo las opciones del menú
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);
            } while (tecla != ConsoleKey.Enter);
        }
        public static int MostrarMenuJugadorCentrado()
        {
            int opcionSeleccionada = 0;
            int anchoTerminal = Console.WindowWidth;

            // Mostrar el título una sola vez
            Console.Clear();
            Cartel.TituloJuegoRapido(0, Cartel.letraASCII); // Mostrar el título sin animación
            Console.ResetColor();
            ConsoleKey tecla;
            do
            {
                // Posicionar el cursor donde comienza el menú para no recargar el título
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);

                for (int i = 0; i < Ruta.menuJugador.Length; i++)
                {
                    string opcion = Ruta.menuJugador[i];
                    int padding = (anchoTerminal - opcion.Length) / 2;
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(new string(' ', padding) + ">> " + opcion);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(new string(' ', padding) + "   " + opcion);
                    }
                }

                tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        opcionSeleccionada = (opcionSeleccionada == 0) ? Ruta.menuJugador.Length - 1 : opcionSeleccionada - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        opcionSeleccionada = (opcionSeleccionada == Ruta.menuJugador.Length - 1) ? 0 : opcionSeleccionada + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (opcionSeleccionada)
                        {
                            case 0:
                                return 0;
                            case 1:
                                return 1;
                            case 2:
                                return 2;
                            case 3:
                                return 3;
                            default:
                                MostrarMenuConTituloCentrado();
                                return 4;
                        }
                }
                // Volver a colocar el cursor en la posición inicial para sobreescribir solo las opciones del menú
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);

            } while (tecla != ConsoleKey.Enter);
            return 9999;
        }
        public static void MostrarDificultad()
        {
            int opcionSeleccionada = 0;
            int anchoTerminal = Console.WindowWidth;
            Console.Clear();
            Cartel.TituloJuegoRapido(0, Cartel.letraASCII); // Mostrar el título sin animación
            Console.ResetColor();
            ConsoleKey tecla;
            do
            {
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);// Posicionar el cursor donde comienza el menú para no recargar el título

                for (int i = 0; i < Ruta.Dificultad.Length; i++)
                {
                    string opcion = Ruta.Dificultad[i];
                    int padding = (anchoTerminal - opcion.Length) / 2;
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(new string(' ', padding) + ">> " + opcion);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(new string(' ', padding) + "   " + opcion);
                    }
                }

                tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        opcionSeleccionada = (opcionSeleccionada == 0) ? Ruta.Dificultad.Length - 1 : opcionSeleccionada - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        opcionSeleccionada = (opcionSeleccionada == Ruta.Dificultad.Length - 1) ? 0 : opcionSeleccionada + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (opcionSeleccionada)
                        {
                            case 0:
                                CrearPersonaje.GenerarPersonajes(4);
                                Console.WriteLine("Manten Presionada la Barra Espaciadora para Saltar la Animacion....");
                                Thread.Sleep(3000);
                                Cartel.Introduccion(10, Cartel.Inicio);
                                MenuSeleccionPersonajes();
                                break;
                            case 1:
                                CrearPersonaje.GenerarPersonajes(6);
                                Console.WriteLine("Manten Presionada la Barra Espaciadora para Saltar la Animacion....");
                                Thread.Sleep(3000);
                                Cartel.Introduccion(10, Cartel.Inicio);
                                MenuSeleccionPersonajes();
                                break;
                            case 2:
                                CrearPersonaje.GenerarPersonajes(8);
                                Console.WriteLine("Manten Presionada la Barra Espaciadora para Saltar la Animacion....");
                                Thread.Sleep(3000);
                                Cartel.Introduccion(10, Cartel.Inicio);
                                MenuSeleccionPersonajes();
                                break;
                        }
                        break;
                }
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);// Volver a colocar el cursor en la posición inicial para sobreescribir solo las opciones del menú

            } while (tecla != ConsoleKey.Enter);
        }
        public static void MenuSeleccionPersonajes()
        {
            List<CrearPersonajes.Personaje> personajes = CrearPersonaje.LeerPersonajes(Ruta.rutaArchivosJson[0]); // Leer personajes desde el archivo

            if (personajes.Count == 0)
            {
                Console.WriteLine("No hay personajes disponibles.");
                return;
            }

            // Mostrar menú de selección
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            int opcionSeleccionada = 0;
            string Encabezado = "Selecciona un personaje:";
            int anchoTerminal = Console.WindowWidth;
            int padding2 = (anchoTerminal - Encabezado.Length) / 2;
            Console.WriteLine(new string(' ', padding2) + Encabezado);
            Console.ResetColor();
            ConsoleKey tecla;
            do
            {
                // Limpiar las opciones del menú antes de redibujarlas
                Console.SetCursorPosition(0, 1);
                for (int i = 0; i < personajes.Count; i++)
                {
                    string opcion = personajes[i].Informacion.Nombre;
                    int padding = (anchoTerminal - opcion.Length) / 2;
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(new string(' ', padding) + ">> " + opcion);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(new string(' ', padding) + "   " + opcion);
                    }
                }

                tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        opcionSeleccionada = (opcionSeleccionada == 0) ? personajes.Count - 1 : opcionSeleccionada - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        opcionSeleccionada = (opcionSeleccionada == personajes.Count - 1) ? 0 : opcionSeleccionada + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        // Guardar personaje seleccionado y los restantes
                        CrearPersonaje.CrearLuchadores(personajes, opcionSeleccionada);
                        Batalla.combate();
                        break;
                }

                // Limpiar la consola después de cada interacción
                Console.SetCursorPosition(0, 1);
                for (int i = 1; i <= personajes.Count; i++)
                {
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, i);
                }

            } while (tecla != ConsoleKey.Enter);
        }
        public static int MostrarMenuAumentoEstadisticas(CrearPersonajes.Personaje peleador, int puntosAumento)
        {
            int opcionSeleccionada = 0;
            int anchoTerminal = Console.WindowWidth;
            Console.Clear();
            Cartel.VisordeVidaPelador(peleador);
            Console.ResetColor();
            ConsoleKey tecla;
            do
            {
                // Posicionar el cursor donde comienza el menú para no recargar el título
                Console.SetCursorPosition(0, 12);
                string Encabezado = $"Puntos Disponibles:{puntosAumento}";
                int padding2 = (anchoTerminal - Encabezado.Length) / 2;
                Console.WriteLine(new string(' ', padding2) + Encabezado);
                for (int i = 0; i < Ruta.MenuEstadisticas.Length; i++)
                {
                    string opcion = Ruta.MenuEstadisticas[i];
                    int padding = (anchoTerminal - opcion.Length) / 2;
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(new string(' ', padding) + ">> " + opcion);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(new string(' ', padding) + "   " + opcion);
                    }
                }

                tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        opcionSeleccionada = (opcionSeleccionada == 0) ? Ruta.MenuEstadisticas.Length - 1 : opcionSeleccionada - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        opcionSeleccionada = (opcionSeleccionada == Ruta.MenuEstadisticas.Length - 1) ? 0 : opcionSeleccionada + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (opcionSeleccionada)
                        {
                            case 0:
                                return 0;
                            case 1:
                                return 1;
                            case 2:
                                return 2;
                            case 3:
                                return 3;
                            case 4:
                                return 4;
                        }
                        break;
                }
                // Volver a colocar el cursor en la posición inicial para sobreescribir solo las opciones del menú
                Console.SetCursorPosition(0, 12);

            } while (tecla != ConsoleKey.Enter);
            return 9999;
        }
        public static int MenuDeBatalla()
        {
            int opcionSeleccionada = 0;
            int anchoTerminal = Console.WindowWidth;
            Console.ResetColor();
            ConsoleKey tecla;
            do
            {
                // Limpiar las opciones del menú antes de redibujarlas
                Console.SetCursorPosition(0, 17);
                for (int i = 0; i < Ruta.MenuDeBatalla.Length; i++)
                {
                    string opcion = Ruta.MenuDeBatalla[i];
                    int padding = (anchoTerminal - opcion.Length) / 2;
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(new string(' ', padding) + ">> " + opcion);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(new string(' ', padding) + "   " + opcion);
                    }
                }

                tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        opcionSeleccionada = (opcionSeleccionada == 0) ? Ruta.MenuDeBatalla.Length - 1 : opcionSeleccionada - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        opcionSeleccionada = (opcionSeleccionada == Ruta.MenuDeBatalla.Length - 1) ? 0 : opcionSeleccionada + 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (opcionSeleccionada)
                        {
                            case 0:
                                return 0;

                            case 1:
                                return 1;

                            case 2:
                                return 2;
                        }
                        break;
                }

                // Limpiar la consola después de cada interacción
                Console.SetCursorPosition(0, 17);
                for (int i = 1; i <= Ruta.MenuDeBatalla.Length; i++)
                {
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, i + 17);
                }

            } while (tecla != ConsoleKey.Enter);
            return 3;
        }
    }
}
