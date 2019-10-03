using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Жалюзи
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.DropDownStyle =
                ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
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
                    else comboBox1.Focus();
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
            double цена = 0;
            double сумма;

            w = Convert.ToDouble(textBox1.Text);
            h = Convert.ToDouble(textBox2.Text);

            switch (comboBox1.SelectedIndex)
            {
                case 0: цена = 50; break;
                case 1: цена = 100; break;
                case 2: цена = 75; break;
                case 3: цена = 70; break;
                case 4: цена = 60; break;
            }
            сумма = (w * h) / 10000 * цена;
            label4.Text =
                "Размер: " + w + "x" + h + " см. \n" +
                "Цена (р./м.кв.): " + цена.ToString("c") +
                "\nСумма: " + сумма.ToString("c");
        }
    }
}
