using System.Xml;
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

        public string Nombre { get; set; }
        public string Version { get; set; }
        public double EspacioGB { get; set; }
        public double Soporte { get; set; }

        
        public SistemaOperativo()
        {

        }
        public SistemaOperativo(string nombre, string version, double espacio,EEstadoSoporte soporte)
        {
            this.nombre = nombre;
            this.version = version;
            this.EspacioGB = espacio;
            this.estadoSoporte = soporte;
        }
        public abstract string DevolverInformacionEspecifica();

        public virtual string Descargar()
        {
            return $"Sistema operativo {this.Nombre}{this.Version} instalado";
        }

        public override string ToString()
        {
            return $"Sistema operativo {this.Nombre} {this.Version}";
        }
    }
}
