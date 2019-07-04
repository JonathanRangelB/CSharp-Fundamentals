using System;
using CoreEscuela.Entidades;

namespace FundamentosCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Como los ultimos 2 valores son opcionales al constructor, los les puedo cambiar el orden, el valor que mando siempre va despues de :
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad:"Bogota", pais:"Colombia");
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            //creamos un arreglo de objetos curso y los asignamos de difetenres maneras al arreglo
            var cursos = new Curso[3];
            cursos[0] = new Curso()
            {
                Nombre = "101"
            };
            var curso2 = new Curso() {
                Nombre = "201"
            };
            cursos[1] = curso2;
            cursos[2]= new Curso{
                Nombre = "301"
            };

            //imprimimos los valores de nuestros objetos
            Console.WriteLine(escuela);
            System.Console.WriteLine("================================");
            imprimirCursos(cursos);
        }

        //Imprime todos los elementos del arreglo
        private static void imprimirCursos(Curso[] cursos)
        {
            int contador = 0;
            while (contador < cursos.Length)
            {
                Console.WriteLine($"Nombre {cursos[contador].Nombre}, ID {cursos[contador].UniqueId}");
                contador++;
            }
        }
    }
}
