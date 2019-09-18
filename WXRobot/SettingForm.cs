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

        bool isEnable = IniUtil.getValueAsBool(Constants.REMIND_ENABLE, true);
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

        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Utils.isStartUp();

            bindListData();

        }

        //string[] titles = { "提醒内容", "时间", "提醒方式" };
        private void bindListData(){
            updateListItemEnable();
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

        private void updateListItemEnable() {
            foreach (RemindItem item in RemindManager.getInstance().getList())
            {
                item.isEnable = isEnable;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RemindNewForm dlg = new RemindNewForm();
            dlg.ShowDialog();

        }



        private void btnAllEnable_Click(object sender, EventArgs e)
        {

            isEnable = !isEnable;
            IniUtil.setValue(Constants.REMIND_ENABLE, isEnable);

            bindListData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var indexs = listView1.SelectedIndices;

            if (indexs.Count == 1) {
                int index =indexs[0];
                var var=RemindManager.getInstance().getList()[index];
                RemindNewForm dlg = new RemindNewForm();
                dlg.remindItem = var;
                dlg.ShowDialog();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var indexs = listView1.SelectedIndices;
            if (indexs.Count == 1) {
                if (MessageBox.Show("确认删除？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    RemindManager.getInstance().getList().RemoveAt(indexs[0]);
                    bindListData();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认清空？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                RemindManager.getInstance().getList().Clear();
                bindListData();
            } 
        }
    }
}
