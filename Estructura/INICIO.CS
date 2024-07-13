using System;
namespace Interfaz
{
    class Cartel
    {
        static void Main()
        {
            string[] cyberpunkArt = new string[]
            {
            @" ____ __      __  ____     ____   _____    _____   _    _   __     _   __   __ ",
            @"|  __|\ \    / / |  _  \  |  __| |  _  |  |  _  | | |  | | |   \  | | |  | / / ",
            @"| |    \ \  / /  | |_) /  | |__  | |_) |  | |_) | | |  | | | |\ \ | | |  |/ / ",
            @"| |     \ \/ /   |  _ <   |  __| |     |  |   __| | |  | | | | \ \| | |    / ",
            @"| |__    |  |    | |_) \  | |__  | | \ \  |  |    | |__| | | |  \   | |  |\ \ ",
            @"|____|   |__|    |_____/  |____| |_|  \_\ |__|    |______| |_|   \__| |__| \_\ ",
            @" ",
            };

            foreach (string line in cyberpunkArt)
            {
                Console.WriteLine(line);
            }
        }
    }
}
