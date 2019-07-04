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
            var curso1 = new Curso() {
                Nombre = "101"
            };
            var curso2 = new Curso() {
                Nombre = "201"
            };
            var curso3 = new Curso() {
                Nombre = "301"
            };
            Console.WriteLine(escuela);

            System.Console.WriteLine("================================");
            System.Console.WriteLine(curso1.Nombre + " , " + curso1.UniqueId);
            System.Console.WriteLine($"{curso2.Nombre} , {curso2.UniqueId}");
            System.Console.WriteLine(curso3);
        }
    }
}
