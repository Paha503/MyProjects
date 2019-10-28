using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Просмотр_Иллюстраций_2
{
    public partial class Form1 : Form
    {
        List<string> imgList = new List<string>(); //список картинок
        int nImg = 0; //номер картинки
        int pbw, pbh,//размер pictureBox
            pbX, pbY;//положение pictureBox
        string aPath;//путь
        public Form1()
        {
            InitializeComponent();
            pbh = pictureBox1.Height;
            pbw = pictureBox1.Width;
            pbX = pictureBox1.Location.X;
            pbY = pictureBox1.Location.Y;
            DirectoryInfo di;
            di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            aPath = di.FullName;
            FillListBox(aPath);//получить список картинок
        }
        private Boolean FillListBox(string aPath)//получить список картинок
        {
            DirectoryInfo di =
                new DirectoryInfo(aPath);
            FileInfo[] fi = di.GetFiles("*.jpg");
            imgList.Clear();
            foreach (FileInfo fc in fi)
            {
                imgList.Add(fc.Name);
            }
            if (fi.Length == 0) return false;
            else
            {
                nImg = 0;
                ShowPicture(aPath + "\\" + imgList[nImg]);
                button2.Enabled = false;//недоступна кнопка назад
                if (imgList.Count == 1)
                    button3.Enabled = false;//если только одна картинка то нельзя перейти на вторую
                this.Text = aPath;
                return true;
            }
        }
        private void ShowPicture(string aPicture) //вывод картинки в pictureBox
        {
            double mh, mw;
            pictureBox1.Visible = false;
            pictureBox1.Left = pbX;
            pictureBox1.SizeMode =
                PictureBoxSizeMode.AutoSize;
            pictureBox1.Image =
                new Bitmap(aPicture);
            if ((pictureBox1.Image.Width > pbw) || //подгон картинки под pictureBox
                (pictureBox1.Image.Height > pbh))
            {
                pictureBox1.SizeMode =
                    PictureBoxSizeMode.StretchImage;
                mh = (double)pbh /
                    (double)pictureBox1.Image.Height;
                mw = (double)pbw /
                    (double)pictureBox1.Image.Width;
                if (mh < mw)
                {
                    pictureBox1.Width = Convert.ToInt16(
                        pictureBox1.Image.Width * mh);
                    pictureBox1.Height = pbh;
                }
                else
                {
                    pictureBox1.Width = pbw;
                    pictureBox1.Height = Convert.ToInt16(
                        pictureBox1.Image.Height * mw);
                }
            }
            pictureBox1.Left =  //разместить картинку в центре
                pbX + (pbw - pictureBox1.Width) / 2;
            pictureBox1.Top =
                pbY + (pbh - pictureBox1.Height) / 2;
            pictureBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)//назад
        {
            if (!button3.Enabled)
                button3.Enabled = true;
            if (nImg > 0)
            {
                nImg--;
                ShowPicture(aPath + "\\" + imgList[nImg]);
                if (nImg == 0)
                {
                    button2.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//вперед
        {
            if (!button2.Enabled)
                button2.Enabled = true;
            if (nImg < imgList.Count)
            {
                nImg++;
                ShowPicture(aPath + "\\" + imgList[nImg]);
                if (nImg == imgList.Count - 1)
                {
                    button3.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//обзор
        {
            FolderBrowserDialog fb =
                new FolderBrowserDialog();
            fb.Description =
                "Выберите папку,\n" +
                "в которой находятся иллюстрации";
            fb.ShowNewFolderButton = false;
            fb.SelectedPath = aPath;//показывается стартовый каталог
            if (fb.ShowDialog() == DialogResult.OK)
            {
                aPath = fb.SelectedPath;//стартовый каталог меняется на выбранный
                if (!FillListBox(fb.SelectedPath))
                    pictureBox1.Image = null;
            }
        }

    }
}
