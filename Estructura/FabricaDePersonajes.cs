using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ApodosYClases;
using CrearPersonajes;
using Rutas;
namespace FabricaDePersonajes
{
    public static class CrearPersonaje
    {
        private static Random rand = new Random();

        public static List<Personaje> GenerarPersonajes(int cantidad)
        {
            var personajes = new List<Personaje>();
            for (int i = 0; i < cantidad; i++)
            {
                Caracteristicas info = new Caracteristicas();
                do
                {
                    info.Nombre = LeerMonstruos()[rand.Next(0, 11)];
                } while (PersonajeExiste(personajes, info.Nombre));
                info.Apodo = ApYCl.CrearApodos(info.Nombre);
                info.Tipo = ApYCl.CrearTipos(info.Nombre);
                info.Edad = rand.Next(1000000, 3000000);
                Datos Stats = new Datos();
                Stats.Velocidad = rand.Next(10, 20);
                Stats.Destreza = rand.Next(10, 16);
                Stats.Fuerza = rand.Next(10, 20);
                Stats.Nivel = 1;
                Stats.Armadura = rand.Next(10, 20);
                Stats.Salud = 100;
                personajes.Add(new Personaje
                {
                    Informacion = info,
                    Estadisticas = Stats,
                });
            }
            GuardarPersonajes(personajes, Ruta.rutaArchivosJson[0]);
            return personajes;
        }
        public static bool PersonajeExiste(List<Personaje> personajes, string nombre)
        {
            foreach (var personaje in personajes)
            {
                if (personaje.Informacion.Nombre == nombre)
                {
                    return true;
                }
            }
            return false;
        }
        public static void GuardarPersonajes(List<Personaje> personajes, string archivo)
        {
            var json = JsonSerializer.Serialize(personajes);
            File.WriteAllText(archivo, json);
        }

        public static List<Personaje> LeerPersonajes(string archivo)
        {
            var json = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<List<Personaje>>(json);
        }
        private static List<string> LeerMonstruos()
        {
            string pathMonstruos = Ruta.rutaArchivosBackup[0];
            string jsonMonstruos = File.ReadAllText(pathMonstruos);
            List<string> nombresMonstruos = JsonSerializer.Deserialize<List<string>>(jsonMonstruos);
            return nombresMonstruos;
        }
        public static bool Existe(string archivo)
        {
            return File.Exists(archivo) && new FileInfo(archivo).Length > 0;
        }
        public static void CrearLuchadores(List<Personaje> personajes, int opcionSeleccionada)
        {
            CrearPersonajes.Personaje peleador = personajes[opcionSeleccionada];
            List<CrearPersonajes.Personaje> contrincantes = new List<CrearPersonajes.Personaje>(personajes);
            contrincantes.RemoveAt(opcionSeleccionada);
            CrearPersonaje.GuardarPersonajes(new List<CrearPersonajes.Personaje> { peleador }, Ruta.rutaArchivosJson[3]);
            CrearPersonaje.GuardarPersonajes(contrincantes, Ruta.rutaArchivosJson[2]);
        }
    }
}