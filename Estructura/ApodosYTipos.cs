using FabricaDePersonajes;
using System;
using CrearPersonajes;
namespace ApodosYClases
{
    public static class ApYCl
    {
        public static string CrearApodos(string nombre)
        {
            Caracteristicas inform = new Caracteristicas();
            switch (nombre)
            {
                case "Ghidorah":
                    return "El Dragon Milenario";
                case "Godzilla":
                    return "Depredador Alfa";
                case "Mothra":
                    return "La Reina de los monstruos";
                case "Rodan":
                    return "Zero-Two Fire";
                case "Methuselah":
                    return "La Montania Andante";
                case "Scylla":
                    return "Guardián del Agua";
                case "Behemoth":
                    return "Mapinguary";
                case "King_Kong":
                    return "el Rey de las Bestias";
                case "Leviathan":
                    return "EL rey del oceano";
                case "Mokele_Mbembe":
                    return "El que detiene el flujo de los ríos";
                case "MUTO":
                    return "Massive Unidentified Terrestrial Organism,";
                case "Na_Kika":
                    return "Titanus Na Kika";
                case "Tiamat":
                    return "La Serpiente del Norte";
                default:
                    return null;
            }
        }
        public static string CrearTipos(string nombre)
        {
            Caracteristicas inform = new Caracteristicas();
            switch (nombre)
            {
                case "Ghidorah":
                    return "Alienigena";
                case "Godzilla":
                    return "Agua";
                case "Mothra":
                    return "Aire";
                case "Rodan":
                    return "Fuego";
                case "Methuselah":
                    return "Tierra";
                case "Scylla":
                    return "Agua";
                case "Behemoth":
                    return "Tierra";
                case "King_Kong":
                    return "Bestia";
                case "Leviathan":
                    return "Agua";
                case "Mokele_Mbembe":
                    return "Tierra";
                case "MUTO":
                    return "Aire";
                case "Na_Kika":
                    return "Agua";
                case "Tiamat":
                    return "Hielo";
                default:
                    return null;
            }
        }
    }
}

