using System;
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
                    Console.Write(c);
                    Thread.Sleep(milisegundos / texto.Length);
                    LimpiarBuffer();
                }
                Console.WriteLine();
            }
            else if (tipo == 0)
            {
                foreach (char c in texto)
                {
                    Console.Write(c);
                    Thread.Sleep(milisegundos / texto.Length);
                    LimpiarBuffer();
                }
            }
            else
            {
                Console.WriteLine("Ingresó un tipo equivocado de texto");
            }
        }
        public static void TituloJuego(int tiempo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string[] letraASCII = [
@"██╗  ██╗██╗███╗   ██╗ ██████╗",
@"██║ ██╔╝██║████╗  ██║██╔════╝",
@"█████╔╝ ██║██╔██╗ ██║██║  ███╗",
@"██╔═██╗ ██║██║╚██╗██║██║   ██║",
@"██║  ██╗██║██║ ╚████║╚██████╔╝",
@"╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝ ╚═════╝ ",
@"      ██████╗ ███████╗",
@"      ██╔═══██╗██╔════╝",
@"      ██║   ██║█████╗  ",
@"      ██║   ██║██╔══╝  ",
@" ╚██████╔╝██║",
@"  ╚═════╝ ╚═╝",
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
@"╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚══════╝",
    ];

            int anchoTerminal = Console.WindowWidth;
            string centrado = "";

            foreach (string linea in letraASCII)
            {
                int padding = (anchoTerminal - linea.Length) / 2;
                centrado += new string(' ', padding) + linea + Environment.NewLine; //Enviroment.NewLine remplaza el uso de \r y \n y permite compatibilidad con distintos sistemas operativos
            }
            TextoTiempo(centrado, tiempo, 1);
        }
    }
}
