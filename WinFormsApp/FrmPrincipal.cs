using Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace WinFormsApp
{
    public partial class FrmPrincipal : Form
    {
        private Computadora computadora;
        protected string xmlpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SO.xml");


        public Computadora Computadora
        {
            get { return this.computadora; }
            set { this.computadora = value; }
        }
        public FrmPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.computadora = new Computadora();
            ActualizarVisor();
        }


        private void ActualizarVisor()
        {
            this.lstBox.Items.Clear();
            if (File.Exists(this.xmlpath))
            {
                this.DeserializarLista();
                foreach (SistemaOperativo sistema in this.computadora.ListaSistemasOperativos)
                {
                    this.lstBox.Items.Add(sistema.ToString());
                }
            }
        }

        /// <summary>
        /// recibe un lista que serializa en el archivo xml 
        /// </summary>
        /// <param name="lista"></param>
        private void SerializarLista(List<SistemaOperativo> lista)
        {
            using (XmlTextWriter writer = new XmlTextWriter(this.xmlpath, Encoding.UTF8))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<SistemaOperativo>));
                ser.Serialize(writer, lista);
            }
        }

        /// <summary>
        /// Deserializa el xml con la lista de SO y actualiza la lista de SO del atributo computadora.
        /// </summary>
        private void DeserializarLista()
        {

            using (XmlTextReader reader = new XmlTextReader(this.xmlpath))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<SistemaOperativo>));
                this.computadora.ListaSistemasOperativos = (List<SistemaOperativo>)ser.Deserialize(reader);
            }
        }

        private void eliminarSistemOperativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstBox.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un SO para poder eliminar.");
            }
            else
            {
                this.Computadora.ListaSistemasOperativos.RemoveAt(this.lstBox.SelectedIndex);
                SerializarLista(this.Computadora.ListaSistemasOperativos);
                ActualizarVisor();
            }
        }
        private void instalarWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarWindows instalarWindows = new FrmInstalarWindows(this.computadora.ListaSistemasOperativos);
            instalarWindows.ShowDialog(this);
            if (instalarWindows.DialogResult == DialogResult.OK)
            {
                this.computadora.ListaSistemasOperativos = instalarWindows.ListaSistemasOperativos;
                this.SerializarLista(this.computadora.ListaSistemasOperativos);
                this.ActualizarVisor();
            }
        }

        private void instalarMacOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarMac instalarMac = new FrmInstalarMac(this.computadora.ListaSistemasOperativos);
            instalarMac.ShowDialog(this);
            if(instalarMac.DialogResult  == DialogResult.OK)
            {
                this.computadora.ListaSistemasOperativos = instalarMac.ListaSistemasOperativos;
                this.SerializarLista(this.computadora.ListaSistemasOperativos);
                this.ActualizarVisor();
            }
        }
    }
}
