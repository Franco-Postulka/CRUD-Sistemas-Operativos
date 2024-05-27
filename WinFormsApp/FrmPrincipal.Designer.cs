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
            descendenteToolStripMenuItem = new ToolStripMenuItem();
            ascendenteToolStripMenuItem = new ToolStripMenuItem();
            ordenarPorGBToolStripMenuItem = new ToolStripMenuItem();
            ascendeteToolStripMenuItem = new ToolStripMenuItem();
            descendenteToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            menuOrdenar.SuspendLayout();
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
            menuStrip.Size = new Size(889, 33);
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
            lstBox.Location = new Point(27, 73);
            lstBox.Name = "lstBox";
            lstBox.Size = new Size(709, 304);
            lstBox.TabIndex = 1;
            // 
            // menuOrdenar
            // 
            menuOrdenar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            menuOrdenar.Dock = DockStyle.None;
            menuOrdenar.ImageScalingSize = new Size(24, 24);
            menuOrdenar.Items.AddRange(new ToolStripItem[] { ordenarToolStripMenuItem, ordenarPorGBToolStripMenuItem });
            menuOrdenar.Location = new Point(27, 389);
            menuOrdenar.Name = "menuOrdenar";
            menuOrdenar.Size = new Size(384, 33);
            menuOrdenar.TabIndex = 2;
            menuOrdenar.Text = "menuStrip1";
            // 
            // ordenarToolStripMenuItem
            // 
            ordenarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { descendenteToolStripMenuItem, ascendenteToolStripMenuItem });
            ordenarToolStripMenuItem.Name = "ordenarToolStripMenuItem";
            ordenarToolStripMenuItem.Size = new Size(223, 29);
            ordenarToolStripMenuItem.Text = "Ordenar alfabéticamente";
            // 
            // descendenteToolStripMenuItem
            // 
            descendenteToolStripMenuItem.Name = "descendenteToolStripMenuItem";
            descendenteToolStripMenuItem.Size = new Size(216, 34);
            descendenteToolStripMenuItem.Text = "Ascendente";
            descendenteToolStripMenuItem.Click += descendenteToolStripMenuItem_Click;
            // 
            // ascendenteToolStripMenuItem
            // 
            ascendenteToolStripMenuItem.Name = "ascendenteToolStripMenuItem";
            ascendenteToolStripMenuItem.Size = new Size(216, 34);
            ascendenteToolStripMenuItem.Text = "Descendente";
            // 
            // ordenarPorGBToolStripMenuItem
            // 
            ordenarPorGBToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ascendeteToolStripMenuItem, descendenteToolStripMenuItem1 });
            ordenarPorGBToolStripMenuItem.Name = "ordenarPorGBToolStripMenuItem";
            ordenarPorGBToolStripMenuItem.Size = new Size(153, 29);
            ordenarPorGBToolStripMenuItem.Text = "Ordenar por GB";
            // 
            // ascendeteToolStripMenuItem
            // 
            ascendeteToolStripMenuItem.Name = "ascendeteToolStripMenuItem";
            ascendeteToolStripMenuItem.Size = new Size(216, 34);
            ascendeteToolStripMenuItem.Text = "Ascendete";
            // 
            // descendenteToolStripMenuItem1
            // 
            descendenteToolStripMenuItem1.Name = "descendenteToolStripMenuItem1";
            descendenteToolStripMenuItem1.Size = new Size(216, 34);
            descendenteToolStripMenuItem1.Text = "Descendente";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 450);
            Controls.Add(lstBox);
            Controls.Add(menuStrip);
            Controls.Add(menuOrdenar);
            MainMenuStrip = menuStrip;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistemas Operativos";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            menuOrdenar.ResumeLayout(false);
            menuOrdenar.PerformLayout();
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
        private ToolStripMenuItem descendenteToolStripMenuItem;
        private ToolStripMenuItem ascendenteToolStripMenuItem;
        private ToolStripMenuItem ordenarPorGBToolStripMenuItem;
        private ToolStripMenuItem ascendeteToolStripMenuItem;
        private ToolStripMenuItem descendenteToolStripMenuItem1;
    }
}
