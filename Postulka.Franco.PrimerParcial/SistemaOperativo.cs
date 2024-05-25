using System.Xml;

namespace Entidades
{
    public abstract class SistemaOperativo
    {
        private string nombre;
        private string version;
        private double espacioGB;
        private EEstadoSoporte estadoSoporte;

        public string Nombre { get;}
        public string Version { get;}
        public double EspacioGB { get;}
        public double Soporte { get; } 

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
            return this.DevolverInformacionEspecifica();
        }
    }
}
