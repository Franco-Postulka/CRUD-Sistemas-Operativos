namespace WinFormsApp
{
    partial class FrmInstalar
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
            txtNombre = new TextBox();
            txtVersion = new TextBox();
            txtEspacio = new TextBox();
            cboEstado = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnInstalar = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(176, 63);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 31);
            txtNombre.TabIndex = 0;
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(176, 119);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(150, 31);
            txtVersion.TabIndex = 1;
            // 
            // txtEspacio
            // 
            txtEspacio.Location = new Point(542, 63);
            txtEspacio.Name = "txtEspacio";
            txtEspacio.Size = new Size(150, 31);
            txtEspacio.TabIndex = 2;
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(542, 119);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(182, 33);
            cboEstado.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 63);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 4;
            label1.Text = "Nombe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 119);
            label2.Name = "label2";
            label2.Size = new Size(70, 25);
            label2.TabIndex = 5;
            label2.Text = "Version";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(435, 69);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 6;
            label3.Text = "Espacio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(435, 125);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 7;
            label4.Text = "Soporte";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(326, 9);
            label5.Name = "label5";
            label5.Size = new Size(123, 25);
            label5.TabIndex = 8;
            label5.Text = "Datos basicos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(310, 203);
            label6.Name = "label6";
            label6.Size = new Size(150, 25);
            label6.TabIndex = 9;
            label6.Text = "Datos específicos";
            // 
            // btnInstalar
            // 
            btnInstalar.Location = new Point(326, 372);
            btnInstalar.Name = "btnInstalar";
            btnInstalar.Size = new Size(112, 34);
            btnInstalar.TabIndex = 10;
            btnInstalar.Text = "Instalar";
            btnInstalar.UseVisualStyleBackColor = true;
            btnInstalar.Click += btnInstalar_Click;
            // 
            // FrmInstalar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnInstalar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboEstado);
            Controls.Add(txtEspacio);
            Controls.Add(txtVersion);
            Controls.Add(txtNombre);
            Name = "FrmInstalar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmInstalar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected TextBox txtNombre;
        protected TextBox txtVersion;
        protected TextBox txtEspacio;
        protected ComboBox cboEstado;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        protected Button btnInstalar;
    }
}