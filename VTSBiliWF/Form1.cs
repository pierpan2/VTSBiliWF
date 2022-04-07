using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTSBiliWF
{
    public partial class Form1 : Form
    {
        private Mei mei;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mei = new Mei();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mei.PrintAPIStats(label1);
        }
    }
}
