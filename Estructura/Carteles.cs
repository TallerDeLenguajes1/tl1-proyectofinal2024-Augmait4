using System;
using System.Security.Cryptography.X509Certificates;
using menuSeleccionable;
using FabricaDePersonajes;
using Combate;
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
        public static void VisordeVida(CrearPersonajes.Personaje peleador, CrearPersonajes.Personaje contrincante)
        {
            Console.Clear();
            string[] cartel = new string[]
            {
        "╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗",
        $"║  Nombre: {peleador.Informacion.Nombre.PadRight(43)}     ║  Nombre: {contrincante.Informacion.Nombre.PadLeft(43)}                   ║",
        "║══════════════════════════════════════════════════════════╬════════════════════════════════════════════════════════════════════════║",
        $"║  Salud: {peleador.Estadisticas.Salud.ToString().PadRight(44)}     ║  Salud: {contrincante.Estadisticas.Salud.ToString().PadLeft(44)}                   ║",
        $"║  Velocidad: {peleador.Estadisticas.Velocidad.ToString().PadRight(39)}      ║  Velocidad: {contrincante.Estadisticas.Velocidad.ToString().PadLeft(39)}                    ║",
        $"║  Destreza: {peleador.Estadisticas.Destreza.ToString().PadRight(40)}      ║  Destreza: {contrincante.Estadisticas.Destreza.ToString().PadLeft(40)}                    ║",
        $"║  Fuerza: {peleador.Estadisticas.Fuerza.ToString().PadRight(42)}      ║  Fuerza: {contrincante.Estadisticas.Fuerza.ToString().PadLeft(42)}                    ║",
        $"║  Nivel: {peleador.Estadisticas.Nivel.ToString().PadRight(43)}      ║  Nivel: {contrincante.Estadisticas.Nivel.ToString().PadLeft(43)}                    ║",
        $"║  Armadura: {peleador.Estadisticas.Armadura.ToString().PadRight(40)}      ║  Armadura: {contrincante.Estadisticas.Armadura.ToString().PadLeft(40)}                    ║",
        "╚══════════════════════════════════════════════════════════╩════════════════════════════════════════════════════════════════════════╝"
            };
            int anchoTerminal = Console.WindowWidth;
            foreach (string linea in cartel)
            {
                int padding = (anchoTerminal - linea.Length) / 2;
                if (padding > 0)
                {
                    Console.WriteLine(new string(' ', padding) + linea);
                }
                else
                {
                    Console.WriteLine(linea);
                }
            }
        }
        public static void VisordeVidaPelador(CrearPersonajes.Personaje peleador)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string[] cartel = new string[]
            {
        "╔══════════════════════════════════════════════════════════╗",
        $"║  Nombre: {peleador.Informacion.Nombre.PadRight(43)}     ║",
        "║══════════════════════════════════════════════════════════║",
        $"║  Salud: {peleador.Estadisticas.Salud.ToString().PadRight(44)}     ║",
        $"║  Velocidad: {peleador.Estadisticas.Velocidad.ToString().PadRight(39)}      ║",
        $"║  Destreza: {peleador.Estadisticas.Destreza.ToString().PadRight(40)}      ║",
        $"║  Fuerza: {peleador.Estadisticas.Fuerza.ToString().PadRight(42)}      ║",
        $"║  Nivel: {peleador.Estadisticas.Nivel.ToString().PadRight(43)}      ║",
        $"║  Armadura: {peleador.Estadisticas.Armadura.ToString().PadRight(40)}      ║",
        "╚══════════════════════════════════════════════════════════╝"
            };
            int anchoTerminal = Console.WindowWidth;
            foreach (string linea in cartel)
            {
                int padding = (anchoTerminal - linea.Length) / 2;
                if (padding > 0)
                {
                    Console.WriteLine(new string(' ', padding) + linea);
                }
                else
                {
                    Console.WriteLine(linea);
                }
            }
        }
                public static void VisordeVidaRival(CrearPersonajes.Personaje contrincante)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string[] cartel = new string[]
            {
        "╔══════════════════════════════════════════════════════════════════════════╗",
        $"║  Nombre: {contrincante.Informacion.Nombre.PadLeft(43)}                   ║",
        "║════════════════════════════════════════════════════════════════════════║",
        $"║  Salud: {contrincante.Estadisticas.Salud.ToString().PadLeft(44)}                   ║",
        $"║  Velocidad: {contrincante.Estadisticas.Velocidad.ToString().PadLeft(39)}                    ║",
        $"║  Destreza: {contrincante.Estadisticas.Destreza.ToString().PadLeft(40)}                    ║",
        $"║  Fuerza: {contrincante.Estadisticas.Fuerza.ToString().PadLeft(42)}                    ║",
        $"║  Nivel: {contrincante.Estadisticas.Nivel.ToString().PadLeft(43)}                    ║",
        $"║  Armadura: {contrincante.Estadisticas.Armadura.ToString().PadLeft(40)}                    ║",
        "╚══════════════════════════════════════════════════════════════════════════╝"
            };
            int anchoTerminal = Console.WindowWidth;
            foreach (string linea in cartel)
            {
                int padding = (anchoTerminal - linea.Length) / 2;
                if (padding > 0)
                {
                    Console.WriteLine(new string(' ', padding) + linea);
                }
                else
                {
                    Console.WriteLine(linea);
                }
            }
        }
    }
}
