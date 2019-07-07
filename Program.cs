using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console; //ESTO NOS PERMITE PODER UTILIZAR EL WRITELINE CONTENIDO EN SYSTEM.CONSOLE SIN TENER QUE ESCRIBIRLO TODO

namespace FundamentosCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Como los ultimos 2 valores son opcionales al constructor, los les puedo cambiar el orden, el valor que mando siempre va despues de :
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            escuela.Cursos = new List<Curso>(){
                new Curso() {Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "301", Jornada = TiposJornada.Mañana}
            };

            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            var otraColeccion = new List<Curso>(){
                new Curso() {Nombre = "401", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "501", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "502", Jornada = TiposJornada.Tarde}
            };

            var tmp = new Curso{Nombre = "Vacacional", Jornada = TiposJornada.Noche};
            escuela.Cursos.AddRange(otraColeccion);
            escuela.Cursos.Add(tmp);
            imprimirCursosEscuela(escuela);
            escuela.Cursos.RemoveAll(Predicado);//usando el metodo de un predicado/delegado para remover de la coleccion un elemento especifico
            escuela.Cursos.RemoveAll(cur => cur.Nombre == "502");//usando una expresion lambda para eliminar los elementos de la coleccion que cumplan la condicion
            WriteLine("=========================");
            imprimirCursosEscuela(escuela);

        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("====================");
            WriteLine("Cursos de la escuela");
            WriteLine("====================");

            //la siguiente comparacion es para las nuevas versiones de C#,
            //el simbolo ? le indica que la expresion a evaluar solo sera cierta
            //solo si lo que esta entes del simbolo ?, en este caso el objeto escuela,
            //es diferente de null, para posteriormente revisar si su atributo cursos es igualmente
            //diferente de null
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, ID {curso.UniqueId}");
                }
            }
        }
    }
}
