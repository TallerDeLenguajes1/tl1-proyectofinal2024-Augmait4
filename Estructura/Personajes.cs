namespace CrearPersonajes
{
    public class Datos
    {
        private float velocidad;
        private float destreza;
        private float fuerza;
        private float nivel;
        private float armadura;
        private float salud;

        public float Velocidad { get => velocidad; set => velocidad = value; }
        public float Destreza { get => destreza; set => destreza = value; }
        public float Fuerza { get => fuerza; set => fuerza = value; }
        public float Nivel { get => nivel; set => nivel = value; }
        public float Armadura { get => armadura; set => armadura = value; }
        public float Salud { get => salud; set => salud = value; }
    }
    public class Caracteristicas
    {
        private string tipo;
        private string nombre;
        private string apodo;

        private int edad;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public int Edad { get => edad; set => edad = value; }
    }
    public class Personaje
    {
        private Datos estadisticas;
        private Caracteristicas informacion;
        private DateTime fechaVictoria;
        public Datos Estadisticas { get => estadisticas; set => estadisticas = value; }
        public Caracteristicas Informacion { get => informacion; set => informacion = value; }
        public DateTime FechaVictoria { get => fechaVictoria; set => fechaVictoria = value; }
    }
}
