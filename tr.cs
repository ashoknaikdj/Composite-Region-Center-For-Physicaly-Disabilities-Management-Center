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
    public partial class tr : Form
    {
        public tr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tr_Load(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            DataTable dt2 = new DataTable();


            dataGridView1.DataSource = dt2;
            dataGridView1.Visible = false;


            try
            {
                con.Open();

                MySqlCommand cmd1 = new MySqlCommand(" select distinct(patientid) from vr4");
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from vr4 where patientid='"+comboBox1.Text+"'");
                cmd2.Connection = con;

                MySqlDataAdapter dr = new MySqlDataAdapter();
                dr.SelectCommand = cmd2;

                DataTable dt2 = new DataTable();
                dr.Fill(dt2);

                dataGridView1.DataSource = dt2;
                dataGridView1.Visible = true;
            }
            catch (Exception )
            {
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);

            try
            {
                con.Open();

                MySqlCommand cmd2 = new MySqlCommand("select * from vr4 where pdate='" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'");
                cmd2.Connection = con;
                MySqlDataAdapter dr2 = new MySqlDataAdapter();
                dr2.SelectCommand = cmd2;
                DataTable dt2 = new DataTable();
                dr2.Fill(dt2);
                dataGridView1.DataSource = dt2;
                dataGridView1.Visible = true;
            }
            catch(Exception)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 F = new Form4();
            F.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
