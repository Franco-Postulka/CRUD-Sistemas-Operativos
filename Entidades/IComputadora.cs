using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal interface IComputadora<T>
    {
        List<T> Lista { get; set; }
        int ID { get; set; }
        void OrdenarLista(Comparison<T> comparison);
    }
}
