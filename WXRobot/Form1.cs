using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WXRobot
{



    public partial class Form1 : Form
    {

        Bitmap[] bitmaps;
   
        const int HEIGHT = (int)(23 * 2);
        const int WIDTH = (int)(13 * 2) ;

        const int PADDING = 2;//起始绘制位置
        const int DATA_LEN = 8;
        int[] map = new int[DATA_LEN];
        Graphics g;
        Graphics graphicsControl;
        Bitmap bufferimage;

        public Form1()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("启动完成");
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawImage(bufferimage,0,0);
            graphicsControl.DrawImage(bufferimage, 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (bitmaps == null)
                return;


            DateTime dateTime = DateTime.Now;
        
            map[0] = dateTime.Hour / 10;
            map[1] = dateTime.Hour % 10;
            map[3] = dateTime.Minute / 10;
            map[4] = dateTime.Minute % 10;
            map[6] = dateTime.Second / 10;
            map[7] = dateTime.Second % 10;

            //map[9] = dateTime.Millisecond / 100;
            //map[10] = dateTime.Millisecond / 10%10;
            //map[11] = dateTime.Millisecond % 10;
            for (int i = 0; i < DATA_LEN; i++)
            {

                int mapIndex = map[i];
                int x = PADDING+ i * WIDTH;
                int y = PADDING;
                g.DrawImage(bitmaps[mapIndex], x, y, WIDTH, HEIGHT);
            }
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LogUtil.print(Application.StartupPath);


            bitmaps = new Bitmap[]{
                global::WXRobot.Properties.Resources.num0,
                global::WXRobot.Properties.Resources.num1,
                global::WXRobot.Properties.Resources.num2,
                global::WXRobot.Properties.Resources.num3,
                global::WXRobot.Properties.Resources.num4,
                global::WXRobot.Properties.Resources.num5,
                global::WXRobot.Properties.Resources.num6,
                global::WXRobot.Properties.Resources.num7,
                global::WXRobot.Properties.Resources.num8,
                global::WXRobot.Properties.Resources.num9,
                global::WXRobot.Properties.Resources.space,
                global::WXRobot.Properties.Resources.line
            };


            graphicsControl=this.CreateGraphics();
       

            this.ClientSize = new Size(WIDTH * DATA_LEN + PADDING*2, HEIGHT+ PADDING*2);



            const int LINE_INDEX = 11;
            //const int SPACE_INDEX = 10;
            map[5]= map[2] = LINE_INDEX;
            //map[8] = SPACE_INDEX;

            bufferimage = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(bufferimage);
            g.Clear(this.BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量

            timer1_Tick(null, null);


            defaultConfig();
       

        }

        private void defaultConfig() {
            //默认设置
            if (!IniUtil.isExistINIFile())
            {
                IniUtil.setValue(Constants.START_UP, 1);
                Utils.enableStartUp(true);
                defaultLocation();
            }
            else
            {
                string startLocation=IniUtil.getValue(Constants.START_LOCATION,null);
                if (startLocation == null||startLocation.Length==0)
                {
                    defaultLocation();
                }
                else {
                    string[] arr = startLocation.Split(',');
                    this.Location = new Point(NumberUtil.convertToInt(arr[0]), NumberUtil.convertToInt(arr[1]));
                }
            }

            isStarted = true;
        }

        bool isStarted = false;

        private void defaultLocation() {
            Rectangle rec = Screen.GetWorkingArea(this);
            this.Location = new Point(rec.Width - this.Width - 5, 5);
        }


        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm setting = new SettingForm();
            setting.Show();
        }
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (isStarted) {
                IniUtil.setValue(Constants.START_LOCATION, Location.X + "," + Location.Y);
            }
        }
    }
}
