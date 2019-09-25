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

namespace WXRobot
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
            DataManager.getInstance().saveAll();
            this.Close();
        }

        

        private void SettingForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Utils.isStartUp();
            cbShutdownHour.SelectedIndex = 0;
            cbShutdownHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            cbShutdownMinute.SelectedIndex = 3;
            cbShutdownMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            bindListData();
            bindKJListData();

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
                listView1.Items.Add(list);
            }

            //listRemind.EnsureVisible();
        }



        //string[] titles = { "提醒内容", "时间", "提醒方式" };
        private void bindListData()
        {

            listView1.Items.Clear();
            foreach (RemindItem item in DataManager.getInstance().getRemindData())
            {

                ListViewItem list = new ListViewItem();
                list.Text = item.content;
                list.SubItems.Add(item.getShowTime());
                list.SubItems.Add(item.getRemindTypeString());
                list.SubItems.Add(item.getEnableString());
                listView1.Items.Add(list);
            }

            //listRemind.EnsureVisible();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRemindForm dlg = new AddRemindForm();
            dlg.ShowDialog();

        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = getListViewSelectIndex();
            if (index != -1)
            {
                var var = DataManager.getInstance().getRemindData()[index];
                AddRemindForm dlg = new AddRemindForm();
                dlg.remindItem = var;
                dlg.ShowDialog();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            int index = getListViewSelectIndex();
            if (index != -1)
            {
                if (MessageBox.Show("确认删除？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                bindListData();
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {

            int index = getListViewSelectIndex();
            if (index != -1)
            {
                var var = DataManager.getInstance().getRemindData()[index];
                var.isEnable = !var.isEnable;
                //listView1.Items[index].SubItems[]
                bindListData();
            }
        }


        private int getListViewSelectIndex()
        {
            var indexs = listView1.SelectedIndices;
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
            LogUtil.print(time);
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

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    listBox1.Items.AddRange(dialog.FileNames);

            //    foreach (string str in dialog.FileNames)
            //    {
            //        StartUpItem item = new StartUpItem();
            //        item.path = str;
            //        DataManager.getInstance().getStartUpData().Add(item);
            //    }
            //    DataManager.getInstance().saveStartUpData();
            //}
        }


        private void btnKJRemove_Click(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex != -1) {

            //    DataManager.getInstance().getStartUpData().RemoveAt(listBox1.SelectedIndex);
            //    DataManager.getInstance().saveStartUpData();
            //    listBox1.Items.RemoveAt(listBox1.SelectedIndex);

            //}
        }

        private void btnKJTest_Click(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex != -1)
            //{
            //    Utils.runExe(listBox1.SelectedItem.ToString());
            //}
        }

        private void btnRMTest_Click(object sender, EventArgs e)
        {

            int index = getListViewSelectIndex();
        

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

        }

        private void btnKJEdit_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnStartPath_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.StartupPath);
        }

   
    }
}
