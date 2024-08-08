using FabricaDePersonajes;
using System.Collections.Generic;
using System;
using System.Text.Json;
using CrearPersonajes;
using Rutas;
using menuSeleccionable;
using Interfaz;
using Newtonsoft.Json;
namespace Combate
{
    public static class Batalla
    {
        public static Random rand = new Random();
        public static void combate()
        {
            int desicionGanandor = 2;
            int cont = 1;
            int puntosDeAumentos = 0;
            List<CrearPersonajes.Personaje> Peleador = CrearPersonaje.LeerPersonajes(Ruta.rutaArchivosJson[3]);
            List<CrearPersonajes.Personaje> Contrincantes = CrearPersonaje.LeerPersonajes(Ruta.rutaArchivosJson[2]);
            CrearPersonajes.Personaje peleador = Peleador[0];
            Random rand = new Random();
            CrearPersonajes.Personaje contrincante = Contrincantes[rand.Next(0, Contrincantes.Count)];
            while (Contrincantes.Count != 0)
            {
                int desicionDeMenu = menuu.MostrarMenuJugadorCentrado();
                if (desicionDeMenu == 4)
                {
                    break;
                }
                switch (desicionDeMenu)
                {
                    case 0:
                        desicionGanandor = Luchar(desicionGanandor, peleador, contrincante);
                        break;
                    case 1:
                        Cartel.VisordeVidaRival(contrincante);
                        Console.SetCursorPosition(0, 13);
                        Console.WriteLine("Apretar cualquier tecla para volver al Menu .....");
                        Console.ReadKey();
                        break;
                    case 2:
                        Cartel.VisordeVidaPelador(peleador);
                        Console.SetCursorPosition(0, 13);
                        Console.WriteLine("Apretar cualquier tecla para volver al Menu .....");
                        Console.ReadKey();
                        break;
                    case 3:
                        bool salir = false;
                        puntosDeAumentos = mejoraPeleador(puntosDeAumentos, peleador, salir);
                        break;
                    case 4:

                    break;
                }
                if (desicionGanandor == 0)
                {
                    Console.WriteLine($"{peleador.Informacion.Nombre} ha ganado el combate.");
                    Contrincantes.Remove(contrincante); // Eliminar el contrincante derrotado
                    if (Contrincantes.Count > 0)
                    {
                        peleador.Estadisticas.Nivel ++;;
                        puntosDeAumentos = puntosDeAumentos + 30;
                        contrincante = Contrincantes[rand.Next(0, Contrincantes.Count)];
                        cont++;
                        MejoraRival(contrincante, Contrincantes, cont);
                        peleador.Estadisticas.Salud = 100 * peleador.Estadisticas.Nivel; // Restaurar salud del peleador y agrega un mejora En su Salud
                        desicionGanandor = 2;
                    }
                    Thread.Sleep(1000);
                }
                else if (desicionGanandor == 1)
                {
                    Console.WriteLine($"{peleador.Informacion.Nombre} ha sido derrotado.");
                    Cartel.TituloJuegoRapido(0,Cartel.Derrota);
                    Thread.Sleep(7000);
                    // Salir del bucle si el peleador es derrotado
                    break;
                }
            }
            ComprobarDerrotaVictoria(peleador, Contrincantes);
            menuu.MostrarMenuCentrado();
        }

        private static int mejoraPeleador(int puntosDeAumentos, Personaje peleador, bool salir)
        {
            while (salir != true)
            {
                int desicionEstadisticas = menuu.MostrarMenuAumentoEstadisticas(peleador, puntosDeAumentos);
                int puntosAsignar = 10;

                switch (desicionEstadisticas)
                {
                    case 0:
                        if (puntosDeAumentos <= 0)
                        {
                            Console.WriteLine("No tiene Puntos suficientes para Aumentar");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            peleador.Estadisticas.Fuerza += puntosAsignar;
                            puntosDeAumentos -= puntosAsignar;
                        }
                        break;
                    case 1:
                        if (puntosDeAumentos <= 0)
                        {
                            Console.WriteLine("No tiene Puntos suficientes para Aumentar");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            peleador.Estadisticas.Destreza += puntosAsignar;
                            puntosDeAumentos -= puntosAsignar;
                        }
                        break;
                    case 2:
                        if (puntosDeAumentos <= 0)
                        {
                            Console.WriteLine("No tiene Puntos suficientes para Aumentar");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            peleador.Estadisticas.Velocidad += puntosAsignar;
                            puntosDeAumentos -= puntosAsignar;
                        }
                        break;
                    case 3:
                        if (puntosDeAumentos <= 0)
                        {
                            Console.WriteLine("No tiene Puntos suficientes para Aumentar");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            peleador.Estadisticas.Armadura += puntosAsignar;
                            puntosDeAumentos -= puntosAsignar;
                        }
                        break;
                    case 4:
                        salir = true;
                        break;
                }

            }
            return puntosDeAumentos;
        }

        private static int Luchar(int desicionGanandor, Personaje peleador, Personaje contrincante)
        {
            int contPoderAliado = 0;
            int contPoderEnemigo = 0;
            while (desicionGanandor != 1 && desicionGanandor != 0)
            {
                if (contPoderAliado < 3)
                {
                    contPoderAliado++;
                }
                if (contPoderEnemigo < 3)
                {
                    contPoderEnemigo++;
                }
                Console.Clear();
                Cartel.VisordeVida(peleador, contrincante, contPoderAliado, contPoderEnemigo);
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
                    case 2:
                        if (contPoderAliado == 3)
                        {
                            Console.WriteLine($"{peleador.Informacion.Nombre} Hace un ataque especial a {contrincante.Informacion.Nombre}");
                            DañoEspecial(peleador, contrincante);
                            contPoderAliado = 0;
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("El Ataque especial aun no Esta listo");
                            Console.WriteLine($"{peleador.Informacion.Nombre} se defiende.");
                            Defender(peleador);
                            Thread.Sleep(1000);
                        };
                        break;
                    case 3:
                        peleador.Estadisticas.Salud = 0;
                        break;
                }
                if (peleador.Estadisticas.Salud <= 0)
                {
                    desicionGanandor = 1;
                    break;
                }
                if (contrincante.Estadisticas.Salud <= 0)
                {
                    desicionGanandor = 0;
                    break;
                }
                int poder = razonamientoIA(peleador, contrincante, contPoderEnemigo);
                if (poder == 1)
                {
                    contPoderEnemigo = 0;
                }
                if (peleador.Estadisticas.Salud <= 0)
                {
                    desicionGanandor = 1;
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }
            return desicionGanandor;
        }

        private static void MejoraRival(CrearPersonajes.Personaje contrincante, List<CrearPersonajes.Personaje> Rivales, int cont)
        {
            float AumentoDeNivel = (cont * 80) / 100;
            contrincante.Estadisticas.Armadura = contrincante.Estadisticas.Armadura * AumentoDeNivel;
            contrincante.Estadisticas.Destreza = contrincante.Estadisticas.Destreza * AumentoDeNivel;
            contrincante.Estadisticas.Fuerza = contrincante.Estadisticas.Fuerza * AumentoDeNivel;
            contrincante.Estadisticas.Velocidad = contrincante.Estadisticas.Velocidad * AumentoDeNivel;
            contrincante.Estadisticas.Nivel = cont;
            contrincante.Estadisticas.Salud = contrincante.Estadisticas.Salud * (contrincante.Estadisticas.Nivel * 2);
        }
        private static void ComprobarDerrotaVictoria(CrearPersonajes.Personaje luchador, List<CrearPersonajes.Personaje> Rivales)
        {
            if (Rivales.Count == 0)
            {
                Console.WriteLine($"{luchador.Informacion.Nombre} ha derrotado a todos los contrincantes.");
                Cartel.TituloJuegoRapido(0,Cartel.Victoria);
                Thread.Sleep(7000);
                luchador.FechaVictoria = DateTime.Now;
                List<CrearPersonajes.Personaje> ganadores = new List<CrearPersonajes.Personaje>();
                try
                {
                    ganadores = CrearPersonaje.LeerPersonajes(Ruta.rutaArchivosJson[1]);
                }
                catch (Exception ex)
                {
                    // Si el archivo no existe o hay otro problema, inicializar una nueva lista
                    Console.WriteLine("No se pudo leer el archivo de ganadores existentes: " + ex.Message);
                }
                ganadores.Add(luchador);
                CrearPersonaje.GuardarPersonajes(ganadores, Ruta.rutaArchivosJson[1]);
            }
        }
        private static int razonamientoIA(CrearPersonajes.Personaje Peleador, CrearPersonajes.Personaje Contrincante, int contPoder)
        {
            int accionContrincante = rand.Next(1, 3);
            if (contPoder == 3)
            {
                Console.WriteLine($"{Contrincante.Informacion.Nombre} Hacer un ataque especial a {Peleador.Informacion.Nombre}");
                DañoEspecial(Contrincante, Peleador);
                Thread.Sleep(1000);
                return 1;
            }
            else
            if (accionContrincante == 1)
            {
                Console.WriteLine($"{Contrincante.Informacion.Nombre} ataca a {Peleador.Informacion.Nombre}");
                Daño(Contrincante, Peleador);
                Thread.Sleep(1000);
                return 0;
            }
            else
            {
                Console.WriteLine($"{Contrincante.Informacion.Nombre} se defiende.");
                Defender(Contrincante);
                Thread.Sleep(1000);
                return 0;
            }
        }
        private static void Daño(CrearPersonajes.Personaje Peleador, CrearPersonajes.Personaje Contrincante)
        {
            float ataque = Peleador.Estadisticas.Fuerza * Peleador.Estadisticas.Destreza * Peleador.Estadisticas.Nivel;
            float defensa = Contrincante.Estadisticas.Armadura * Contrincante.Estadisticas.Velocidad;
            int Efectividad = rand.Next(1, 100);
            int constanteDeAjuste = 500;
            float danioprovocado = Math.Abs(((ataque * Efectividad) - defensa) / constanteDeAjuste);
            int danioInt = Convert.ToInt32(danioprovocado);
            Console.WriteLine($"Danio Realizado {danioInt}");
            Contrincante.Estadisticas.Salud -= danioInt;
            if (Contrincante.Estadisticas.Salud < 0)
            {
                Contrincante.Estadisticas.Salud = 0;
            }
        }
        private static void DañoEspecial(CrearPersonajes.Personaje Peleador, CrearPersonajes.Personaje Contrincante)
        {
            float ataque = Peleador.Estadisticas.Fuerza * Peleador.Estadisticas.Destreza * Peleador.Estadisticas.Nivel;
            float defensa = Contrincante.Estadisticas.Armadura * Contrincante.Estadisticas.Velocidad;
            int Efectividad = rand.Next(1, 100);
            int constanteDeAjuste = 500;
            float danioprovocado = Math.Abs(((ataque * Efectividad) - defensa) / constanteDeAjuste);
            int danioInt = Convert.ToInt32(danioprovocado * 2);
            Console.WriteLine($"Danio Especial Realizado {danioInt}");
            Contrincante.Estadisticas.Salud -= danioInt;
            if (Contrincante.Estadisticas.Salud < 0)
            {
                Contrincante.Estadisticas.Salud = 0;
            }
        }
        private static void Defender(CrearPersonajes.Personaje defensor)
        {
            // Aquí puedes implementar la lógica de defensa
            defensor.Estadisticas.Armadura += 5; // Ejemplo: aumentar temporalmente la armadura
            Console.WriteLine($"{defensor.Informacion.Nombre} ha aumentado su armadura temporalmente.");
        }
    }
}

