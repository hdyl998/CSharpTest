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
    public partial class AddRemindForm : Form
    {

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
        List<int> listSelType = new List<int>();


        List<int> listTaskType = new List<int>();


        private void RemindNewForm_Load(object sender, EventArgs e)
        {


            listSelType.Add(RemindType.DAY);
            listSelType.Add(RemindType.WEEK);
            listSelType.Add(RemindType.MONTH);
            listSelType.Add(RemindType.YEAR);
            listSelType.Add(RemindType.HOUR);
            listSelType.Add(RemindType.ONCE);


            foreach (int type in listSelType) {
                comboBox1.Items.Add(RemindType.type2String(type));
            }


            listTaskType.Add(TaskType.REMIND);
            listTaskType.Add(TaskType.SHUT_DONW);
            listTaskType.Add(TaskType.OPEN_EXE);

            foreach (int type in listTaskType)
            {
                comboBox2.Items.Add(TaskType.type2String(type));
            }


            comboBox1.SelectedIndex = 0;

            comboBox2.SelectedIndex = 0;

            if (remindItem != null) {
                textBox1.Text = remindItem.content;
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {

        }
    }
}
