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
    public partial class Form4 : Form
    {
        public connect con = new connect();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Lunch");
            comboBox1.Items.Add("Dinner");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Waiter(WID,Wname,WShift,WAdd,WContact,WSal) values(@WID,@Wname,@WShift,@WAdd,@WContact,@WSal)", con.conn);
            cmd.Parameters.AddWithValue("@WID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Wname", textBox2.Text);
            cmd.Parameters.AddWithValue("@WShift", comboBox1.Text);
            cmd.Parameters.AddWithValue("@WAdd", textBox3.Text);
            cmd.Parameters.AddWithValue("@WContact", textBox4.Text);
            cmd.Parameters.AddWithValue("@WSal", textBox5.Text);


            cmd.ExecuteNonQuery();
            con.conn.Close();

            MessageBox.Show("Record has been added !");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("Select count(WID) from Waiter ", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            if (comboBox1.Text == "Lunch")
            {
                textBox1.Text = "WAITER-LUNCH-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            if (comboBox1.Text == "Dinner")
            {
                textBox1.Text = "WAITER-DINNER-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            con.conn.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
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
