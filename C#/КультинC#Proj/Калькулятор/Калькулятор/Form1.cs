using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Калькулятор
{
    public partial class Form1 : Form
    {
        private const int bw = 40, bh = 22; //размер кнопок
        private const int dx = 5, dy = 5; //расстояние между кнопками
        private Button[] btn = new Button[15];
        char[] btnText = {'7','8','9','+', //текст кнопок
                              '4','5','6','-',
                              '1','2','3','=',
                              '0',',','c'};
        int[] btnTag = {7,8,9,-3,
                            4,5,6,-4,
                            1,2,3,-2,
                            0,-1,-5};
        private double ac = 0;//аккумулятор
        private int op = 0;//код операции
        private Boolean fd = true; //при fd = true ожидание первой цифры числа, затем при операции с числом переходит в false, ожидая следующее число.
        public Form1()
        {
            InitializeComponent();
            int k = 0;
            int x, y;
            this.ClientSize =       //размер приложухи
                new Size(4 * bw + 5 * dx, 5 * bh + 7 * dy);
            textBox1.SetBounds(dx, dy, 4 * bw + 3 * dx, bh); //циферка
            textBox1.Text = "0";
            y = textBox1.Bottom + dy;
            for (int i = 0; i < 4; i++)
            {
                x = dx;
                for (int j = 0; j < 4; j++)
                {
                    if (!((i == 3) && (j == 0)))
                    {
                        btn[k] = new Button(); //создание кнопки
                        btn[k].SetBounds(x, y, bw, bh);
                        btn[k].Tag = btnTag[k];
                        btn[k].Text = btnText[k].ToString();

                        this.btn[k].Click +=
                   new System.EventHandler(this.Button_Click);
                        if (btnTag[k] < 0)
                        {
                            btn[k].BackColor =
                                SystemColors.ControlLight;
                        }
                        this.Controls.Add(this.btn[k]);
                        x = x + bw + dx;
                        k++;
                    }
                    else
                    {
                        btn[k] = new Button();
                        btn[k].SetBounds(x, y, bw * 2 + dx, bh);
                        btn[k].Tag = btnTag[k];
                        btn[k].Text = btnText[k].ToString();
                        this.btn[k].Click +=
                            new
                            System.EventHandler(this.Button_Click);
                        this.Controls.Add(this.btn[k]);

                        x = x + 2 * bw + 2 * dx;
                        k++;
                        j++;
                    }
                }
                y = y + bh + dy;
            }
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;

            if (Convert.ToInt32(btn.Tag) > 0)
            {
                if (fd)
                {
                    textBox1.Text = btn.Text;
                    fd = false;
                }
                else
                    textBox1.Text += btn.Text;
                return;
            }
            if (Convert.ToInt32(btn.Tag) == 0)
            {
                if (fd) textBox1.Text = btn.Text;
                if (textBox1.Text != "0")
                    textBox1.Text += btn.Text;
                return;
            }
            if (Convert.ToInt32(btn.Tag) == -1)
            {
                if (fd)
                {
                    textBox1.Text = "0,";
                    fd = false;
                }
                else
                    if (textBox1.Text.IndexOf(",")==-1)
                    textBox1.Text += btn.Text;
                return;
            }
            if (Convert.ToInt32(btn.Tag) == -5)
            {
                ac = 0;
                op = 0;
                textBox1.Text = "0";
                fd = true;
                return;
            }
            if (Convert.ToInt32(btn.Tag) < -1)
            {
                double n;
                n = Convert.ToDouble(textBox1.Text);
                if (ac != 0)
                {
                    switch (op)
                    {
                        case -3: ac += n;
                            break;
                        case -4: ac -= n;
                            break;
                        case -2: ac = n;
                            break;
                    }
                    textBox1.Text = ac.ToString("N");
                }
                else {
                    ac = n;
                }
                op = Convert.ToInt32(btn.Tag);
                fd = true;
            }
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
            e.Handled = true; //запрет на ввод других символов.
        }
    }
}
