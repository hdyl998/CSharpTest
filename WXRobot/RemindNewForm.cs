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

        private void RemindNewForm_Load(object sender, EventArgs e)
        {
            if (remindItem != null) {
                textBox1.Text = remindItem.content;

            }
        }
    }
}
