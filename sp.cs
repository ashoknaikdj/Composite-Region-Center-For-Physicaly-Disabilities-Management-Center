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
    public partial class sp : Form
    {
        public sp()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from sp");
                cmd2.Connection = con;

                MySqlDataAdapter dr2 = new MySqlDataAdapter();
                dr2.SelectCommand = cmd2;

                DataTable dt2 = new DataTable();
                dr2.Fill(dt2);

                dataGridView1.DataSource = dt2;
                dataGridView1.Visible = true;
            }
            catch (Exception )
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("delete from sp where Unique_id='" + textBox2.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Doctor Details Removed successfully..");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("update sp set Service_provider='" + comboBox3.Text + "',Provider_name='" + textBox1.Text + "',Gender='" + comboBox1.Text + "',Qulification='" + comboBox2.Text + "',Purpose_of_allocation='" + comboBox4.Text + "' where Unique_id='" + textBox2.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("service provider Details Updated successfully..");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            MySqlCommand cmd1 = new MySqlCommand(" select * from sp where Unique_Id='" + textBox2.Text + "'");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                comboBox3.Text = dr.GetString(0);
                textBox1.Text = dr.GetString(1);
                textBox2.Text = dr.GetString(2);
                comboBox1.Text = dr.GetString(3);
                comboBox2.Text = dr.GetString(4);
                comboBox4.Text = dr.GetString(5);
            }
            else
            {
                MessageBox.Show(" No such Records present");
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            dataGridView1.Visible = false;
            comboBox3.Focus();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Please select the option");
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Please enter provider name");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter the uniqueid");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Select the gender");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Please Select Qulification");
            }
            else if (comboBox4.Text == "")
            {
                MessageBox.Show("Select the option");
            }
            else
            {


                String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

                MySqlConnection con = new MySqlConnection(cs);

                con.Open();

                MySqlCommand cmd = new MySqlCommand("insert into sp values('" + comboBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox4.Text + "')");

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data save successfully..");
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void sp_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();


            dataGridView1.DataSource = dt2;
            dataGridView1.Visible = false;

        }
    }
}
