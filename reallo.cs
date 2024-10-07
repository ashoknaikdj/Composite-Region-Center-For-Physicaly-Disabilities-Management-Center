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
    public partial class reallo : Form
    {
        public reallo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String cs = "Server=localhost;PORT=3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            MySqlCommand cmd1 = new MySqlCommand(" select * from issueresource where patid='" + comboBox1.Text + "'");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr.GetString(1);
                textBox2.Text = dr.GetString(2);
            }
            else
            {
                MessageBox.Show(" No such Resorce as not present");

                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Focus();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);
            con.Open();
            string test = DateTime.Now.ToString("yyyy-MM-dd");

            MySqlCommand cmd1 = new MySqlCommand(" select * from resourceavail where rname='" + textBox1.Text + "'");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            dr.Read();

            int cnt = Int32.Parse(dr.GetString(1));

            cnt = cnt + 1;

            dr.Close();

            cmd1 = new MySqlCommand("update resourceavail set ravail='" + cnt.ToString() + "' where rname='" + textBox1.Text + "'");
            cmd1.Connection = con;

            cmd1.ExecuteNonQuery();

            MySqlCommand cmd3 = new MySqlCommand("insert into revokeresource values('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','"+test+"')");
            cmd3.Connection = con;

            cmd3.ExecuteNonQuery();

            cmd1 = new MySqlCommand("delete from issueresource where patid='" + comboBox1.Text + "'");
            cmd1.Connection = con;

            cmd1.ExecuteNonQuery();

            MessageBox.Show(" Resource Reallocated Successfully...");
        }

        private void reallo_Load(object sender, EventArgs e)
        {
            String cs = "Server=localhost;PORT=3306;UID=root;PWD=admin;DATABASE=hms";

            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            MySqlCommand cmd1 = new MySqlCommand(" select * from issueresource");
            MySqlDataReader dr;

            DataTable dt2 = new DataTable();


            dataGridView1.DataSource = dt2;
            dataGridView1.Visible = false;


            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            while(dr.Read())
            {

              comboBox1.Items.Add(dr.GetString(0));

            }

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

        private void button8_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from issueresource");
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

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";


            dataGridView1.Visible = false;

        }
    }
}
