﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DigitalClockPackge
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
            Bitmap[] bitmaps = { global::DigitalClock.Properties.Resources.bg1
                      ,global::DigitalClock.Properties.Resources.bg3
                            ,global::DigitalClock.Properties.Resources.bg4
  
            };
            int index = new Random().Next(bitmaps.Length);
            Bitmap bitmap=bitmaps[index];
            panel1.BackgroundImage = bitmap;
            this.ClientSize = new Size(bitmap.Width,bitmap.Height);

            button1.Location = new Point((bitmap.Width-button1.Width) / 2, bitmap.Height-button1.Height-10);
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

            isShowing = true;

            thread = new Thread(new ThreadStart(startChangeLocation));
        
            thread.Start();
        }


        Thread thread;

        private void startChangeLocation() {
            int x=this.Location.X;
            int y = this.Location.Y;

          

            Action<int,int> action = changeLocationUi;

            while (isShowing) {
                
                Thread.Sleep(10);
                this.Invoke(action, x, y);
                Thread.Sleep(10);
                this.Invoke(action, x, y);

                Thread.Sleep(200);
            }
        }
        Random random = new Random();
        private void changeLocationUi(int x,int y) {

            x = x + random.Next(10)-5;
            y = y + random.Next(10)-5;
            this.Location = new Point(x,y );
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        bool isShowing = true;

        private void RemindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShowing = false;
            thread.Abort();
        }
    }
}
