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
            if (nombre == "Ghidora")
            {

                return "El Dragon Milenario";
            }
            if (nombre == "Godzilla")
            {

                return "Depredador Alfa";
            }
            if (nombre == "Mothra")
            {

                return "La Reina de los monstruos";
            }
            if (nombre == "Rodan")
            {

                return "Zero-Two Fire";
            }
            if (nombre == "Methuselah")
            {

                return "La Montania Andante";
            }
            if (nombre == "Scylla")
            {

                return "Guardián del Agua";
            }
            if (nombre == "Behemoth")
            {

                return "Mapinguary";
            }
            if (nombre == "King_Kong")
            {

                return "el Rey de las Bestias";
            }
            if (nombre == "Leviathan")
            {

                return "EL rey del oceano";
            }
            if (nombre == "Mokele_Mbembe")
            {

                return "El que detiene el flujo de los ríos";
            }
            if (nombre == "MUTO")
            {

                return "Massive Unidentified Terrestrial Organism,";
            }
            if (nombre == "Na_Kika")
            {

                return "Titanus Na Kika";
            }
            if (nombre == "Tiamat")
            {

                return "La Serpiente del Norte";
            }
            return null;
        }
        public static string CrearTipos(string nombre)
        {
            Caracteristicas inform = new Caracteristicas();
            if (nombre == "Ghidora")
            {
                return "Alienigena";
            }
            if (nombre == "Godzilla")
            {
                return "Agua";
            }
            if (nombre == "Mothra")
            {
                return "Aire";
            }
            if (nombre == "Rodan")
            {
                return "Fuego";
            }

            if (nombre == "Methuselah")
            {
                return "Tierra";
            }
            if (nombre == "Scylla")
            {
                return "Agua";
            }
            if (nombre == "Behemoth")
            {
                return "Tierra";
            }
            if (nombre == "King_Kong")
            {
                return "Bestia";
            }
            if (nombre == "Leviathan")
            {
                return "Agua";
            }
            if (nombre == "Mokele_Mbembe")
            {
                return "Tierra";

            }
            if (nombre == "MUTO")
            {
                return "Aire";

            }
            if (nombre == "Na_Kika")
            {
                return "Agua";
            }
            if (nombre == "Tiamat")
            {
                return "Hielo";
            }
            return null;
        }
    }
}

