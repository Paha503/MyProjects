using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Крыша
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (sender.Equals(textBox1))
                        textBox2.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length == 0) ||
                (textBox2.Text.Length == 0))
                button1.Enabled = false;
            else
                button1.Enabled = true;
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double w;
            double h;
            int количество;
            double цена = 0;
            double сумма;

            w = Convert.ToDouble(textBox1.Text);
            h = Convert.ToDouble(textBox2.Text);
            double w_met = 1.2;
            double h_met = 6;
            количество = Convert.ToInt32(h/h_met+w/w_met);
            if (radioButton1.Checked)
            {
                цена = 4950;
            }
            if (radioButton2.Checked)
            {
                цена = 4570;
            }
            if (radioButton3.Checked)
            {
                цена = 4220;
            }
            if (checkBox1.Checked)
            {
                цена += 700;
            }
            if (checkBox2.Checked)
            {
                цена += 1000;
            }
            сумма = (w * h) / 10000 * цена * количество;
            label4.Text =
                "Количество: " + количество+ " шт.\n"+
                "Размер: " + w_met + "x" + h_met + " м. \n" +
                "Цена (т./м.кв.): " + цена.ToString("c") +
                "\nСумма: " + сумма.ToString("c");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Крыша.Properties.Resources._1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
             pictureBox1.Image = Крыша.Properties.Resources._2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Крыша.Properties.Resources._3;
        }

    }
}
