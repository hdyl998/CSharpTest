using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DigitalClockPackge
{
    public partial class SettingForm : Form
    {

        public SettingForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string str = Utils.enableStartUp(checkBox1.Checked);
            if (str == null)
            {
                DataManager.getInstance().getDataItem().startUp = checkBox1.Checked ? 1 : 0;
                DataManager.getInstance().saveAll();
            }
            else
            {
                MessageBox.Show(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        

        private void SettingForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Utils.isStartUp();
            cbShutdownHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbShutdownMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            bindListData();
            bindKJListData();

            UiItem item = DataManager.getInstance().getUiItem();
            radioButton1.Checked = item.guanjiRadio == 0;
            radioButton2.Checked = item.guanjiRadio != 0;

            bindUiConfig();
            isLoaded = true;
        }

        bool isLoaded = false;


        private void bindUiConfig()
        {

            try
            {
                UiItem item = DataManager.getInstance().getUiItem();
                if (radioButton1.Checked)
                {

                    cbShutdownHour.SelectedIndex = item.guanjiHour;
                    cbShutdownMinute.SelectedIndex = item.guanjiMinute;
                }
                else
                {
                    cbShutdownHour.SelectedIndex = item.guanjiHour2;
                    cbShutdownMinute.SelectedIndex = item.guanjiMinute2;
                }
            }
            catch (Exception)
            {
            }

  

        }

        private void bindKJListData()
        {

        
            listViewKJ.Items.Clear();
            foreach (StartUpItem item in DataManager.getInstance().getStartUpData())
            {

                ListViewItem list = new ListViewItem();
                list.Text = item.getAppName();
                list.SubItems.Add(item.path);
                list.SubItems.Add(item.getEnableString());
                listViewKJ.Items.Add(list);
            }
        }




        private void bindListData()
        {

            listView1.Items.Clear();
            foreach (RemindItem item in DataManager.getInstance().getRemindData())
            {

                ListViewItem list = new ListViewItem();
                list.Text = item.content==null?"": item.content;
                list.SubItems.Add(item.getShowTime());
                list.SubItems.Add(item.getPeriodString());
                list.SubItems.Add(item.getRemindTypeString());
                list.SubItems.Add(item.getEnableString());

                listView1.Items.Add(list);
            }

            //listRemind.EnsureVisible();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRemindForm dlg = new AddRemindForm();
            if (dlg.ShowDialog() == DialogResult.OK) {
                DataManager.getInstance().getRemindData().Add(dlg.remindItem);
                DataManager.getInstance().saveAll();
                bindListData();
}

        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = getListViewSelectIndex(listView1);
            if (index != -1)
            {
                var var = DataManager.getInstance().getRemindData()[index];
                AddRemindForm dlg = new AddRemindForm();
                dlg.remindItem = var;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    DataManager.getInstance().getRemindData()[index] = dlg.remindItem;
                    DataManager.getInstance().saveAll();
                    bindListData();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            int index = getListViewSelectIndex(listView1);
            if (index != -1)
            {
                if (MessageBox.Show("确认移除？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataManager.getInstance().getRemindData().RemoveAt(index);
                    bindListData();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataManager.getInstance().getRemindData().Clear();
                DataManager.getInstance().saveAll();
                bindListData();
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {

            int index = getListViewSelectIndex(listView1);
            if (index != -1)
            {
                var var = DataManager.getInstance().getRemindData()[index];
                var.isEnable = !var.isEnable;
                bindListData();
            }
        }


        private int getListViewSelectIndex(ListView listView)
        {
            var indexs = listView.SelectedIndices;
            if (indexs.Count == 1)
            {
                return indexs[0];
            }
            return -1;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Utils.runExe("calc");
        }

        private void btnNotepad_Click(object sender, EventArgs e)
        {
            Utils.runExe("notepad");
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            Utils.runExe("mspaint");
        }

        private void btnShutdownCancel_Click(object sender, EventArgs e)
        {
            Utils.runCmd("shutdown -a");
        }

        private void btnShutdownStart_Click(object sender, EventArgs e)
        {
            int hour = NumberUtil.convertToInt(cbShutdownHour.SelectedItem.ToString());
            int min = NumberUtil.convertToInt(cbShutdownMinute.SelectedItem.ToString());

            if (radioButton1.Checked)
            {
                int second = hour * 3600 + min * 60;
                shutdownWithTime(second);
            }
            else {
                DateTime dateTime = DateTime.Now;

                int targetSecond = hour * 3600 + min * 60;
                int nowSecond = dateTime.Hour * 3600 + dateTime.Minute * 60;

                if (nowSecond > targetSecond) {
                    targetSecond += 24 * 3600;
                }
                shutdownWithTime(targetSecond- nowSecond);
            }
        }

        private void btnShutdownRightNow_Click(object sender, EventArgs e)
        {
            shutdownWithTime(0);
        }

        private void shutdownWithTime(int time) {
            LogUtil.Print(time);
            if (time < 10)
            {
                time = 10;
            }
            int hour = time / 3600;
            int minute = time / 60%60;
            int second = time % 60;

            StringBuilder builder = new StringBuilder();
            builder.Append("【");
            if (hour > 0) {
                builder.Append(hour);
                builder.Append("小时");
            }

            if (minute > 0)
            {
                builder.Append(minute);
                builder.Append("分");
            }

            if (second > 0)
            {
                builder.Append(second);
                builder.Append("秒");
            }
            builder.Append("】");
            if (MessageBox.Show("关机将在"+ builder + "后进行?", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Utils.runCmd("shutdown -a");
                Action<int> action = shutdownDelay;
                action.BeginInvoke(time, null, null);
            }


        }


        private void shutdownDelay(int time) {
            Thread.Sleep(300);
            Utils.runCmd("shutdown -s -t " + time);
        }



        private void btnKJAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "选择程序或快捷方式";
            dialog.Multiselect = true;
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "All files(*.*)|*.*|可执行程序|*.exe|快捷方式|*.lnk";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                foreach (string str in dialog.FileNames)
                {
                    StartUpItem item = new StartUpItem();

                    int indexEnd=str.LastIndexOf(".");
                    int indexStart=str.LastIndexOf("\\");
                    if (indexEnd != -1 && indexStart != -1)
                    {
                        item.appName = str.Substring(indexStart+1, indexEnd- indexStart-1);
                    }
                    else {
                        item.appName = str;
                    }
        
                    item.path = str;
                    DataManager.getInstance().getStartUpData().Add(item);
                }
                bindKJListData();
                DataManager.getInstance().saveAll();
            }
        }


        private void btnKJRemove_Click(object sender, EventArgs e)
        {

            int index = getListViewSelectIndex(listViewKJ);
            if (index != -1)
            {
                if (MessageBox.Show("确认移除？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataManager.getInstance().getStartUpData().RemoveAt(index);
                    bindKJListData();
                    DataManager.getInstance().saveAll();
                }
            }

        }

        private void btnKJTest_Click(object sender, EventArgs e)
        {

            int index = getListViewSelectIndex(listViewKJ);
            if (index != -1)
            {
                string path = DataManager.getInstance().getStartUpData()[index].path;
                Utils.runExe(path);
            }
        }

        private void btnRMTest_Click(object sender, EventArgs e)
        {

            int index = getListViewSelectIndex(listView1);
        

            RemindForm dlg = new RemindForm();
            List<RemindItem> lists = new List<RemindItem>();
            if (index != -1)
            {
                lists.Add(DataManager.getInstance().getRemindData()[index]);
                dlg.items = lists;
            }
            dlg.ShowDialog();
        }

        private void btnKJEnable_Click(object sender, EventArgs e)
        {
            int index = getListViewSelectIndex(listViewKJ);
            if (index != -1)
            {
                var var = DataManager.getInstance().getStartUpData()[index];
                var.isEnable = !var.isEnable;
                bindKJListData();
                DataManager.getInstance().saveAll();
            }
        }



        private void btnStartPath_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.StartupPath);
        }

 

        private void recordConfig() {
            if (!isLoaded) {
                return;
            }

            UiItem item = DataManager.getInstance().getUiItem();
            item.guanjiRadio = radioButton1.Checked ? 0 : 1;
            if (radioButton1.Checked) { 
                item.guanjiHour = cbShutdownHour.SelectedIndex;
                item.guanjiMinute = cbShutdownMinute.SelectedIndex;
            }
            else{
                item.guanjiHour2= cbShutdownHour.SelectedIndex;
                item.guanjiMinute2= cbShutdownMinute.SelectedIndex;
            }
            LogUtil.Print("记录配置", item);

            isUiConfigChanged = true;

        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (isUiConfigChanged) {
                recordConfig();
                DataManager.getInstance().saveUiItem();
            }

        }

        bool isCheckChanged = false;

        bool isUiConfigChanged = false;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoaded) {
                return;
            }
            isCheckChanged = true;
            bindUiConfig();
            isCheckChanged = false;

            isUiConfigChanged = true;
        }

        private void cbShutdownHour_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!isCheckChanged) {
                recordConfig();
            }
    
        }

        private void cbShutdownMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isCheckChanged)
            {
                recordConfig();
            }
        }

        private void btnRobot_Click(object sender, EventArgs e)
        {
            WxRobotForm dlg = new WxRobotForm();
            dlg.ShowDialog();
        }
    }
}
