using Entidades;
using Entidades.Enumerados;
using System.Globalization;

namespace WinFormsApp
{
    public partial class FrmInstalarWindows : FrmInstalar
    {
        
        public CheckBox CkeckVirtualizacionPermitida
        {
            get { return this.checkVirtualizacion; }
            set { this.checkVirtualizacion = value; }
        }
        public ComboBox CboEdicionWindows
        {
            get { return this.cboEdicion; }
            set { this.cboEdicion = value; }
        }
        public FrmInstalarWindows(List<SistemaOperativo> sistema) : base(sistema)
        {
            InitializeComponent();
            foreach (EEdicionWindows edicion in Enum.GetValues(typeof(EEdicionWindows)))
            {
                this.cboEdicion.Items.Add(edicion);
            }
            this.cboEdicion.SelectedItem = EEdicionWindows.Home;
            this.txtNombre.Text = "Windows";
        }

        protected override void btnInstalar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string version = this.txtVersion.Text;
            double espacio;
            string txtEspacio = this.txtEspacio.Text.Replace(',', '.');
            bool validacion_espacio = double.TryParse(txtEspacio, NumberStyles.Any, CultureInfo.InvariantCulture, out espacio);
            EEstadoSoporte soporte = (EEstadoSoporte)this.cboEstado.SelectedItem;
            EEdicionWindows edicion = (EEdicionWindows)this.cboEdicion.SelectedItem;
            bool virtualizacion = this.checkVirtualizacion.Checked;
            if (!validacion_espacio)
            {
                MessageBox.Show("Error al ingresar la cantidad de GB de espacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (String.IsNullOrWhiteSpace(version))
            {
                MessageBox.Show("No ingresó nada en el campo Version.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(String.IsNullOrWhiteSpace(nombre) && virtualizacion == false)
                {
                    Windows windows = new Windows(version, espacio, soporte, edicion);
                    this.sistemaOperativo = windows;
                }
                else if (String.IsNullOrWhiteSpace(nombre))
                {
                    Windows windows = new Windows(version, espacio, soporte, edicion, virtualizacion);
                    this.sistemaOperativo = windows;
                }else if(virtualizacion == false)
                {
                    Windows windows = new Windows(nombre,version, espacio, soporte, edicion);
                    this.sistemaOperativo = windows;
                }
                else
                {
                    Windows windows = new Windows(nombre, version, espacio, soporte, edicion, virtualizacion);
                    this.sistemaOperativo = windows;

                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
