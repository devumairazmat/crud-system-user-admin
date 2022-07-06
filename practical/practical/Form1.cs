using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practical
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String co = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\StudentManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con=new SqlConnection(co);
            con.Open();
            String ins_query = "insert into [User](username,password,firstname,lastname,email,phoneno) values('" + unametxtbx.Text + "','" + passtxtbx.Text + "','" + fnametxtbx.Text + "','" + lnametxtbx.Text + "','" + emailtxtbx.Text + "','" + phonetxtbx.Text + "')";
            SqlCommand com = new SqlCommand(ins_query, con);
            int i = com.ExecuteNonQuery();
            if (i == 0)
            {
                MessageBox.Show("error occur");
            }
            else
            {
                MessageBox.Show("successfully registerd");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            login l = new login();
            l.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
