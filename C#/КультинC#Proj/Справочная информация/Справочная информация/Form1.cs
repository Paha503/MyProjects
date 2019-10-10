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
            helpProvider1.HelpNamespace = "npv.chm";
            helpProvider1.SetHelpNavigator(this,
                            HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(textBox1,
                                        "npv_02.htm");
            helpProvider1.SetHelpNavigator(textBox1,
                                          HelpNavigator.Topic);
            helpProvider1.SetShowHelp(textBox1, true);
            helpProvider1.SetHelpKeyword(textBox2,
                                        "npv_03.htm");
            helpProvider1.SetHelpNavigator(textBox2,
                                          HelpNavigator.Topic);
            helpProvider1.SetShowHelp(textBox2, true);
            helpProvider1.SetHelpKeyword(textBox3,
                                        "npv_04.htm");
            helpProvider1.SetHelpNavigator(textBox3,
                                          HelpNavigator.Topic);
            helpProvider1.SetShowHelp(textBox3, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                  "npv_01.htm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double p = 0;
            double r = 0;
            double d = 0;
            double npv = 0;
            try
            {
                p = Convert.ToDouble(textBox1.Text);
                r = Convert.ToDouble(textBox2.Text);
                d = Convert.ToDouble(textBox3.Text) / 100;

                npv = (p - r) / (1.0 + d);
                label4.Text =
                    "Чистый дискрементированный доход (NPV) = " +
                    npv.ToString("c");
            }
            catch
            { 
            }
        }
    }
}
