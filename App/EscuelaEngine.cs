using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicilizar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");
            Escuela.TipoEscuela = TiposEscuela.Secundaria;

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura {Nombre = "Matematicas"},
                    new Asignatura {Nombre = "Educacion Fisica"},
                    new Asignatura {Nombre = "Castellano"},
                    new Asignatura {Nombre = "Ciencias Naturales"},
                    new Asignatura {Nombre = "Programacion"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar( int cantidad)
        {
            string[] nombre1 = {"Jonathan","Elvia","Maximiliano","Mario","Daniel","Nerida","Edgar","Ivone"};
            string[] nombre2 = {"Zarina","Angel","Cipriano","Vega","Silvana","Teodoro","Simon","Alvin"};
            string[] apellido1 = {"Ruiz","Rangel","Hernandez","Monreal","Uribe","Trump","Herrera","Garcia"};
            string[] apellido2 = {"Ruiz","Rangel","Hernandez","Monreal","Uribe","Trump","Herrera","Garcia"};

            //Implementacion de LINQ para unir las listas
            var listaDeAlumnos = from n1 in nombre1 from n2 in nombre2 from a1 in apellido1 from a2 in apellido2 select new Alumno{ Nombre = $"{n1} {n2} {a1} {a2}"};
            return listaDeAlumnos.OrderBy(al => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso() {Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "401", Jornada = TiposJornada.Tarde},
                new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };
            Random rnd = new Random();
            foreach (var cur in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                cur.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }   
    }
}