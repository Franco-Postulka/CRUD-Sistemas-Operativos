using Entidades.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La deben implementar clases de tipo SistemaOperativo 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface ISistema<T> where T : SistemaOperativo
    {
        string DevolverInformacionEspecifica();
        string Descargar();

        public string Nombre { get; set; }
        public string Version { get; set; }
        public double EspacioGB { get; set; }
        public EEstadoSoporte Soporte { get; set; }
        public int Id { get; set; }
    }
}
