using System;
using Interfaz;
using Rutas;
using FabricaDePersonajes;
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
                                // Lógica para la segunda opción
                                break;
                        }
                        break;
                }

                // Volver a colocar el cursor en la posición inicial para sobreescribir solo las opciones del menú
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);

            } while (tecla != ConsoleKey.Enter);
        }
        public static void MostrarMenuJugadorCentrado()
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
                            case 4:
                                MostrarMenuConTituloCentrado();
                                break;
                                // Lógica para otras opciones
                        }
                        break;
                }

                // Volver a colocar el cursor en la posición inicial para sobreescribir solo las opciones del menú
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);

            } while (tecla != ConsoleKey.Enter);
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
                                Cartel.Introduccion(10, Cartel.Inicio);
                                MenuSeleccionPersonajes();
                                MostrarMenuJugadorCentrado();
                                break;
                            case 1:
                                Cartel.Introduccion(10, Cartel.Inicio);
                                MenuSeleccionPersonajes();
                                MostrarMenuJugadorCentrado();
                                break;
                            case 2:
                                Cartel.Introduccion(10, Cartel.Inicio);
                                MenuSeleccionPersonajes();
                                MostrarMenuJugadorCentrado();
                                break;
                        }
                        break;
                }
                Console.SetCursorPosition(0, Cartel.letraASCII.Length + 2);// Volver a colocar el cursor en la posición inicial para sobreescribir solo las opciones del menú

            } while (tecla != ConsoleKey.Enter);
        }
        public static void MenuSeleccionPersonajes()
        {
            List<CrearPersonajes.Personaje> personajes = CrearPersonaje.LeerPersonajes(@"resources/json/MonstruosDatos.json"); // Leer personajes desde el archivo

            if (personajes.Count == 0)
            {
                Console.WriteLine("No hay personajes disponibles.");
                return;
            }

            // Mostrar menú de selección
            Console.Clear();
            Console.WriteLine("Selecciona un personaje:");
            int opcionSeleccionada = 0;
            int anchoTerminal = Console.WindowWidth;
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
                        CrearPersonajes.Personaje peleador = personajes[opcionSeleccionada];
                        List<CrearPersonajes.Personaje> contrincantes = new List<CrearPersonajes.Personaje>(personajes);
                        contrincantes.RemoveAt(opcionSeleccionada);

                        CrearPersonaje.GuardarPersonajes(new List<CrearPersonajes.Personaje> { peleador }, @"resources/json/Peleador.json");
                        CrearPersonaje.GuardarPersonajes(contrincantes, @"resources/json/Contrincantes.json");
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
    }
}
