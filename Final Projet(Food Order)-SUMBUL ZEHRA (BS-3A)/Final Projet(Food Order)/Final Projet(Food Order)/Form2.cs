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
    public partial class Form2 : Form
    {
       public connect con = new connect();
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("Select count(CID) from ChefInfo where Speci='" + comboBox1.Text + "' ", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            if (comboBox1.Text == "Beverages")
            {
                textBox1.Text = "CHEF-BEVE-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            if (comboBox1.Text == "Burgers")
            {
                textBox1.Text = "CHEF-BURG-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            con.conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Beverages");
            comboBox1.Items.Add("Burgers");


        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("insert into ChefInfo(CID,Cname,Speci,CAdd,Contact,CSal) values(@CID,@Cname,@Speci,@CAdd,@Contact,@CSal)", con.conn);
            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Speci", comboBox1.Text);
            cmd.Parameters.AddWithValue("@CAdd", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@CSal", textBox5.Text);
            

            cmd.ExecuteNonQuery();
            con.conn.Close();
       
            MessageBox.Show("Record has been added !");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            this.Hide();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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
