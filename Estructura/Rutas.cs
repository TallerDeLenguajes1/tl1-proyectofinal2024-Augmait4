using System;
namespace Rutas
{
    public static class Ruta
    {
        public static string[] audios = {@"resources\audio\Cyberpunk 2077 – E3 2018 Trailer Music ⧸- ''SPOILER'' (4K).wav",}; 
        public static string urlApi = @"https://godzilla-api.vercel.app/api/monsters";
        public static string rutaBackup = @"resources\backup";
        public static string rutaArchivo = @"resources\backup\Monstruos.Json";
        public static string[] menuInicial = {@"Jugar", @"Salir"};
        public static string[] menuJugador = {@"Ir a La Pelea",@"Rival",@"Estadisticas",@"Aumentar Estadisticas",@"Volver al Menu Principal"};
        public static string[] Dificultad = {@"Facil",@"Normal",@"Dificil"};
    }
}