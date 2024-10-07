using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHREE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminlog a = new adminlog();
            a.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            doclog d = new doclog();
            d.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            resmenu r = new resmenu();
            r.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox7.Left = pictureBox7.Left - 2;
            pictureBox8.Left = pictureBox8.Left - 2;
            pictureBox9.Left = pictureBox9.Left - 2;
            pictureBox10.Left = pictureBox10.Left - 2;
            pictureBox11.Left = pictureBox11.Left - 2;
            pictureBox12.Left = pictureBox12.Left - 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}

 