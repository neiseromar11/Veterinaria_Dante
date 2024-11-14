using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    public class Nodo
    {
        public Mascota Dato { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(Mascota mascota)
        {
            Dato = mascota;
            Izquierdo = null;
            Derecho = null;
        }
    }
}
