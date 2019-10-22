using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Денежный_конвертер
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //событие ввода
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;

            if (e.KeyChar == '.') e.KeyChar = ',';

            if (e.KeyChar == ',')
            {
                if ((textBox1.Text.IndexOf(',') != -1) ||
                    (textBox1.Text.Length == 0))
                {
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter) //нажат Enter
                {
                    if (sender.Equals(textBox1))
                        textBox2.Focus();
                    else //нажат enter во втором текстбоксе
                        button1.Focus();
                }
                return;
            }
            e.Handled = true; //запрет ввода остальных символов
        }
        //событие для блокировки кнопки когда символов нет
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            if ((textBox1.Text.Length == 0) ||
                (textBox2.Text.Length == 0))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) //сама кнопочка
        {
            double доллар;
            double курс;
            double тенге;
            double перевод;

            доллар = Convert.ToDouble(textBox1.Text);
            курс = Convert.ToDouble(textBox2.Text);

            тенге = доллар * курс;

            label3.Text =
                    тенге.ToString("C");
            MessageBox.Show(
            "У вас " + тенге.ToString("C")+ "\n"+ "Не хотите ли перевести обратно?",
            "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            перевод = тенге / доллар;
            MessageBox.Show(
            "У вас " +перевод.ToString()+ "$." + "\n" + "Операция закончена",
            "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            this.Close();
        }
    }
}
