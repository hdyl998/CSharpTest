using System;
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
    public partial class ShutDownForm : Form
    {
        public ShutDownForm()
        {
            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.runCmd("shutdown -s -t " + 5);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utils.runCmd("shutdown -s -a");
            this.Close();
        }
        Thread thread;
        private void ShutDownForm_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(startCount));

            thread.Start();
        }
        const int REST_TIME = 20;

        private void startCount()
        {
            int count = REST_TIME;
            while (isRunning&& count>0) {
                Thread.Sleep(1000);
                count--;

                if (!isRunning)
                {
                    return;
                }
                this.Invoke((Action<int>)updateText,count);

            }
            Utils.runCmd("shutdown -s -t " + 5);
        }

        private void updateText(int a)
        {
            if (a == 0)
            {
                label2.Text = "即将关机...";
            }
            else {
                label2.Text = a + "秒";
            }
        }

        private bool isRunning = true;

        private void ShutDownForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
        }
    }
}
