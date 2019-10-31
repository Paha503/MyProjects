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
        private string fn = string.Empty;//обьявить пустую строку fn
        private bool docChanged = false;
        public Form1()
        {
            InitializeComponent();

            textBox1.ScrollBars = ScrollBars.Vertical;//полоса прокрутки
            textBox1.Text = string.Empty;//при запуске пустой текст
            
            this.Text = "NkEdit - Новый документ";//поменять название формы

            toolStrip1.Visible = true;
            ParamToolStripMenuItem.Checked = true;

            openFileDialog1.DefaultExt = "txt";//настройка openFileDialog
            openFileDialog1.Filter = "текст|*.txt";
            openFileDialog1.Title = "Открыть документ";
            openFileDialog1.Multiselect = false;

            saveFileDialog1.DefaultExt = "txt";//настройка openFileDialog
            saveFileDialog1.Filter = "текст|*.txt";
            saveFileDialog1.Title = "Сохранить документ";
        }
        private void OpenDocument()//событие кнопки открыть файл
        {
            openFileDialog1.FileName = string.Empty;//в названии пусто
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//если все прошло успешно
            {
                fn = openFileDialog1.FileName;
                this.Text = fn;//редактору присваивается имя открытого файла
                try//выводим файл на экран
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fn);
                    textBox1.Text = sr.ReadToEnd();
                    textBox1.SelectionStart = textBox1.TextLength;
                    //считываем файл
                    sr.Close();//закрываем поток для чтения
                }
                catch(Exception exc)//вывод исключения на экран
                {
                    MessageBox.Show("Ошибка доступа к файлу\n" +
                    exc.ToString(), "NkEdit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private int SaveDocument()
        {
            int result = 0;
            if (fn == string.Empty)//сохранение если у файла нет имени
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)//если все прошло успешно
                {
                    fn = saveFileDialog1.FileName;
                    this.Text = fn;//присвоить имя сохраненного файла программе
                }
                else result = -1;
            }
            if (fn != string.Empty)//сохранение именованного файла
            {
                try//если проходит
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fn);//получаем инфу о файле
                    System.IO.StreamWriter sw = fi.CreateText();//открываем поток для редактирования
                    sw.Write(textBox1.Text);//редактируем
                    sw.Close();//закрываем поток
                    result = 0;//возвращаем ничего
                }
                catch(Exception exc)//если ашипка
                {
                    MessageBox.Show(exc.ToString(),
                        "NkEdit",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            return result;//возвращаем данные
        }

        private void FileCreateToolStripButton_Click(object sender, EventArgs e)//создать файл
        {
            if (docChanged)//если файл изменен
            {
                DialogResult dr;//работа месейджбокса
                dr = MessageBox.Show(
                    "Сохранить изменения?", "NkEdit",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                switch (dr)//кнопки Месейджбокса
                {
                    case DialogResult.Yes://да
                        if (SaveDocument()==0)
                        {
                            textBox1.Clear();
                            docChanged = false;
                        }
                        break;
                    case DialogResult.No://нет
                        textBox1.Clear();
                        docChanged = false;
                        break;
                    case DialogResult.Cancel://отмена
                        break;
                };
            }
        }

        private void FileOpenToolStripButton_Click(object sender, EventArgs e)//открыть файл
        {
            openFileDialog1.FileName = string.Empty;//поле ввода файла для открытия пустое
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//если все прошло успешно
            {
                fn = openFileDialog1.FileName;
                this.Text = fn;//присвоить имя открытого файла программе
                try//если проходит
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fn);
                    textBox1.Text = sr.ReadToEnd();
                    textBox1.SelectionStart = textBox1.TextLength;
                    //чтение файла
                    sr.Close();//закрыть поток для чтения
                }
                catch(Exception exc)//если ошибка
                {
                    MessageBox.Show("Ошибка чтения файла.\n"+
                        exc.ToString(),"MEdit",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void FileSaveToolStripButton_Click(object sender, EventArgs e)//кнопка сохранить
        {
            SaveDocument();//вызов события сохранения
        }

        private void FileExitToolStripMenuItem_Click(object sender, EventArgs e)//выход из программы
        {
            this.Close();
        }

        private void ParamToolStripMenuItem_Click(object sender, EventArgs e)//параметры панели инструментов
        {
            toolStrip1.Visible = !toolStrip1.Visible;
            ParamToolStripMenuItem.Checked = !ParamToolStripMenuItem.Checked;
        }

        private void ParamFontToolStripMenuItem_Click(object sender, EventArgs e)//изменить шрифт
        {
            fontDialog1.Font = textBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
            //изменяем шрифт textBox
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//изменения в редакторе
        {
            docChanged = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//при закрытии формы
        {
            if (docChanged)//если файл изменен
            {
                DialogResult dr;
                dr = MessageBox.Show("Сохранить изменения?",
                    "NkEdit",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (SaveDocument() != 0)
                            e.Cancel = true;
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 about = new Form2();
            about.ShowDialog();
        }

        private void печатьToolStripButton_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }
        

    }
}
