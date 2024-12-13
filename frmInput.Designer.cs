namespace WindowsFormsApp1
{
    partial class frmInput
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
            this.lblAuthorA = new System.Windows.Forms.Label();
            this.lblAuthorB = new System.Windows.Forms.Label();
            this.txtAuthorA = new System.Windows.Forms.TextBox();
            this.txtAuthorB = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAuthorA
            // 
            this.lblAuthorA.AutoSize = true;
            this.lblAuthorA.Location = new System.Drawing.Point(34, 42);
            this.lblAuthorA.Name = "lblAuthorA";
            this.lblAuthorA.Size = new System.Drawing.Size(76, 16);
            this.lblAuthorA.TabIndex = 0;
            this.lblAuthorA.Text = "A Yazarı ID:";
            // 
            // lblAuthorB
            // 
            this.lblAuthorB.AutoSize = true;
            this.lblAuthorB.Location = new System.Drawing.Point(169, 42);
            this.lblAuthorB.Name = "lblAuthorB";
            this.lblAuthorB.Size = new System.Drawing.Size(76, 16);
            this.lblAuthorB.TabIndex = 1;
            this.lblAuthorB.Text = "B Yazarı ID:";
            // 
            // txtAuthorA
            // 
            this.txtAuthorA.Location = new System.Drawing.Point(37, 73);
            this.txtAuthorA.Name = "txtAuthorA";
            this.txtAuthorA.Size = new System.Drawing.Size(116, 22);
            this.txtAuthorA.TabIndex = 2;
            this.txtAuthorA.TextChanged += new System.EventHandler(this.txtAuthorA_TextChanged);
            // 
            // txtAuthorB
            // 
            this.txtAuthorB.Location = new System.Drawing.Point(172, 73);
            this.txtAuthorB.Name = "txtAuthorB";
            this.txtAuthorB.Size = new System.Drawing.Size(112, 22);
            this.txtAuthorB.TabIndex = 3;
            this.txtAuthorB.TextChanged += new System.EventHandler(this.txtAuthorB_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(172, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 33);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(252, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 237);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtAuthorB);
            this.Controls.Add(this.txtAuthorA);
            this.Controls.Add(this.lblAuthorB);
            this.Controls.Add(this.lblAuthorA);
            this.Name = "frmInput";
            this.Text = "frmInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuthorA;
        private System.Windows.Forms.Label lblAuthorB;
        private System.Windows.Forms.TextBox txtAuthorA;
        private System.Windows.Forms.TextBox txtAuthorB;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}