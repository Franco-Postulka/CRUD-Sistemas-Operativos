using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postulka.Franco.PrimerParcial
{
    internal class MacOS:SistemaOperativo
    {
        private bool integracionIcloud;
        private bool compatibleConProcesadorApple;

        public bool IntegracionIcloud { get;}
        public bool CompatibleConProcesadorApple {  get;}

        public MacOS(string nombre, string version, double espacio, EstadoSoporte soporte,bool integracionIcloud,bool compatibleApple):base(nombre,version,espacio,soporte)
        {
            this.integracionIcloud = integracionIcloud;
            this.compatibleConProcesadorApple = compatibleApple;
        }
    }
}
