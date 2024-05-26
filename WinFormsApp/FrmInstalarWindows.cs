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
using System.Xml;
using System.Xml.Serialization;

namespace WinFormsApp
{
    public partial class FrmInstalarWindows : FrmInstalar
    {
        public FrmInstalarWindows(List<SistemaOperativo> lista) : base(lista)
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
            bool validacion_espacio = double.TryParse(this.txtEspacio.Text, out espacio);
            EEstadoSoporte soporte = (EEstadoSoporte)this.cboEstado.SelectedItem;
            EEdicionWindows edicion = (EEdicionWindows)this.cboEdicion.SelectedItem;
            bool virtualizacion = this.checkVirtualizacion.Checked;
            if (validacion_espacio)
            {
                Windows windows = new Windows(nombre, version, espacio, soporte, edicion, virtualizacion);
                bool existe = false; 
                foreach (SistemaOperativo sistema in this.ListaSistemasOperativos)
                {
                    if (windows.Equals(sistema))
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
                    this.ListaSistemasOperativos.Add(windows);
                    MessageBox.Show(windows.Descargar());
                    this.DialogResult =DialogResult.OK;
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
