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

        private void Form1_Paint(object sender, PaintEventArgs e)//отрисовка
        {
            e.Graphics.DrawString("Microsoft Visual C#", this.Font, Brushes.DarkGreen, 10, 10);//отрисовка текста шрифтом
            Font aFont = new Font("Tahoma", 12, FontStyle.Regular);
            e.Graphics.DrawString("Microsoft Visual C#", aFont, Brushes.Black, 10, 30);//отрисовка пользовательским шрифтом
            //отрисовка заголовка
            Font hFont = new Font("Tahoma", 14, FontStyle.Regular);
            string header = "Microsoft Visual C# 2008 Express Edition";
            //размер отображения текста
            int w = (int)e.Graphics.MeasureString(header, hFont).Width;
            int h = (int)e.Graphics.MeasureString(header, hFont).Height;
            //положение по центру
            int x = (this.ClientSize.Width - w) / 2;
            int y = (this.ClientSize.Height - h) / 2;
            e.Graphics.DrawString(header,hFont,System.Drawing.Brushes.DarkGreen, x, y);//текст
            e.Graphics.DrawString(header, hFont, System.Drawing.Brushes.DarkGreen, x, y+h);//заголовок
        }

        private void Form1_Resize(object sender, EventArgs e)//перерисовка окна при изменении его размеров
        {
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
