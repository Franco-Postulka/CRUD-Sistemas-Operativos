using Entidades;
using System.Globalization;

namespace WinFormsApp
{
    public partial class FrmInstalarLinux : FrmInstalar
    {
        public CheckBox CheckInterfazGrafica
        {
            get { return this.checkInterfaz; }
            set { this.checkInterfaz = value; }
        }

        public ComboBox CboDistribucion
        {
            get { return this.cboDistribucion; }
            set { this.cboDistribucion = value; }
        }
        public FrmInstalarLinux()
        {
            InitializeComponent();
        }

        public FrmInstalarLinux(List<SistemaOperativo> sistema) : base(sistema)
        {
            InitializeComponent();
            foreach (EDistribucionLinux distribucion in Enum.GetValues(typeof(EDistribucionLinux)))
            {
                this.cboDistribucion.Items.Add(distribucion);
            }
            this.cboDistribucion.SelectedItem = EDistribucionLinux.Ubuntu;
            this.txtNombre.Text = "Linux";
        }

        private void btnInstalar_Click_1(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string version = this.txtVersion.Text;
            double espacio;
            string txtEspacio = this.txtEspacio.Text.Replace(',', '.');
            bool validacion_espacio = double.TryParse(txtEspacio, NumberStyles.Any, CultureInfo.InvariantCulture, out espacio);
            EEstadoSoporte soporte = (EEstadoSoporte)this.cboEstado.SelectedItem;

            EDistribucionLinux distribucionLinux = (EDistribucionLinux)this.cboDistribucion.SelectedItem;
            bool interfaz = this.checkInterfaz.Checked;
            if (!validacion_espacio)
            {
                MessageBox.Show("Error al ingresar la cantidad de GB de espacio.","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (version == "")
            {
                MessageBox.Show("No ingresó nada en el campo Version.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (nombre == "" && interfaz == false)
                {
                    Linux linux = new Linux(version, espacio, soporte, distribucionLinux);
                    this.sistemaOperativo = linux;
                }
                else if(nombre == "")
                {
                    Linux linux = new Linux(version, espacio, soporte, distribucionLinux, interfaz);
                    this.sistemaOperativo = linux;
                }
                else if(interfaz == false)
                {
                    Linux linux = new Linux(nombre, version, espacio, soporte, distribucionLinux);
                    this.sistemaOperativo = linux;
                }
                else
                {
                    Linux linux = new Linux(nombre, version, espacio, soporte, distribucionLinux, interfaz);
                    this.sistemaOperativo = linux;

                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
