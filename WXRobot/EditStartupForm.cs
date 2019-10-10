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
        public EditStartupForm()
        {
            InitializeComponent();
        }

        public int selHour, selMinute;

        private void button1_Click(object sender, EventArgs e)
        {

            //selHour = NumberUtil.convertToInt(cbShutdownHour.SelectedItem.ToString());
            //selMinute = NumberUtil.convertToInt(cbShutdownMinute.SelectedItem.ToString());

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void AddGuanjiForm_Load(object sender, EventArgs e)
        {
            //cbShutdownHour.SelectedIndex = 0;
            //cbShutdownMinute.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
