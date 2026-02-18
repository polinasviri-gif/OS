using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace LAB1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.button1.Click += new EventHandler(AnyButton_Click);
            this.button2.Click += new EventHandler(AnyButton_Click);

            this.button1.MouseLeave += new EventHandler(AnyButton_MouseLeave);
            this.button2.MouseLeave += new EventHandler(AnyButton_MouseLeave);

            this.button1.MouseEnter += new EventHandler(button1_MouseEnter);
            this.button2.MouseEnter += new EventHandler(button2_MouseEnter);
        }

        private void AnyButton_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void AnyButton_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "";
            button2.Text = "";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "пришел";
            button2.Text = "ушел";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "ушел";
            button2.Text = "пришел";
        }
    }
}
