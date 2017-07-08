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
    public partial class Form7 : Form
    {
        public connect con = new connect();

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();

            SqlCommand cmd = new SqlCommand("select ID from Items where Itemgroup='" + comboBox1.Text + "'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["ID"]);
            }
            con.conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Items where ID='" + comboBox2.Text + "'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {


                textBox5.Text = dr["Itemname"].ToString();
                textBox11.Text = dr["Itemprice"].ToString();
                textBox2.Text = dr["ChefID"].ToString();
                textBox4.Text = dr["ChefName"].ToString();
                textBox3.Text = dr["Speci"].ToString();
            }
            con.conn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
             this.textBox11.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            this.textBox5.ReadOnly = false;
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Items SET ID = '" + comboBox2.Text + "',Itemname = '" + textBox5.Text + "',Itemgroup = '" + comboBox2.Text + "',Itemprice = '" + textBox11.Text + "',ChefID = '" + textBox2.Text + "', ChefName = '" + textBox4.Text + "',Speci = '" + textBox3.Text + "' WHERE ID = @ID", con.conn);
            cmd.Parameters.AddWithValue("@ID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Itemname", textBox5.Text);
            cmd.Parameters.AddWithValue("@Itemgroup", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Itemprice", textBox11.Text);
            cmd.Parameters.AddWithValue("@ChefID", textBox2.Text);
            cmd.Parameters.AddWithValue("@ChefName", textBox4.Text);
            cmd.Parameters.AddWithValue("@Speci", textBox3.Text);

            cmd.ExecuteNonQuery();
            con.conn.Close();
            MessageBox.Show("Record has been Updated !");
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