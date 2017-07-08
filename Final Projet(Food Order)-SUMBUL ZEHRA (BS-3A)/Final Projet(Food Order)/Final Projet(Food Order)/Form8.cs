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
    public partial class Form8 : Form
    {
        string[] id = new string[500];
        string[] prds = new string[500];
        int[] qty = new int[500];
        int[] amount = new int[500];  
        int counter = 0;


        public connect con = new connect();

        public Form8()
        {
            InitializeComponent();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            //this.button1.BackColor = Color.Red;
            //this.button2.BackColor = Color.Red;
            //this.button3.BackColor = Color.Red;
            //this.button4.BackColor = Color.Red;
            //this.button5.BackColor = Color.Red;

            this.button7.BackColor = Color.Red;
            this.button8.BackColor = Color.Red;
            this.button14.BackColor = Color.Red;
            con.connstring();
            con.conn.Open();

            SqlCommand cmd = new SqlCommand("select ID from Items where Itemgroup ='Burgers'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["ID"]);
            }
            con.conn.Close();


            con.connstring();
            con.conn.Open();

            SqlCommand cmd1 = new SqlCommand("select ID from Items where Itemgroup ='Beverages'", con.conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                comboBox3.Items.Add(dr1["ID"]);
            }
            con.conn.Close();

            con.connstring();
           
            con.conn.Open();

            SqlCommand cmd2 = new SqlCommand("select WID from Waiter", con.conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                comboBox4.Items.Add(dr2["WID"]);
            }
            con.conn.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("select ID,Itemname,Itemprice from Items where ID='" + comboBox1.Text + "'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox1.Text = dr["ID"].ToString();
                textBox2.Text = dr["Itemname"].ToString();
                textBox3.Text = dr["Itemprice"].ToString();

            }
            con.conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox3.Text);
            double b = Convert.ToDouble(textBox4.Text);
            textBox5.Text = (a * b).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //id
            textBox11.Text += textBox1.Text + Environment.NewLine;

            //quatity
            textBox13.Text += textBox4.Text +  Environment.NewLine;
            //products
            textBox12.Text += textBox2.Text +  Environment.NewLine;
            //price
            textBox14.Text += textBox5.Text +  Environment.NewLine;
            prds[counter] = textBox2.Text;
            qty[counter] = Convert.ToInt32(textBox4.Text);
            amount[counter] = Convert.ToInt32(textBox5.Text);
            id[counter] = textBox1.Text;
            counter++;




        
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("Select count(OrderID) from Orders", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }


            textBox15.Text = "Order-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            textBox16.Text = "Cust-00" + c.ToString() + "-" + System.DateTime.Today.Year;




            con.conn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Orders (OrderID,CustID,OrderType,CustName,ServingTime,WaiterID,WaiterName,Status) values(@OrderID,@CustID,@OrderType,@CustName,@ServingTime,@WaiterID,@WaiterName,@Status)", con.conn);
            cmd.Parameters.AddWithValue("@OrderID", textBox15.Text);
            cmd.Parameters.AddWithValue("@CustID", textBox16.Text);
            cmd.Parameters.AddWithValue("@OrderType", comboBox2.Text);
            cmd.Parameters.AddWithValue("@CustName", textBox17.Text);
            cmd.Parameters.AddWithValue("@ServingTime", textBox18.Text);
            cmd.Parameters.AddWithValue("@WaiterID", comboBox4.Text);
            cmd.Parameters.AddWithValue("@WaiterName", textBox19.Text);
            cmd.Parameters.AddWithValue("@Status", textBox21.Text);


            cmd.ExecuteNonQuery();
            con.conn.Close();

            con.connstring();
            con.conn.Open();

            for (int i = 0; i < counter; i++)
            {

                SqlCommand cmd1 = new SqlCommand("insert into OrderProducts(OID,IID,IName,Qty,Cost) values(@OID,@IID,@IName,@Qty,@Cost)", con.conn);
                cmd1.Parameters.AddWithValue("@OID",  textBox15.Text );
                cmd1.Parameters.AddWithValue("@IID",  id[i]);
                cmd1.Parameters.AddWithValue("@IName", prds[i]);
                cmd1.Parameters.AddWithValue("@Qty",  qty[i]);
                cmd1.Parameters.AddWithValue("@Cost", amount[i]);
                cmd1.ExecuteNonQuery();
            }

            con.conn.Close();
            MessageBox.Show("Record has been added !");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Waiter where WID='" + comboBox4.Text + "'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {


                textBox19.Text = dr["Wname"].ToString();

            }
            con.conn.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            double a = Convert.ToDouble(textBox7.Text);
            double b = Convert.ToDouble(textBox8.Text);
            textBox6.Text = (a * b).ToString();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("select ID,Itemname,Itemprice from Items where ID='" + comboBox3.Text + "'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox10.Text = dr["ID"].ToString();
                textBox9.Text = dr["Itemname"].ToString();
                textBox8.Text = dr["Itemprice"].ToString();

            }
            con.conn.Close();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            //id
            textBox11.Text += textBox10.Text +  Environment.NewLine;

            //quatity
            textBox13.Text += textBox7.Text +  Environment.NewLine;
            //products
            textBox12.Text += textBox9.Text + Environment.NewLine;
            //price
            textBox14.Text += textBox6.Text + Environment.NewLine;
            prds[counter] = textBox9.Text;
            qty[counter] = Convert.ToInt32(textBox7.Text);
            amount[counter] = Convert.ToInt32(textBox6.Text);
            id[counter] = textBox10.Text;
            counter++;

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            button14.Enabled = true;
        }
    }
}

