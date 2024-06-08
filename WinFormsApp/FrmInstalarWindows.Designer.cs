namespace WinFormsApp
{
    partial class FrmInstalarWindows
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
            label8 = new Label();
            checkVirtualizacion = new CheckBox();
            cboEdicion = new ComboBox();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(435, 275);
            label8.Name = "label8";
            label8.Size = new Size(69, 25);
            label8.TabIndex = 12;
            label8.Text = "Edición";
            // 
            // checkVirtualizacion
            // 
            checkVirtualizacion.AutoSize = true;
            checkVirtualizacion.Location = new Point(49, 271);
            checkVirtualizacion.Name = "checkVirtualizacion";
            checkVirtualizacion.Size = new Size(223, 29);
            checkVirtualizacion.TabIndex = 13;
            checkVirtualizacion.Text = "Virtualizacion permitida";
            checkVirtualizacion.UseVisualStyleBackColor = true;
            // 
            // cboEdicion
            // 
            cboEdicion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEdicion.FormattingEnabled = true;
            cboEdicion.Location = new Point(542, 275);
            cboEdicion.Name = "cboEdicion";
            cboEdicion.Size = new Size(182, 33);
            cboEdicion.TabIndex = 14;
            // 
            // FrmInstalarWindows
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboEdicion);
            Controls.Add(checkVirtualizacion);
            Controls.Add(label8);
            Name = "FrmInstalarWindows";
            Text = "Insatalar Windows";
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtVersion, 0);
            Controls.SetChildIndex(txtEspacio, 0);
            Controls.SetChildIndex(cboEstado, 0);
            Controls.SetChildIndex(btnInstalar, 0);
            Controls.SetChildIndex(label8, 0);
            Controls.SetChildIndex(checkVirtualizacion, 0);
            Controls.SetChildIndex(cboEdicion, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label8;
        private CheckBox checkVirtualizacion;
        private ComboBox cboEdicion;
    }
}