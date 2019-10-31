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
        private double[] d;
        private void drawDiagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;//холст

            Font dFont = new Font("Tahoma", 9);//шрифт подписей данных

            Font hFont = new Font("Tahoma", 14, FontStyle.Regular);//заголовок
            string header = "Изменение курса доллара";

            int wh = (int)g.MeasureString(header, hFont).Width;//область отображения текста
            int x = (this.ClientSize.Width - wh) / 2;
            g.DrawString(header, hFont, System.Drawing.Brushes.DarkGreen, x, 5);//прорисовка заголовка
            double max = d[0];//макс элемент массива
            double min = d[0];//мин элемент массива
            for (int i = 1; i < d.Length; i++)
            {
                if (d[i] > max) max = d[i];
                if (d[i] < min) min = d[i];
            }

            int x1, y1;//левый верхний угол столбика
            int w, h;//размер столбца
            w = (ClientSize.Width - 40 - 5 * (d.Length - 1)) / d.Length;
            x1 = 20;
            for (int i = 0; i < d.Length;i++ )//диаграмма
            {
                y1 = this.ClientSize.Height-20-(int)((this.ClientSize.Height-100)*(d[i]-min/(max-min)));
                g.DrawString(Convert.ToString(d[i]), dFont, System.Drawing.Brushes.Black, x1, y1 - 20);
                h = ClientSize.Height - y1 - 20 + 1;
                g.FillRectangle(Brushes.ForestGreen, x1, y1, w, h);
                g.DrawRectangle(System.Drawing.Pens.Black,x1,y1,w,h);
                x1 = x1 + w + 5;
            }
        }
        public Form1()
        {
            InitializeComponent();
            System.IO.StreamReader sr;//открыть поток для чтения
            try//обработка
            {
                sr = new System.IO.StreamReader(Application.StartupPath + "\\usd.dat");//читать локальный файл usd.dat
                d = new double[10];
                int i = 0;
                string t = sr.ReadLine();
                while ((t != null) && (i < d.Length))
                {
                    d[i++] = Convert.ToDouble(t);
                    t = sr.ReadLine();
                }
                sr.Close();//закрыть поток
                this.Paint += new PaintEventHandler(drawDiagram);
            }
            catch (System.IO.FileNotFoundException ex)//файл не найден
            {
                MessageBox.Show(ex.Message + "\n" +
                    "(" + ex.GetType().ToString() + ")",
                    "График",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)//другие ошибки
            {
                MessageBox.Show(ex.ToString(), "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
