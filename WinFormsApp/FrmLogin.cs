using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FrmLogin : Form
    {
        private string path;
        public FrmLogin(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private bool ComprobarDatos()
        {
            bool retorno = false;
            string mail = this.txtEmail.Text;
            string clave = this.txtClave.Text;
            using (StreamReader streamreader = new StreamReader(this.path))
            {
                string jsonusUario = streamreader.ReadToEnd();
                List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonusUario);
                Console.WriteLine(usuarios[0].correo);
                foreach (Usuario usuario in usuarios)
                {
                    if (usuario.correo == mail && usuario.clave == clave)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool datos_validados = this.ComprobarDatos();
            if (datos_validados)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, "Email o clave erroneos, vuelva a ingresar los datos.");
                this.txtEmail.Text = "";
                this.txtClave.Text = "";
            }
        }
    }
}
