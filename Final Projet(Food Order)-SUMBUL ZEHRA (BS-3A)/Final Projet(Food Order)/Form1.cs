using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Projet_Food_Order_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button3.Visible = true;
            this.button7.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button9.Visible = true;
            this.button8.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button10.Visible = true;
            this.button11.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form4 F4 = new Form4();
            F4.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5();
            F5.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form6 F6 = new Form6();
            F6.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form7 F7 = new Form7();
            F7.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 F8 = new Form8();
            F8.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 F9 = new Form9();
            F9.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
