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
        private double[] d;//данные
        private void drawDiagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;//холст
            Font dFont = new Font("Tahoma", 9);//шрифт данных
            Font hFont = new Font("Tahoma", 14, FontStyle.Regular);//заголовок
            string header = "Курс доллара";

            int w = (int)g.MeasureString(header, hFont).Width;//ширина области заголовка
            int x = (this.ClientSize.Width - w);//центрирование
            g.DrawString(header, hFont, System.Drawing.Brushes.Black,x, 5);//построение заголовка

            int sw = (int)((this.ClientSize.Width-40)/(d.Length-1));//расстояние между точками
            double max = d[0];
            double min = d[0];
            //макс. и мин. элементы массива
            for (int i = 1; i < d.Length; i++)
            {
                if (d[i] > max) max = d[i];
                if (d[i] < min) min = d[i];
            }

            int x1, y1, x2, y2;
            x1 = 20;//первая точка
            y1 = this.ClientSize.Height - 20 - (int)((this.ClientSize.Height - 100) * (d[0] - min) / (max - min));
            g.DrawRectangle(System.Drawing.Pens.Black, x1 - 2, y1 - 2, 4, 4);
            g.DrawString(Convert.ToString(d[0]), dFont, System.Drawing.Brushes.Black, x1 - 10, y1 - 20);
            //остальные точки
            for (int i = 1; i < d.Length; i++)
            {
                x2 = 8 + i * sw;
                y2 = this.ClientSize.Height - 20 - (int)((this.ClientSize.Height - 100) * (d[i] - min) / (max - min));
                g.DrawRectangle(System.Drawing.Pens.Black, x2 - 2, y2 - 2, 4, 4);
                g.DrawLine(System.Drawing.Pens.Black, x1, y1, x2, y2);//соединить точки
                g.DrawString(Convert.ToString(d[i]), dFont, System.Drawing.Brushes.Black, x2 - 10, y2 - 20);
                x1 = x2;
                y1 = y2;
            }

        }
        public Form1()
        {
            InitializeComponent();
            System.IO.StreamReader sr;//поток для чтения
            try
            {
                sr = new System.IO.StreamReader(Application.StartupPath + "\\usd.dat");//читать usd.dat
                d = new double[10];
                int i = 0;
                string t = sr.ReadLine();
                while ((t != null) && (i < d.Length))
                {
                    d[i++] = Convert.ToDouble(t);
                    t = sr.ReadLine();
                }
                sr.Close();//закрыть поток для чтения
                this.Paint += new PaintEventHandler(drawDiagram);//вывести диаграмму
            }
            catch (System.IO.FileNotFoundException ex)//нет файла данных
            {
                MessageBox.Show(ex.Message + "\n" +
                    "(" + ex.GetType().ToString() + ")",
                    "График",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)//другие ошибки
            {
                MessageBox.Show(ex.ToString(),
                    "",
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
