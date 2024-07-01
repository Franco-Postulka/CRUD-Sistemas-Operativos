using Entidades;
using Entidades.Enumerados;
using System.Globalization;

namespace WinFormsApp
{
    public partial class FrmInstalar : Form, IInstalar
    {
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
        }

        protected void validar_datos()
        {
            //valida el txtEspacio (que sea un numero) y que se haya completado el campo version 
            try
            {
                string nombre = this.txtNombre.Text;
                string version = this.txtVersion.Text;
                double espacio;
                string txtEspacio = this.txtEspacio.Text.Replace(',', '.');
                bool validacion_espacio = double.TryParse(txtEspacio, NumberStyles.Any, CultureInfo.InvariantCulture, out espacio);
                EEstadoSoporte soporte = (EEstadoSoporte)this.cboEstado.SelectedItem;

                if (!validacion_espacio)
                {
                    throw new NoValidadoExcepcion("Error al ingresar la cantidad de GB de espacio.");
                }
                else if (espacio <= 0)
                {
                    throw new NoValidadoExcepcion("Error al ingresar la cantidad de GB de espacio.");
                }
                else if (String.IsNullOrWhiteSpace(version))
                {
                    throw new NoValidadoExcepcion("No ingresó nada en el campo Version");
                }
            }
            catch (NoValidadoExcepcion ex)
            {
                throw new NoValidadoExcepcion(ex.Message);
            }
        }

        public virtual void btnInstalar_Click(object sender, EventArgs e) 
        {
            validar_datos();
        }
    }
}
