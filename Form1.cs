using Prolab3.DataStructures;
using Prolab3.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private GrafGorsellestirici grafGorsellestirici;
        private Graf graf;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(Graf graf)
        {
            InitializeComponent();
            this.graf = graf;

            // GrafGorsellestirici'yi başlat
            grafGorsellestirici = new GrafGorsellestirici();

            // Graf görselleştiriciyi panel'e ekle (panel adınıza göre değiştirin)
            pnlGraphDisplay.Controls.Add(grafGorsellestirici.GrafKontrolunuGetir());

            // Grafı göster
            grafGorsellestirici.GrafiGoster(graf);
        }
        private void pnlOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlGraphDisplay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollGraph_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void hScrollGraph_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void trkZoom_Scroll(object sender, EventArgs e)
        {

        }

        private void pnlOperations_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShortestPath_Click(object sender, EventArgs e)
        {

        }

        private void btnQueueByWeight_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateBST_Click(object sender, EventArgs e)
        {

        }

        private void btnShortestPaths_Click(object sender, EventArgs e)
        {

        }

        private void btnCollaborationCount_Click(object sender, EventArgs e)
        {

        }

        private void btnMostCollaborative_Click(object sender, EventArgs e)
        {

        }

        private void btnLongestPath_Click(object sender, EventArgs e)
        {

        }
    }
}
