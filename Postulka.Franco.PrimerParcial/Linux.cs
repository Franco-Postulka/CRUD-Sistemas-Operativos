using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postulka.Franco.PrimerParcial
{
    internal class Linux : SistemaOperativo
    {
        private DistribucionLinux distribucion;
        private bool interfazGrafica;

        public DistribucionLinux Distribucion { get; }
        public bool InterfazGrafica { get; }

        public Linux(string nombre, string version, double espacioGB, EstadoSoporte soporte, DistribucionLinux distribucion, bool interfaz) : base(nombre, version, espacioGB, soporte)
        {
            /// <summary>
            /// constructor con todos los parametros
            /// </summary>
            this.distribucion = distribucion;
            this.interfazGrafica = interfaz;
        }

        public Linux(string version, double espacioGB, EstadoSoporte soporte, DistribucionLinux distribucion, bool interfaz) : base("Linux", version, espacioGB, soporte)
        {
            /// <summary>
            /// constructor sin nombre de parametro (se asigna como Linux)
            /// </summary>
            this.distribucion = distribucion;
            this.interfazGrafica = interfaz;
        }
        public Linux(string nombre, string version, double espacioGB, EstadoSoporte soporte, DistribucionLinux distribucion) : base(nombre, version, espacioGB, soporte)
        {
            /// <summary>
            /// constructor sin interfaz como parametro (se asigna como true)
            /// </summary>
            this.distribucion = distribucion;
            this.interfazGrafica = true;
        }
        public Linux(string version, double espacioGB, EstadoSoporte soporte, DistribucionLinux distribucion) : base("Linux", version, espacioGB, soporte)
        {
            /// <summary>
            /// constructor sin interfaz como parametro y sin nombre (se asigna como true y Linux)
            /// </summary>
            this.distribucion = distribucion;
            this.interfazGrafica = true;
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
            return this.DevolverInformacionEspecifica();
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
