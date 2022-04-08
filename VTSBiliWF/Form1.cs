using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTSBiliWF
{
    public partial class Form1 : Form
    {
        public Sender vtssender;
        LoadPython py;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vtssender = new Sender();
            py = new LoadPython(vtssender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vtssender.PrintAPIStats();
            vtssender.ActivateExpression("expression1");
            py.StartPy(22666832);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            vtssender.Close();
            py.Close();
            foreach(var process in Process.GetProcessesByName("blivedm.exe"))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit(100);
                }
                catch (Exception ex) { }
            }
        }
    }
}
