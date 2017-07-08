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
    public partial class Form5 : Form
    {
        public connect con = new connect();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;

            con.connstring();
            con.conn.Open();

            SqlCommand cmd = new SqlCommand("select WID from Waiter", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["WID"]);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
             con.connstring();
            con.conn.Open();
           SqlCommand cmd = new SqlCommand("select * from Waiter where WID='"+comboBox1.Text+"'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {


                textBox1.Text = dr["Wname"].ToString();
                textBox2.Text = dr["WAdd"].ToString();
                textBox3.Text = dr["WContact"].ToString();
                textBox4.Text = dr["WSal"].ToString();
                textBox5.Text = dr["WShift"].ToString();
            }
            con.conn.Close();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Waiter SET WName = '" + textBox1.Text + "',WAdd = '" + textBox2.Text + "',WContact = '" + textBox3.Text + "',WSal = '" + textBox4.Text + "',WShift = '" + textBox5.Text + "' WHERE WID = @WID", con.conn);
            cmd.Parameters.AddWithValue("@WID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@WName", textBox1.Text);
            cmd.Parameters.AddWithValue("@WShift", textBox5.Text);
            cmd.Parameters.AddWithValue("@WAdd", textBox2.Text);
            cmd.Parameters.AddWithValue("@WContact", textBox3.Text);
            cmd.Parameters.AddWithValue("@WSal", textBox4.Text);

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
