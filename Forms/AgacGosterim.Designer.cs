namespace WindowsFormsApp1.Forms
{
    partial class AgacGosterim
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
            this.panelAgac = new System.Windows.Forms.Panel();
            this.btnAgaciGoster = new System.Windows.Forms.Button();
            this.btnYazarSil = new System.Windows.Forms.Button();
            this.btnAgaciTemizle = new System.Windows.Forms.Button();
            this.panelAgac.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAgac
            // 
            this.panelAgac.Controls.Add(this.btnAgaciTemizle);
            this.panelAgac.Controls.Add(this.btnYazarSil);
            this.panelAgac.Controls.Add(this.btnAgaciGoster);
            this.panelAgac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAgac.Location = new System.Drawing.Point(0, 0);
            this.panelAgac.Name = "panelAgac";
            this.panelAgac.Size = new System.Drawing.Size(800, 450);
            this.panelAgac.TabIndex = 0;
            // 
            // btnAgaciGoster
            // 
            this.btnAgaciGoster.Location = new System.Drawing.Point(80, 345);
            this.btnAgaciGoster.Name = "btnAgaciGoster";
            this.btnAgaciGoster.Size = new System.Drawing.Size(147, 44);
            this.btnAgaciGoster.TabIndex = 0;
            this.btnAgaciGoster.Text = "Ağacı Göster";
            this.btnAgaciGoster.UseVisualStyleBackColor = true;
            // 
            // btnYazarSil
            // 
            this.btnYazarSil.Location = new System.Drawing.Point(283, 345);
            this.btnYazarSil.Name = "btnYazarSil";
            this.btnYazarSil.Size = new System.Drawing.Size(147, 44);
            this.btnYazarSil.TabIndex = 1;
            this.btnYazarSil.Text = "Yazar sil";
            this.btnYazarSil.UseVisualStyleBackColor = true;
            // 
            // btnAgaciTemizle
            // 
            this.btnAgaciTemizle.Location = new System.Drawing.Point(512, 345);
            this.btnAgaciTemizle.Name = "btnAgaciTemizle";
            this.btnAgaciTemizle.Size = new System.Drawing.Size(147, 44);
            this.btnAgaciTemizle.TabIndex = 2;
            this.btnAgaciTemizle.Text = "Ağacı Temizle";
            this.btnAgaciTemizle.UseVisualStyleBackColor = true;
            // 
            // AgacGosterim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelAgac);
            this.Name = "AgacGosterim";
            this.Text = "AgacGosterim";
            this.panelAgac.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAgac;
        private System.Windows.Forms.Button btnAgaciTemizle;
        private System.Windows.Forms.Button btnYazarSil;
        private System.Windows.Forms.Button btnAgaciGoster;
    }
}