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
    public partial class Cust_search : UserControl
    {
            private static Cust_search Cust_instance3;
            public static Cust_search instance_Cust3
            {
                get
                {
                    if (Cust_instance3 == null)
                        Cust_instance3 = new Cust_search();
                    return Cust_instance3;
                }
            }
            string Cs = "Data Source=DESKTOP-3OTKFSM;Initial Catalog = Furniture Store Management System; Integrated Security = True";
        public Cust_search()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

          //  string Cs = "Data Source=LBOTAL-PC;Initial Catalog=Furniture Store Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(Cs);
            con.Open();

            if (SearchbyModel.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("select * from furniture F inner join category C on C.ID = F.cat_id where F.model = @model ", con);
                cmd.Parameters.Add(new SqlParameter("@model", comboBox13.Text));
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();


                DataTable thelistsearched = new DataTable();
                thelistsearched.Columns.Add("size");
                thelistsearched.Columns.Add("color");
                thelistsearched.Columns.Add("price");
                thelistsearched.Columns.Add("units_in_stock");
                thelistsearched.Columns.Add("Cat Name");


                DataRow row;

                while (reader.Read())
                {
                    row = thelistsearched.NewRow();
                    row["size"] = reader["size"];
                    row["color"] = reader["color"];
                    row["price"] = reader["price"];
                    row["units_in_stock"] = reader["units_in_stock"];
                    row["Cat Name"] = reader["name"];

                    thelistsearched.Rows.Add(row);
                }

                reader.Close();
                con.Close();

                listofSearch.DataSource = thelistsearched;
            }

            else if (Searchbycat.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("select * from furniture F inner join category C on C.ID = F.cat_id where C.name = @cat", con);
                cmd.Parameters.Add(new SqlParameter("@cat", comboBox14.Text));
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();


                DataTable thelistsearched = new DataTable();
                thelistsearched.Columns.Add("size");
                thelistsearched.Columns.Add("color");
                thelistsearched.Columns.Add("model");
                thelistsearched.Columns.Add("price");
                thelistsearched.Columns.Add("units_in_stock");
                thelistsearched.Columns.Add("Cat Name");

                DataRow row;

                while (reader.Read())
                {
                    row = thelistsearched.NewRow();
                    row["size"] = reader["size"];
                    row["color"] = reader["color"];
                    row["model"] = reader["model"];
                    row["price"] = reader["price"];
                    row["units_in_stock"] = reader["units_in_stock"];
                    row["Cat Name"] = reader["name"];

                    thelistsearched.Rows.Add(row);
                }

                reader.Close();
                con.Close();

                listofSearch.DataSource = thelistsearched;
            }
            else
                MessageBox.Show("invaild input");

            comboBox13.Text = "";
            comboBox14.Text = "";

        }
    }
}
