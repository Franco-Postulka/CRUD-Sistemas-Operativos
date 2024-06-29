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

        public void OrdenarListaPorGBAscendente()
        {
            List<SistemaOperativo> lista = this.ListaSistemasOperativos;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (lista[i].EspacioGB > lista[j].EspacioGB)
                    {
                        SistemaOperativo sistemai = lista[i];
                        lista[i] = lista[j];
                        lista[j] = sistemai;
                    }
                }
            }
            this.sistemasOperativos = lista;
        }

        public void OrdenarListaPorGBDescendenete()
        {
            this.OrdenarListaPorGBAscendente();
            this.ListaSistemasOperativos.Reverse();
        }

        /// <summary>
        /// Compara los nombres del sistema operativo y los ordena de manera ascendente (de la A a la Z)
        /// </summary>
        public void OrdenarListaAlfabeticamenteAscendente()
        {
            List<SistemaOperativo> lista = this.ListaSistemasOperativos;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    int comparacion = String.Compare(lista[i].Nombre, lista[j].Nombre);
                    if (comparacion > 0) //el primer string va despues alfabeticamente
                    {
                        SistemaOperativo sistemai = lista[i];
                        lista[i] = lista[j];
                        lista[j] = sistemai;
                    }
                }
            }
            this.sistemasOperativos = lista;
        }
        /// <summary>
        /// Compara los nombres del sistema operativo y los ordena de manera descendente (de la Z a la A)
        /// </summary>
        public void OrdenarListaAlfabeticamenteDescendente()
        {
            this.OrdenarListaAlfabeticamenteAscendente();
            
            this.ListaSistemasOperativos.Reverse();
        }
    }
}
