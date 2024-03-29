using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelBase, ILugar
    {
        public int AnoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }
        string ILugar.Direccion { get; set; }

        //Constructor corto con asignacion por tuplas
        public Escuela(string nombre, int anoDeCreacion) => (Nombre, AnoDeCreacion) = (nombre, anoDeCreacion);
        //Constructor normal y con los ultimos 2 tipos de datos como opcionales
        public Escuela(string nombre, int anoDeCreacion, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            (Nombre, AnoDeCreacion) = (nombre, anoDeCreacion);//podemos reusar la asignacion por tuplas
            Pais = pais;
            Ciudad = ciudad;
        }
        //sobreescribimos el metodo toString de la clase object y le damos el comportamiento que queremos para este objeto en especifico
        //El signo e dolar $ antes del string le dice al compilador que dentro del string tendremos instrucciones
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\"{System.Environment.NewLine}Tipo: \"{TipoEscuela}\"{System.Environment.NewLine}Ciudad: \"{Ciudad}\"";
        }

        public void LimpiarLugar()
        {
            Printer.Beep(1000,cantidad:3);
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Printer.WriteTitle($"Escuela {Nombre} Limpia");
        }
    }
}