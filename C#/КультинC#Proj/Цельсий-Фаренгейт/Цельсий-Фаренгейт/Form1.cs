using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Фунты_килограммы
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false; //Сделать ТЫК! недоступным.
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (e.KeyChar == '.') e.KeyChar = ','; //замена точки на запятую

            if (e.KeyChar == ',')
            {                                                   //Нельзя ставить запятую первой, нельзя ставить больше одной
                if ((textBox1.Text.IndexOf(',') != -1) ||
                    (textBox1.Text.Length == 0))
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))  //enter, ctrl, esc
            {
                if (e.KeyChar == (char)Keys.Enter)
                    button1.Focus();
                return;
            }
            e.Handled = true; //запрет на ввод других символов.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = ""; //очистка поля
            if (textBox1.Text.Length == 0) //если пусто
                button1.Enabled = false;
            else //иначе кнопка рабочая
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double цельсий;
            double фаренгейт;

            цельсий = Convert.ToDouble(textBox1.Text);
            фаренгейт = 9/5 * цельсий + 32;

            label2.Text = цельсий.ToString("N") + " градусов Цельсия = "
                            + фаренгейт.ToString("N") + " градусов Фаренгейта.";
        }
    }
}
