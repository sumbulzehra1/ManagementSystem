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
    public partial class Form10 : Form
    {
        int counter=0;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.Text = "LOGIN";
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.AcceptButton = this.button1;
            this.CancelButton = this.button2;
            this.textBox1.MaxLength = 4;
            this.textBox2.MaxLength = 4;
            this.textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox2.Text == "food" || textBox2.Text == "food")
            {
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                     counter++;
                if (counter == 1 || counter == 2)
                {
                    MessageBox.Show("Details you provided are incorrect");
                }
                if (counter == 3)
                {
                    MessageBox.Show("Try Again !");
                    Application.Exit();
                }
                }
        }
    }
}
