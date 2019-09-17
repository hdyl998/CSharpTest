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
        public SettingForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            IniUtil.setValue(Constants.START_UP,checkBox1.Checked);
            string str=Utils.enableStartUp(checkBox1.Checked);
            if (str == null)
            {
                LogUtil.showMessageBox("设置成功");
            }
            else {
                MessageBox.Show(str);
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Utils.isStartUp();

            bindListData();

        }

        //string[] titles = { "提醒内容", "时间", "提醒方式" };
        private void bindListData(){



            int index = 0;
     
            foreach (RemindItem item in RemindManager.getInstance().getList())
            {

                ListViewItem list = new ListViewItem();
                list.Text = item.content;
                list.SubItems.Add(item.getShowTime());
                list.SubItems.Add(item.remindType + "");
                listView1.Items.Add(list);
            }
            index++;
            //list.EnsureVisible();






        }
    }
}
