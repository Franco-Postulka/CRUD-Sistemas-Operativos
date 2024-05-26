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
            set { this.computadora = value;}
        }
        public FrmPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true; 
            this.computadora = new Computadora();
            ActualizarVisor();  
        }

        private void instalarWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarWindows instalarWindows = new FrmInstalarWindows(this.computadora.ListaSistemasOperativos);
            instalarWindows.ShowDialog(this);
            if(instalarWindows.DialogResult == DialogResult.OK)
            {
                this.computadora.ListaSistemasOperativos = instalarWindows.ListaSistemasOperativos;
                using (XmlTextWriter writer = new XmlTextWriter(this.xmlpath, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<SistemaOperativo>));
                    ser.Serialize(writer, this.computadora.ListaSistemasOperativos);
                }
                this.ActualizarVisor();
            }
        }

        private void ActualizarVisor()
        {
            this.lstBox.Items.Clear();
            if(File.Exists(this.xmlpath))
            {
                using (XmlTextReader reader = new XmlTextReader(this.xmlpath))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<SistemaOperativo>));
                    this.computadora.ListaSistemasOperativos = (List<SistemaOperativo>)ser.Deserialize(reader);
                }
                foreach (SistemaOperativo sistema in this.computadora.ListaSistemasOperativos)
                {
                    this.lstBox.Items.Add(sistema.ToString());
                }
            }
        }
    }
}
