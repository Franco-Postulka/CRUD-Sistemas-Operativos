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

        public override string DevolverInformacionEspecifica()
        {
            string procesador = "Intel";
            if(this.CompatibleConProcesadorApple)
            {
                procesador = "Apple";
            }
            string tienICloud = "No";
            if (this.IntegracionIcloud)
            {
                tienICloud = "Si";
            }

            return $"El SO MacOS tiene las siguientes caracteristicas:\n" +
                $"Nombre: {this.Nombre}\n" +
                $"Version: {this.Version}\n" +
                $"Ocupa: {this.EspacioGB} GB\n" +
                $"Soporte actual {this.Soporte}\n" +
                $"Marca de procesado compatible:{procesador} \n" +
                $"Posee integracion con Icloud: {tienICloud}";

        }
    }
}
