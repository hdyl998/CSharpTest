using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WXRobot
{
    public partial class SettingForm : Form
    {

        //bool isEnable = IniUtil.getValueAsBool(Constants.REMIND_ENABLE, true);
        public SettingForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string str = Utils.enableStartUp(checkBox1.Checked);
            if (str == null)
            {
                IniUtil.setValue(Constants.START_UP, checkBox1.Checked);
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
            cbShutdownHour.SelectedIndex = 0;
            cbShutdownHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            cbShutdownMinute.SelectedIndex = 1;
            cbShutdownMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            bindListData();

        }


        int selectIndex = -1;
        //string[] titles = { "提醒内容", "时间", "提醒方式" };
        private void bindListData()
        {

            selectIndex = getListViewSelectIndex();
            listView1.Items.Clear();
            foreach (RemindItem item in RemindManager.getInstance().getList())
            {

                ListViewItem list = new ListViewItem();
                list.Text = item.content;
                list.SubItems.Add(item.getShowTime());
                list.SubItems.Add(item.getRemindTypeString());
                list.SubItems.Add(item.getEnableString());
                listView1.Items.Add(list);
            }
            //list.EnsureVisible();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            RemindNewForm dlg = new RemindNewForm();
            dlg.ShowDialog();

        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = getListViewSelectIndex();
            if (index != -1)
            {
                var var = RemindManager.getInstance().getList()[index];
                RemindNewForm dlg = new RemindNewForm();
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
                    RemindManager.getInstance().getList().RemoveAt(index);
                    bindListData();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                RemindManager.getInstance().getList().Clear();
                bindListData();
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            //isEnable = !isEnable;
            //IniUtil.setValue(Constants.REMIND_ENABLE, isEnable);

            int index = getListViewSelectIndex();
            if (index != -1)
            {
                var var = RemindManager.getInstance().getList()[index];
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

        
            int hour=NumberUtil.convertToInt(cbShutdownHour.SelectedItem.ToString());
            int min= NumberUtil.convertToInt(cbShutdownMinute.SelectedItem.ToString());
            int second = hour * 3600 + min * 60;
      
            shutdownWithTime(second);
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
                Utils.runCmd("shutdown -a", "shutdown -s -t " + time);
            }

      
        }
    }
}
