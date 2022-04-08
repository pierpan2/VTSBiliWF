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
        private Sender vtssender;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vtssender = new Sender();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vtssender.PrintAPIStats();
            vtssender.ActivateExpression("expression1");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            vtssender.Close();
        }
    }
}
