using System.Text.Json;

namespace WinFormsApp
{
    public partial class FrmLogin : Form
    {
        private string path;
        private Usuario usuario;

        public Usuario Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
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
                        this.usuario = usuario;
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
