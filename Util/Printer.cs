using System;
using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int tamano = 10) //si no me mandan nada como parametro, el tamano siempre sera 10
        {
            WriteLine("".PadLeft(tamano,'='));
        }

        public static void PresioneEnter() //si no me mandan nada como parametro, el tamano siempre sera 10
        {
            WriteLine("Presiones ENTER para continuar");
        }

        public static void WriteTitle(string titulo) //si no me mandan nada como parametro, el tamano siempre sera 10
        {
            var tamano = titulo.Length + 4;
            DrawLine(tamano);
            WriteLine($"| {titulo} |");
            DrawLine(tamano);
        }

        public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1){
            while(cantidad-- > 0){
                Console.Beep(hz,tiempo);
            }
        }
    }
}