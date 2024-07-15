namespace CrearPersonajes
{
    public  class Datos{
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int Nivel;
        private int Armadura;
        private int Salud;

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel1 { get => Nivel; set => Nivel = value; }
        public int Armadura1 { get => Armadura; set => Armadura = value; }
        public int Salud1 { get => Salud; set => Salud = value; }
    }
    public class Caracteristicas{
        private string tipo;
        private string Nombre;
        private string Apodo;
        private DateOnly FechaNac;
        private int Edad;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apodo1 { get => Apodo; set => Apodo = value; }
        public DateOnly FechaNac1 { get => FechaNac; set => FechaNac = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
    }
}
