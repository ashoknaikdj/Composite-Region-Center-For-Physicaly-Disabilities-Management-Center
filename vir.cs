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
    public partial class vir : Form
    {
        public vir()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f2 = new Form4();
            f2.Show();

        }

        private void vir_Load(object sender, EventArgs e)
        {
            string test = DateTime.Now.ToString("yyyy-MM-dd");
            textBox2.Text = test.ToString();

            String patientid = comboBox4.Text;

            DataTable dt2 = new DataTable();
           

            dataGridView2.DataSource = dt2;
            dataGridView2.Visible = false;









            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();

                MySqlCommand cmd1 = new MySqlCommand(" select * from cr");
                MySqlDataReader dr;

                cmd1.Connection = con;
                dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    comboBox4.Items.Add(dr.GetString(0));
                }
            }


            catch (Exception)
            {

            }

        }


        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {





        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {



        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (comboBox4.Text == "")
            {
                MessageBox.Show("Please Select Patient ID..");
                comboBox4.Focus();
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Please Select Treatment Type..");
                comboBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please Select Treatment Discription..");
                textBox3.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Please enter treatment cost..");
                textBox6.Focus();
            }
            else
            {
                String patientid = comboBox4.Text;

                String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

                MySqlConnection con = new MySqlConnection(cs);

                try
                {


                    con.Open();


                    MySqlCommand cmd = new MySqlCommand("insert into vr4 values('" + textBox2.Text + "','" + comboBox4.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "')");

                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Data save successfully..");

                    comboBox4.Text = "";
                    comboBox2.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    comboBox4.Focus();
                }

                catch (Exception)
                {

                }

            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            String patientid = comboBox4.Text;
            if (patientid == "")
            {



                String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
                MySqlConnection con = new MySqlConnection(cs);


                try
                {
                    con.Open();

                    MySqlCommand cmd2 = new MySqlCommand("select * from vr4");
                    cmd2.Connection = con;

                    MySqlDataAdapter dr2 = new MySqlDataAdapter();
                    dr2.SelectCommand = cmd2;

                    DataTable dt2 = new DataTable();
                    dr2.Fill(dt2);

                    dataGridView2.DataSource = dt2;
                    dataGridView2.Visible = true;
                }
                catch (Exception)
                {
                }

            }

            else
            {
                String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
                MySqlConnection con = new MySqlConnection(cs);
                try
                {
                    con.Open();
                    MySqlCommand cmd2 = new MySqlCommand("select * from vr4 where patientid='" + comboBox4.Text + "'");
                    cmd2.Connection = con;

                    MySqlDataAdapter dr2 = new MySqlDataAdapter();
                    dr2.SelectCommand = cmd2;

                    DataTable dt2 = new DataTable();
                    dr2.Fill(dt2);

                    dataGridView2.DataSource = dt2;
                    dataGridView2.Visible = true;
                }
                catch (Exception)
                {
                }

            }
        }












        private void button12_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            MySqlCommand cmd1 = new MySqlCommand(" select * from vr4 where patientid='" + comboBox4.Text + "'");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                comboBox4.Text = dr.GetString(1);


                comboBox2.Text = dr.GetString(2);

                textBox3.Text = dr.GetString(3);
                textBox6.Text = dr.GetString(4);

            }
            else
            {
                MessageBox.Show(" No such Records present");
                comboBox4.Text = "";
                comboBox4.Focus();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);

            try
            {


                con.Open();

                MySqlCommand cmd = new MySqlCommand("update vr4 set treatmenttype='" + comboBox2.Text + "',treatmentdesc='" + textBox3.Text + "',treatmentcost='" + textBox6.Text + "'where patientid='" + comboBox4.Text + "'");

                cmd.Connection = con;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Visiter Details Updated successfully..");

            }
            catch (Exception)
            {
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);




            
            con.Open();

            MySqlCommand cmd = new MySqlCommand("delete from vr4 where patientid='" + comboBox4.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

                MessageBox.Show("Visiter Details Removed successfully..");
        }

        private void vir_Load_1(object sender, EventArgs e)
        {
            string test = DateTime.Now.ToString("yyyy-MM-dd");
            textBox2.Text = test.ToString();

            String patientid = comboBox4.Text;

            DataTable dt2 = new DataTable();


            dataGridView2.DataSource = dt2;
            dataGridView2.Visible = false;




            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();

                MySqlCommand cmd1 = new MySqlCommand(" select distinct(patientid) from  cr");
                MySqlDataReader dr;

                cmd1.Connection = con;
                dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    comboBox4.Items.Add(dr.GetString(0));
                }
            }


            catch (Exception)
            {

            }




        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

          

            dataGridView2.Visible = false;
           
          
            comboBox4.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox2.Focus();   

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form4 F = new Form4();
            F.Show();

        }

      

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
    }
}




   

