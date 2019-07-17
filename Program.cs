﻿using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console; //ESTO NOS PERMITE PODER UTILIZAR EL WRITELINE CONTENIDO EN SYSTEM.CONSOLE SIN TENER QUE ESCRIBIRLO TODO

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicilizar();
            Printer.WriteTitle("Bienvenidos a la Escuela");
            //cantidad es el 3er parametro, pero aqui esta como segundo, pero funciona porque tien el caracter ':'
            //que le indica a que parametro pertenece el valor que le estoy mandando, no importa el orden de los parametros
            // Printer.Beep(10000,cantidad:10);
            imprimirCursosEscuela(engine.Escuela);
            //regresa una lista de objetos de fifetentes tipos, pero como todos heredan de la clase base, son compatibles por polimorfismo
            //podemos obtener valores dl metodo sin usar retur con la palabra reservada out
            var listaObjetos = engine.getObjetosEscuela();
            // foreach (var item in listaObjetos)
            // {
            //     if (item is Curso) //valida si el item es del tipo curso, caso contrario no entra al cuerpo del if
            //     {
            //         WriteLine(item.Nombre);
            //     }

            //     WriteLine(item as Asignatura); //retorna null si el item no es del tipo Asignatura, caso contrario regresara sus datos
            // }
            //engine.Escuela.LimpiarLugar();

            //esta parte usa linq para recorrer la lista anterior y crear una nueva lista tomando en cuenta si el objeto,
            //en este caso, es de tipo ILugar, podriamos cambiarlo a Alumno por ejemplo, y nos traeria solamente objetos de
            //tipo Alumno
            // var listaILugar = from obj in listaObjetos
            // where obj is ILugar //si quitamos este where, nos va a dar un error silencioso, donde todo pasa bien, pero al final si hubi un error interno en la lista y se fue guardando en la misma
            // select (ILugar)obj;
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "JuanK");
            diccionario.Add(23, "Lorem Ipsum");

            foreach (var keyValPair in diccionario)
            {
                System.Console.WriteLine($"key: {keyValPair.Key} Value: {keyValPair.Value}");
            }
            Printer.WriteTitle("Acceso a diccionario");
            diccionario[0] = "Pekerman";
            System.Console.WriteLine(diccionario[0]);
            Printer.WriteTitle("Acceso a diccionario");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["luna"] = "Cuerpo celeste que gira alrededor de la luna";
            System.Console.WriteLine(dic["luna"]);
            dic.Add("luna", "protagonista de soy luna");
            //dic["luna"] = "protagonista de soy luna";
            System.Console.WriteLine(dic["luna"]);
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
