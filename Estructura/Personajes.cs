namespace CrearPersonajes
{
    public  class Datos{
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
    }
    public class Caracteristicas{
        private string tipo;
        private string Nombre;
        private string Apodo;
        private DateTime FechaNac;
        private int Edad;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apodo1 { get => Apodo; set => Apodo = value; }
        public DateTime FechaNac1 { get => FechaNac; set => FechaNac = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
    }
        public class Personaje{
        private Datos estadisticas;
        private Caracteristicas informacion;

        public Datos Estadisticas { get => estadisticas; set => estadisticas = value; }
        public Caracteristicas Informacion1 { get => informacion; set => informacion = value; }
    }
}
