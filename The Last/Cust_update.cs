using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace The_Last
{
    public partial class Cust_update : UserControl
    {
        private static Cust_update Cust_instance1;
        public static Cust_update instance_Cust1
        {
            get
            {
                if (Cust_instance1 == null)
                    Cust_instance1 = new Cust_update();
                return Cust_instance1;
            }
        }
        string Cs = "Data Source=DESKTOP-3OTKFSM;Initial Catalog = Furniture Store Management System; Integrated Security = True";
        public Cust_update()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string a = textBox10.Text + "-" + textBox12.Text + "-" + textBox11.Text;
                //string Cs = "Data Source=DESKTOP-L0VPAVI\\SQLEXPRESS;Initial Catalog=Furniture Store Management System;Integrated Security=True";
             //   string Cs = "Data Source=LBOTAL-PC;Initial Catalog=Furniture Store Management System;Integrated Security=True";
                SqlConnection con = new SqlConnection(Cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("update order1 set Delivery_Date=@0 where ID = @00", con);
                cmd.Parameters.Add(new SqlParameter("@0", a));
                cmd.Parameters.Add(new SqlParameter("@00", textBox4.Text));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (checkBox1.Checked == true)
            {
                if (radioButton3.Checked == true)
                {
                    //string Cs = "Data Source=DESKTOP-L0VPAVI\\SQLEXPRESS;Initial Catalog=Furniture Store Management System;Integrated Security=True";
                   
                    SqlConnection con = new SqlConnection(Cs);
                    con.Open();
                    SqlCommand com = new SqlCommand("select ID from category where name=@name", con);
                    com.Parameters.Add(new SqlParameter("@name", comboBox11.Text));
                    int d = (int)com.ExecuteScalar();
                    string C = "select price from furniture where size=@s and color = @c and model=@m and cat_id=@x";
                    SqlCommand cmd = new SqlCommand(C, con);
                    cmd.Parameters.Add(new SqlParameter("@s", comboBox6.Text));
                    cmd.Parameters.Add(new SqlParameter("@c", comboBox5.Text));
                    cmd.Parameters.Add(new SqlParameter("@m", comboBox4.Text));
                    cmd.Parameters.Add(new SqlParameter("@x", d));
                    int price = (int)cmd.ExecuteScalar();
                    SqlCommand cmd1 = new SqlCommand("update order1 set Total_Cost=(Total_Cost+@1),Num_Of_Items=(Num_Of_Items+1) where ID =@2", con);
                    cmd1.Parameters.Add(new SqlParameter("@1", price));
                    cmd1.Parameters.Add(new SqlParameter("@2", textBox4.Text));
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("select ID from furniture where model=@mm and color = @mmm and size = @mmmm and cat_id=@m", con);
                    cmd2.Parameters.Add(new SqlParameter("@mm", comboBox4.Text));
                    cmd2.Parameters.Add(new SqlParameter("@mmm", comboBox5.Text));
                    cmd2.Parameters.Add(new SqlParameter("@mmmm", comboBox6.Text));
                    cmd2.Parameters.Add(new SqlParameter("@m", d));
                    int IDD = (int)cmd2.ExecuteScalar();
                    SqlCommand cmd3 = new SqlCommand("insert into order_furniture_relation values (@1,@2)", con);
                    cmd3.Parameters.Add(new SqlParameter("@1", textBox4.Text));
                    cmd3.Parameters.Add(new SqlParameter("@2", IDD));
                    cmd3.ExecuteNonQuery();
                    con.Close();
                }
                else if (radioButton4.Checked == true)
                {
                    //string Cs = "Data Source=DESKTOP-L0VPAVI\\SQLEXPRESS;Initial Catalog=Furniture Store Management System;Integrated Security=True";
                //    string Cs = "Data Source=LBOTAL-PC;Initial Catalog=Furniture Store Management System;Integrated Security=True";
                    SqlConnection con = new SqlConnection(Cs);
                    con.Open();
                    SqlCommand com = new SqlCommand("select ID from category where name=@name", con);
                    com.Parameters.Add(new SqlParameter("@name", comboBox12.Text));
                    int d = (int)com.ExecuteScalar();
                    string C = "select price from furniture where size=@s and color = @c and model=@m and cat_id=@b";
                    SqlCommand cmd = new SqlCommand(C, con);
                    cmd.Parameters.Add(new SqlParameter("@s", comboBox9.Text));
                    cmd.Parameters.Add(new SqlParameter("@c", comboBox8.Text));
                    cmd.Parameters.Add(new SqlParameter("@m", comboBox7.Text));
                    cmd.Parameters.Add(new SqlParameter("@b", d));
                    int price = (int)cmd.ExecuteScalar();
                    SqlCommand cmd1 = new SqlCommand("update order1 set Total_Cost=(Total_Cost-@1),Num_Of_Items=(Num_Of_Items-1) where ID =@2", con);
                    cmd1.Parameters.Add(new SqlParameter("@1", price));
                    cmd1.Parameters.Add(new SqlParameter("@2", textBox4.Text));
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("select ID from furniture where model=@mm and color=@mmm and size = @mmmm and cat_id=@a", con);
                    cmd2.Parameters.Add(new SqlParameter("@mm", comboBox7.Text));
                    cmd2.Parameters.Add(new SqlParameter("@mmm", comboBox8.Text));
                    cmd2.Parameters.Add(new SqlParameter("@mmmm", comboBox9.Text));
                    cmd2.Parameters.Add(new SqlParameter("@a", d));
                    int IDD = (int)cmd2.ExecuteScalar();
                    SqlCommand cmd3 = new SqlCommand("delete from order_furniture_relation where order_id=@1 and furniture_id=@2", con);
                    cmd3.Parameters.Add(new SqlParameter("@1", textBox4.Text));
                    cmd3.Parameters.Add(new SqlParameter("@2", IDD));
                    cmd3.ExecuteNonQuery();
                    con.Close();
                }
            }
            //MessageBox.Show("Order has been updated successfuly");
        }
    }
}
