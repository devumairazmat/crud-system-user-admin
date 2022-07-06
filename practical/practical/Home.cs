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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                unametxtbx.Text = row.Cells["username"].Value.ToString();
                fnametxtbx.Text = row.Cells["firstname"].Value.ToString();
                passtxtbx.Text = row.Cells["password"].Value.ToString();
                lnametxtbx.Text = row.Cells["lastname"].Value.ToString();
                emailtxtbx.Text = row.Cells["email"].Value.ToString();
                phonetxtbx.Text = row.Cells["phoneno"].Value.ToString();
                

            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

            String checking = login.usrname;
            String co = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\StudentManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(co);
            con.Open();

            if (checking == "admin")
            {
                

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                button1.Visible = false;

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User] where username='"+checking+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            login l = new login();
                l.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String co = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\StudentManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(co);
            con.Open();

            string Query = "update [User] set username='" + this.unametxtbx.Text + "',password='" + this.passtxtbx.Text + "',firstname='" + this.fnametxtbx.Text + "',lastname='" + this.lnametxtbx.Text + "',email='" + this.emailtxtbx.Text + "' where phoneno='" + this.phonetxtbx.Text + "' where username='"+unametxtbx.Text+"';";
            //This is  MySqlConnection here i have created the object and pass my connection string.
            
            SqlCommand MyCommand2 = new SqlCommand(Query, con);
            SqlDataReader MyReader2;
         
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data Updated");
            while (MyReader2.Read())
            {
            }
            con.Close();//Connection closed here
        }

        private void Home_Click(object sender, EventArgs e)
        {
            String checking = login.usrname;
            String co = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\StudentManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(co);
            con.Open();

            if (checking == "admin")
            {


                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                


                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User] where username='" + checking + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String co = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\StudentManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(co);
            con.Open();

            string Query = "delete from [User] where username='"+unametxtbx.Text+"'";
            //This is  MySqlConnection here i have created the object and pass my connection string.

            SqlCommand MyCommand2 = new SqlCommand(Query, con);
            SqlDataReader MyReader2;

            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data deleted");
            
            con.Close();//Connection closed here
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String co = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\StudentManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(co);
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
    }
}
