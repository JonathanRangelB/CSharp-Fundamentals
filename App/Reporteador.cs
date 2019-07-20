using System.Collections.Generic;
using CoreEscuela.Entidades;
using System;
using System.Linq;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObjEsc));
            }
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            return new List<Evaluacion>();
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out IEnumerable<Evaluacion> dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();
            return (from ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvalXAsig()
        {
            var listaAsig = GetListaAsignaturas(out var listaEval);
            var dicRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            foreach (var asig in listaAsig)
            {
                var evalAsig = from eval in listaEval
                               where eval.Asignatura.Nombre == asig
                               select eval;
                dicRta.Add(asig, evalAsig);
            }
            return dicRta;
        }

        public Dictionary<String, IEnumerable<Object>> GetPromedioAlumnoPorAsignatura()
        {
            var rta = new Dictionary<String, IEnumerable<Object>>();
            var dicEvalXAsig = GetDicEvalXAsig();
            foreach (var asigConEval in dicEvalXAsig)
            {
                var promAlumn = from eval in asigConEval.Value
                                group eval by new { eval.Alumno.UniqueId, eval.Alumno.Nombre }
                                into grupoEvalAlumno
                                select new AlumnoPromedio//poniendo entre corchetes esta parte se le conoce como objeto anonimo, que no tiene nombre y solo tiene valores, y no puede ser instanciada
                                {
                                    nombre = grupoEvalAlumno.Key.UniqueId,
                                    alumnoNombre = grupoEvalAlumno.Key.Nombre,
                                    promedio = grupoEvalAlumno.Average(x => x.Nota)
                                };
                rta.Add(asigConEval.Key, promAlumn);
            }
            return rta;
        }
    }
}