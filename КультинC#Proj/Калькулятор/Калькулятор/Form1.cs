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
            label1.SetBounds(dx, dy, 4 * bw + 3 * dx, bh); //циферка
            label1.Text = "0";
            y = label1.Bottom + dy;
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
                        btn[k].SetBounds(x, y,
                    }
                }
            }
        }
    }
}
