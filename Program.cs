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
            Console.WriteLine(escuela.ToString());
        }
    }
}
