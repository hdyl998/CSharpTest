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

            IniUtil.setValue(Constants.START_UP,checkBox1.Checked?1:0);
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
        }
    }
}
