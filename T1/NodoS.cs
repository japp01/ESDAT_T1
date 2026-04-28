using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class NodoS
    {
        public Carro Dato { get; set; }
        public NodoS Anterior { get; set; }
        public NodoS Siguiente { get; set; }

        public NodoS(Carro carro)
        {
            Dato = carro;
        }
    }
}
