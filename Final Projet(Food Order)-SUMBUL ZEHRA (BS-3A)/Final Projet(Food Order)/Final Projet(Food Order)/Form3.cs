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
    public partial class Form3 : Form
    {
        public connect con = new connect();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;

            con.connstring();
            con.conn.Open();
            
            SqlCommand cmd = new SqlCommand("select CID from ChefInfo", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]);
            }
            con.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             con.connstring();
            con.conn.Open();
           SqlCommand cmd = new SqlCommand("select * from ChefInfo where CID='"+comboBox1.Text+"'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {


                textBox1.Text = dr["Cname"].ToString();
                textBox2.Text = dr["CAdd"].ToString();
                textBox3.Text = dr["Contact"].ToString();
                textBox4.Text = dr["CSal"].ToString();
                textBox5.Text = dr["Speci"].ToString();
            }
            con.conn.Close();   
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            this.textBox5.ReadOnly = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE ChefInfo SET Cname = '" + textBox1.Text + "',CAdd = '" + textBox2.Text + "',Contact = '" + textBox3.Text + "',CSal = '" + textBox4.Text + "',Speci = '" + textBox5.Text + "' WHERE CID = @CID", con.conn);
            cmd.Parameters.AddWithValue("@CID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Cname", textBox1.Text);
            cmd.Parameters.AddWithValue("@Speci", textBox5.Text);
            cmd.Parameters.AddWithValue("@CAdd", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@CSal", textBox4.Text);
         
            cmd.ExecuteNonQuery();
            con.conn.Close();
            MessageBox.Show("Record has been Updated !");
        
            
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
