using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//загрузить таблицу
        {
            oleDbConnection1.ConnectionString = Settings.Default.ContactsConnectionString;
            oleDbDataAdapter1.Fill(dataTable1);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)//удаление
        {
            DialogResult dr =
                MessageBox.Show("Удалить запись?",
                "Удаление записи",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);//да или нет
            if (dr == DialogResult.Cancel)//если нажата отмена
            {
                e.Cancel = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            oleDbDataAdapter1.Update(dataSet1.Tables["contacts"]);
        }

        private void oleDbConnection1_InfoMessage(object sender, System.Data.OleDb.OleDbInfoMessageEventArgs e)
        {

        }
    }
}
