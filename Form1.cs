using Prolab3.DataStructures;
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

        public Form1(Prolab3.DataStructures.Graf graf)
        {
            InitializeComponent();
        }

        public Form1(Graf graf, GrafGorsellestirici grafGorsellestirici) : this(graf)
        {
            this.grafGorsellestirici = grafGorsellestirici;
        }
    }
}
