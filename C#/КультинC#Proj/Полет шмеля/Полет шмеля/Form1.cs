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
        System.Drawing.Bitmap flower, bee;//шмель и цветы
        Graphics g;//холст

        int dx;//скорость шмеля
        Rectangle rct;//нахождение шмеля
        Boolean demo = true;
        System.Random rnd;//генератор случайных чисел
        public Form1()
        {
            InitializeComponent();

            try//прогрузка изображений
            {
                flower = new Bitmap("flower.bmp");
                bee = new Bitmap("bee.bmp");
                this.BackgroundImage = new Bitmap("flower.bmp");
            }
            catch (Exception exception)//изображений нет
            {
                MessageBox.Show(exception.ToString(),
                    "Полет шмеля", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
                return;
            }
            bee.MakeTransparent();
            this.ClientSize = new System.Drawing.Size(new Point(BackgroundImage.Width, BackgroundImage.Height));
            g = Graphics.FromImage(BackgroundImage);
            rnd = new System.Random();
            rct.X = -40;//исходные координаты шмеля
            rct.Y = 20 + rnd.Next(20);
            rct.Width = bee.Width;
            rct.Height = bee.Height;
            dx = 2;//скорость полета 2 пикселя
            timer2.Interval = 20;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            g.DrawImage(flower, new Point(0, 0));
            if (rct.X < this.ClientRectangle.Width)
                rct.X += dx;
            else //если дошли до границы все заново
            {
                rct.X = -40;
                rct.Y = 20 + rnd.Next(40);
                dx = 2 + rnd.Next(4);
            }
            g.DrawImage(bee, rct.X, rct.Y);
            if (!demo)
                this.Invalidate(rct);//обновить рамку
            else 
            {
                Rectangle reg = new Rectangle(20, 20, flower.Width - 40, flower.Height - 40);//если обьект вне рамки то его видно не будет
                g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
                this.Invalidate(reg);//обновить рамку
            }
        }
    }
}
