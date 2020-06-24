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
    public partial class AddTimeForm : Form
    {

     public RemindItem remindItem;

 


        public AddTimeForm()
        {
            InitializeComponent();

         

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (remindItem == null) {
                remindItem = new RemindItem();
            }

            remindItem._year = textBoxYear.Text;
            remindItem._month = textBoxMonth.Text;
            remindItem._day = textBoxDay.Text;
            remindItem._week = textBoxWeek.Text;
            remindItem._hour = textBoxHour.Text;
            remindItem._min = textBoxMin.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddTimeForm_Load(object sender, EventArgs e)
        {
            if (remindItem != null)
            {

                textBoxYear.Text = remindItem._year;
                textBoxMonth.Text = remindItem._month;
                textBoxDay.Text = remindItem._day;
                textBoxWeek.Text = remindItem._week;
                textBoxHour.Text = remindItem._hour;
                textBoxMin.Text = remindItem._min;
            }
        }
    }
}
