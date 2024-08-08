using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rutas;
using System.Net.Cache;
using System.Globalization;
using Newtonsoft.Json.Converters;
namespace MonstersApi
{
    class consumiendoApi{
        private static readonly HttpClient client = new HttpClient();

        public static async Task Get()
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync(Ruta.urlApi);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<MonstruosDatos> listMonsters = JsonConvert.DeserializeObject<List<MonstruosDatos>>(responseBody);

                string json = JsonConvert.SerializeObject(listMonsters, Formatting.Indented);
                List<string> monsterNames = new List<string>();

                foreach (var monster in listMonsters)
                {
                    monsterNames.Add(monster.Name);
                }

                string json2 = JsonConvert.SerializeObject(monsterNames, Formatting.Indented);
                await File.WriteAllTextAsync(Ruta.rutaArchivosBackup[0], json2);
                await File.WriteAllTextAsync(Ruta.rutaArchivosBackup[1], json);

                Console.WriteLine("CONEXION EXITOSA CON LA BASE DE DATOS DE MONARCA.");
                Console.WriteLine("Manten Presionada la Barra Espaciadora para Saltar la Animacion....");
                Thread.Sleep(3000);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("No se pudo conectar con MONARCA. Cargando datos del respaldo...");
                Thread.Sleep(1000);
                try
                {
                    string backupJson = await File.ReadAllTextAsync(Ruta.rutaArchivosBackup[1]);
                    List<MonstruosDatos> listMonsters = JsonConvert.DeserializeObject<List<MonstruosDatos>>(backupJson);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("El archivo de respaldo no existe.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al leer el archivo de respaldo: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }
        }
    }
        public partial class MonstruosDatos
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        [JsonProperty("ability")]
        public string Ability { get; set; }

        [JsonProperty("firstAppearance")]
        public long FirstAppearance { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }
    } 
}