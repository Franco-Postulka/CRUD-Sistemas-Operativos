namespace WinFormsApp
{
    partial class FrmLogueos
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
            lstBox = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lstBox
            // 
            lstBox.FormattingEnabled = true;
            lstBox.ItemHeight = 25;
            lstBox.Location = new Point(12, 83);
            lstBox.Name = "lstBox";
            lstBox.Size = new Size(834, 329);
            lstBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(352, 29);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 1;
            label1.Text = "Usuarios logueados";
            // 
            // FrmLogueos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 450);
            Controls.Add(label1);
            Controls.Add(lstBox);
            Name = "FrmLogueos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLogueos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstBox;
        private Label label1;
    }
}