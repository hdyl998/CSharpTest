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
    public partial class RemindForm : Form
    {


        private RemindItem remindItem {
            get;set;
        }


        

        public RemindForm()
        {
            InitializeComponent();
        }

        private void RemindForm_Load(object sender, EventArgs e)
        {

        }
    }
}
