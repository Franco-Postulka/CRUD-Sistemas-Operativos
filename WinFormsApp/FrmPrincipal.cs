using ADO;
using Entidades;
using Entidades.Enumerados;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WinFormsApp
{
    public partial class FrmPrincipal : Form
    {
        private Computadora computadora;

        private string rutaxml = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "rutas.txt");
        private string pathXmlPredeterminado = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SO.xml");
        private string xmlpath;

        private Usuario usuario;
        private string rutaUsuariosLogueados = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "usuarios.log");

        //Declaro delegado para manejar el evento 
        public delegate void SistemaNoSeleccionadoEventHandler(object sender, EventArgs e);

        //Declaro el evento usando el delegado
        public event SistemaNoSeleccionadoEventHandler SistemaNoSeleccionado;

        //Declaro el metodo que dispara el evento
        private void OnSistemaNoSeleccionado(EventArgs e)
        {
            SistemaNoSeleccionado.Invoke(this, e);
        }

        public Computadora Computadora
        {
            get { return this.computadora; }
            set { this.computadora = value; }
        }
        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            AccesoDatos acceso = new AccesoDatos();
            int id = acceso.ObtenerUltimoIdGenerado();
            this.computadora = new Computadora(id);
            this.xmlpath = DevolverPathSerializacion();
            ActualizarVisor();

            this.usuario = usuario;
            DateTime date = DateTime.Now;
            GuardarDatosUsuario();
            this.toolStripStatusLabel.Text = $" Usuario logueado: {this.usuario.nombre}, fecha: {date.ToString("dd/MM/yyyy")}";

            //El metodo receptor se suscribe al evento.
            this.SistemaNoSeleccionado += new SistemaNoSeleccionadoEventHandler(Receptor_SistemaNoSeleccionado);
        }

        /// <summary>
        /// Suscriptor al evento SistemaNoSeleccionado, cuando se lanza el evento, se ejecuta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Receptor_SistemaNoSeleccionado(object sender, EventArgs e)
        {
            MessageBox.Show("Debe seleccionar un SO para poder realizar esta acción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Guarda los datos del usuario que inicio sesion en el archivo .log que gurada esa info (this.rutaUsuariosLogueados)
        /// </summary>
        private void GuardarDatosUsuario()
        {
            using (StreamWriter writer = new StreamWriter(this.rutaUsuariosLogueados, true))
            {
                Usuario usuario = this.usuario;
                string info = $"El {usuario.perfil} {usuario.nombre} {usuario.apellido}, legajo {usuario.legajo}, correo " +
                    $"{usuario.correo}. Ingresó el: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                writer.WriteLine(info);
            }
        }
        private void ActualizarVisor()
        {
            this.lstBox.Items.Clear();
            if (File.Exists(this.xmlpath))
            {
                this.DeserializarLista();
                foreach (SistemaOperativo sistema in this.computadora.ListaSistemasOperativos)
                {
                    this.lstBox.Items.Add(sistema.ToString());
                }
            }
        }

        /// <summary>
        /// recibe un lista que serializa en el archivo xml 
        /// </summary>
        /// <param name="lista"></param>
        private void SerializarLista(List<SistemaOperativo> lista)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(this.xmlpath, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<SistemaOperativo>));
                    ser.Serialize(writer, lista);
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show($"Error de XML durante la serialización: {ex.Message}", "Error de Serialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error de Serialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda un SO en la DB
        /// </summary>
        /// <param name="sistema"></param>
        private void GuardarEnDB(SistemaOperativo sistema)
        {
            AccesoDatos acceso = new AccesoDatos(); 
            bool agregado_correcto = acceso.AgregarSistema(sistema);
            if (!agregado_correcto)
            {
                MessageBox.Show($"El sistema operativo no se agregó correctamente en la base de datos",
                    "Error en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<SistemaOperativo> RetornarListaDB()
        {
            AccesoDatos acceso = new AccesoDatos();
            List<SistemaOperativo> sistemas =  acceso.ObtenerListaSistemas();
            return sistemas;
        }

        private void ModificarSistemaEnDB(SistemaOperativo sistema)
        {
            AccesoDatos acceso = new AccesoDatos();
            bool modificado_correcto = acceso.ModificarSistema(sistema);
            if (!modificado_correcto)
            {
                MessageBox.Show($"El sistema operativo no se modificó correctamente en la base de datos",
                    "Error en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarSistemaEnDB(SistemaOperativo sistema)
        {
            AccesoDatos acceso = new AccesoDatos();
            bool borrado_correcto = acceso.EliminarSistema(sistema.Id);
            if (!borrado_correcto) 
            {
                MessageBox.Show($"El sistema operativo no se borró correctamente en la base de datos",
                    "Error en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Deserializa el xml con la lista de SO y actualiza la lista de SO del atributo computadora.
        /// </summary>
        private void DeserializarLista()
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(this.xmlpath))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<SistemaOperativo>));
                    this.computadora.ListaSistemasOperativos = (List<SistemaOperativo>)ser.Deserialize(reader);
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show($"Error de XML durante la serialización: {ex.Message}", "Error de Serialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error de Serialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Eelimina el sistema seleccionado, si no se selecciono ninguno lanza el evento SistemaNoSeleccionado
        /// en el metodo OnSistemaNoSeleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminarSistemOperativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indice = this.lstBox.SelectedIndex;
            if (indice == -1)
            {
                this.OnSistemaNoSeleccionado(EventArgs.Empty);
            }
            else
            {
                DialogResult result = MessageBox.Show("Esta seguro que desea eliminar el SO?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SistemaOperativo sistemaOperativo = this.computadora.ListaSistemasOperativos[indice];
                    this.computadora -= sistemaOperativo;
                    this.BorrarSistemaEnDB(sistemaOperativo);
                    SerializarLista(this.Computadora.ListaSistemasOperativos);
                    ActualizarVisor();
                }
            }
            //if(this.usuario.perfil == "administrador")
            //{
            //}
            //else
            //{
            //    MessageBox.Show($"Solo los perfiles de administrador pueden eliminar, usted es {this.usuario.perfil}.",
            //        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        /// <summary>
        /// Recibe un formulario de instalacion, actualiza la lista del atributo computadora,
        /// serializa la lista y actualiza el visor
        /// </summary>
        /// <param name="frmInstalar"></param>
        private void ActualizarListas(FrmInstalar frmInstalar)
        {
            this.computadora += frmInstalar.SistemaOperativo;
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.GuardarEnDB(frmInstalar.SistemaOperativo);
            this.ActualizarVisor();
        }
        /// <summary>
        /// Recibe fomulario de instalacion, si el objeto SistemaOperativo del formulario esta en la lsita 
        /// de SO de la computadora, avisa al usuario, si no esta lo agrega con el metodo ActualizarListas
        /// </summary>
        /// <param name="frmInstalar"></param>
        private void ManejarFormularioInstalacion(FrmInstalar frmInstalar)
        {
            if (frmInstalar.DialogResult == DialogResult.OK)
            {
                bool existe = false;
                existe = this.computadora == frmInstalar.SistemaOperativo;
                if (existe)
                {
                    MessageBox.Show("El sistema que desea instalar ya existe.");
                }
                else
                {
                    MessageBox.Show(frmInstalar.SistemaOperativo.Descargar());
                    ActualizarListas(frmInstalar);
                }
            }

        }
        private void instalarWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarWindows instalarWindows = new FrmInstalarWindows(this.computadora.ListaSistemasOperativos);
            instalarWindows.ShowDialog(this);
            ManejarFormularioInstalacion(instalarWindows);
        }

        private void instalarMacOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarMac instalarMac = new FrmInstalarMac(this.computadora.ListaSistemasOperativos);
            instalarMac.ShowDialog(this);
            ManejarFormularioInstalacion(instalarMac);
        }

        private void instalarLinuxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstalarLinux instalarLinux = new FrmInstalarLinux(this.computadora.ListaSistemasOperativos);
            instalarLinux.ShowDialog(this);
            ManejarFormularioInstalacion(instalarLinux);
        }



        /// <summary>
        /// Revisa el sistema operativo que se selecciono y segun su tipo (Windows, MacOs o Linux), precompleta
        /// las clasillas de un fromulario de instalacion segun los atributos del SO seleccionado,
        /// muestra el formulario y modifica el sistema operativo con la nueva version.
        /// Si no se seleccionó ningun sistema lanza el evento SistemaNoSeleccionado en el metodo OnSistemaNoSeleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificarSistemaOperativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indice = this.lstBox.SelectedIndex;
            if (indice == -1)
            {
                this.OnSistemaNoSeleccionado(EventArgs.Empty);
            }
            else
            {
                SistemaOperativo sistema = computadora.ListaSistemasOperativos[indice];
                int id = sistema.Id;
                if (sistema.GetType() == typeof(Windows))
                {
                    Windows windows = (Windows)sistema;
                    FrmInstalarWindows frmInstalarWindows = new FrmInstalarWindows(this.computadora.ListaSistemasOperativos);
                    ConfigurarFormularioModificacion(windows, frmInstalarWindows);

                    frmInstalarWindows.CkeckVirtualizacionPermitida.Checked = windows.VirtualizacionPermitida;
                    frmInstalarWindows.CboEdicionWindows.SelectedItem = windows.Edicion;

                    ModificarSistema(frmInstalarWindows, indice, id);
                }
                else if (sistema.GetType() == typeof(MacOS))
                {
                    MacOS mac = (MacOS)sistema;
                    FrmInstalarMac frmInstalarMac = new FrmInstalarMac(this.computadora.ListaSistemasOperativos);
                    ConfigurarFormularioModificacion(mac, frmInstalarMac);
                    frmInstalarMac.CheckIntegracionIcloud.Checked = mac.IntegracionIcloud;
                    frmInstalarMac.CheckCompatibleApple.Checked = mac.CompatibleConProcesadorApple;

                    ModificarSistema(frmInstalarMac, indice, id);
                }
                else if (sistema.GetType() == typeof(Linux))
                {
                    Linux linux = (Linux)sistema;
                    FrmInstalarLinux frmInstalarLinux = new FrmInstalarLinux(this.computadora.ListaSistemasOperativos);
                    ConfigurarFormularioModificacion(linux, frmInstalarLinux);
                    frmInstalarLinux.CheckInterfazGrafica.Checked = linux.InterfazGrafica;
                    frmInstalarLinux.CboDistribucion.SelectedItem = linux.Distribucion;

                    ModificarSistema(frmInstalarLinux, indice, id);
                }
            }

        }

        /// <summary>
        /// Recibe un formulario de modificacion (el de instalacion precompletado) y el indice del sistema
        /// a modificar en la lista de la computadora(clase contenedora)
        /// Una vez completado el formulario correctamente se modifica el indice de la lista con la nueva version 
        /// del sitema, se serializa la lista y se actualiza el visor
        /// </summary>
        /// <param name="frmInstalar"></param>
        /// <param name="indice"></param>
        private void ModificarSistema(FrmInstalar frmInstalar, int indice, int id)
        {
            frmInstalar.ShowDialog();
            if (frmInstalar.DialogResult == DialogResult.OK)
            {
                frmInstalar.SistemaOperativo.Id = id;
                this.computadora.ListaSistemasOperativos[indice] = frmInstalar.SistemaOperativo;
                this.SerializarLista(this.computadora.ListaSistemasOperativos);
                this.ModificarSistemaEnDB(frmInstalar.SistemaOperativo);
                this.ActualizarVisor();
            }
        }
        /// <summary>
        /// Reutiliza el frmInstalar para modificar atributos de un SO, precompletando las
        /// casillas del formulario con los atributos del sistema que recibe por parametros.
        /// </summary>
        /// <param name="sistema"></param>
        /// <param name="frmInstalar"></param>
        private void ConfigurarFormularioModificacion(SistemaOperativo sistema, FrmInstalar frmInstalar)
        {
            string nombre = sistema.Nombre;
            string version = sistema.Version;
            double espacio = sistema.EspacioGB;
            EEstadoSoporte soporte = sistema.Soporte;
            frmInstalar.Text = $"Modificar {sistema.GetType().Name}";
            frmInstalar.TxtNombre.Text = nombre;
            frmInstalar.TxtVersion.Text = version;
            frmInstalar.TxtEspacio.Text = espacio.ToString();
            frmInstalar.CboEstadoSoporte.SelectedItem = soporte;
            frmInstalar.BtnInstalar.Text = "Modificar";
        }

        /// <summary>
        /// Ordena a lista de SO de manera descendente teniendo en cuenta el atributo Nombre, 
        /// serializa la lista y actualiza el visor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ascendenteAlfabeticamente_Click(object sender, EventArgs e)
        {
            this.computadora.OrdenarListaAlfabeticamenteAscendente();
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
            MessageBox.Show("Lista ordenada alfabéticamente de manera ascendente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Ordena a lista de SO de manera descendente teniendo en cuenta el atributo Nombre, 
        /// serializa la lista y actualiza el visor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descendenteAlfabeticamente_Click(object sender, EventArgs e)
        {
            this.computadora.OrdenarListaAlfabeticamenteDescendente();
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
            MessageBox.Show("Lista ordenada alfabéticamente de manera descendente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Ordena a lista de SO de manera ascendente teniendo en cuenta el atributo GB, 
        /// serializa la lista y actualiza el visor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ascendeteGB_Click(object sender, EventArgs e)
        {
            this.computadora.OrdenarListaPorGBAscendente();
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
            MessageBox.Show("Lista ordenada según GB de manera ascendente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Ordena a lista de SO de manera descendente teniendo en cuenta el atributo GB, 
        /// serializa la lista y actualiza el visor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descendenteGB_Click(object sender, EventArgs e)
        {
            this.computadora.OrdenarListaPorGBDescendenete();
            this.SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
            MessageBox.Show("Lista ordenada según GB de manera descendente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Abre cuadro de dialogo para confirmar si sl usuario quiere cerrar o no la app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea cerrar el formulario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Lee el archivo txt rutaxml que solo guarda el path de donde se serializan los SO
        /// Si el el archivo txt rutaxml no tiene nada o la ruta que tiene no existe inicializa 
        /// escribe en el txt la ruta del archivo.xml predeterminado, sino, retorna la ruta.
        /// Si el archivo donde esta la ruta del .xml no existe, lo crea y le escribe la ruta predeterminada
        /// </summary>
        /// <returns></returns>
        private string DevolverPathSerializacion()
        {
            try
            {
                string path;
                using (StreamReader reader = new StreamReader(this.rutaxml))
                {
                    path = reader.ReadLine();
                }
                if (path != null && File.Exists(path))
                {
                    return path;
                }
                else
                { //Si el archivo no esta porque lo eliminó o lo que sea
                    MessageBox.Show("Archivo de alamcenamiento no encontrado, se utilizará ubicacion predeterminada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    using (StreamWriter writer = new StreamWriter(this.rutaxml, false))
                    {
                        writer.Write(pathXmlPredeterminado);
                    }
                    return this.pathXmlPredeterminado;
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Archivo de rutas inexistente, se creará ubicacion predeterminada." +
                    "\nSi es la primera vez que abre la aplicacion, ignorar este mensaje.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (StreamWriter writer = new StreamWriter(this.rutaxml, false))
                {
                    writer.Write(pathXmlPredeterminado);
                }
                return this.pathXmlPredeterminado;
            }
        }
        /// <summary>
        /// Cambia la ruta del archivo .xml donde se serializan los objetos segun lo que elige el usuario
        /// serializa la lista y actualiza el visor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elegirUbicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path_nuevo = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos xml (*.xml)|*.xml";

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_nuevo = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(this.rutaxml, false))
                {
                    writer.Write(path_nuevo);
                    this.xmlpath = path_nuevo;
                }
                SerializarLista(this.computadora.ListaSistemasOperativos);
                this.ActualizarVisor();
            }
        }
        /// <summary>
        /// cambia la ruta del archivo xml a la ruta predeterminada, serializa la lista y actualiza el visor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ubicacionPredeterminadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (StreamWriter writer = new StreamWriter(this.rutaxml, false))
            {
                writer.Write(this.pathXmlPredeterminado);
                this.xmlpath = this.pathXmlPredeterminado;
            }
            SerializarLista(this.computadora.ListaSistemasOperativos);
            this.ActualizarVisor();
        }

        /// <summary>
        /// Abre formulario donde aparecen todos los logueos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verLogueosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogueos frmLogueos = new FrmLogueos();
            frmLogueos.ShowDialog();
        }

        /// <summary>
        /// Muestra la informacion especifica de un sistema operativo si el usuario selecciono uno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informaciónEspecíficaDelSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indice = this.lstBox.SelectedIndex;
            if (indice == -1)
            {
                MessageBox.Show("Debe seleccionar un SO para poder ver su información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SistemaOperativo sistema = computadora.ListaSistemasOperativos[indice];
                string info = (string)sistema; //Explicit usado en cada clase para usar el metodo DevolverInformacionEspecifica()
                MessageBox.Show(info, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
