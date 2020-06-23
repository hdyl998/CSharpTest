using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DigitalClockPackge
{



    public partial class MainForm : Form
    {

        Bitmap[] bitmaps;

        int HEIGHT = (int)(23 * 2);
        int WIDTH = (int)(13 * 2) ;

        const int PADDING = 2;//起始绘制位置
        const int DATA_LEN = 8;
        int[] map = new int[DATA_LEN];

        int[] mapTemp = new int[DATA_LEN];

        Graphics g;
        Graphics graphicsControl;
        Bitmap bufferimage;

        public MainForm()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("启动完成");
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.BackgroundImage = bufferimage;

            LogUtil.Print("Form1_Paint");
        }
        private bool isMapSame() {
            for (int i = 0; i < mapTemp.Length; i++) {
                if (map[i] != mapTemp[i]) {
                    return false;
                }
            }
            return true;
        }

        private void copyMap() {
            //交换地址
            var temp = map;
            map = mapTemp;
            mapTemp = temp;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {


            if (bitmaps == null)
                return;


            DateTime dateTime = DateTime.Now;

            mapTemp[0] = dateTime.Hour / 10;
            mapTemp[1] = dateTime.Hour % 10;
            mapTemp[3] = dateTime.Minute / 10;
            mapTemp[4] = dateTime.Minute % 10;
            mapTemp[6] = dateTime.Second / 10;
            mapTemp[7] = dateTime.Second % 10;

            if (isMapSame()) {
                return;
            }
            copyMap();
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
            graphicsControl.DrawImage(bufferimage, 0, 0);
            if (dateTime.Second == 0) {
                var list = DataManager.getInstance().handleTime(dateTime);
                if (list != null) {
                    handleAction(list);
                }
            }
            else if (dateTime.Second == 59) {
                closeDialog();
            }
        }

        private void closeDialog() {
            if (dlg != null)
            {
                dlg.Close();
                dlg = null;
            }

            if (dlgShutDown != null)
            {
                dlgShutDown.Close();
                dlgShutDown = null;
            }
           
        }

        RemindForm dlg;
        ShutDownForm dlgShutDown;

        private void handleAction(List<RemindItem> list) {
            closeDialog();
            List<RemindItem> listReminds=null;
            foreach (RemindItem item in list) {

                switch (item.taskType) {
                    case TaskType.SHUT_DONW:
                        dlgShutDown = new ShutDownForm();
                        dlgShutDown.Show();
                        return;//只能出现一个关机的对话框
                    case TaskType.REMIND:
                        if (listReminds == null)
                        {
                            listReminds = new List<RemindItem>();
                        }
                        listReminds.Add(item);
                        break;
                    default:
                        item.handleWork();
                        break;
                }
            }
            if (listReminds != null) {
                showRemindDialog(listReminds);
            }
        }

        private void showRemindDialog(List<RemindItem>listReminds) {

            dlg = new RemindForm();
            dlg.items = listReminds;
            dlg.ShowDialog();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //new EditQuickMenuForm().ShowDialog();

            //Utils.runExe("C:\\Windows\\notepad.exe", "C:\\Windows\\notepad.exe");
            LogUtil.Print(Application.StartupPath);
            bitmaps = new Bitmap[]{
                Properties.Resources.num0,
                Properties.Resources.num1,
                Properties.Resources.num2,
                Properties.Resources.num3,
                Properties.Resources.num4,
                Properties.Resources.num5,
                Properties.Resources.num6,
                Properties.Resources.num7,
                Properties.Resources.num8,
                Properties.Resources.num9,
                Properties.Resources.space,
                Properties.Resources.line
            };

            //调整大小
            for (int i = 0; i < bitmaps.Length; i++) {
                bitmaps[i] = new Bitmap(bitmaps[i], WIDTH, HEIGHT);
            }

       



            const int LINE_INDEX = 11;
            //const int SPACE_INDEX = 10;
            map[5] = map[2] = LINE_INDEX;
            mapTemp[5] = mapTemp[2] = LINE_INDEX;


            //map[8] = SPACE_INDEX;
          


            defaultConfig();


            handleStartUp();

            createUserDefineMenuItems();

            //NetBuilder.create(this).asGet().setUrl("http://www.weather.com.cn/data/sk/101010100.html").start((data) =>
            //{
            //    LogUtil.Print(data);
            //});





        }

        private void setScaleSize(int var)
        {

            float scale = var / 10f;
            HEIGHT = (int)(23 * scale);
            WIDTH = (int)(13 * scale);

            this.ClientSize = new Size(WIDTH * DATA_LEN + PADDING * 2, HEIGHT + PADDING * 2);
            bufferimage = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(bufferimage);
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            g.Clear(this.BackColor);
            graphicsControl = this.CreateGraphics();
            timer1_Tick(null, null);
            this.Invalidate();
        }

        private void handleStartUp() {

 

            if (Constants.isDebug) {
                return;
            }

            foreach(StartUpItem item in DataManager.getInstance().getStartUpData()){
                if (item.isEnable &&File.Exists(item.path)) {
                    Utils.runExe(item.path);
                }
            }
        }

        private void defaultConfig()
        {


            setScaleSize(DataManager.getInstance().getUiItem().uiScale);
            setFormBoderStyle(DataManager.getInstance().getUiItem().uiBorderStyleIndex);


            int startX= DataManager.getInstance().getDataItem().startX;

           int startY = DataManager.getInstance().getDataItem().startY;

           int startUp = DataManager.getInstance().getDataItem().startUp;

            Utils.enableStartUp(startUp==1);

            if (startX < 0 || startY < 0)
            {
                defaultLocation();
            }
            else {
                this.Location = new Point(startX, startY);
            }



            isStarted = true;

            if (DataManager.getInstance().getDataItem().startMin == 1) {
                new Thread(new ThreadStart(HideMainForm)).Start();
            }
        }



        bool isStarted = false;

        private void defaultLocation() {
            Rectangle rec = Screen.GetWorkingArea(this);
            this.Location = new Point(rec.Width - this.Width - 5, 5);
        }

        SettingForm setting;
        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setting == null|| setting.IsDisposed) {
                setting = new SettingForm();
                setting.deleHandler = new DelegateDone(onStyleChange);
            }
            setting.Show();
            setting.Activate();
        }
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (isStarted) {
                if (Location.X > 0 && Location.Y > 0) {
                    DataManager.getInstance().getDataItem().startX = Location.X;
                    DataManager.getInstance().getDataItem().startY = Location.Y;
                    DataManager.getInstance().setChanged();
                }
  
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideMainForm();
            }
        }

        private void HideMainForm()
        {
            this.Invoke((MethodInvoker)(() =>//子线程中操作UI
            {
                Hide();
            }));
        }

        private void ShowMainForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void menuNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        private void menuExit_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }

        private void ExitMainForm()
        {
            this.notifyIcon1.Visible = false;
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;

                HideMainForm();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                ShowMainForm();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            DataManager.getInstance().saveIfChanged();
        }

        private void menuHide_Click_Click(object sender, EventArgs e)
        {
            HideMainForm();
        }


        private void menuShow_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }




        public void onStyleChange(int type, object vaule)
        {
            if (type == SettingForm.UI_SETTING_TYPE_BORDER)
            {
                setFormBoderStyle((int)vaule);
            }
            else if (type == SettingForm.UI_SETTING_TYPE_SIZE)
            {
                setScaleSize((int)vaule);
            }
            else if (type == SettingForm.UI_SETTING_MENUCHANGE) {
                createUserDefineMenuItems();

            }
        }

        private void createUserDefineMenuItems() {
            toolStripMenuItemUser.DropDownItems.Clear();

            var list = DataManager.getInstance().getQuickMenuItems();

            int realCount = 0;
            foreach (var v in list)
            {
                if (v.isEnable)
                {
                    realCount++;
                }
            }

            if (realCount == 0)
            {
                return;
            }

            ToolStripItem[] items = new ToolStripItem[realCount];


            int index = 0;
            foreach (var v in list)
            {

                if (!v.isEnable)
                {
                    continue;
                }
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Tag = v.action;
                item.Text = v.name;
                item.Size = new System.Drawing.Size(152, 22);
                item.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
                items[index++] = item;


            }

            toolStripMenuItemUser.DropDownItems.AddRange(items);
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
           string action= item.Tag.ToString();

            if(!Utils.isTextEmpty(action))
            Utils.runCmd(action);
        }

        public  void setFormBoderStyle( int index)
        {
            try
            {
                FormBorderStyle[] objects = { FormBorderStyle.FixedDialog, FormBorderStyle.FixedToolWindow, FormBorderStyle.None };
                this.FormBorderStyle = objects[index];
            }
            catch (Exception)
            {
            }

        }

        private void 启动项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Utils.runExe("msconfig");
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.runExe("notepad");
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.runExe("calc");
        }

        private void 画图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.runExe("mspaint");
        }

     

        private void 任务管理器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.runExe("taskmgr");
        }

        private void 资源管理器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.runExe("explorer");
        }

        private void 计算机管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.runExe("compmgmt.msc");
        }
    }
}
