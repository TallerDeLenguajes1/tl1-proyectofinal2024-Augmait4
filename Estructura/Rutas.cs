using System;
namespace Rutas
{
    public static class Ruta
    {
        public static string[] audios = { @"resources\audio\Cyberpunk 2077 – E3 2018 Trailer Music ⧸- ''SPOILER'' (4K).wav", };
        public static string urlApi = @"https://godzilla-api.vercel.app/api/monsters";
        public static string rutaBackup = @"resources\backup";
        public static string[] rutaArchivosBackup = {@"resources\backup\NombreMonstruos.json", @"resources\backup\InformacionMonstruos.json"};
        public static string[] rutaArchivosJson = {@"resources\json\MonstruosDatos.json",@"resources\json\Ganadores.json",@"resources\json\Contrincantes.json",@"resources\json\Peleador.json"};
        public static string[] menuInicial = { @"Jugar",@"Historial de Ganadores", @"Salir" };
        public static string[] menuJugador = { @"Ir a La Pelea", @"Rival", @"Estadisticas", @"Aumentar Estadisticas", @"Volver al Menu Principal" };
        public static string[] Dificultad = { @"Facil", @"Normal", @"Dificil" };
        public static string[] MenuDeBatalla = { @"Atacar", @"Defender", @"Ataque Especial", @"Rendirse" };
        public static string[] MenuEstadisticas = { @"Fuerza", @"Destreza", @"Velocidad", @"Armadura",@"Salir"};
    }
}