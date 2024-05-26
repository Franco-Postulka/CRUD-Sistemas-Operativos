using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WinFormsApp
{
    public partial class FrmInstalarMac : FrmInstalar
    {
        public FrmInstalarMac()
        {
            InitializeComponent();
        }
        public FrmInstalarMac(List<SistemaOperativo> lista) :base(lista) 
        {
            InitializeComponent();
        }

        protected override void btnInstalar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string version = this.txtVersion.Text;
            double espacio;

            string txtEspacio = this.txtEspacio.Text.Replace(',', '.');
            bool validacion_espacio = double.TryParse(txtEspacio, NumberStyles.Any, CultureInfo.InvariantCulture, out espacio);
            bool compatible_Apple = this.checkCompatibleApple.Checked;
            EEstadoSoporte soporte = (EEstadoSoporte)this.cboEstado.SelectedItem;
            bool integracionIcloud = this.checkIntegracion.Checked;
            if (validacion_espacio)
            {
                MacOS mac = new MacOS(nombre,version,espacio,compatible_Apple,soporte,integracionIcloud);
                bool existe = false;
                foreach (SistemaOperativo sistema in this.ListaSistemasOperativos)
                {
                    if (mac.Equals(sistema))
                    {
                        existe = true;
                    }
                }
                if (existe)
                {
                    MessageBox.Show("El sistema que desea instalar ya existe.");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    this.ListaSistemasOperativos.Add(mac);
                    MessageBox.Show(mac.Descargar());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error al ingresar la cantidad de GB de espacio.");
            }
        }

    }
}
