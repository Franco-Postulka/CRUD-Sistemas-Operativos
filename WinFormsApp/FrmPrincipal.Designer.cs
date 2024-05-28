namespace WinFormsApp
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            instalarSsitemaOperativoToolStripMenuItem = new ToolStripMenuItem();
            instalarWindowsToolStripMenuItem = new ToolStripMenuItem();
            instalarMacOSToolStripMenuItem = new ToolStripMenuItem();
            instalarLinuxToolStripMenuItem = new ToolStripMenuItem();
            modificarSistemaOperativoToolStripMenuItem = new ToolStripMenuItem();
            eliminarSistemOperativoToolStripMenuItem = new ToolStripMenuItem();
            lstBox = new ListBox();
            menuOrdenar = new MenuStrip();
            ordenarToolStripMenuItem = new ToolStripMenuItem();
            ascendenteAlfabeticamente = new ToolStripMenuItem();
            descendenteAlfabeticamente = new ToolStripMenuItem();
            ordenarPorGBToolStripMenuItem = new ToolStripMenuItem();
            ascendeteGB = new ToolStripMenuItem();
            descendenteGB = new ToolStripMenuItem();
            guardarSOComoToolStripMenuItem = new ToolStripMenuItem();
            ubicacionPredeterminadaToolStripMenuItem = new ToolStripMenuItem();
            elegirUbicacionToolStripMenuItem = new ToolStripMenuItem();
            visualizadorToolStripMenuItem = new ToolStripMenuItem();
            verLogueosToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            menuStrip.SuspendLayout();
            menuOrdenar.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Anchor = AnchorStyles.Top;
            menuStrip.Dock = DockStyle.None;
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { instalarSsitemaOperativoToolStripMenuItem, modificarSistemaOperativoToolStripMenuItem, eliminarSistemOperativoToolStripMenuItem });
            menuStrip.Location = new Point(27, 9);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(709, 33);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // instalarSsitemaOperativoToolStripMenuItem
            // 
            instalarSsitemaOperativoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { instalarWindowsToolStripMenuItem, instalarMacOSToolStripMenuItem, instalarLinuxToolStripMenuItem });
            instalarSsitemaOperativoToolStripMenuItem.Name = "instalarSsitemaOperativoToolStripMenuItem";
            instalarSsitemaOperativoToolStripMenuItem.Size = new Size(220, 29);
            instalarSsitemaOperativoToolStripMenuItem.Text = "Instalar sitema sperativo";
            // 
            // instalarWindowsToolStripMenuItem
            // 
            instalarWindowsToolStripMenuItem.Name = "instalarWindowsToolStripMenuItem";
            instalarWindowsToolStripMenuItem.Size = new Size(250, 34);
            instalarWindowsToolStripMenuItem.Text = "Instalar Windows";
            instalarWindowsToolStripMenuItem.Click += instalarWindowsToolStripMenuItem_Click;
            // 
            // instalarMacOSToolStripMenuItem
            // 
            instalarMacOSToolStripMenuItem.Name = "instalarMacOSToolStripMenuItem";
            instalarMacOSToolStripMenuItem.Size = new Size(250, 34);
            instalarMacOSToolStripMenuItem.Text = "Instalar MacOS";
            instalarMacOSToolStripMenuItem.Click += instalarMacOSToolStripMenuItem_Click;
            // 
            // instalarLinuxToolStripMenuItem
            // 
            instalarLinuxToolStripMenuItem.Name = "instalarLinuxToolStripMenuItem";
            instalarLinuxToolStripMenuItem.Size = new Size(250, 34);
            instalarLinuxToolStripMenuItem.Text = "Instalar Linux";
            instalarLinuxToolStripMenuItem.Click += instalarLinuxToolStripMenuItem_Click;
            // 
            // modificarSistemaOperativoToolStripMenuItem
            // 
            modificarSistemaOperativoToolStripMenuItem.Name = "modificarSistemaOperativoToolStripMenuItem";
            modificarSistemaOperativoToolStripMenuItem.Size = new Size(249, 29);
            modificarSistemaOperativoToolStripMenuItem.Text = "Modificar sistema operativo";
            modificarSistemaOperativoToolStripMenuItem.Click += modificarSistemaOperativoToolStripMenuItem_Click;
            // 
            // eliminarSistemOperativoToolStripMenuItem
            // 
            eliminarSistemOperativoToolStripMenuItem.Name = "eliminarSistemOperativoToolStripMenuItem";
            eliminarSistemOperativoToolStripMenuItem.Size = new Size(232, 29);
            eliminarSistemOperativoToolStripMenuItem.Text = "Eliminar Sistem Operativo";
            eliminarSistemOperativoToolStripMenuItem.Click += eliminarSistemOperativoToolStripMenuItem_Click;
            // 
            // lstBox
            // 
            lstBox.FormattingEnabled = true;
            lstBox.ItemHeight = 25;
            lstBox.Location = new Point(27, 57);
            lstBox.Name = "lstBox";
            lstBox.Size = new Size(709, 304);
            lstBox.TabIndex = 1;
            // 
            // menuOrdenar
            // 
            menuOrdenar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            menuOrdenar.Dock = DockStyle.None;
            menuOrdenar.ImageScalingSize = new Size(24, 24);
            menuOrdenar.Items.AddRange(new ToolStripItem[] { ordenarToolStripMenuItem, ordenarPorGBToolStripMenuItem, guardarSOComoToolStripMenuItem, visualizadorToolStripMenuItem });
            menuOrdenar.Location = new Point(72, 376);
            menuOrdenar.Name = "menuOrdenar";
            menuOrdenar.Size = new Size(788, 33);
            menuOrdenar.TabIndex = 2;
            menuOrdenar.Text = "menuStrip1";
            // 
            // ordenarToolStripMenuItem
            // 
            ordenarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ascendenteAlfabeticamente, descendenteAlfabeticamente });
            ordenarToolStripMenuItem.Name = "ordenarToolStripMenuItem";
            ordenarToolStripMenuItem.Size = new Size(223, 29);
            ordenarToolStripMenuItem.Text = "Ordenar alfabéticamente";
            // 
            // ascendenteAlfabeticamente
            // 
            ascendenteAlfabeticamente.Name = "ascendenteAlfabeticamente";
            ascendenteAlfabeticamente.Size = new Size(216, 34);
            ascendenteAlfabeticamente.Text = "Ascendente";
            ascendenteAlfabeticamente.Click += ascendenteAlfabeticamente_Click;
            // 
            // descendenteAlfabeticamente
            // 
            descendenteAlfabeticamente.Name = "descendenteAlfabeticamente";
            descendenteAlfabeticamente.Size = new Size(216, 34);
            descendenteAlfabeticamente.Text = "Descendente";
            descendenteAlfabeticamente.Click += descendenteAlfabeticamente_Click;
            // 
            // ordenarPorGBToolStripMenuItem
            // 
            ordenarPorGBToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ascendeteGB, descendenteGB });
            ordenarPorGBToolStripMenuItem.Name = "ordenarPorGBToolStripMenuItem";
            ordenarPorGBToolStripMenuItem.Size = new Size(153, 29);
            ordenarPorGBToolStripMenuItem.Text = "Ordenar por GB";
            // 
            // ascendeteGB
            // 
            ascendeteGB.Name = "ascendeteGB";
            ascendeteGB.Size = new Size(216, 34);
            ascendeteGB.Text = "Ascendete";
            ascendeteGB.Click += ascendeteGB_Click;
            // 
            // descendenteGB
            // 
            descendenteGB.Name = "descendenteGB";
            descendenteGB.Size = new Size(216, 34);
            descendenteGB.Text = "Descendente";
            descendenteGB.Click += descendenteGB_Click;
            // 
            // guardarSOComoToolStripMenuItem
            // 
            guardarSOComoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubicacionPredeterminadaToolStripMenuItem, elegirUbicacionToolStripMenuItem });
            guardarSOComoToolStripMenuItem.Name = "guardarSOComoToolStripMenuItem";
            guardarSOComoToolStripMenuItem.Size = new Size(171, 29);
            guardarSOComoToolStripMenuItem.Text = "Guardar SO como";
            // 
            // ubicacionPredeterminadaToolStripMenuItem
            // 
            ubicacionPredeterminadaToolStripMenuItem.Name = "ubicacionPredeterminadaToolStripMenuItem";
            ubicacionPredeterminadaToolStripMenuItem.Size = new Size(322, 34);
            ubicacionPredeterminadaToolStripMenuItem.Text = "Ubicacion predeterminada";
            ubicacionPredeterminadaToolStripMenuItem.Click += ubicacionPredeterminadaToolStripMenuItem_Click;
            // 
            // elegirUbicacionToolStripMenuItem
            // 
            elegirUbicacionToolStripMenuItem.Name = "elegirUbicacionToolStripMenuItem";
            elegirUbicacionToolStripMenuItem.Size = new Size(322, 34);
            elegirUbicacionToolStripMenuItem.Text = "Elegir ubicacion ";
            elegirUbicacionToolStripMenuItem.Click += elegirUbicacionToolStripMenuItem_Click;
            // 
            // visualizadorToolStripMenuItem
            // 
            visualizadorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verLogueosToolStripMenuItem });
            visualizadorToolStripMenuItem.Name = "visualizadorToolStripMenuItem";
            visualizadorToolStripMenuItem.Size = new Size(53, 29);
            visualizadorToolStripMenuItem.Text = "Ver";
            // 
            // verLogueosToolStripMenuItem
            // 
            verLogueosToolStripMenuItem.Name = "verLogueosToolStripMenuItem";
            verLogueosToolStripMenuItem.Size = new Size(182, 34);
            verLogueosToolStripMenuItem.Text = "Logueos";
            verLogueosToolStripMenuItem.Click += verLogueosToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(764, 32);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(179, 25);
            toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 460);
            Controls.Add(statusStrip1);
            Controls.Add(lstBox);
            Controls.Add(menuStrip);
            Controls.Add(menuOrdenar);
            MainMenuStrip = menuStrip;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistemas Operativos";
            FormClosing += FrmPrincipal_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            menuOrdenar.ResumeLayout(false);
            menuOrdenar.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem instalarSsitemaOperativoToolStripMenuItem;
        private ToolStripMenuItem instalarWindowsToolStripMenuItem;
        private ToolStripMenuItem instalarMacOSToolStripMenuItem;
        private ToolStripMenuItem instalarLinuxToolStripMenuItem;
        private ToolStripMenuItem modificarSistemaOperativoToolStripMenuItem;
        private ToolStripMenuItem eliminarSistemOperativoToolStripMenuItem;
        private ListBox lstBox;
        private MenuStrip menuOrdenar;
        private ToolStripMenuItem ordenarToolStripMenuItem;
        private ToolStripMenuItem ascendenteAlfabeticamente;
        private ToolStripMenuItem descendenteAlfabeticamente;
        private ToolStripMenuItem ordenarPorGBToolStripMenuItem;
        private ToolStripMenuItem ascendeteGB;
        private ToolStripMenuItem descendenteGB;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripMenuItem guardarSOComoToolStripMenuItem;
        private ToolStripMenuItem ubicacionPredeterminadaToolStripMenuItem;
        private ToolStripMenuItem elegirUbicacionToolStripMenuItem;
        private ToolStripMenuItem visualizadorToolStripMenuItem;
        private ToolStripMenuItem verLogueosToolStripMenuItem;
    }
}
