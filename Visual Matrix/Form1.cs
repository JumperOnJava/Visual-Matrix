using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Matrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Program.drawT.Start();
            Program.FindT.Start();
        }
        static public void setText(string input)
        {
            try
            { 
                textBox1.Text = input;
            }
            catch
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
                Clipboard.SetText(Program.tmp);
            //Program.Fin();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
