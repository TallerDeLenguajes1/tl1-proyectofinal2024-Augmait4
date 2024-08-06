using FabricaDePersonajes;
using System.Collections.Generic;
using System;
using CrearPersonajes;
using Rutas;
using menuSeleccionable;
using Interfaz;
namespace Combate
{
    public static class Batalla
    {
        public static Random rand = new Random();
        public static void combate()
        {
            int desicionGanandor = 2;
            int cont = 1;
            List<CrearPersonajes.Personaje> Peleador = CrearPersonaje.LeerPersonajes(@"resources\json\Peleador.json");
            List<CrearPersonajes.Personaje> Contrincantes = CrearPersonaje.LeerPersonajes(@"resources\json\Contrincantes.json");
            CrearPersonajes.Personaje peleador = Peleador[0];
            Random rand = new Random();
            CrearPersonajes.Personaje contrincante = Contrincantes[rand.Next(0, Contrincantes.Count)];
            while (Contrincantes.Count != 0)
            {
                int desicionDeMenu = menuu.MostrarMenuJugadorCentrado();
                switch (desicionDeMenu)
                {
                    case 0:
                        desicionGanandor = Luchar(desicionGanandor, peleador, contrincante);
                        break;
                    case 1:
                        Cartel.VisordeVidaRival(contrincante);
                        Console.WriteLine("Apretar cualquier tecla para volver al Menu .....");
                        Console.ReadKey();
                        break;
                    case 2:
                        Cartel.VisordeVidaPelador(peleador);
                        Console.WriteLine("Apretar cualquier tecla para volver al Menu .....");
                        Console.ReadKey();
                        break;
                    case 3:
                        break;
                    case 4:
                        menuu.MostrarMenuConTituloCentrado();
                        break;
                }
                if (desicionGanandor == 0)
                {
                    Console.WriteLine($"{peleador.Informacion.Nombre} ha ganado el combate.");
                    Contrincantes.Remove(contrincante); // Eliminar el contrincante derrotado
                    if (Contrincantes.Count > 0)
                    {
                        contrincante = Contrincantes[rand.Next(0, Contrincantes.Count)];
                        cont++;
                        MejoraRival(contrincante, Contrincantes, cont);
                        peleador.Estadisticas.Salud = 100; // Restaurar salud del peleador
                        desicionGanandor = 2;
                    }
                    Thread.Sleep(1000);
                }
                else if (desicionGanandor == 1)
                {
                    Console.WriteLine($"{peleador.Informacion.Nombre} ha sido derrotado.");
                    Thread.Sleep(1000);
                    // Salir del bucle si el peleador es derrotado
                    break;
                }

            }

            ComprobarDerrotaVictoria(peleador, Contrincantes);
        }

        private static int Luchar(int desicionGanandor, Personaje peleador, Personaje contrincante)
        {
            while (desicionGanandor != 1 && desicionGanandor != 0)
            {
                Console.Clear();
                Cartel.VisordeVida(peleador, contrincante);
                int menu = menuu.MenuDeBatalla();
                switch (menu)
                {
                    case 0:
                        Console.WriteLine($"{peleador.Informacion.Nombre} ataca a {contrincante.Informacion.Nombre}");
                        Daño(peleador, contrincante);
                        Thread.Sleep(1000);
                        break;
                    case 1:
                        Console.WriteLine($"{peleador.Informacion.Nombre} se defiende.");
                        Defender(peleador);
                        Thread.Sleep(1000);
                        break;
                }

                if (contrincante.Estadisticas.Salud <= 0)
                {
                    desicionGanandor = 0;
                    break;
                }
                razonamientoIA(peleador, contrincante);
                if (peleador.Estadisticas.Salud <= 0)
                {
                    desicionGanandor = 1;
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }
            return desicionGanandor;
        }

        public static void MejoraRival(CrearPersonajes.Personaje contrincante, List<CrearPersonajes.Personaje> Rivales, int cont)
        {
            float AumentoDeNivel = (cont * 80) / 100;
            contrincante.Estadisticas.Armadura = contrincante.Estadisticas.Armadura * AumentoDeNivel;
            contrincante.Estadisticas.Destreza = contrincante.Estadisticas.Destreza * AumentoDeNivel;
            contrincante.Estadisticas.Fuerza = contrincante.Estadisticas.Fuerza * AumentoDeNivel;
            contrincante.Estadisticas.Velocidad = contrincante.Estadisticas.Velocidad * AumentoDeNivel;
            contrincante.Estadisticas.Nivel = cont;
        }
        public static void ComprobarDerrotaVictoria(CrearPersonajes.Personaje luchador, List<CrearPersonajes.Personaje> Rivales)
        {
            if (Rivales.Count == 0)
            {
                Console.WriteLine($"{luchador.Informacion.Nombre} ha derrotado a todos los contrincantes.");
                List<CrearPersonajes.Personaje> ganadores = new List<CrearPersonajes.Personaje>();
                try
                {
                    ganadores = CrearPersonaje.LeerPersonajes(@"resources\json/Ganadores.json");
                }
                catch (Exception ex)
                {
                    // Si el archivo no existe o hay otro problema, inicializar una nueva lista
                    Console.WriteLine("No se pudo leer el archivo de ganadores existentes: " + ex.Message);
                }
                ganadores.Add(luchador);
                CrearPersonaje.GuardarPersonajes(ganadores, @"resources/json/Ganadores.json");
            }
        }
        public static void razonamientoIA(CrearPersonajes.Personaje Peleador, CrearPersonajes.Personaje Contrincante)
        {
            int accionContrincante = rand.Next(1, 3);

            if (accionContrincante == 1)
            {
                Console.WriteLine($"{Contrincante.Informacion.Nombre} ataca a {Peleador.Informacion.Nombre}");
                Daño(Contrincante, Peleador);
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"{Contrincante.Informacion.Nombre} se defiende.");
                Defender(Contrincante);
                Thread.Sleep(1000);
            }
        }
        public static void Daño(CrearPersonajes.Personaje Peleador, CrearPersonajes.Personaje Contrincante)
        {
            float ataque = Peleador.Estadisticas.Fuerza * Peleador.Estadisticas.Destreza * Peleador.Estadisticas.Nivel;
            float defensa = Contrincante.Estadisticas.Armadura * Contrincante.Estadisticas.Velocidad;
            int Efectividad = rand.Next(1, 100);
            int constanteDeAjuste = 500;
            float danioprovocado = Math.Abs(((ataque * Efectividad) - defensa) / constanteDeAjuste);
            Console.WriteLine($"Danio Realizado {danioprovocado}");
            int danioInt = Convert.ToInt32(danioprovocado);
            Contrincante.Estadisticas.Salud -= danioInt;
            if (Contrincante.Estadisticas.Salud < 0)
            {
                Contrincante.Estadisticas.Salud = 0;
            }
        }
        private static void Defender(CrearPersonajes.Personaje defensor)
        {
            // Aquí puedes implementar la lógica de defensa
            defensor.Estadisticas.Armadura += 2; // Ejemplo: aumentar temporalmente la armadura
            Console.WriteLine($"{defensor.Informacion.Nombre} ha aumentado su armadura temporalmente.");
        }
    }
}

