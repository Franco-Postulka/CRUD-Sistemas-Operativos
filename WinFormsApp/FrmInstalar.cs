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
        public FrmInstalar()
        {
            InitializeComponent();
            foreach (EEstadoSoporte rango in Enum.GetValues(typeof(ERangos)))
            {
                this.cboRango.Items.Add(rango);
            }
            this.cboRango.SelectedItem = ERangos.Cliente;

        }
    }
}
