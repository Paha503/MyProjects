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
        }

        private void button1_Click(object sender, EventArgs e)//события при нажатии на кнопку ОК
        {
            System.IO.StreamReader sr;//определить переменную sr как поток для чтения данных
            try
            {
                sr = new System.IO.StreamReader(Application.StartupPath + "\\usd.txt", System.Text.Encoding.GetEncoding(1251));//окрыть поток для чтения в кодировке WINDOWS-1251
                /*определить переменные типа
                DateTime как начало и конец
                 выделенной даты в календаре*/
                DateTime dateStart = monthCalendar1.SelectionStart;
                DateTime dateEnd = monthCalendar1.SelectionEnd;

                string st1,st2 = "";//обьявить строковые переменные
                DateTime date;//обьявить переменную типа DateTime
                listBox1.Items.Clear();//очистить список
                
                while(!sr.EndOfStream)
                {
                    st1 = sr.ReadLine();//показать дату как строку
                    date = System.Convert.ToDateTime(st1);//присвоить преобразованные данные из переменной st1
                    st2 = sr.ReadLine();
                    if ((date >= dateStart) && (date <= dateEnd))//добавить даты в список
                    {
                        listBox1.Items.Add(st1 + "  " + st2);
                    }
                }
                sr.Close();//закрыть поток для чтения
                if (listBox1.Items.Count == 0)
                {
                    listBox1.Items.Add("--- нет данных ---");
                }

            }
            catch(Exception exc)//если ошибка, исключение
            {
                MessageBox.Show//вывод ошибки на экран
                    ("Ошибка доступа к файлу данных\n" +
                    exc.ToString(),
                    "Котировки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                button1.Enabled = false;//отключить кнопку
            }

        }
    }
}
