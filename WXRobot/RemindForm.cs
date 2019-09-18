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


        public List<RemindItem> items {
            get;set;
        }


        

        public RemindForm()
        {
            InitializeComponent();
        }

        private void RemindForm_Load(object sender, EventArgs e)
        {
            if (items.Count == 1)
            {
                label1.Text = items[0].content;
            }
            else {
                StringBuilder builder = new StringBuilder();
                foreach (RemindItem item in items)
                {
                    if (builder.Length != 0)
                    {
                        builder.Append(" ");
                    }
                    builder.Append(item.content);
                }
                label1.Text = builder.ToString();
            }

    
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
