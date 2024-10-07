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
    public partial class pr : Form
    {
        public pr()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter the Nmae");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Patient Name");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please Enter Guadiana are parent name");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Select the Gender");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please Enter the age");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Please Enter the occupation");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Please Enter the area are location");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Please Enter Address");
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("Please Enter the 10-digit phonr number");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Please select the option");
            }
            else
            {
                String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

                MySqlConnection con = new MySqlConnection(cs);

                con.Open();

                MySqlCommand cmd = new MySqlCommand("insert into pr values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox6.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + dateTimePicker2.Text + "')");

                cmd.Connection = con;
                cmd.ExecuteNonQuery();


                Int32 pcnt = Int32.Parse(textBox2.Text) + 1;

                MySqlCommand cmd1 = new MySqlCommand("update pcount set num='" + pcnt.ToString() + "'");

                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();




                MessageBox.Show("Patient Record Added successfully..");
            } 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from pr");
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

            MySqlCommand cmd = new MySqlCommand("delete from pr where uniqueid='" + textBox2.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Patient Record Removed successfully..");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("update pr set adhar='" + textBox1.Text + "',patientname='" + textBox3.Text + "',guardian='" + textBox4.Text + "',gender='" + comboBox1.Text + "',dob='" + dateTimePicker1.Text + "',age='" + textBox5.Text + "',occupation='" + textBox7.Text + "',address='" + textBox8.Text + "',area='" + textBox6.Text + "',contact='" + textBox9.Text + "',proof='" + comboBox2.Text + "',dor='" + dateTimePicker2.Text + "' where uniqueid='" + textBox2.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Patient Record Updated successfully..");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            MySqlCommand cmd1 = new MySqlCommand(" select * from pr where uniqueid='" + textBox2.Text + "'");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr.GetString(0);
                textBox2.Text = dr.GetString(1);
                textBox3.Text = dr.GetString(2);
                textBox4.Text = dr.GetString(3);
                comboBox1.Text = dr.GetString(4);
                dateTimePicker1.Text = dr.GetString(5);
                textBox5.Text = dr.GetString(6);
                textBox7.Text = dr.GetString(7);
                textBox8.Text = dr.GetString(8);
                textBox6.Text = dr.GetString(9);
                textBox9.Text = dr.GetString(10);
                comboBox2.Text = dr.GetString(11);
                dateTimePicker2.Text = dr.GetString(12);
            }
            else
            {
                MessageBox.Show(" No such Records present");
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pr_Load(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            DataTable dt2 = new DataTable();


            dataGridView1.DataSource = dt2;
            dataGridView1.Visible = false;


            MySqlCommand cmd1 = new MySqlCommand(" select * from pcount");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                textBox2.Text = dr.GetString(0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();


            dataGridView1.DataSource = dt2;
            dataGridView1.Visible = true;
        }
    }
}
