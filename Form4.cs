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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            vir v = new vir();
            v.Show();
           
            
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            ra r = new ra();
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            tr r = new tr();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            doclog d = new doclog();
            d.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            reallo r = new reallo();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
        }
    }
}
