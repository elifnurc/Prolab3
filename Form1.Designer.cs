namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlOutput = new System.Windows.Forms.RichTextBox();
            this.pnlGraphDisplay = new System.Windows.Forms.Panel();
            this.vScrollGraph = new System.Windows.Forms.VScrollBar();
            this.hScrollGraph = new System.Windows.Forms.HScrollBar();
            this.trkZoom = new System.Windows.Forms.TrackBar();
            this.pnlOperations = new System.Windows.Forms.Panel();
            this.btnLongestPath = new System.Windows.Forms.Button();
            this.btnMostCollaborative = new System.Windows.Forms.Button();
            this.btnCollaborationCount = new System.Windows.Forms.Button();
            this.btnShortestPaths = new System.Windows.Forms.Button();
            this.btnQueueByWeight = new System.Windows.Forms.Button();
            this.btnCreateBST = new System.Windows.Forms.Button();
            this.btnShortestPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlGraphDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).BeginInit();
            this.pnlOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOutput
            // 
            this.pnlOutput.Location = new System.Drawing.Point(23, 45);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(161, 424);
            this.pnlOutput.TabIndex = 0;
            this.pnlOutput.Text = "";
            this.pnlOutput.TextChanged += new System.EventHandler(this.pnlOutput_TextChanged);
            // 
            // pnlGraphDisplay
            // 
            this.pnlGraphDisplay.Controls.Add(this.vScrollGraph);
            this.pnlGraphDisplay.Controls.Add(this.hScrollGraph);
            this.pnlGraphDisplay.Location = new System.Drawing.Point(208, 46);
            this.pnlGraphDisplay.Name = "pnlGraphDisplay";
            this.pnlGraphDisplay.Size = new System.Drawing.Size(743, 422);
            this.pnlGraphDisplay.TabIndex = 1;
            this.pnlGraphDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGraphDisplay_Paint);
            // 
            // vScrollGraph
            // 
            this.vScrollGraph.Location = new System.Drawing.Point(729, 343);
            this.vScrollGraph.Name = "vScrollGraph";
            this.vScrollGraph.Size = new System.Drawing.Size(14, 79);
            this.vScrollGraph.TabIndex = 4;
            this.vScrollGraph.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollGraph_Scroll);
            // 
            // hScrollGraph
            // 
            this.hScrollGraph.Location = new System.Drawing.Point(0, 406);
            this.hScrollGraph.Name = "hScrollGraph";
            this.hScrollGraph.Size = new System.Drawing.Size(114, 16);
            this.hScrollGraph.TabIndex = 3;
            this.hScrollGraph.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollGraph_Scroll);
            // 
            // trkZoom
            // 
            this.trkZoom.Location = new System.Drawing.Point(224, 489);
            this.trkZoom.Name = "trkZoom";
            this.trkZoom.Size = new System.Drawing.Size(87, 56);
            this.trkZoom.TabIndex = 2;
            this.trkZoom.Scroll += new System.EventHandler(this.trkZoom_Scroll);
            // 
            // pnlOperations
            // 
            this.pnlOperations.Controls.Add(this.btnLongestPath);
            this.pnlOperations.Controls.Add(this.btnMostCollaborative);
            this.pnlOperations.Controls.Add(this.btnCollaborationCount);
            this.pnlOperations.Controls.Add(this.btnShortestPaths);
            this.pnlOperations.Controls.Add(this.btnQueueByWeight);
            this.pnlOperations.Controls.Add(this.btnCreateBST);
            this.pnlOperations.Controls.Add(this.btnShortestPath);
            this.pnlOperations.Location = new System.Drawing.Point(957, 51);
            this.pnlOperations.Name = "pnlOperations";
            this.pnlOperations.Size = new System.Drawing.Size(125, 418);
            this.pnlOperations.TabIndex = 3;
            this.pnlOperations.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlOperations_Paint);
            // 
            // btnLongestPath
            // 
            this.btnLongestPath.Location = new System.Drawing.Point(4, 352);
            this.btnLongestPath.Name = "btnLongestPath";
            this.btnLongestPath.Size = new System.Drawing.Size(118, 38);
            this.btnLongestPath.TabIndex = 6;
            this.btnLongestPath.Text = "7.İster";
            this.btnLongestPath.UseVisualStyleBackColor = true;
            this.btnLongestPath.Click += new System.EventHandler(this.btnLongestPath_Click);
            // 
            // btnMostCollaborative
            // 
            this.btnMostCollaborative.Location = new System.Drawing.Point(4, 294);
            this.btnMostCollaborative.Name = "btnMostCollaborative";
            this.btnMostCollaborative.Size = new System.Drawing.Size(118, 38);
            this.btnMostCollaborative.TabIndex = 5;
            this.btnMostCollaborative.Text = "6.İster";
            this.btnMostCollaborative.UseVisualStyleBackColor = true;
            this.btnMostCollaborative.Click += new System.EventHandler(this.btnMostCollaborative_Click);
            // 
            // btnCollaborationCount
            // 
            this.btnCollaborationCount.Location = new System.Drawing.Point(3, 241);
            this.btnCollaborationCount.Name = "btnCollaborationCount";
            this.btnCollaborationCount.Size = new System.Drawing.Size(118, 38);
            this.btnCollaborationCount.TabIndex = 4;
            this.btnCollaborationCount.Text = "5.İster";
            this.btnCollaborationCount.UseVisualStyleBackColor = true;
            this.btnCollaborationCount.Click += new System.EventHandler(this.btnCollaborationCount_Click);
            // 
            // btnShortestPaths
            // 
            this.btnShortestPaths.Location = new System.Drawing.Point(3, 183);
            this.btnShortestPaths.Name = "btnShortestPaths";
            this.btnShortestPaths.Size = new System.Drawing.Size(118, 38);
            this.btnShortestPaths.TabIndex = 3;
            this.btnShortestPaths.Text = "4.İster";
            this.btnShortestPaths.UseVisualStyleBackColor = true;
            this.btnShortestPaths.Click += new System.EventHandler(this.btnShortestPaths_Click);
            // 
            // btnQueueByWeight
            // 
            this.btnQueueByWeight.Location = new System.Drawing.Point(3, 67);
            this.btnQueueByWeight.Name = "btnQueueByWeight";
            this.btnQueueByWeight.Size = new System.Drawing.Size(118, 38);
            this.btnQueueByWeight.TabIndex = 2;
            this.btnQueueByWeight.Text = "2.İster";
            this.btnQueueByWeight.UseVisualStyleBackColor = true;
            this.btnQueueByWeight.Click += new System.EventHandler(this.btnQueueByWeight_Click);
            // 
            // btnCreateBST
            // 
            this.btnCreateBST.Location = new System.Drawing.Point(4, 121);
            this.btnCreateBST.Name = "btnCreateBST";
            this.btnCreateBST.Size = new System.Drawing.Size(118, 38);
            this.btnCreateBST.TabIndex = 1;
            this.btnCreateBST.Text = "3.İster";
            this.btnCreateBST.UseVisualStyleBackColor = true;
            this.btnCreateBST.Click += new System.EventHandler(this.btnCreateBST_Click);
            // 
            // btnShortestPath
            // 
            this.btnShortestPath.Location = new System.Drawing.Point(6, 11);
            this.btnShortestPath.Name = "btnShortestPath";
            this.btnShortestPath.Size = new System.Drawing.Size(118, 38);
            this.btnShortestPath.TabIndex = 0;
            this.btnShortestPath.Text = "1.İster";
            this.btnShortestPath.UseVisualStyleBackColor = true;
            this.btnShortestPath.Click += new System.EventHandler(this.btnShortestPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "ÇIKTI EKRANI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 587);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlOperations);
            this.Controls.Add(this.trkZoom);
            this.Controls.Add(this.pnlGraphDisplay);
            this.Controls.Add(this.pnlOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlGraphDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).EndInit();
            this.pnlOperations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox pnlOutput;
        private System.Windows.Forms.Panel pnlGraphDisplay;
        private System.Windows.Forms.VScrollBar vScrollGraph;
        private System.Windows.Forms.HScrollBar hScrollGraph;
        private System.Windows.Forms.TrackBar trkZoom;
        private System.Windows.Forms.Panel pnlOperations;
        private System.Windows.Forms.Button btnLongestPath;
        private System.Windows.Forms.Button btnMostCollaborative;
        private System.Windows.Forms.Button btnCollaborationCount;
        private System.Windows.Forms.Button btnShortestPaths;
        private System.Windows.Forms.Button btnQueueByWeight;
        private System.Windows.Forms.Button btnCreateBST;
        private System.Windows.Forms.Button btnShortestPath;
        private System.Windows.Forms.Label label1;
    }
}

