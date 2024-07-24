using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ApodosYClases;
using CrearPersonajes;
namespace FabricaDePersonajes
{
    public static class CrearPersonaje
    {
        private static Random rand = new Random();

        public static List<Personaje> GenerarPersonajes(int cantidad)
        {
            var personajes = new List<Personaje>();
            for (int i = 0; i <= cantidad; i++)
            {
                Caracteristicas info = new Caracteristicas();
                info.Nombre = LeerMonstruos()[rand.Next(0, 11)];
                info.Apodo = ApYCl.CrearApodos(info.Nombre);
                info.Tipo = ApYCl.CrearTipos(info.Nombre);
                if (PersonajeExiste(personajes, info.Nombre))// Verificar si el personaje ya existe
                {
                    continue; // Saltar a la siguiente iteración si el personaje ya existe
                }
                info.Edad = rand.Next(1000000, 300000000);
                Datos Stats = new Datos();
                Stats.Velocidad = rand.Next(10, 20);
                Stats.Destreza = rand.Next(10, 16);
                Stats.Fuerza = rand.Next(10, 20);
                Stats.Nivel = 1;
                Stats.Armadura = rand.Next(10, 20);
                Stats.Salud= 100;
                personajes.Add(new Personaje
                {
                    Informacion = info,
                    Estadisticas = Stats,
                });
            }
            GuardarPersonajes(personajes, @"resources/json/MonstruosDatos.json");
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
        public static List<string> LeerMonstruos()
        {
            string pathMonstruos = @"resources/json/NombreMonstruos.json";
            string jsonMonstruos = File.ReadAllText(pathMonstruos);
            List<string> nombresMonstruos = JsonSerializer.Deserialize<List<string>>(jsonMonstruos);
            return nombresMonstruos;
        }
        public static bool Existe(string archivo)
        {
            return File.Exists(archivo) && new FileInfo(archivo).Length > 0;
        }
    }
}