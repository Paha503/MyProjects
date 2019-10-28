using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int m, s, ms;//собсна минуты секунды и миллисекунды(а не часы)
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 500;//сигнал каждые полсекунды
            m = 0; s = 0; ms = 0;//ОБНУЛЕНИЕ
            label1.Text = "00";
            label2.Text = "00";
            label3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)//кнопка пуск и стоп
        {
            if (timer1.Enabled)//кнопка пуск
            {
                timer1.Enabled = false;
                button1.Text = "Пуск";
                button2.Enabled = true;
            }
            else//кнопка стоп
            {
                timer1.Enabled = true;
                button1.Text = "Стоп";
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)//кнопка сброс
        {
            m = 0; s = 0; ms = 0;//ОБНУЛЕНИЕ
            label1.Text = "00";
            label2.Text = "00";
        }

        private void timer1_Tick(object sender, EventArgs e)//сигнал таймера
        {
            if (label3.Visible)//двоеточие мигает с интервалом в полсекунды
            {
                if (s < 59)//до тех пор пока секунды не равны 59, они будут увеличиваться
                {
                    s++;
                    if (s < 10)//если секунд меньше чем 10, то нумерация будет вида 0X
                        label2.Text = "0" + s.ToString();
                    else
                        label2.Text = s.ToString();
                }
                else
                {
                    if (m < 59)//до тех пор пока минуты не равны 59, они будут увеличиваться
                    {
                        m++;
                        if (m < 10)//если минут меньше чем 10, то нумерация будет вида 0X
                            label1.Text = "0" + s.ToString();
                        else
                            label1.Text = s.ToString();
                        s = 0;
                        label2.Text = "00";
                    }
                    else
                    {
                        m = 0;
                        label1.Text = "00";
                    }
                }
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true; 
            }
        }
    }
}
