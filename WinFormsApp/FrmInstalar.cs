using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace WinFormsApp
{
    public partial class FrmInstalar : Form
    {
        protected string xmlpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SO.xml");
        protected List<SistemaOperativo> sistemasOperativos;
        public List<SistemaOperativo> ListaSistemasOperativos
        {
            get { return this.sistemasOperativos; }
            set { this.sistemasOperativos = value; }
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

        protected virtual void btnInstalar_Click(object sender, EventArgs e)
        {

        }
    }
}
