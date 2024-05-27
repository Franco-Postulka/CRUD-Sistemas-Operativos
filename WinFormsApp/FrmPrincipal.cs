using Entidades;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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
            int indice = this.lstBox.SelectedIndex;
            if (indice == -1)
            {
                MessageBox.Show("Debe seleccionar un SO para poder eliminar.");
            }
            else
            {
                //this.Computadora.ListaSistemasOperativos.RemoveAt(this.lstBox.SelectedIndex);
                SistemaOperativo sistemaOperativo = this.computadora.ListaSistemasOperativos[indice];
                this.computadora -= sistemaOperativo;
                SerializarLista(this.Computadora.ListaSistemasOperativos);
                ActualizarVisor();
            }
        }

        /// <summary>
        /// Recibe un formulario de instalacion, actualiza la lista del atributo computadora,
        /// serializa la lsita y actualiza el visor
        /// </summary>
        /// <param name="frmInstalar"></param>
        private void ActualizarListas(FrmInstalar frmInstalar)
        {
            this.computadora += frmInstalar.SistemaOperativo;
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
        }
        /// <summary>
        /// Recibe fomulario de instalacion, si el objeto SistemaOperativo del formulario esta en la lsita 
        /// de SO de la computadora, avisa al usuario, si no esta lo agrega con el metodo ActualizarListas
        /// </summary>
        /// <param name="frmInstalar"></param>
        private void ManejarFormularioInstalacion(FrmInstalar frmInstalar)
        {
            if (frmInstalar.DialogResult == DialogResult.OK)
            {
                bool existe = false;
                existe = this.computadora == frmInstalar.SistemaOperativo;
                if (existe)
                {
                    MessageBox.Show("El sistema que desea instalar ya existe.");
                }
                else
                {
                    MessageBox.Show(frmInstalar.SistemaOperativo.Descargar());
                    ActualizarListas(frmInstalar);
                }
            }

        }
        private void instalarWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarWindows instalarWindows = new FrmInstalarWindows(this.computadora.ListaSistemasOperativos);
            instalarWindows.ShowDialog(this);
            ManejarFormularioInstalacion(instalarWindows);
        }

        private void instalarMacOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarMac instalarMac = new FrmInstalarMac(this.computadora.ListaSistemasOperativos);
            instalarMac.ShowDialog(this);
            ManejarFormularioInstalacion(instalarMac);
        }

        private void instalarLinuxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarLinux instalarLinux = new FrmInstalarLinux(this.computadora.ListaSistemasOperativos);
            instalarLinux.ShowDialog(this);
            ManejarFormularioInstalacion(instalarLinux);
        }



        private void modificarSistemaOperativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indice = this.lstBox.SelectedIndex;
            if (indice == -1)
            {
                MessageBox.Show("Debe seleccionar un SO para poder modificar.");
            }
            else
            {
                SistemaOperativo sistema = computadora.ListaSistemasOperativos[indice];
                if (sistema.GetType() == typeof(Windows))
                {
                    Windows windows = (Windows)sistema;
                    FrmInstalarWindows frmInstalarWindows = new FrmInstalarWindows(this.computadora.ListaSistemasOperativos);
                    ConfigurarFormularioModificacion(windows, frmInstalarWindows);

                    frmInstalarWindows.CkeckVirtualizacionPermitida.Checked = windows.VirtualizacionPermitida;
                    frmInstalarWindows.CboEdicionWindows.SelectedItem = windows.Edicion;

                    ModificarSistema(frmInstalarWindows, indice);
                }
                else if (sistema.GetType() == typeof(MacOS))
                {
                    MacOS mac = (MacOS)sistema;
                    FrmInstalarMac frmInstalarMac = new FrmInstalarMac(this.computadora.ListaSistemasOperativos);
                    ConfigurarFormularioModificacion(mac, frmInstalarMac);
                    frmInstalarMac.CheckIntegracionIcloud.Checked = mac.IntegracionIcloud;
                    frmInstalarMac.CheckCompatibleApple.Checked = mac.CompatibleConProcesadorApple;

                    ModificarSistema(frmInstalarMac, indice);
                }
                else if (sistema.GetType() == typeof(Linux))
                {
                    Linux linux = (Linux)sistema;
                    FrmInstalarLinux frmInstalarLinux = new FrmInstalarLinux(this.computadora.ListaSistemasOperativos);
                    ConfigurarFormularioModificacion(linux, frmInstalarLinux);
                    frmInstalarLinux.CheckInterfazGrafica.Checked = linux.InterfazGrafica;
                    frmInstalarLinux.CboDistribucion.SelectedItem = linux.Distribucion;

                    ModificarSistema(frmInstalarLinux, indice);
                }
            }

        }

        private void ModificarSistema(FrmInstalar frmInstalar, int indice)
        {
            frmInstalar.ShowDialog();
            if (frmInstalar.DialogResult == DialogResult.OK)
            {
                this.computadora.ListaSistemasOperativos[indice] = frmInstalar.SistemaOperativo;
                this.SerializarLista(this.computadora.ListaSistemasOperativos);
                this.ActualizarVisor();
            }
        }
        private void ConfigurarFormularioModificacion(SistemaOperativo sistema, FrmInstalar frmInstalar)
        {
            string nombre = sistema.Nombre;
            string version = sistema.Version;
            double espacio = sistema.EspacioGB;
            EEstadoSoporte soporte = sistema.Soporte;
            frmInstalar.Text = $"Modificar {sistema.GetType().Name}";
            frmInstalar.TxtNombre.Text = nombre;
            frmInstalar.TxtVersion.Text = version;
            frmInstalar.TxtEspacio.Text = espacio.ToString();
            frmInstalar.CboEstadoSoporte.SelectedItem = soporte;
            frmInstalar.BtnInstalar.Text = "Modificar";
        }

        private void ascendenteAlfabeticamente_Click(object sender, EventArgs e)
        {
            this.computadora.OrdenarListaAlfabeticamenteAscendente();
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
        }

        private void descendenteAlfabeticamente_Click(object sender, EventArgs e)
        {
            this.computadora.OrdenarListaAlfabeticamenteDescendente();
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
        }

        private void ascendeteGB_Click(object sender, EventArgs e)
        {
            this.computadora.OrdenarListaPorGBAscendente();
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
        }

        private void descendenteGB_Click(object sender, EventArgs e)
        {

            this.computadora.OrdenarListaPorGBDescendenete();
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
        }
    }
}
