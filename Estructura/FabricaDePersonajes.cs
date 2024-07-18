using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CrearPersonajes;
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
                info.Tipo = "Tipo" + i;
                info.Nombre1 = LeerMonstruos()[rand.Next(0,12)];
                info.Apodo1 = "Apodo" + i;
                info.FechaNac1 = DateTime.Now.AddYears(-rand.Next(0, 301));
                info.Edad1 = rand.Next(0, 301);
                Datos Stats = new Datos();
                    Stats.Velocidad = rand.Next(1, 11);
                    Stats.Destreza = rand.Next(1, 6);
                    Stats.Fuerza = rand.Next(1, 11);
                    Stats.Nivel = rand.Next(1, 11);
                    Stats.Armadura = rand.Next(1, 11);
                personajes.Add(new Personaje
                {
                    Informacion1 = info,
                    Estadisticas = Stats,
                });
            }
            GuardarPersonajes(personajes, @"resources/json/MonstruosDatos.json");
            return personajes;
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