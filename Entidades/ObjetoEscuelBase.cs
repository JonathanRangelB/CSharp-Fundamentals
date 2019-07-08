using System;

namespace CoreEscuela.Entidades
{
    //el hecho que sea clase abstracta nos indica que no se puede instanciar un objeto de esta clase, y se queda como una "idea abstracta" no como algo instanciable
    //es exactamente lo contrario al modificador de clase sealed, que ese si nos deja instanciar pero no heredar
    public abstract class ObjetoEscuelBase
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }

        public ObjetoEscuelBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}