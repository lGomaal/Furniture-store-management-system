using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace The_Last
{
    public partial class Admin_Form : Form
    {
        string Connection = "Data Source=DESKTOP-3OTKFSM;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        public Admin_Form()
        {
            InitializeComponent();
        }
        
        private void Admin_Form_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            this.Hide();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mail = Admin_Mail.Text;
            string pass = Admin_pass.Text;
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select E_mail , password from adminstrator where E_mail=@mail and password=@pass", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@mail", mail);
            com.Parameters.AddWithValue("@pass", pass);
            SqlDataReader r = com.ExecuteReader();
            if (r.HasRows)
            {
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                Admin_panel.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                Admin_panel.Enabled = false;
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Admin_panel.Controls.Contains(Admin_Add.instance))
            {
                Admin_panel.Controls.Add(Admin_Add.instance);
                Admin_Add.instance.Dock = DockStyle.Fill;
                Admin_Add.instance.BringToFront();
            }
            else
                Admin_Add.instance.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!Admin_panel.Controls.Contains(Admin_Delete.instance1))
            {
                Admin_panel.Controls.Add(Admin_Delete.instance1);
                Admin_Delete.instance1.Dock = DockStyle.Fill;
                Admin_Delete.instance1.BringToFront();
            }
            else
                Admin_Delete.instance1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Admin_panel.Controls.Contains(Admin_Update.instance2))
            {
                Admin_panel.Controls.Add(Admin_Update.instance2);
                Admin_Update.instance2.Dock = DockStyle.Fill;
                Admin_Update.instance2.BringToFront();
            }
            else
                Admin_Update.instance2.BringToFront();
        }
    }
}
