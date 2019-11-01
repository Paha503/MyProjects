using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.ForestGreen,20,20,30,60);//монотонный зеленый
            e.Graphics.FillRectangle(Brushes.White, 50, 20, 30, 60);//монотонный белый
            e.Graphics.FillRectangle(Brushes.Red, 80, 20, 30, 60);//монотонный красный
            e.Graphics.DrawRectangle(Pens.Black, 20, 20, 90, 60);//обводка
            e.Graphics.DrawString("Solid Brush", this.Font, Brushes.Black, 20, 85);//название

            LinearGradientBrush lgBrush_1 = new LinearGradientBrush
                (new RectangleF(200, 20, 90, 10), Color.Blue,
                Color.LightBlue, LinearGradientMode.Horizontal);//градиентная кисть
            e.Graphics.FillRectangle(lgBrush_1, 200, 20, 90, 60);//нарисовать градиент
            e.Graphics.DrawString("Linear Gradient - Horizontal", this.Font, Brushes.Black, 200, 85);//название

            LinearGradientBrush lgBrush_2 = new LinearGradientBrush
                (new RectangleF(0, 0, 10, 60), Color.Blue,
                Color.LightBlue, LinearGradientMode.Vertical);//градиентная кисть
            e.Graphics.FillRectangle(lgBrush_2, 20, 120, 90, 60);//нарисовать градиент
            e.Graphics.DrawString("Linear Gradient - Vertical", this.Font, Brushes.Black, 20, 185);//название

            try
            {
                TextureBrush tBrush =
                    new TextureBrush(Image.FromFile("brush_2.bmp"));//текстурная кисть из файла
                e.Graphics.FillRectangle(tBrush, 200, 120, 90, 60);
            }
            catch(System.IO.FileNotFoundException)//если файла нет
            {
                e.Graphics.DrawRectangle(Pens.Black,200,120,90,60);
                e.Graphics.DrawString("Source Image", this.Font, Brushes.Black, 160, 135);
                e.Graphics.DrawString("not found", this.Font, Brushes.Black, 170, 200);
            }
            e.Graphics.DrawString("Texture Brush", this.Font, Brushes.Black, 200, 185);//подпись
            
            HatchBrush hBrush = new HatchBrush(HatchStyle.DottedGrid, Color.Black, Color.Gold);
            e.Graphics.FillRectangle(hBrush, 20, 220, 90, 60);//желтая сетка
            e.Graphics.DrawString("HatchBrush - DottedGrid", this.Font, Brushes.Black, 20, 285);//подпись

            HatchBrush hBrush_2 = new HatchBrush(HatchStyle.DiagonalCross, Color.Black, Color.Gold);
            e.Graphics.FillRectangle(hBrush_2, 200, 220, 90, 60);//желтая крестовина
            e.Graphics.DrawString("HatchBrush - DiagonalCross", this.Font, Brushes.Black, 200, 285);//подпись
        }
    }
}
