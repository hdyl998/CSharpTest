using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClockPackge
{
    public partial class EditStartupForm : Form
    {

        public int editIndex;

        public EditStartupForm()
        {
            InitializeComponent();
        }

        public int selHour, selMinute;

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0) {
                MessageBox.Show("数据不能为空");
                return;
            }


            StartUpItem item = DataManager.getInstance().getStartUpData()[editIndex];

            item.appName = textBox1.Text;
            item.path = textBox2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddGuanjiForm_Load(object sender, EventArgs e)
        {
            StartUpItem item = DataManager.getInstance().getStartUpData()[editIndex];
            textBox1.Text = item.appName;
            textBox2.Text = item.path;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
