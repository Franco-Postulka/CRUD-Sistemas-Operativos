namespace WinFormsApp
{
    partial class FrmInstalarMac
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
            checkIntegracion = new CheckBox();
            checkCompatibleApple = new CheckBox();
            SuspendLayout();
            // 
            // checkIntegracion
            // 
            checkIntegracion.AutoSize = true;
            checkIntegracion.Location = new Point(59, 284);
            checkIntegracion.Name = "checkIntegracion";
            checkIntegracion.Size = new Size(260, 29);
            checkIntegracion.TabIndex = 11;
            checkIntegracion.Text = "Tiene integración con Icloud";
            checkIntegracion.UseVisualStyleBackColor = true;
            // 
            // checkCompatibleApple
            // 
            checkCompatibleApple.AutoSize = true;
            checkCompatibleApple.Location = new Point(455, 284);
            checkCompatibleApple.Name = "checkCompatibleApple";
            checkCompatibleApple.Size = new Size(311, 29);
            checkCompatibleApple.TabIndex = 12;
            checkCompatibleApple.Text = "Compatible con procesador Apple";
            checkCompatibleApple.UseVisualStyleBackColor = true;
            // 
            // FrmInstalarMac
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkCompatibleApple);
            Controls.Add(checkIntegracion);
            Name = "FrmInstalarMac";
            Text = "FrmInstalarMac";
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtVersion, 0);
            Controls.SetChildIndex(txtEspacio, 0);
            Controls.SetChildIndex(cboEstado, 0);
            Controls.SetChildIndex(btnInstalar, 0);
            Controls.SetChildIndex(checkIntegracion, 0);
            Controls.SetChildIndex(checkCompatibleApple, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkIntegracion;
        private CheckBox checkCompatibleApple;
    }
}