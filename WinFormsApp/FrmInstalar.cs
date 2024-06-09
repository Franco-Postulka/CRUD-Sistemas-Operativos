using Entidades;
using Entidades.Enumerados;
using System.Globalization;

namespace WinFormsApp
{
    public partial class FrmInstalar : Form
    {
        protected bool validacion_ingresos;
        protected string xmlpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SO.xml");
        protected SistemaOperativo sistemaOperativo;
        public SistemaOperativo SistemaOperativo { get { return this.sistemaOperativo; } set { this.sistemaOperativo = value; } }

        protected List<SistemaOperativo> sistemasOperativos;
        public List<SistemaOperativo> ListaSistemasOperativos
        {
            get { return this.sistemasOperativos; }
            set { this.sistemasOperativos = value; }
        }

        public TextBox TxtNombre
        {
            get { return this.txtNombre; }
            set { this.txtNombre = value; }
        }
        public TextBox TxtVersion
        {
            get { return this.txtVersion; }
            set { this.txtVersion = value; }
        }
        public TextBox TxtEspacio
        {
            get { return this.txtEspacio; }
            set { this.txtEspacio = value; }
        }
        public ComboBox CboEstadoSoporte
        {
            get { return this.cboEstado; }
            set { this.cboEstado = value; }
        }
        public Button BtnInstalar
        {
            get { return this.btnInstalar; }
            set { this.btnInstalar = value; }
        }
        public FrmInstalar()
        {
            InitializeComponent();
        }
        public FrmInstalar(List<SistemaOperativo> lista):this()
        {
            foreach (EEstadoSoporte estado in Enum.GetValues(typeof(EEstadoSoporte)))
            {
                this.cboEstado.Items.Add(estado);
            }
            this.cboEstado.SelectedItem = EEstadoSoporte.SoporteCompleto;

            this.sistemasOperativos = lista;
            this.validacion_ingresos = false;
        }

        protected void validar_datos()
        {
            //valida el txtEspacio (que sea un numero) y que se haya completado el campo version 
            string nombre = this.txtNombre.Text;
            string version = this.txtVersion.Text; 
            double espacio;
            string txtEspacio = this.txtEspacio.Text.Replace(',', '.');
            bool validacion_espacio = double.TryParse(txtEspacio, NumberStyles.Any, CultureInfo.InvariantCulture, out espacio);
            EEstadoSoporte soporte = (EEstadoSoporte)this.cboEstado.SelectedItem;

            if (!validacion_espacio)
            {
                MessageBox.Show("Error al ingresar la cantidad de GB de espacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (espacio <=0)
            {
                MessageBox.Show("Error al ingresar la cantidad de GB de espacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrWhiteSpace(version))
            {
                MessageBox.Show("No ingresó nada en el campo Version.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.validacion_ingresos = true;
            }
        }
    }
}
