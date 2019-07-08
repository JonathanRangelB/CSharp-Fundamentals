using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso: ObjetoEscuelBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        // public Curso() => UniqueId = Guid.NewGuid().ToString();

        public Curso(){
            Alumnos = new List<Alumno>();
        }
    }
}