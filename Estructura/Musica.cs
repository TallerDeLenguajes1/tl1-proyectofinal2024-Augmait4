using System;
using System.Threading;
using Rutas;
using System.Media;
namespace Musica
{
    class Music
    {
        public static void Inicio()
        {
            // Ruta al archivo de audio
            string rutaAudio = Ruta.audios[0];

            // Crear un objeto SoundPlayer para reproducir el archivo de audio
            using (SoundPlayer player = new SoundPlayer(rutaAudio))
            {
                player.PlayLooping(); // Reproducir el audio
            }
        }
    }
}