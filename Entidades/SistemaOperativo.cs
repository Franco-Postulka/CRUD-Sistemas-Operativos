using Entidades.Enumerados;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Windows))]
    [XmlInclude(typeof(Linux))]
    [XmlInclude(typeof(MacOS))]
    public abstract class SistemaOperativo
    {
        private string nombre;
        private string version;
        private double espacioGB;
        private EEstadoSoporte estadoSoporte;

        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Version { get { return this.version; } set { this.version = value; } }
        public double EspacioGB { get { return this.espacioGB; } set { this.espacioGB = value; } }
        public EEstadoSoporte Soporte { get { return this.estadoSoporte; } set { this.estadoSoporte = value; } }


        public SistemaOperativo()
        {
        }
        public SistemaOperativo(string nombre, string version, double espacio, EEstadoSoporte soporte)
        {
            this.nombre = nombre;
            this.version = version;
            this.EspacioGB = espacio;
            this.estadoSoporte = soporte;
        }
        public SistemaOperativo(string nombre, string version, double espacio) : this(nombre, version, espacio, EEstadoSoporte.SoporteCompleto)
        {
            ///Sobrecarga sin EEstadoSoporte como parametro, lo inicializa como EEstadoSoporte.SoporteCompleto 
        }
        public abstract string DevolverInformacionEspecifica();

        public virtual string Descargar()
        {
            return $"Sistema operativo {this.Nombre} {this.Version} instalado";
        }

        public override string ToString()
        {
            return $"Sistema de {this.espacioGB} GB, {this.estadoSoporte}, {this.Nombre} {this.Version}";
        }

        public static bool operator ==(SistemaOperativo sistema, SistemaOperativo otroSistema)
        {
            return (sistema.GetType().Name == otroSistema.GetType().Name && sistema.Nombre == otroSistema.Nombre && sistema.Version == otroSistema.Version);
        }
        public static bool operator !=(SistemaOperativo sistema, SistemaOperativo otroSistema)
        {
            return !(sistema == otroSistema);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                return (this == (SistemaOperativo)obj);
            }
        }
    }
}
