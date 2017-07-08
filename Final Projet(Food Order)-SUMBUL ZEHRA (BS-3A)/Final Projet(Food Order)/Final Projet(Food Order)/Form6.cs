using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Final_Projet_Food_Order_
{
    public partial class Form6 : Form
    {
        public connect con = new connect();

        public Form6()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("Select count(ID) from Items where Itemgroup='" + comboBox1.Text + "' ", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            if (comboBox1.Text == "Burgers")
            {
                textBox1.Text = "BURG-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            if (comboBox1.Text == "Beverages")
            {
                textBox1.Text = "BEVE-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

        

            con.conn.Close();

            con.connstring();
            con.conn.Open();

            SqlCommand cmd1 = new SqlCommand("select CID from ChefInfo where Speci='" + comboBox1.Text + "'", con.conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["CID"]);
            }
            con.conn.Close();

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Burgers");
            comboBox1.Items.Add("Beverages");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("select * from ChefInfo where CID='" + comboBox2.Text + "'  ", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
             textBox3.Text = dr["Cname"].ToString();
             textBox2.Text = dr["Speci"].ToString();
            }
            con.conn.Close();   
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Items(ID,Itemname,Itemgroup,Itemprice,ChefID,ChefName,Speci) values(@ID,@Itemname,@Itemgroup,@Itemprice,@ChefID,@ChefName,@Speci)", con.conn);
            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Itemname", textBox4.Text);
            cmd.Parameters.AddWithValue("@Itemgroup", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Itemprice", textBox11.Text);
            cmd.Parameters.AddWithValue("@ChefID",comboBox2.Text);
            cmd.Parameters.AddWithValue("@ChefName", textBox3.Text);
            cmd.Parameters.AddWithValue("@Speci", textBox2.Text);


            cmd.ExecuteNonQuery();
            con.conn.Close();

            MessageBox.Show("Record has been added !");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keypress = e.KeyChar;
            if (char.IsDigit(keypress) || e.KeyChar == Convert.ToChar(Keys.Back))
            {


            }
            else
            {
                MessageBox.Show("You Can Only Enter A Number!");
                e.Handled = true;
            }
        }
    }
}
