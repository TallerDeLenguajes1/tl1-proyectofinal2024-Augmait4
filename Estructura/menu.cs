using System;
using Interfaz; 

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
            Cartel.TituloJuego(10); // Mostrar el título con animación
            MostrarMenuCentrado();
        }

        public static void MostrarMenuCentrado()
        {
            string[] opciones = { "Jugar", "Opciones", "Salir" };
            int opcionSeleccionada = 0;
            int anchoTerminal = Console.WindowWidth;

            ConsoleKey tecla;
            do
            {
                Console.Clear();
                Cartel.TituloJuego(0);  // Mostrar el título sin animación

                for (int i = 0; i < opciones.Length; i++)
                {
                    string opcion = opciones[i];
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

                tecla = Console.ReadKey().Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        opcionSeleccionada = (opcionSeleccionada == 0) ? opciones.Length - 1 : opcionSeleccionada - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        opcionSeleccionada = (opcionSeleccionada == opciones.Length - 1) ? 0 : opcionSeleccionada + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("Has seleccionado: " + opciones[opcionSeleccionada]);
                        // Lógica para la opción seleccionada
                        break;
                }

            } while (tecla != ConsoleKey.Enter);
        }
    }
}
