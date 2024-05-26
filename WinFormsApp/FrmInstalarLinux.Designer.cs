namespace WinFormsApp
{
    partial class FrmInstalarLinux
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboDistribucion = new ComboBox();
            label7 = new Label();
            checkInterfaz = new CheckBox();
            SuspendLayout();
            // 
            // btnInstalar
            // 
            btnInstalar.Click += btnInstalar_Click_1;
            // 
            // cboDistribucion
            // 
            cboDistribucion.FormattingEnabled = true;
            cboDistribucion.Location = new Point(542, 291);
            cboDistribucion.Name = "cboDistribucion";
            cboDistribucion.Size = new Size(182, 33);
            cboDistribucion.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(435, 299);
            label7.Name = "label7";
            label7.Size = new Size(107, 25);
            label7.TabIndex = 12;
            label7.Text = "Distribución";
            // 
            // checkInterfaz
            // 
            checkInterfaz.AutoSize = true;
            checkInterfaz.Location = new Point(49, 295);
            checkInterfaz.Name = "checkInterfaz";
            checkInterfaz.Size = new Size(210, 29);
            checkInterfaz.TabIndex = 13;
            checkInterfaz.Text = "Tienen interfaz gráfica";
            checkInterfaz.UseVisualStyleBackColor = true;
            // 
            // FrmInstalarLinux
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkInterfaz);
            Controls.Add(label7);
            Controls.Add(cboDistribucion);
            Name = "FrmInstalarLinux";
            Text = "FrmInstalarLinux";
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtVersion, 0);
            Controls.SetChildIndex(txtEspacio, 0);
            Controls.SetChildIndex(cboEstado, 0);
            Controls.SetChildIndex(btnInstalar, 0);
            Controls.SetChildIndex(cboDistribucion, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(checkInterfaz, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboDistribucion;
        private Label label7;
        private CheckBox checkInterfaz;
    }
}