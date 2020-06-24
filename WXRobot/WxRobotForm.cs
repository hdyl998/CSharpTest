using Newtonsoft.Json;
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


        public bool isEditMode = false;


        
       


        private void button1_Click(object sender, EventArgs e)
        {
            IniUtil.setValue(Constants.APP_ROBOT_PATH, textBoxWebHook.Text);
        }

        private void WxRobot_Load(object sender, EventArgs e)
        {
            radioButton41.Enabled = radioButton42.Enabled = radioButton43.Enabled = false;

            textBoxWebHook.Text = IniUtil.getValue(Constants.APP_ROBOT_PATH);
            comboBoxStyle.SelectedIndex = 0;
            checkBoxCheckLine.Checked = true;

            initConfig();

            if (isEditMode)
            {
                buttonAddTask.Enabled = true;
            }
            else {
                buttonAddTask.Enabled = false;
            }


            if (!string.IsNullOrEmpty(hookUrl))
            {
                textBoxWebHook.Text = hookUrl;
            }

            if (!string.IsNullOrEmpty(sendData))
            {

                WxSendHelper helper = new WxSendHelper(hookUrl, sendData);


                if (helper.isNormalMsg())
                {
                    textBox2.Text = sendData;
                    textBoxRich.Text = sendData;
                    try
                    {
                        PicTextItem dataItem = Utils.parseObject<PicTextItem>(sendData);
                        NewsItem news = dataItem.news.articles[0];
                        textBoxTWTitle.Text = news.title;
                        textBoxTWDescription.Text = news.description;
                        textBoxTWUrl.Text = news.url;
                        textBoxTWPicUrl.Text = news.picurl;
                        tabControl1.SelectedIndex = 2;
                    }
                    catch (Exception)
                    {
                    }

                }
                else if (helper.isWeather())
                {
                    tabControl1.SelectedIndex = 3;

                    int initSel = helper.getExtraAsInt(0);
                    textBox1.Text = helper.getExtra(1);
                    Utils.setRadioButtonCheckedIndex(initSel, radioButton41, radioButton42, radioButton43);
                }
                else if (helper.isNews()) {
                    tabControl1.SelectedIndex = 4;
                    int initSel = helper.getExtraAsInt(0);
                    Utils.setRadioButtonCheckedIndex(initSel, radioButton51, radioButton52);
                }
   
            }
 
        }

        public class MessageItem {
            public string msgtype="text";
            public DetailItem text=new DetailItem();
        }

        public class DetailItem {
            public string content;
            public List<string> mentioned_mobile_list = new List<string>();
        }


        public class MarkDownItem {
            public string msgtype="markdown";
            public MarkDown markdown=new MarkDown();
        }

        public class MarkDown {
            public string content;
       
        }




        public class PicTextItem {
            public string msgtype = "news";
            public Articles news = new Articles();
        }

        public class Articles {
            public List<NewsItem> articles = new List<NewsItem>();
        }

        public class NewsItem {
            public string title;
            public string description;
            public string url;
            public string picurl;
        }







        private void button2_Click(object sender, EventArgs e)
        {


            string text = buildData();
            if (text == null) {
                return;
            }

            if (tabControl1.SelectedIndex == 3)
            {
                string url = textBox1.Text;
                NetBuilder.create(this).asGet().setUrl(url).start((data) =>
                {
                    LogUtil.Print(data);
                    try
                    {
                        Weather.WealthNowItem item = Utils.parseObject<Weather.WealthNowItem>(data);

                        sendDataConfirm(item.toSendString());
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("查询天气失败！" + e1.Message);
                    }
                });
            }
            else if (tabControl1.SelectedIndex == 4) {
                NetBuilder.create(this).asGet().setUrl(News.URL).start((data) =>
                {
                    LogUtil.Print(data);

                   

                    try
                    {
                        News.NewsItem item = Utils.parseObject<News.NewsItem>(data);
                        int selIndex = Utils.getRadioButtonCheckedIndex(radioButton51, radioButton52);
                        sendDataConfirm(item.toSendString(selIndex));
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("查询新闻失败！" + e1.Message);
                    }
                });
            }
            else
            {
                sendDataConfirm(text);
            }
        }

        private void sendDataConfirm(string text) {
            if (MessageBox.Show(text, "确认发送？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                NetBuilder.create(this).setUrl(textBoxWebHook.Text).setPostData(text).start((data) =>
                {
                    MessageBox.Show(data);
                });
            }
        }


        private string buildData() {
            if (textBoxWebHook.TextLength == 0)
            {
                MessageBox.Show("HOOK地址为空");
                return null;
            }

            object obj = null;

            if (tabControl1.SelectedIndex == 0)
            {

                if (textBox2.TextLength == 0)
                {
                    MessageBox.Show("必填数据为空");
                    return null;
                }

                MessageItem item = new MessageItem();
                obj = item;
                List<string> lists = item.text.mentioned_mobile_list;
                item.text.content = textBox2.Text;
                if (comboBox1.Text.Length > 0)
                {
                    item.text.content += string.Format("【{0}】", comboBox1.Text);
                }

                if (checkBoxAtAll.Checked)
                {
                    lists.Add("@all");
                }

                string mobile = textBoxAt.Text.Trim();
                if (mobile.Length > 0)
                {
                    string[] arr = mobile.Split(',');
                    lists.AddRange(arr);
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {

                if (textBoxRich.TextLength == 0)
                {
                    MessageBox.Show("必填数据为空");
                    return null;
                }


                MarkDownItem item = new MarkDownItem();
                obj = item;

                item.markdown.content = textBoxRich.Text;
                if (comboBox1.Text.Length > 0)
                {
                    item.markdown.content += string.Format("【{0}】", comboBox1.Text);
                }
            }

            else if (tabControl1.SelectedIndex == 2)
            {

                if (textBoxTWTitle.TextLength == 0 || textBoxTWUrl.TextLength == 0 || textBoxTWPicUrl.TextLength == 0)
                {
                    MessageBox.Show("必填数据为空");
                    return null;
                }
                PicTextItem item = new PicTextItem();
                obj = item;
                NewsItem news = new NewsItem();


                news.title = textBoxTWTitle.Text;
                news.description = textBoxTWDescription.Text;
                news.url = textBoxTWUrl.Text;
                news.picurl = textBoxTWPicUrl.Text;

                item.news.articles.Add(news);

            }
            else if (tabControl1.SelectedIndex == 3) {
                if (textBox1.TextLength == 0) {
                    MessageBox.Show("天气数据 请求地址 为空");
                    return null;
                }
                int selIndex = Utils.getRadioButtonCheckedIndex(radioButton41, radioButton42, radioButton43);
                string extra = string.Format("{0:d},{1}", selIndex, textBox1.Text);
                return WxSendHelper.getCommonExtra(WxSendHelper.EXTRA_FUN_WEATHER, extra);
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                int selIndex = Utils.getRadioButtonCheckedIndex(radioButton51, radioButton52);
                string extra = string.Format("{0:d}", selIndex);//0文字，1图片
                return WxSendHelper.getCommonExtra(WxSendHelper.EXTRA_FUN_NEWS, extra);
            }


            if (obj == null) {
                return null;
            }
            string text = Utils.toJSONString(obj);
            return text;
        }




        private void buttonAddressPaste_Click(object sender, EventArgs e)
        {
            textBoxWebHook.Text = Utils.getClipBoardText();
        }

        private void buttonLinkPaste_Click(object sender, EventArgs e)
        {
            textBoxLinkLink.Text = Utils.getClipBoardText();
        }

        private void buttonStylePaste_Click(object sender, EventArgs e)
        {
            textBoxStyle.Text = Utils.getClipBoardText();
        }

        private void buttonStyleAdd_Click(object sender, EventArgs e)
        {
            if (textBoxStyle.TextLength == 0|| comboBoxStyle.SelectedIndex==0&& textBoxLinkLink.TextLength==0) {
                MessageBox.Show("数据为空");
                return;
            }
            string data = null;
            switch (comboBoxStyle.SelectedIndex) {
                case 0:
                    data = string.Format("[{0}]({1})", textBoxStyle.Text, textBoxLinkLink.Text);
                    break;
                case 1:
                    data = string.Format("# {0}", textBoxStyle.Text);
                    break;
                case 2:
                    data = string.Format("## {0}", textBoxStyle.Text);
                    break;
                case 3:
                    data = string.Format("### {0}", textBoxStyle.Text);
                    break;
                case 4:
                    data = string.Format("#### {0}", textBoxStyle.Text);
                    break;
                case 5:
                    data = string.Format("##### {0}", textBoxStyle.Text);
                    break;
                case 6:
                    data = string.Format("###### {0}", textBoxStyle.Text);
                    break;
                case 7://加粗
                    data = string.Format("**{0}**", textBoxStyle.Text);

                    break;
                case 8://引用
                    data = string.Format("> {0}", textBoxStyle.Text);
                    break;
                case 9://行内代码段（暂不支持跨行）
                    data = string.Format("`{0}`", textBoxStyle.Text);

                    break;
                case 10://字体颜色（绿色）
                    data = string.Format("<font color=\"info\">{0}</font>", textBoxStyle.Text);

                    break;
                case 11://字体颜色（灰色）
                    data = string.Format("<font color=\"comment\">{0}</font>", textBoxStyle.Text);

                    break;
                case 12://字体颜色（橙红色）
                    data = string.Format("<font color=\"warning\">{0}</font>", textBoxStyle.Text);
                    break;

            }
            textBoxRich.AppendText(data);
            if (checkBoxCheckLine.Checked)
            {
                textBoxRich.AppendText("\r\n");
            }
            initConfig();
        }

        private void initConfig() {
            textBoxStyle.Text = "";
            textBoxLinkLink.Text = "http://";
        }

        private void comboBoxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStyle.SelectedIndex == 0)
            {
                textBoxLinkLink.Enabled = true;
                buttonPasteLink.Enabled = true;
            }
            else {
                textBoxLinkLink.Enabled = false;
                buttonPasteLink.Enabled = false;
            }
        }

        public string hookUrl;
        public string sendData;

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            string data=buildData();
            if (data != null) {
                sendData = data;
                hookUrl = textBoxWebHook.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxTWTitle.Text = Utils.getClipBoardText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxTWDescription.Text = Utils.getClipBoardText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxTWUrl.Text = Utils.getClipBoardText();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxTWPicUrl.Text = Utils.getClipBoardText();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WeatherForm dlg = new WeatherForm();
            dlg.isEditMode = true;
            dlg.intSelIndex = Utils.getRadioButtonCheckedIndex(radioButton41, radioButton42, radioButton43);
            if (dlg.ShowDialog() == DialogResult.OK) {
                textBox1.Text = dlg.strAddr;
                Utils.setRadioButtonCheckedIndex(dlg.intSelIndex, radioButton41, radioButton42, radioButton43);
            }
        }
    }
}
