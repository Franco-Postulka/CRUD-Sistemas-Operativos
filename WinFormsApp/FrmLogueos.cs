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

namespace WinFormsApp
{
    public partial class FrmLogueos : Form
    {
        private string rutaUsuariosLogueados = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "usuarios.log");
        public FrmLogueos()
        {
            InitializeComponent();
            actualizarListbox();
        }

        private void actualizarListbox()
        {
            try
            {
                using (StreamReader reader = new StreamReader(this.rutaUsuariosLogueados))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lstBox.Items.Add(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("El archivo no existe.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al leer el archivo: " + ex.Message);
            }
        }
    }
}
