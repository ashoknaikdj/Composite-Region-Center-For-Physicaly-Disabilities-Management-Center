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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text =="")
            {
                MessageBox.Show("Please select patient ID");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Please enter the purpose of visit");
            }
            else
            {

                String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

                MySqlConnection con = new MySqlConnection(cs);

                con.Open();

                MySqlCommand cmd = new MySqlCommand("insert into cr values('" + comboBox1.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + textBox2.Text + "')");

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data save successfully..");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from cr");
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

            MySqlCommand cmd = new MySqlCommand("delete from cr where patientid='" + comboBox1.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Patient Details Removed successfully..");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("update cr set patientid='" + comboBox1.Text + "',scheduledate='" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "',purposeofvisit='" + textBox2.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Patient Details Updated successfully..");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            MySqlCommand cmd1 = new MySqlCommand(" select * from cr where patientid='" + comboBox1.Text + "'");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                comboBox1.Text = dr.GetString(0);
                dateTimePicker1.Text = dr.GetString(1);
                textBox2.Text = dr.GetString(2);
            }
            else
            {
                MessageBox.Show(" No such Records present");
                comboBox1.Text = "";
                dateTimePicker1.Text = "";
                comboBox1.Focus();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
           
            dataGridView1.DataSource = dt2;
            dataGridView1.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand(" select * from pr where uniqueid='" + comboBox1.Text + "'");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
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
                    comboBox1.Items.Add(dr.GetString(0));
                }
            }

            catch(Exception )
            {

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
