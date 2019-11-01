using DigitalClockPackge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static DigitalClockPackge.Weather;

namespace DigitalClockPackge
{
    public partial class WeatherForm : Form
    {

        public bool isEditMode = false;


        public string strAddr;

        public int intSelIndex=-1;

        public WeatherForm()
        {
            InitializeComponent();
        }

        private void WeatherForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = IniUtil.getValue(Constants.APP_WEATHER_CITY);


            if (intSelIndex != -1)
            {
                textBox2.Text = strAddr;
                Utils.setRadioButtonCheckedIndex(intSelIndex, radioButton1, radioButton2, radioButton3);
            }

            if (intSelIndex == 0||intSelIndex==-1) {
                autoFillEdit(Weather.TYPE_NOW);
            }

            if (isEditMode)
            {
                button1.Enabled = true;
                button13.Enabled = false;
            }
            else {
                button1.Enabled = false;
                button13.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

   

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                getWealtherInfo(Weather.TYPE_NOW);
            }
            else if (radioButton2.Checked)
            {
                getWealtherInfo(Weather.TYPE_FORECAST);
            }
            else {
                getWealtherInfo(Weather.TYPE_LIFESTYLE);
            }
        }


        private void getWealtherInfo(string type) {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("请先设置城市");
                return;
            }

            string url = Weather.getUrl(type, textBox1.Text.Trim());

            textBox2.Text = url;

            NetBuilder.create(this).asGet().setUrl(url).start((data) =>
            {
                LogUtil.Print(data);
                try
                {
                    WealthNowItem item = Utils.parseObject<WealthNowItem>(data);
                    label2.Text = item.ToString();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("查询失败！" + e1.Message);
                }
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IniUtil.setValue(Constants.APP_WEATHER_CITY,textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1 .Text= ((Button)sender).Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {


            WxRobotForm dlg = new WxRobotForm();
            dlg.sendData = label2.Text.Replace("\n","\r\n"); ;
            dlg.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) { 
            strAddr=textBox2.Text;
            if (strAddr == null) {
                MessageBox.Show("请求地址 不能为空");
                return;
            }
            intSelIndex = Utils.getRadioButtonCheckedIndex(radioButton1, radioButton2, radioButton3);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) {
               autoFillEdit(Weather.TYPE_NOW);
            }
   
        }

        private void autoFillEdit(string type) {
            if (textBox1.TextLength == 0) {
                textBox2.Text = "";
                return;
            }
            textBox2.Text=Weather.getUrl(type, textBox1.Text.Trim());
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                autoFillEdit(Weather.TYPE_FORECAST);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                autoFillEdit(Weather.TYPE_LIFESTYLE);
            }
        }
    }
}
