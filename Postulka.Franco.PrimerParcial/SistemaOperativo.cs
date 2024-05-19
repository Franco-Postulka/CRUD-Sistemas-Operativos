using System.Xml;

namespace Postulka.Franco.PrimerParcial
{
    public abstract class SistemaOperativo
    {
        private string nombre;
        private string version;
        private double espacioGB;
        private EstadoSoporte estadoSoporte;

        public string Nombre { get;}
        public string Version { get;}
        public double EspacioGB { get;}
        public double Soporte { get; } 

        public SistemaOperativo(string nombre, string version, double espacio,EstadoSoporte soporte)
        {
            this.nombre = nombre;
            this.version = version;
            this.EspacioGB = espacio;
            this.estadoSoporte = soporte;
        }
       //public abstract bool ComprobarAlmacenamientoNecesario();

        //public abstract string Instalar();
    }
}
