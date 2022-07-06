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
    
    public partial class login : Form
    {
        public static string usrname = ""; //for validating admin priviliages
        public login()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            usrname = unametxtbx.Text;

            String co = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\StudentManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(co);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [User] WHERE username='" + unametxtbx.Text + "' AND password='" + passtxtbx.Text + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */

                Home hf = new Home();
                hf.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Invalid username or password");

        }
    }
    }

