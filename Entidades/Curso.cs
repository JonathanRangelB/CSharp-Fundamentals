using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso: ObjetoEscuelBase, ILugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        // public Curso() => UniqueId = Guid.NewGuid().ToString();
        string ILugar.Direccion { get; set; }

        public Curso(){
            Alumnos = new List<Alumno>();
        }

        public void LimpiarLugar(){
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Nombre} Limpio");
        }
    }
}