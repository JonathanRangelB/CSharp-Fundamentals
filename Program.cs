using System;
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

            escuela.Cursos = new Curso[]{
                new Curso(){ Nombre = "101"},
                new Curso() {Nombre = "201"},
                new Curso() {Nombre = "301"}
            };

            //imprimimos los valores de nuestros objetos
            imprimirCursosEscuela(escuela);
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
