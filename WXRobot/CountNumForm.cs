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
    public partial class CountNumForm : Form
    {

        List<String> records = new List<string>();
        int nums = 0;
        public CountNumForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nums = 0;
            records.Add("----清0----" + DateTime.Now);
            updateUi();
        }


        private void updateUi() {
            label1.Text = nums + "";
        }

        private void CountNumForm_Load(object sender, EventArgs e)
        {
            nums = 0;
            updateUi();

            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nums++;
            updateUi();

            records.Add("----增加1----"+DateTime.Now);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nums--;
            updateUi();
            records.Add("----减少1----" + DateTime.Now);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            StringBuilder builder = new StringBuilder();

            builder.Append(string.Format("共{0:d}条记录", records.Count));

            foreach (String tt in records) {
                builder.Append("\n");
                builder.Append(tt);
                
            }


            MessageBox.Show(builder.ToString(),"记录",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
