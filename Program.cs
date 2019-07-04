using System;
using CoreEscuela.Entidades;

namespace FundamentosCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Como los ultimos 2 valores son opcionales al constructor, los les puedo cambiar el orden, el valor que mando siempre va despues de :
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            //creamos un arreglo de objetos curso y los asignamos de difetenres maneras al arreglo
            var cursos = new Curso[3];
            cursos[0] = new Curso()
            {
                Nombre = "101"
            };
            var curso2 = new Curso()
            {
                Nombre = "201"
            };
            cursos[1] = curso2;
            cursos[2] = new Curso
            {
                Nombre = "301"
            };

            //imprimimos los valores de nuestros objetos
            Console.WriteLine(escuela);
            System.Console.WriteLine("================================");
            imprimirCursosWhile(cursos);
            System.Console.WriteLine("================================");
            imprimirCursosDoWhile(cursos);
            System.Console.WriteLine("================================");
            imprimirCursosConFor(cursos);
            System.Console.WriteLine("================================");
            imprimirCursosConForEach(cursos);
        }

        //Imprime todos los elementos del arreglo con un while
        private static void imprimirCursosWhile(Curso[] cursos)
        {
            int contador = 0;
            while (contador < cursos.Length)
            {
                Console.WriteLine($"Nombre {cursos[contador].Nombre}, ID {cursos[contador].UniqueId}");
                contador++;
            }
        }

        //Imprime todos los elementos del arreglo con un do while
        private static void imprimirCursosDoWhile(Curso[] cursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre {cursos[contador].Nombre}, ID {cursos[contador].UniqueId}");
                contador++;
            } while (contador < cursos.Length);
        }

        //Imprime todos los elementos del arreglo con un for
        private static void imprimirCursosConFor(Curso[] cursos)
        {
            for (int i = 0; i < cursos.Length; i++)
            {
                Console.WriteLine($"Nombre {cursos[i].Nombre}, ID {cursos[i].UniqueId}");
            }
        }

        //Imprime todos los elementos del arreglo con un for
        private static void imprimirCursosConForEach(Curso[] cursos)
        {
            foreach (var item in cursos)
            {
                Console.WriteLine($"Nombre {item.Nombre}, ID {item.UniqueId}");
            }
        }
    }
}
