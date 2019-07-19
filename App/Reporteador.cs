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

        public IEnumerable<Escuela> GetListaEvaluaciones(){
            var rta = _diccionario.TryGetValue(LlaveDiccionario.Escuela,out IEnumerable<ObjetoEscuelBase> lista);
            return lista.Cast<Escuela>();
        }
    }
}