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
    public partial class doclog : Form
    {
        public doclog()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text== "")
            {
                MessageBox.Show("Please Enter the User Name");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Please Enter the password");
            }
            else
            {
                String jtype;


                String cs = "Server = localhost;PORT = 3306;UID=root;PWD=admin;DATABASE=hms";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                MySqlCommand cmd1 = new MySqlCommand(" select * from sp where Provider_name='" + textBox1.Text + "' && Unique_id='" + textBox2.Text + "'");
                MySqlDataReader dr;

                cmd1.Connection = con;
                dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    jtype = dr.GetString(0).ToString();

                    if (jtype == "Receptionist")
                    {

                        Form2 f = new Form2();
                        f.Show();
                    }
                    else
                    {
                        Form4 f = new Form4();
                        f.Show();
                    }
                }
                else
                {
                    MessageBox.Show(" Invalid User Account...");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
            }
            
      }
        

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
