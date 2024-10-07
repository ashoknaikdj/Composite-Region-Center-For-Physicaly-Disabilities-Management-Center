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
    public partial class ra : Form
    {
        public ra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cnt = Int32.Parse(textBox1.Text);

            cnt = cnt - 1;
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please select  the option");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select  the option");
            }
            else
            {

                string cs = "server=localhost;PORT=3306;UID=root;PWD=admin;DATABASE=hms";

                MySqlConnection con = new MySqlConnection(cs);

                con.Open();
                string test = DateTime.Now.ToString("yyyy-MM-dd");

                MySqlCommand cmd3 = new MySqlCommand("insert into issueresource values('" + comboBox2.Text + "','" + comboBox1.Text + "','" + test + "')");
                cmd3.Connection = con;

                cmd3.ExecuteNonQuery();

                cmd3 = new MySqlCommand("update resourceavail set ravail='" + cnt.ToString() + "' where rname='" + comboBox1.Text + "'");
                cmd3.Connection = con;

                cmd3.ExecuteNonQuery();


                MessageBox.Show("saved successfully");
            }
            
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from resourceavail");
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ra_Load(object sender, EventArgs e)
        {

            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            DataTable dt2 = new DataTable();


            dataGridView1.DataSource = dt2;
            dataGridView1.Visible = false;


            try
            {
                con.Open();

                MySqlCommand cmd1 = new MySqlCommand(" select distinct(uniqueid) from pr  ");
                MySqlDataReader dr;

                cmd1.Connection = con;
                dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    comboBox2.Items.Add(dr.GetString(0));
                }

                con.Close();
                con.Open();


                MySqlCommand cmd2 = new MySqlCommand("select * from resourceavail where ravail>0");
                MySqlDataReader dr2;

                cmd2.Connection = con;
                dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox1.Items.Add(dr2.GetString(0));
                }


            }

            catch (Exception)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);

            con.Open();
            MySqlCommand cmd1 = new MySqlCommand(" select * from resourceavail where rname='" + comboBox1.Text + "'");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
               
                textBox1.Text = dr.GetString(1);

            }
            else
            {
                MessageBox.Show(" No such Resorce as not present");

                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox1.Focus();

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("delete from issueresource where patid='" + comboBox2.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Removed successfully..");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            comboBox1.Focus();
          
            dataGridView1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f = new Form4();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



