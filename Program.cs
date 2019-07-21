using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console; //ESTO NOS PERMITE PODER UTILIZAR EL WRITELINE CONTENIDO EN SYSTEM.CONSOLE SIN TENER QUE ESCRIBIRLO TODO

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento; //anadimos al stack de eventos "ProcessExit" la funcion "AccionDelEvento", osea que los eventos son delegados
            //AppDomain.CurrentDomain.ProcessExit += (s,e) => Printer.Beep(2000,1000,1); //tambien se pueden anadir con expresiones lambda
            //AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento; //esto quita del stack de eventos "ProcessExit", entonces cuando termine el programa, el stack solo tendra 1 evento a ejecutar
            var engine = new EscuelaEngine();
            engine.Inicilizar();
            Printer.WriteTitle("Bienvenidos a la Escuela");

            var reporteador = new Reporteador(engine.getDiccionarioDeObjetos());
            var eval = reporteador.GetListaEvaluaciones();
            var asig = reporteador.GetListaAsignaturas();
            var listaPromXAsig = reporteador.GetPromedioAlumnoPorAsignatura();
            string nombre, notastring;
            float nota;

            var newEval = new Evaluacion();
            WriteLine("Ingrese el nombre de la evaluacion");
            Printer.PresioneEnter();
            nombre = ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El valor del nombre no puede estar vacio");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evalucaion ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluacion");
            Printer.PresioneEnter();
            notastring = ReadLine();
            try
            {
                nota = float.Parse(notastring);
                if (nota < 0 || nota > 5)
                {
                    throw new ArgumentOutOfRangeException("La nota debe ser entre 0.0 y 5.0");
                }
            }
            catch (ArgumentOutOfRangeException aore)
            {
                System.Console.WriteLine(aore.Message);
            }
            catch (Exception)
            {
                Printer.WriteTitle("El valor de la nota no es un valor valido");
            }
            finally{
                System.Console.WriteLine("Modulo Finally");
            }
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo");
            //Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("Salio");
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos en la Escuela");

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
