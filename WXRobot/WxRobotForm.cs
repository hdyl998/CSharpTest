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
    public partial class WxRobotForm : Form
    {
        public WxRobotForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IniUtil.setValue(Constants.APP_ROBOT_PATH, textBox1.Text);
        }

        private void WxRobot_Load(object sender, EventArgs e)
        {
            textBox1.Text = IniUtil.getValue(Constants.APP_ROBOT_PATH);
        }

        public class MessageItem {
            public string msgtype="text";
            public DetailItem text=new DetailItem();

        }

        public class DetailItem {
            public string content;
            public List<string> mentioned_mobile_list = new List<string>();
        }

          


        private void button2_Click(object sender, EventArgs e)
        {




            MessageItem item = new MessageItem();

            if (comboBox1.Text.Length > 0)
            {
                item.text.content = string.Format("{0}【{1}】", textBox2.Text, comboBox1.Text);
            }
            else {
                item.text.content = string.Format("{0}", textBox2.Text);
            }
            

            if (checkBoxAtAll.Checked) {
                item.text.mentioned_mobile_list.Add("@all");
            }

            string mobile = textBoxAt.Text.Trim();
            if (mobile.Length > 0) {
                string []arr= mobile.Split(',');
                item.text.mentioned_mobile_list.AddRange(arr);
            }
            string text = Utils.toJSONString(item);



            if (MessageBox.Show(text, "确认发送？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                NetBuilder.create(this).setUrl(textBox1.Text).setPostData(text).start((data) =>
                {
                    MessageBox.Show(data);
                });
            }

  
        }
    }
}
