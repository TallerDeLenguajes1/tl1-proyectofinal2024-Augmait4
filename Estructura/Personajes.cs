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
        private string nombre;
        private string apodo;
        private DateTime fechaNac;
        private int edad;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo{ get => apodo; set => apodo = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
    }
        public class Personaje{
        private Datos estadisticas;
        private Caracteristicas informacion;

        public Datos Estadisticas { get => estadisticas; set => estadisticas = value; }
        public Caracteristicas Informacion { get => informacion; set => informacion = value; }
    }
}
