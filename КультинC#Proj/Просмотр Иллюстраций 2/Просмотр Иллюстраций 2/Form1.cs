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
        List<string> imgList = new List<string>();
        int nImg = 0;
        int pbw, pbh,
            pbX, pbY;
        string aPath;
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
            FullListBox(aPath);
        }
        private Boolean FullListBox(string aPath)
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
                    button2.Enabled = false;
                this.Text = aPath;
                return true;
            }
        }
        private void ShowPicture(string aPicture)
        {
            double mh, mw;
            pictureBox1.Visible = false;
            pictureBox1.Left = pbX;
            pictureBox1.SizeMode =
                PictureBoxSizeMode.AutoSize;
            pictureBox1.Image =
                new Bitmap(aPicture);
            if ((pictureBox1.Image.Width > pbw) ||
                (pictureBox1.Image.Height > pbh))
            {
                pictureBox1.SizeMode =
                    PictureBoxSizeMode.StretchImage;
                mh = (double)pbh /
                    (double)pictureBox1.Image.Height;
                mw = (double)pbw /
                    (double)pictureBox1.Image.Width;
            }
        }
    }
}
