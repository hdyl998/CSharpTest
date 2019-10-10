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
    public partial class AddRemindForm : Form
    {

        List<int> listPeriod = new List<int>();
        List<int> listType = new List<int>();

        public RemindItem remindItem {
            get;set;
        }

        


        public AddRemindForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void initComboBox() {
            listPeriod.Add(RemindType.DAY);
            listPeriod.Add(RemindType.WEEK);
            listPeriod.Add(RemindType.MONTH);
            listPeriod.Add(RemindType.YEAR);
            listPeriod.Add(RemindType.HOUR);
            listPeriod.Add(RemindType.ONCE);
            listPeriod.Add(RemindType.USER_DEFINE);


            foreach (int type in listPeriod)
            {
                comboBoxPeriod.Items.Add(RemindType.type2String(type));
            }
            listType.Add(TaskType.REMIND);
            listType.Add(TaskType.SHUT_DONW);
            listType.Add(TaskType.OPEN_EXE);

            foreach (int type in listType)
            {
                comboBoxType.Items.Add(TaskType.type2String(type));
            }

            DateTime dateTime = DateTime.Now;
            for (int i = dateTime.Year; i < dateTime.Year+99; i++) {
                comboBoxYear.Items.Add(i+"年");
            }

            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add(i + "月");
            }
            for (int i = 1; i <= 31; i++)
            {
                comboBoxDay.Items.Add(i + "日");
            }

            string[] weekString = {"日","一","二","三","四","五","六"};
            for (int i = 0; i < 7; i++)
            {
                comboBoxWeek.Items.Add("星期"+weekString[i]);
            }
            for (int i = 0; i < 24; i++)
            {
                comboBoxHour.Items.Add(i+"时");
            }

            for (int i = 0; i < 60; i++)
            {
                comboBoxMinute.Items.Add(i + "分");
            }
        }

        private void initTimeSel() {
            if (comboBoxPeriod.SelectedIndex == -1) {
                return;
            }

            int Period = listPeriod[comboBoxPeriod.SelectedIndex];

            bool isYearEnable = false;
            bool isMonthEnable = false;
            bool isDayEnable = false;
            bool isWeekEnable = false;
            bool isHourEnable = false;
            bool isMinuteEnable = false;
            switch (Period) {
                case RemindType.DAY:
                    isMinuteEnable=isHourEnable = true;
                    break;
                case RemindType.WEEK:
                    isWeekEnable=isMinuteEnable = isHourEnable = true;
                    break;
                case RemindType.MONTH:
                    isDayEnable= isMinuteEnable = isHourEnable = true;
                    break;
                case RemindType.YEAR:
                    isMonthEnable= isDayEnable = isMinuteEnable = isHourEnable = true;
                    break;
                case RemindType.HOUR:
                    isMinuteEnable = true;
                    break;
                case RemindType.ONCE:
                    isMonthEnable =isYearEnable= isDayEnable = isMinuteEnable = isHourEnable = true;
                    break;
                case RemindType.USER_DEFINE:
                    isMonthEnable = isYearEnable = isDayEnable = isMinuteEnable = isHourEnable = true;
                    break;
            }
 
            comboBoxYear.Enabled = isYearEnable;
            comboBoxMonth.Enabled = isMonthEnable;
            comboBoxDay.Enabled = isDayEnable;
            comboBoxWeek.Enabled = isWeekEnable;
            comboBoxHour.Enabled = isHourEnable;
            comboBoxMinute.Enabled = isMinuteEnable;
        }


        private void RemindNewForm_Load(object sender, EventArgs e)
        {
            initComboBox();
            initTimeSel();
            comboBoxPeriod.SelectedIndex = 0;
            comboBoxType.SelectedIndex = 0;
            comboBoxYear.SelectedIndex = 0;
            comboBoxMonth.SelectedIndex = 0;

  
            comboBoxDay.SelectedIndex = 0;
            comboBoxWeek.SelectedIndex = 0;
            comboBoxHour.SelectedIndex = 0;
            comboBoxMinute.SelectedIndex = 0;

            if (remindItem != null) {
                textBox1.Text = remindItem.content;
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            initTimeSel();
        }
    }
}
