using System.Data.Common;

namespace Entidades
{
    public class Computadora
    {
        private List<SistemaOperativo> sistemasOperativos;
        private int id;

        public List<SistemaOperativo> ListaSistemasOperativos
        {
            get { return this.sistemasOperativos; }
            set { this.sistemasOperativos = value; }
        }
        public int ID { get { return this.id; } set {  this.id = value; } }

        public Computadora(int id)
        {
            this.sistemasOperativos = new List<SistemaOperativo>();
            this.id = id;
        }

        public static bool operator ==(Computadora computadora, SistemaOperativo unsistema)
        {
            bool retorno = false;
            foreach (SistemaOperativo sistemaOperativo in computadora.sistemasOperativos)
            {
                if (sistemaOperativo.Equals(unsistema)) //Usa el Equals sobreescrito de cada sistema operativo 
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Computadora computadora, SistemaOperativo unsistema)
        {
            return !(computadora == unsistema);
        }

        /// <summary>
        /// Agrega un sistema a la lista de computadores, incrementa el ID de la compu
        /// (para que sea paralelo a l DB) y le asigna el ID al sistema
        /// </summary>
        /// <param name="computadora"></param>
        /// <param name="unsistema"></param>
        /// <returns></returns>
        public static Computadora operator +(Computadora computadora, SistemaOperativo unsistema)
        {
            //aumentar el id estatico
            computadora.id += 1;
            //Agregar el atributo id al sistema
            unsistema.Id = computadora.id;
            if (computadora != unsistema)
            {
                computadora.sistemasOperativos.Add(unsistema);
            }
            return computadora;
        }
        public static Computadora operator -(Computadora computadora, SistemaOperativo unsistema)
        {
            if (computadora == unsistema)
            {
                computadora.sistemasOperativos.Remove(unsistema);
            }
            return computadora;
        }

        /// <summary>
        /// Recibe un Delegado Comparison y ordena la lista usando el metodo Sort(comparison)
        /// </summary>
        /// <param name="comparison"></param>
        public void OrdenarLista(Comparison<SistemaOperativo> comparison)
        {
            List<SistemaOperativo> lista = this.ListaSistemasOperativos;
            lista.Sort(comparison);
            this.sistemasOperativos = lista;
        }

        public void OrdenarListaPorGBAscendente() 
        {
            Comparison<SistemaOperativo> comparison = (SistemaOperativo s1,SistemaOperativo s2) => s1.EspacioGB.CompareTo(s2.EspacioGB);
            OrdenarLista(comparison);
        }
        public void OrdenarListaPorGBDescendenete() 
        {
            Comparison<SistemaOperativo> comparison = (SistemaOperativo s1, SistemaOperativo s2) => s2.EspacioGB.CompareTo(s1.EspacioGB);
            OrdenarLista(comparison);
        }
        public void OrdenarListaAlfabeticamenteAscendente()
        {
            Comparison<SistemaOperativo> comparison = (SistemaOperativo s1, SistemaOperativo s2) => String.Compare(s1.Nombre, s2.Nombre);
            OrdenarLista(comparison);
        }
        public void OrdenarListaAlfabeticamenteDescendente() 
        {
            Comparison<SistemaOperativo> comparison = (SistemaOperativo s1, SistemaOperativo s2) => String.Compare(s2.Nombre, s1.Nombre);
            OrdenarLista(comparison);
        }
    }
}
