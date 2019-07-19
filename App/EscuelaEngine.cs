using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    //el modificador de clase sealed nos india que esta clase puede ser instansiada, pero no heredada, es justo lo contrario al modificador de clase abstract
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public void Inicilizar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");
            Escuela.TipoEscuela = TiposEscuela.Secundaria;

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelBase>> getDiccionarioDeObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelBase>>();
            //diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelBase>());
            var listaTmpeEv = new List<Evaluacion>();
            var listaTmpAs = new List<Asignatura>();
            var listaTmpAl = new List<Alumno>();
            foreach (var cur in Escuela.Cursos)
            {
                listaTmpAs.AddRange(cur.Asignaturas);
                listaTmpAl.AddRange(cur.Alumnos);
                foreach (var alum in cur.Alumnos)
                {
                    listaTmpeEv.AddRange(alum.Evaluaciones);
                }
            }
            diccionario.Add(LlaveDiccionario.Evaluacion, listaTmpeEv.Cast<ObjetoEscuelBase>());
            diccionario.Add(LlaveDiccionario.Asignatura, listaTmpAs.Cast<ObjetoEscuelBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listaTmpAl.Cast<ObjetoEscuelBase>());
            return diccionario;
        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelBase>> dic, bool imprEval = false)
        {
            foreach (var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());
                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if (imprEval)
                            {
                                System.Console.WriteLine(val);
                            }
                            break;
                        case LlaveDiccionario.Escuela:
                            System.Console.WriteLine($"Escuela: {val}");
                            break;
                        case LlaveDiccionario.Alumno:
                            System.Console.WriteLine($"Alumno: {val.Nombre}");
                            break;
                        case LlaveDiccionario.Curso:
                            var curtmp = val as Curso;
                            if (curtmp != null)
                            {
                                System.Console.WriteLine($"Curso: {val.Nombre} Cantidad Alumnos: {curtmp.Alumnos.Count}");
                            }
                            break;
                        default:
                            System.Console.WriteLine(val);
                            break;
                    }
                }
            }
        }

        #region Generacion de datos al azar
        public IReadOnlyList<ObjetoEscuelBase> getObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return getObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelBase> getObjetosEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return getObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelBase> getObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return getObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelBase> getObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return getObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy);
        }

        ///<SUMMARY>
        ///Regresa todos los objetos contenidos en el objeto escuela creado, como todos heredan de la clase ObjetoEscuelBase, se pueden meter en la lista por polimorfismo
        ///Tambien, la firma del metodo nos indica que va a regresar 2 elementos, una lista y un entero si los ponemos entre parentesis, o tambien podemos tener valores
        ///de salida con la palabra reservada out antes del tipo de dato en los parametros del metodo
        ///<SUMMARY>
        public IReadOnlyList<ObjetoEscuelBase> getObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = 0;
            var listaObj = new List<ObjetoEscuelBase>();
            listaObj.Add(Escuela);
            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                if (traeAsignaturas)
                {
                    listaObj.AddRange(curso.Asignaturas);
                    conteoAsignaturas += curso.Asignaturas.Count;
                }
                if (traeAlumnos)
                {
                    listaObj.AddRange(curso.Alumnos);
                    conteoAlumnos += curso.Alumnos.Count;
                }
                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }
            return listaObj.AsReadOnly(); //se puede regresar mas de 1 valor en un return si los metemos dentro de parentesis, se coloca como de solo lectura para evitar
            //que otros programadores tengan acceso de escritura a un objeto que no deberia de ser modificado
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Jonathan", "Elvia", "Maximiliano", "Mario", "Daniel", "Nerida", "Edgar", "Ivone" };
            string[] nombre2 = { "Zarina", "Angel", "Cipriano", "Vega", "Silvana", "Teodoro", "Simon", "Alvin" };
            string[] apellido1 = { "Ruiz", "Rangel", "Hernandez", "Monreal", "Uribe", "Trump", "Herrera", "Garcia" };
            string[] apellido2 = { "Ruiz", "Rangel", "Hernandez", "Monreal", "Uribe", "Trump", "Herrera", "Garcia" };

            //Implementacion de LINQ para unir las listas
            var listaDeAlumnos = from n1 in nombre1 from n2 in nombre2 from a1 in apellido1 from a2 in apellido2 select new Alumno { Nombre = $"{n1} {n2} {a1} {a2}" };
            return listaDeAlumnos.OrderBy(al => al.UniqueId).Take(cantidad).ToList();
        }
        #endregion
        #region Cargar Datos
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

        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluacion>();
            var rnd = new Random(System.Environment.TickCount);
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} EV#{i + 1}",
                                Nota = (float)MathF.Round((float)(5 * rnd.NextDouble()),2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }
        #endregion
    }
}