using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NoValidadoExcepcion : Exception
    {
        public NoValidadoExcepcion() : base() { }
        public NoValidadoExcepcion(string message) : base(message) { }
    }
}
