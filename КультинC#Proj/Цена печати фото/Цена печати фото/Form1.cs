using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Цена_печати_фото
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            radioButton1.Checked = true;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double cena;
            int n;
            double сумма;
            cena = 0;
            if (radioButton1.Checked)
                cena = 8.50;
            if (radioButton2.Checked)
                cena = 10;
            if (radioButton3.Checked)
                cena = 15.5;

            n = Convert.ToInt32(textBox1.Text);
            сумма = n * cena;
            label3.Text = "Цена: " + cena.ToString("c") +
                "\nКоличество: " + n.ToString() + "шт. \n" +
                "Сумма заказа: " + сумма.ToString("C");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                button1.Enabled = false;
            else 
                button1.Enabled = true;
            label3.Text = "";

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            textBox1.Focus();
        }
    }
}
