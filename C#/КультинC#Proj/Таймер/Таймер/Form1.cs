using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Таймер
{
    public partial class Form1 : Form
    {
        private DateTime t1;//запуск таймера
        private DateTime t2;//когда сработало
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = 59;//больше 59 минут ставить нельзя
            numericUpDown1.Minimum = 0;
            numericUpDown1.TabStop = false;

            numericUpDown2.Maximum = 59;//больше 59 секунд ставить нельзя
            numericUpDown2.Minimum = 0;
            numericUpDown2.TabStop = false;

            button1.Enabled = false;//кнопка пуск недоступна для клика
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)//позволяет нажать кнопку пуск когда значения минут и секунд поставлены
        {
            if ((numericUpDown1.Value == 0) &&
                (numericUpDown2.Value == 0))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)//пуск
        {
            if (!timer1.Enabled)
            {
                t1 = new DateTime(DateTime.Now.Year,
                    DateTime.Now.Month, DateTime.Now.Day);
                t2 =
                t1.AddMinutes((double)numericUpDown1.Value);
                t2 =
                t2.AddSeconds((double)numericUpDown2.Value);

                groupBox1.Enabled = false;
                button1.Text = "Стоп";
                if (t2.Minute < 9)
                    label1.Text =
                    "0" + t2.Minute.ToString() + "";
                else
                    label1.Text = t2.Minute.ToString() + ":";
                if (t2.Second < 9)
                    label1.Text += "0" +
                    t2.Second.ToString();
                else
                    label1.Text += t2.Second.ToString();
                timer1.Interval = 1000;//сигнал передается каждую секунду
                timer1.Enabled = true;
                groupBox1.Visible = false;
            }
            else
            {
                //когда таймер закончился
                timer1.Enabled = false;
                button1.Text = "Пуск";
                groupBox1.Enabled = true;
                numericUpDown1.Value = t2.Minute;
                numericUpDown2.Value = t2.Second;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)//сигнал самого таймера
        {
            t2 = t2.AddSeconds(-1);
            if (t2.Minute < 9)
                label1.Text = "0" + t2.Minute.ToString() + ":";
            else
                label1.Text = t2.Minute.ToString() + ":";
            if (t2.Second < 9)
                label1.Text += "0" + t2.Second.ToString();
            else
                label1.Text += t2.Second.ToString();
            if (Equals(t1, t2))
            {
                timer1.Enabled = false;
                MessageBox.Show(
                    "Заданный интервал времени истек",
                    "Таймер",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                button1.Text = "Пуск";
                groupBox1.Enabled = true;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
            }
        }


    }
}
