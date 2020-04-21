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

        List<int> listPeriod = RemindType.listPeriod;
        List<int> listType = TaskType.listType;

        public RemindItem remindItem {
            get;set;
        }


        private bool isInited = false;

        public AddRemindForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void btnComplete_Click(object sender, EventArgs e)
        {
            RemindItem item = new RemindItem();
            item.createTime = DateTime.Now.ToString();


            int selType = listType[comboBoxType.SelectedIndex];
            item.periodType = listPeriod[comboBoxPeriod.SelectedIndex];

            item.taskType = selType;
            item.content = textBox1.Text;

            collectTime(item);




            switch (selType) {
                case TaskType.OPEN_EXE:
                    if (Utils.isTextEmpty(textBoxExtra.Text)) {
                        LogUtil.showMessageBox("程序路径不能为空");
                        return;
                    }
                    item.extra = textBoxExtra.Text;
                    break;
                case TaskType.WX_SEND_MSG:
                    if (textBox2.Text.Length ==0|| textBox3.Text.Length==0) {
                        LogUtil.showMessageBox("必填参数不能为空");
                    }
                    item.extra = textBox2.Text;
                    item.extra2 = textBox3.Text;
                    break;

            }
            this.remindItem = item;
            this.DialogResult = DialogResult.OK;

            this.Close();
        }




        private void initComboBox() {


            foreach (int type in listPeriod)
            {
                comboBoxPeriod.Items.Add(RemindType.type2String(type));
            }

            foreach (int type in listType)
            {
                comboBoxType.Items.Add(TaskType.type2String(type));
            }

            DateTime dateTime = DateTime.Now;
            for (int i = dateTime.Year; i < dateTime.Year+30; i++) {
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

           
            for (int i = 0; i < 7; i++)
            {
                comboBoxWeek.Items.Add("星期"+ Constants.weekString[i]);
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

        private void collectTime(RemindItem item)
        {


            DateTime dateTime = DateTime.Now;
            item.year = comboBoxYear.SelectedIndex+ dateTime.Year;
            item.month = comboBoxMonth.SelectedIndex + 1;
            item.day = comboBoxDay.SelectedIndex+1;
            item.week = comboBoxWeek.SelectedIndex;
            item.hour = comboBoxHour.SelectedIndex;
            item.minute = comboBoxMinute.SelectedIndex;
  
        }




        private void initTimeSel() {
 

      

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
                    isMinuteEnable = isHourEnable = true;
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

            DateTime dateTime = DateTime.Now;

            if (remindItem != null)
            {

                textBox1.Text = remindItem.content;
                comboBoxPeriod.SelectedIndex = Utils.findIndex(listPeriod, remindItem.periodType);
                comboBoxType.SelectedIndex = Utils.findIndex(listType, remindItem.taskType);
                comboBoxYear.SelectedIndex = 0;//默认选0
                comboBoxYear.SelectedItem = remindItem.year + "年";
                comboBoxMonth.SelectedItem = remindItem.month + "月";
                comboBoxDay.SelectedItem = remindItem.day + "日";
                comboBoxHour.SelectedItem = remindItem.hour + "时";

                comboBoxMinute.SelectedItem = remindItem.minute + "分";

                comboBoxWeek.SelectedItem = "星期" + Constants.weekString[remindItem.week];


                if (remindItem.taskType == TaskType.SHUT_DONW)
                {
                    textBoxExtra.Text = remindItem.extra;
                }
                else if (remindItem.taskType == TaskType.WX_SEND_MSG) {

                    textBox2.Text = remindItem.extra;
                    textBox3.Text = remindItem.extra2;
                }
            }
            else {

                comboBoxPeriod.SelectedIndex = 0;
                comboBoxType.SelectedIndex = 0;

                comboBoxYear.SelectedIndex = 0;
                comboBoxMonth.SelectedItem = dateTime.Month + "月"; ;


                comboBoxDay.SelectedItem = dateTime.Day + "日"; ;
                comboBoxWeek.SelectedItem = "星期" + Constants.weekString[(int)dateTime.DayOfWeek];
                comboBoxHour.SelectedIndex = dateTime.Hour;
                comboBoxMinute.SelectedIndex = dateTime.Minute;
            }


            isInited = true;
            initTimeSel();
            updateSelTimeInfo();
            updateOpenExeUi();
        }

        private void updateSelTimeInfo() {
            int Period = listPeriod[comboBoxPeriod.SelectedIndex];
    


            StringBuilder builder = new StringBuilder();
            builder.Append("【");
            builder.Append(RemindType.type2String(Period));
            builder.Append("】");
            if (comboBoxYear.Enabled) {
                builder.Append(comboBoxYear.SelectedItem.ToString());
            }
            if (comboBoxMonth.Enabled)
            {
                builder.Append(comboBoxMonth.SelectedItem.ToString());
            }
            if (comboBoxDay.Enabled)
            {
                builder.Append(comboBoxDay.SelectedItem.ToString());
            }

            if (comboBoxWeek.Enabled)
            {
                builder.Append(comboBoxWeek.SelectedItem.ToString());
            }
            if (comboBoxHour.Enabled)
            {
                builder.Append(comboBoxHour.SelectedItem.ToString());
            }
            if (comboBoxMinute.Enabled)
            {
                builder.Append(comboBoxMinute.SelectedItem.ToString());
            }
            builder.Append("【");
            builder.Append(comboBoxType.SelectedItem.ToString());
            builder.Append("】");


            if (Period == RemindType.ONCE)
            {
                builder.Append("【仅执行一次】");
            }
            else {
                builder.Append("【周期执行】");
            }

            labelTime.Text = builder.ToString();
        }


        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "选择程序或快捷方式";
            dialog.Multiselect = false;
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "All files(*.*)|*.*|可执行程序|*.exe|快捷方式|*.lnk";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                textBoxExtra.Text= dialog.FileName;
            }
        }



        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInited)
            {
                return;
            }
            initTimeSel();
            updateSelTimeInfo();
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInited) {
                return;
            }
            updateSelTimeInfo();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxYear_SelectedIndexChanged(sender,e);
        }

        private void comboBoxWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxYear_SelectedIndexChanged(sender, e);
        }

        private void comboBoxMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxYear_SelectedIndexChanged(sender, e);
        }

        private void comboBoxDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxYear_SelectedIndexChanged(sender, e);
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInited)
            {
                return;
            }
            updateSelTimeInfo();
            updateOpenExeUi();
        }

        private void updateOpenExeUi() {
            panelOpenExe.Enabled = listType[comboBoxType.SelectedIndex] == TaskType.OPEN_EXE;

            panelSendMsg.Enabled= listType[comboBoxType.SelectedIndex] == TaskType.WX_SEND_MSG;
        }

        private void buttonRobotSel_Click(object sender, EventArgs e)
        {
            WxRobotForm dlg = new WxRobotForm();
            dlg.hookUrl = textBox2.Text;
            dlg.isEditMode = true;
            dlg.sendData = textBox3.Text;
            if (dlg.ShowDialog() == DialogResult.OK) {
                textBox2.Text = dlg.hookUrl;
                textBox3.Text = dlg.sendData;
            }
        }
    }
}
