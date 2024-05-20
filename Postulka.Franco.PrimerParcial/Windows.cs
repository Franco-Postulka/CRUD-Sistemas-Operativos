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
            /// <summary>
            /// constructor con todos los parametros
            /// </summary>
            this.edicion = edicion;
            this.virtualizacionPermitida = virtualizacion;
        }

        public Windows( string version, double espacio, EstadoSoporte soporte, EdicionWindows edicion, bool virtualizacion) : base("Windows", version, espacio, soporte)
        {
            /// <summary>
            /// constructor sin nombre como parametro (se asigna como Windows)
            /// </summary>
            this.edicion = edicion;
            this.virtualizacionPermitida = virtualizacion;
        }
        public Windows(string nombre, string version, double espacio, EstadoSoporte soporte, EdicionWindows edicion) : base(nombre, version, espacio, soporte)
        {
            /// <summary>
            /// constructor sin virtualizacion como parametro (lo asigna como true)
            /// </summary>
            this.edicion = edicion;
            this.virtualizacionPermitida = true;
        }
        public Windows( string version, double espacio, EstadoSoporte soporte, EdicionWindows edicion) : base("Windows", version, espacio, soporte)
        {
            /// <summary>
            /// constructor sin virtualizacion y sin nombre como parametro (lo asigna como true y Windows)
            /// </summary>
            this.edicion = edicion;
            this.virtualizacionPermitida = true;
        }

        public override string DevolverInformacionEspecifica()
        {
            string aceptavirtualizacion = "No";
            if (this.VirtualizacionPermitida)
            {
                aceptavirtualizacion = "si";
            }

            return $"El SO {this.Nombre} tiene las siguientes caracteristicas:\n" +
                $"Version: {this.Version}\n" +
                $"Edicion: {this.Edicion}\n" +
                $"Soporte: {this.Soporte}\n" +
                $"Ocupa:{this.EspacioGB}" +
                $"Permite virtualizacion: {aceptavirtualizacion}";
        }
        public override string ToString()
        {
            return this.DevolverInformacionEspecifica();
        }

        public static bool operator ==(Windows unwindows, Windows otrowindows)
        {
            return (unwindows.Version == otrowindows.Version && unwindows.Edicion == otrowindows.Edicion);
        }
        public static bool operator !=(Windows unwindows, Windows otrowindows)
        {
            return !(unwindows == otrowindows);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                return (this == (Windows)obj);
            }
        }
    }
}
