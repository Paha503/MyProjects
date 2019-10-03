using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mili_kilometry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //допущение использования Enter, Backspace, замена точки на запятую.
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) //ввод цифр
            {
                return;
            }
            if (e.KeyChar == '.') //замена точки
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1) //запятая стоит.
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter) //Если нажат Enter, то курсор ставится на кнопку ТЫК!
                    button1.Focus();
                return;
            }
            e.Handled = true; //запрещение ввода остальных символов.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double мили;
            double километры;
            try //если в поле нет данных - пустая строка вызывает исключение(смотрите catch).
            {
                мили = Convert.ToDouble(textBox1.Text);
                километры = мили * 1.609344;
                label2.Text = километры.ToString("n")
                                + " км.";
            }
            catch //исключение - переместить курсор в поле ввода.
            {
                textBox1.Focus();
            }
        }
    }
}
