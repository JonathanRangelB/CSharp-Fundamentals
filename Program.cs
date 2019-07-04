using System;
using Core.Escuela.Entidades;

namespace FundamentosCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogota";
            Console.WriteLine(escuela.Nombre);
        }
    }
}
