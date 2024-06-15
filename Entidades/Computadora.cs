using System.Data.Common;

namespace Entidades
{
    public class Computadora
    {
        private List<SistemaOperativo> sistemasOperativos;

        public List<SistemaOperativo> ListaSistemasOperativos
        {
            get { return this.sistemasOperativos; }
            set { this.sistemasOperativos = value; }
        }

        public Computadora()
        {
            this.sistemasOperativos = new List<SistemaOperativo>();
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

        public static Computadora operator +(Computadora computadora, SistemaOperativo unsistema)
        {
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
        public void OrdenarListaAlfabeticamenteDescendente()
        {
            this.OrdenarListaPorGBAscendente();
            this.ListaSistemasOperativos.Reverse();
        }
    }
}
