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
    public partial class RemindNewForm : Form
    {

        public RemindItem remindItem {
            get;set;
        }

        


        public RemindNewForm()
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


        private void RemindNewForm_Load(object sender, EventArgs e)
        {


            listSelType.Add(RemindType.DAY);
            listSelType.Add(RemindType.WEEK);
            listSelType.Add(RemindType.MONTH);
            listSelType.Add(RemindType.YEAR);
            listSelType.Add(RemindType.HOUR);
            listSelType.Add(RemindType.ONCE);


            foreach (int type in listSelType) {
                comboBox1.Items.Add(RemindType.remindType2String(type));
            }
            comboBox1.SelectedIndex = 0;

            if (remindItem != null) {
                textBox1.Text = remindItem.content;

            }
        }
    }
}
