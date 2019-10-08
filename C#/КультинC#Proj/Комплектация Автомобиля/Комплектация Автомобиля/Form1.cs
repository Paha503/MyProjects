using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Комплектация_Автомобиля
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double сумма;
            double скидка;
            double total;

            сумма = 309000;
            скидка = 0;

            if (checkBox1.Checked)
            {
               сумма += 8390;
            }
            if (checkBox1.Checked)
            {
                сумма += 5990;
            }
            if (checkBox1.Checked)
            {
                сумма += 7590;
            }
            total = сумма;

            string st;
            st = "Цена в выбранной комплектации: " +
                сумма.ToString("C");
            if ((checkBox1.Checked) && (checkBox2.Checked) &&
                (checkBox3.Checked))
            {
                скидка = сумма * 0.01;
                total = total - скидка;
                st += "\nСкидка (1%): " +
                    скидка.ToString("C") +
                    "\nИтого: " + total.ToString("C");
            }
            label3.Text = st;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
