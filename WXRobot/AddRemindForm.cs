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

            if (remindItem == null) {
                remindItem = new RemindItem();
            }

            RemindItem item = remindItem;
            item.createTime = DateTime.Now.ToString();


            int selType = listType[comboBoxType.SelectedIndex];
    
            item.taskType = selType;
            item.content = textBox1.Text;
            item.periodType = -1;




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




            foreach (int type in listType)
            {
                comboBoxType.Items.Add(TaskType.type2String(type));
            }

      

         
       
     
        }



 


        private void RemindNewForm_Load(object sender, EventArgs e)
        {
            initComboBox();

            DateTime dateTime = DateTime.Now;

            if (remindItem != null)
            {

                textBox1.Text = remindItem.content;
        
                comboBoxType.SelectedIndex = Utils.findIndex(listType, remindItem.taskType);


                if (remindItem.taskType == TaskType.SHUT_DONW)
                {
                    textBoxExtra.Text = remindItem.extra;
                }
                else if (remindItem.taskType == TaskType.WX_SEND_MSG) {

                    textBox2.Text = remindItem.extra;
                    textBox3.Text = remindItem.extra2;
                }
                labelShowTime.Text = remindItem.getDateInfo();
            }
            else {

      
                comboBoxType.SelectedIndex = 0;
            }



            isInited = true;
      
            updateSelTimeInfo();
            updateOpenExeUi();
        }

        private void updateSelTimeInfo() {
       


            StringBuilder builder = new StringBuilder();
            builder.Append("【");
            builder.Append(comboBoxType.SelectedItem.ToString());
            builder.Append("】");




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

 
        private void button1_Click(object sender, EventArgs e)
        {
            AddTimeForm dlg = new AddTimeForm();

            dlg.remindItem = remindItem;

            if (dlg.ShowDialog() == DialogResult.OK) {
                this.remindItem = dlg.remindItem;
                remindItem.buildInfos();
                labelShowTime.Text = remindItem.getDateInfo();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
