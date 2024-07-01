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

        public override void btnInstalar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar_datos();
                string nombre = this.txtNombre.Text.Replace(" ", "");
                string version = this.txtVersion.Text.Replace(" ", "");
                double espacio = double.Parse(this.txtEspacio.Text.Replace(',', '.'), CultureInfo.InvariantCulture);// YA SE VALIDO EN base.validar_datos();
                EEstadoSoporte soporte = (EEstadoSoporte)this.cboEstado.SelectedItem;
                EEdicionWindows edicion = (EEdicionWindows)this.cboEdicion.SelectedItem;
                bool virtualizacion = this.checkVirtualizacion.Checked;

                if (String.IsNullOrWhiteSpace(nombre) && virtualizacion == false)
                {
                    Windows windows = new Windows(version, espacio, soporte, edicion);
                    this.sistemaOperativo = windows;
                }
                else if (String.IsNullOrWhiteSpace(nombre))
                {
                    Windows windows = new Windows(version, espacio, soporte, edicion, virtualizacion);
                    this.sistemaOperativo = windows;
                }
                else if (virtualizacion == false)
                {
                    Windows windows = new Windows(nombre, version, espacio, soporte, edicion);
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
            catch (NoValidadoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
