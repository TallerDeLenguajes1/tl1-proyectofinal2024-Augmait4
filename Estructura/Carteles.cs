using System;
using System.Security.Cryptography.X509Certificates;
using menuSeleccionable;
namespace Interfaz
{
    public static class Cartel
    {
        public static void LimpiarBuffer()
        {
            // Limpio el buffer para evitar bugs con las teclas que haya presionado el usuario durante el período de sleep
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
        public static void TextoTiempo(string texto, int milisegundos, int tipo)
        {   //Uso el tipo para indicar si quiero que sea un texto con salto de linea (1) o sin salto de linea (0)
            if (tipo == 1) //pregunto antes de realizar el foreach para no hacer un mal uso de la memoria, ya que si fuera adentro el programa haria muchas comparaciones innecesarias
            {
                foreach (char c in texto)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(intercept: true).Key;
                        if (key == ConsoleKey.Spacebar || key == ConsoleKey.Enter)
                        {
                            return;
                        }
                    }
                    Console.Write(c);
                    Thread.Sleep(milisegundos);
                    LimpiarBuffer();
                }
                Console.WriteLine();
            }
            else if (tipo == 0)
            {
                foreach (char c in texto)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(intercept: true).Key;
                        if (key == ConsoleKey.Spacebar || key == ConsoleKey.Enter)
                        {
                            return;
                        }
                    }
                    Console.Write(c);
                    Thread.Sleep(milisegundos);
                    LimpiarBuffer();
                }
            }
            else
            {
                Console.WriteLine("Ingresó un tipo equivocado de texto");
            }
        }
        public static string[] letraASCII = new string[]
        {
            @"██╗  ██╗██╗███╗   ██╗ ██████╗",
            @"██║ ██╔╝██║████╗  ██║██╔════╝",
            @"█████╔╝ ██║██╔██╗ ██║██║  ███╗",
            @"██╔═██╗ ██║██║╚██╗██║██║   ██║",
            @"██║  ██╗██║██║ ╚████║╚██████╔╝",
            @"╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝ ╚═════╝ ",
            @"      ██████╗ ███████╗",
            @"     ██╔═══██╗██╔════╝",
            @"     ██║   ██║█████╗  ",
            @"     ██║   ██║██╔══╝  ",
            @"╚██████╔╝██║",
            @" ╚═════╝ ╚═╝",
            @"████████╗██╗  ██╗███████╗",
            @"╚══██╔══╝██║  ██║██╔════╝",
            @"   ██║   ███████║█████╗  ",
            @"   ██║   ██╔══██║██╔══╝  ",
            @"   ██║   ██║  ██║███████╗",
            @"   ╚═╝   ╚═╝  ╚═╝╚══════╝",
            @"███╗   ███╗ ██████╗ ███╗   ██╗███████╗████████╗███████╗██████╗ ███████╗",
            @"████╗ ████║██╔═══██╗████╗  ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗██╔════╝",
            @"██╔████╔██║██║   ██║██╔██╗ ██║███████╗   ██║   █████╗  ██████╔╝███████╗ ",
            @"██║╚██╔╝██║██║   ██║██║╚██╗██║╔═══╝██║   ██║   ██╔══╝  ██╔══██╗╔═══╝██║ ",
            @"██║ ╚═╝ ██║╚██████╔╝██║ ╚████║███████║   ██║   ███████╗██║  ██║███████║",
            @"╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚══════╝"
        };
        public static string[] Inicio = new string[]{
                @"╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗",
                @"║              En la era de los titanes, donde la humanidad ha quedado a la sombra de colosos descomunales,                        ║",
                @"║                          solo el más poderoso puede reclamar el título de Rey de los Monstruos.                                  ║",
                @"║                        Tu viaje comienza en un mundo arrasado por la furia de criaturas colosales,                               ║",
                @"║                            donde cada paso y cada batalla te acercarán más al trono supremo.                                     ║",
                @"║               Forja tu destino, conquista territorios y desafía a los gigantes que se interponen en tu camino                    ║",
                @"║La batalla por la supremacía ha comenzado; demuestra que eres el único digno de ser el soberano de esta era de caos y destrucción.║",
                @"╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝"
        };
        public static void TituloJuego(int tiempo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            int anchoTerminal = Console.WindowWidth;
            string centrado = "";

            foreach (string linea in letraASCII)
            {
                int padding = (anchoTerminal - linea.Length) / 2;
                string lineaCentrada = new string(' ', padding) + linea + Environment.NewLine;

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    if (key == ConsoleKey.Spacebar || key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break;
                    }
                }

                centrado += lineaCentrada;
            }

            TextoTiempo(centrado, tiempo, 1); // Mostrar el texto con o sin animación
        }
        public static void TituloJuegoRapido(int tiempo, string[] Cartel)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            int anchoTerminal = Console.WindowWidth;
            string centrado = "";

            foreach (string linea in Cartel)
            {
                int padding = (anchoTerminal - linea.Length) / 2;
                string lineaCentrada = new string(' ', padding) + linea + Environment.NewLine;
                centrado += lineaCentrada;
            }

            Console.Write(centrado); // Mostrar el título completo sin animación
        }
        public static int Introduccion(int tiempo, string[] Cartel)
        {
            int eleccion = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            int anchoTerminal = Console.WindowWidth;
            string centrado = "";

            foreach (string linea in Cartel)
            {
                int padding = (anchoTerminal - linea.Length) / 2;
                string lineaCentrada = new string(' ', padding) + linea + Environment.NewLine;

                centrado += lineaCentrada;
            }

            TextoTiempo(centrado, tiempo, 1);

            // Verificar si se presionó una tecla
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    if (key == ConsoleKey.Spacebar || key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        // Mostrar el cartel completo antes de borrar la pantalla
                        Console.WriteLine(centrado);
                        // Esperar un breve momento para que el usuario pueda ver el cartel completo
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        eleccion = 1;
                        return eleccion;
                    }
                }
            }
        }
    }
}
