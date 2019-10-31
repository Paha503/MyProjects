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

            button1.Enabled = false;//кнопка недоступна до тех пор, пока не будут выполнены требования
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//правила ввода символов
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))//можно использовать только числа
                return;
            if (e.KeyChar == '.')//замена точки на запятую
                e.KeyChar = ',';
            if (e.KeyChar == ',')//запятая не может быть первым символом и она может быть только одна
            {
                if ((textBox1.Text.IndexOf(',') != -1) ||
                    (textBox1.Text.Length == 0))
                {
                    e.Handled = true;//другие символы нельзя использовать
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))//при Enter курсор переходит на кнопку Добавить
            {
                if (e.KeyChar == (char)Keys.Enter)
                    button1.Focus();
                return;
            }
            e.Handled = true;//другие символы нельзя использовать
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//проверка textBox на содержание символов
        {
            if (textBox1.Text.Length == 0)//если пусто - кнопку нажать нельзя, если символы введены - то можно
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)//действия при нажатии на кнопку
        {
            double курс;//переменная курса дробного типа
            DateTime дата;//переменная даты типа DateTime

            дата = dateTimePicker1.Value;//присвоить переменной дата дату из компонента dateTimePicker
            курс = System.Convert.ToDouble(textBox1.Text);//преобразовать строки из textBox в дробный тип и присвоить переменной курс
            
            System.IO.FileInfo fi = new System.IO.FileInfo(Application.StartupPath + "\\usd.dat");//получить данные из файла usd.txt и присвоить переменной fi
            System.IO.StreamWriter sw;//определяем переменную sw как поток для записи данных

            if (fi.Exists)//если данные есть, то открываем поток для записи в файл
                sw = fi.AppendText();
            else//если данных нет, то создаем их
                sw = fi.CreateText();
            sw.WriteLine(дата.ToShortDateString());//вывод даты
            sw.WriteLine(курс.ToString("N"));//вывод записи в численном формате
            //закрыть редактирование
            sw.Close();
            button1.Enabled = false;
            textBox1.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)//выбрана другая дата
        {
            //открыть редактирование
            textBox1.Enabled = true;
            textBox1.Clear();
            textBox1.Focus();//установить курсор на вводе
        }

    }
}
