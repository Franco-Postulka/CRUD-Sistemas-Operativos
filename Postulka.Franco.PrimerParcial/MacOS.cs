using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class MacOS:SistemaOperativo
    {
        private bool integracionIcloud;
        private bool compatibleConProcesadorApple;

        public bool IntegracionIcloud { get;}
        public bool CompatibleConProcesadorApple {  get;}

        public MacOS(string nombre, string version, double espacio, bool compatibleApple, EEstadoSoporte soporte,bool integracionIcloud)
            :base(nombre,version,espacio,soporte)
        {
            /// <summary>
            /// constructor con todos los parametros
            /// </summary>
            this.integracionIcloud = integracionIcloud;
            this.compatibleConProcesadorApple = compatibleApple;
        }
        public MacOS(string nombre, string version, double espacio, bool compatibleApple, EEstadoSoporte soporte) 
            : this(nombre, version, espacio, compatibleApple,soporte,true)
        {
            /// <summary>
            /// constructor sin el parametro integracionIcloud (se asigna true)
            /// </summary>
        }
        public MacOS(string nombre, string version, double espacio, EEstadoSoporte soporte, bool integracionIcloud) 
            : this(nombre, version, espacio, true, soporte, integracionIcloud)
        {
            /// <summary>
            /// constructor sin el parametro compatibleApple (se asigna true )
            /// </summary>
        }

        public MacOS(string nombre, string version, double espacio,EEstadoSoporte soporte) 
            : this(nombre, version, espacio, true, soporte, true)
        {
            /// <summary>
            /// constructor sin los parametros compatibleApple e integracionIcloud (se asigna true  y true)
            /// </summary>
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

        public override string Descargar()
        {
            return $"Sistema operativo MacOS {this.Nombre} instalado";
        }

        public override string ToString()
        {
            return this.DevolverInformacionEspecifica();
        }
        public static bool operator ==(MacOS unMac, MacOS otroMac)
        {
            return (unMac.Nombre == otroMac.Nombre && unMac.Version == otroMac.Version);
        }
        public static bool operator !=(MacOS unMac, MacOS otroMac)
        {
            return !(unMac == otroMac);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                return (this == (MacOS)obj);
            }
        }
    }
}
