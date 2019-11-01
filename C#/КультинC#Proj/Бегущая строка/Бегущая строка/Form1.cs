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
        Graphics g;//холст
        Bitmap baner;//реклама
        Rectangle rct;//область вывода рекламы
        public Form1()
        {
            InitializeComponent();
            try
            {
                baner = new Bitmap("banner.png");//файл рекламы
            }
            catch(Exception exception)
            {
                MessageBox.Show(
                    "Ошибка загрузки файла баннера\n"+
                    exception.ToString(),"Баннер");
                this.Close();
                return;
            }
            g = this.CreateGraphics();//холст
            //определение области отображения рекламы
            rct.X = 0;
            rct.Y = 0;
            rct.Width = baner.Width;
            rct.Height = baner.Height;
            //настройка таймера
            timer1.Interval = 50;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)//действия отклика таймера
        {
            rct.X -= 1;//смещение влево
            if (Math.Abs(rct.X) > rct.Width)//если реклама улетела за пределы формы то она появляется справа
                rct.X += rct.Width;
            for (int i = 0; i <= Convert.ToInt16(this.ClientSize.Width / rct.Width) + 1; i++)
                g.DrawImage(baner, rct.X + i * rct.Width, rct.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)//действие при наведении курсора
        {
            if ((e.Y < rct.Y + rct.Height) && (e.Y > rct.Y))//движение останавливается
            {
                if (timer1.Enabled != false)
                    timer1.Enabled = false;
            }
            else
            {
                if (timer1.Enabled != true)
                    timer1.Enabled = true;
            }
        }
    }
}
