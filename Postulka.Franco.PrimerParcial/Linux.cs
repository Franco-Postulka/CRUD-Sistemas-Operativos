using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Linux : SistemaOperativo
    {
        private EDistribucionLinux distribucion;
        private bool interfazGrafica;

        public EDistribucionLinux Distribucion { get; set; }
        public bool InterfazGrafica { get; set; }

        public Linux()
        {

        }
        public Linux(string nombre, string version, double espacioGB, EEstadoSoporte soporte, EDistribucionLinux distribucion, bool interfaz) 
            : base(nombre, version, espacioGB, soporte)
        {
            /// <summary>
            /// constructor con todos los parametros
            /// </summary>
            this.distribucion = distribucion;
            this.interfazGrafica = interfaz;
        }

        public Linux(string version, double espacioGB, EEstadoSoporte soporte, EDistribucionLinux distribucion, bool interfaz)
            : this("Linux", version, espacioGB, soporte, distribucion, interfaz)
        {
            /// <summary>
            /// constructor sin nombre de parametro (se asigna como Linux)
            /// </summary>
        }
        public Linux(string nombre, string version, double espacioGB, EEstadoSoporte soporte, EDistribucionLinux distribucion) 
            : this(nombre, version, espacioGB, soporte, distribucion,true)
        {
            /// <summary>
            /// constructor sin interfaz como parametro (se asigna como true)
            /// </summary>
        }
        public Linux(string version, double espacioGB, EEstadoSoporte soporte, EDistribucionLinux distribucion) 
            : this("Linux", version, espacioGB, soporte, distribucion, true)
        {
            /// <summary>
            /// constructor sin nombre como parametro y sin interfaz (se asigna como Linux y true)
            /// </summary>
        }

        public override string DevolverInformacionEspecifica()
        {
            string interfaz = "No";
            if (this.InterfazGrafica == true)
            {
                interfaz = "Si";
            }

            return $"El SO {this.Nombre} tiene las siguientes caracteristicas:\n" +
                $"Distribucion: {this.Distribucion}\n" +
                $"Version: {this.Version}\n" +
                $"Ocupa: {this.EspacioGB} GB\n" +
                $"Soporte acutual: {this.Soporte}\n" +
                $"Tinene interfaz de usuario: {interfaz}\n";
        }

        public override string Descargar()
        {
            return $"Sistema operativo {this.Nombre} distribucion {this.Distribucion} instalado";
        }
        public override string ToString()
        {
            return $"{this.Nombre} distribucion {this.Distribucion} {this.Version}";
        }

        public static bool operator ==(Linux unlinux, Linux otrolinux)
        {
            return (unlinux.Distribucion == otrolinux.Distribucion && unlinux.Version == otrolinux.Version);
        }

        public static bool operator !=(Linux unlinux, Linux otrolinux)
        {
            return !(unlinux ==  otrolinux);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                return (this == (Linux)obj);
            }
        }
    }
}
