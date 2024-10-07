using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SHREE
{
    public partial class r : Form
    {
        public r()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serfont s2 = new serfont();
            s2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("insert into resource values('" + textBox2.Text + "','" + textBox1.Text + "')");

            cmd.Connection = con;
            cmd.ExecuteNonQuery();


            cmd = new MySqlCommand("insert into resourceavail values('" + textBox2.Text + "','" + textBox1.Text + "')");

            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Data save successfully..");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from resource");
                cmd2.Connection = con;

                MySqlDataAdapter dr2 = new MySqlDataAdapter();
                dr2.SelectCommand = cmd2;

                DataTable dt2 = new DataTable();
                dr2.Fill(dt2);

                dataGridView1.DataSource = dt2;
                dataGridView1.Visible = true;
            }
            catch (Exception)
            {
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void r_Load(object sender, EventArgs e)
        {
           
            dataGridView1.Visible = false;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox2.Text = "";
             textBox1.Text = "";
            dataGridView1.Visible = false;
            textBox2.Focus();
        }
    }
}
