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
    public partial class Form9 : Form
    {
        public connect con = new connect();
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();

            SqlCommand cmd = new SqlCommand("select OrderID from Orders WHERE Status ='Not Paid' ", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["OrderID"]);
            }
            con.conn.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Orders where OrderID='" + comboBox2.Text + "'", con.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox15.Text = dr["OrderType"].ToString();
                textBox16.Text = dr["CustID"].ToString();
                textBox17.Text = dr["CustName"].ToString();
                textBox4.Text = dr["Status"].ToString();
                textBox3.Text = dr["WaiterID"].ToString();
                textBox19.Text = dr["Waitername"].ToString();
            }
            con.conn.Close();


            con.connstring();
            con.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select IID,IName,Qty,Cost from OrderProducts where OID='" + comboBox2.Text + "'", con.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.conn.Close();

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            textBox20.Text = sum.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            this.textBox1.Text = "BILL_" + comboBox2.Text;
            textBox4.Text = "Paid";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.connstring();
            con.conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Bill (Bill_No,OrderID,OrderType,CustID,CustName,WID,Wname,Status,Date,TotalAmount) values(@Bill_No,@OrderID,@OrderType,@CustID,@CustName,@WID,@Wname,@Status,@Date,@TotalAmount)", con.conn);
            cmd.Parameters.AddWithValue("@Bill_No", textBox1.Text);
            cmd.Parameters.AddWithValue("@OrderID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@OrderType", textBox15.Text);
            cmd.Parameters.AddWithValue("@CustID", textBox16.Text);
            cmd.Parameters.AddWithValue("@CustName", textBox17.Text);
            cmd.Parameters.AddWithValue("@WID", textBox3.Text);
            cmd.Parameters.AddWithValue("@Wname", textBox19.Text);
            cmd.Parameters.AddWithValue("@Status", "Paid");
            cmd.Parameters.AddWithValue("@Date", textBox5.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", textBox20.Text);
            cmd.ExecuteNonQuery();
            con.conn.Close();

            con.connstring();
            con.conn.Open();
            SqlCommand cmd1 = new SqlCommand("UPDATE Orders SET Status = '" + textBox4.Text + "' WHERE OrderID = @OrderID", con.conn);
            cmd1.Parameters.AddWithValue("@OrderID", comboBox2.Text);
            cmd.ExecuteNonQuery();
            con.conn.Close();


            MessageBox.Show("Bill Generated. Please click on reciept.");

            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button14.Visible = false;
            button1.Visible = false;
            label3.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

      
    }
}
