using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postulka.Franco.PrimerParcial
{
    internal class Windows : SistemaOperativo
    {
        private EdicionWindows edicion;
        private bool virtualizacionPermitida;

        public EdicionWindows Edicion { get; }
        public bool VirtualizacionPermitida { get; }

        public Windows(string nombre, string version, double espacio, EstadoSoporte soporte, EdicionWindows edicion, bool virtualizacion):base(nombre,version,espacio,soporte)
        {
            this.edicion = edicion;
            this.virtualizacionPermitida = virtualizacion;
        }
    }
}
