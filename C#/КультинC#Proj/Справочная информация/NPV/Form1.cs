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
        public Form1()
        {
            InitializeComponent();

            // файл справки
            helpProvider1.HelpNamespace = "npv.chm";
            helpProvider1.SetHelpNavigator(this, HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);


            helpProvider1.SetHelpKeyword(textBox1, "npv_02.htm");//раздел справки textBox1
            helpProvider1.SetHelpNavigator(textBox1, HelpNavigator.Topic);
            helpProvider1.SetShowHelp(textBox1, true);

            helpProvider1.SetHelpKeyword(textBox2, "npv_03.htm");//раздел справки textBox2
            helpProvider1.SetHelpNavigator(textBox2, HelpNavigator.Topic);
            helpProvider1.SetShowHelp(textBox2, true);

            helpProvider1.SetHelpKeyword(textBox3, "npv_04.htm");//раздел справки textBox3
            helpProvider1.SetHelpNavigator(textBox3, HelpNavigator.Topic);
            helpProvider1.SetShowHelp(textBox3, true);


        }

        private void button1_Click(object sender, EventArgs e)//вычислить Чистый дискрементированный доход
        {
            double p = 0; //Финансовые результаты
            double r = 0;//Финансовые затраты
            double d = 0;//Ставка дисконтирования
            double npv = 0;//Чистый дискрементированный доход
            try//получение Чистого дискрементированного дохода
            {
                p = Convert.ToDouble(textBox1.Text);//взять значение из textBox и перевести в дробный тип
                r = Convert.ToDouble(textBox2.Text);
                d = Convert.ToDouble(textBox3.Text) / 100;

                npv = (p - r) / (1.0 + d);//формула нахождения Чистого дискрементированного дохода
                label4.Text =
                    "Чистый дискрементированный доход (NPV) = " +
                    npv.ToString("c");//вывод в денежном формате
            }
            catch//исключение (его нет)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)//справка
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace, "npv_01.htm");//вывод справки при нажатии на кнопку
        }

    }
}
