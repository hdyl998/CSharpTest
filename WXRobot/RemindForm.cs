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


        public List<RemindItem> items
        {
            get; set;
        }




        public RemindForm()
        {
            InitializeComponent();
        }

        private void RemindForm_Load(object sender, EventArgs e)
        {
            Bitmap[] bitmaps = { global::WXRobot.Properties.Resources.bg1
                ,global::WXRobot.Properties.Resources.bg2
                      ,global::WXRobot.Properties.Resources.bg3
                            ,global::WXRobot.Properties.Resources.bg4
                                  ,global::WXRobot.Properties.Resources.bg5
            };
            int index = new Random().Next(bitmaps.Length);
            Bitmap bitmap=bitmaps[index];
            panel1.BackgroundImage = bitmap;
            if (items == null)
            {
                label1.Text = "测试提示文本";
            }
            else
            {
                if (items.Count == 1)
                {
                    label1.Text = items[0].content;
                }
                else
                {
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




        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
