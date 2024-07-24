using FabricaDePersonajes;
using System.Collections.Generic;
using System;
using CrearPersonajes;
using Rutas;
using menuSeleccionable;
namespace Combate
{
    public static class Batalla
    {
        public static Random rand = new Random();
        public static void combate()
        {
            int desicionGanandor = 2;
            List<CrearPersonajes.Personaje> Peleador = CrearPersonaje.LeerPersonajes(@"resources\json\Peleador.json");
            List<CrearPersonajes.Personaje> Contrincantes = CrearPersonaje.LeerPersonajes(@"resources\json\Contrincantes.json");
            CrearPersonajes.Personaje peleador = Peleador[0];
            Random rand = new Random();
            CrearPersonajes.Personaje contrincante = Contrincantes[rand.Next(0, Contrincantes.Count)];
            while (Contrincantes.Count != 0)
            {

                while (desicionGanandor != 1 && desicionGanandor != 0)
                {
                    Console.Clear();
                    Console.WriteLine($"{peleador.Informacion.Nombre} vs {contrincante.Informacion.Nombre}");
                    Console.WriteLine($"Vida de {peleador.Informacion.Nombre}: {peleador.Estadisticas.Salud}");
                    Console.WriteLine($"Vida de {contrincante.Informacion.Nombre}: {contrincante.Estadisticas.Salud}");
                    int menu = menuu.MenuDeBatalla();
                    switch (menu)
                    {
                        case 0:
                            Console.WriteLine($"{peleador.Informacion.Nombre} ataca a {contrincante.Informacion.Nombre}");
                            Daño(peleador, contrincante);
                            break;
                        case 1:
                            Console.WriteLine($"{peleador.Informacion.Nombre} se defiende.");
                            Defender(peleador);
                            break;
                    }

                    // Turno del contrincante
                    int accionContrincante = rand.Next(1, 3); // 1 para atacar, 2 para defenderse

                    if (accionContrincante == 1)
                    {
                        Console.WriteLine($"{contrincante.Informacion.Nombre} ataca a {peleador.Informacion.Nombre}");
                        Daño(contrincante, peleador);
                    }
                    else
                    {
                        Console.WriteLine($"{contrincante.Informacion.Nombre} se defiende.");
                        Defender(contrincante);
                    }
                    // Esperar antes del siguiente turno
                    System.Threading.Thread.Sleep(1000);
                    if (peleador.Estadisticas.Salud <= 0)
                    {
                        desicionGanandor = 1;
                    }
                    else
                    {
                        if (contrincante.Estadisticas.Salud <= 0)
                        {
                            desicionGanandor = 0;
                        }
                    }
                }
            }
        }

        public static void Daño(CrearPersonajes.Personaje Peleador, CrearPersonajes.Personaje Contrincante)
        {
            int ataque = Peleador.Estadisticas.Fuerza * Peleador.Estadisticas.Destreza * Peleador.Estadisticas.Nivel;
            int defensa = Contrincante.Estadisticas.Armadura * Contrincante.Estadisticas.Velocidad;
            int Efectividad = rand.Next(1, 100);
            int constanteDeAjuste = 500;
            float danioprovocado = Math.Abs(((ataque * Efectividad) - defensa) / constanteDeAjuste);
            Console.WriteLine($"Danio Realizado {danioprovocado}");
            Contrincante.Estadisticas.Salud -= danioprovocado;
        }
        private static void Defender(CrearPersonajes.Personaje defensor)
        {
            // Aquí puedes implementar la lógica de defensa
            defensor.Estadisticas.Armadura += 2; // Ejemplo: aumentar temporalmente la armadura
            Console.WriteLine($"{defensor.Informacion.Nombre} ha aumentado su armadura temporalmente.");
        }
    }
}

