namespace Core.Escuela.Entidades
{
    class Escuela
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }
        }
        public int AnoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        //Constructor
        public Escuela(string nombre, int anoDeCreacion) => (Nombre, AnoDeCreacion) = (nombre, anoDeCreacion);
    }
}