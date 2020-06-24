using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClockPackge
{
  public static  class Utils
    {

        //注册表名字
        private const string APP_RIGISTER_NAME = "DigitalClock";

        /// <summary>
        /// 判断是否是开机自启动
        /// </summary>
        /// <returns></returns>
        public static bool isStartUp() {
            try
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                object obj = rk2.GetValue(APP_RIGISTER_NAME, null);
                rk2.Close();
                rk.Close();
                return obj != null;
            }
            catch (Exception) {
                return false;
            }
        }


        /// <summary>
        /// 开机自启动功能
        /// </summary>
        /// <param name="isStartUp">是否开机自启动</param>
        /// <returns>错误信息，为空表示无错误</returns>
        public static string enableStartUp(bool isStartUp) {

            try
            {
                //设置开机自启动  
                if (isStartUp)
                {
                    /*方法一*/
                    //string StartupPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartup);
                    ////获得文件的当前路径
                    //string dir = Directory.GetCurrentDirectory();
                    ////获取可执行文件的全部路径
                    //string exeDir = dir + @"\自动备份.exe.lnk";
                    //File.Copy(exeDir, StartupPath + @"\自动备份.exe.lnk", true);
                    /*方法二*/
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.SetValue(APP_RIGISTER_NAME, path);
                    rk2.Close();
                    rk.Close();
                }
                //取消开机自启动  
                else
                {
                    /*方法一*/
                    //string StartupPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartup);
                    //System.IO.File.Delete(StartupPath + @"\EcgNetPlug.exe.lnk");
                    /*方法二*/
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.DeleteValue(APP_RIGISTER_NAME, false);
                    rk2.Close();
                    rk.Close();
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
     
        }

        public static bool isTextEmpty(string text) {
            if (text == null || text.Length == 0) {
                return true;
            }
            return false;
        }

      
       
        /**
         * 允许带空格
         * **/   
        public static void runExe(params string[]listExePath) {


            foreach (string str in listExePath)
            {
                Process pr = new Process();//声明一个进程类对象
                pr.StartInfo.FileName = str;
                try
                {
                    pr.Start();
                }
                catch (Exception e)
                {
                }
            }
        }
        /**
      * CMD输入
      * **/
        public static void runCmd(params string []cmds) {
            var startInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            var myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo = startInfo;
            myProcess.Start();

            foreach (string cmd in cmds) {
                myProcess.StandardInput.WriteLine(cmd);
            }
        }


        public static string toJSONString(object obj) {
            return JsonConvert.SerializeObject(obj);
        }


        public static T parseObject<T>(string value) {
           return JsonConvert.DeserializeObject<T>(value);
        }


        public static int findIndex(List<int>list,int value) {
            int index = 0;
            foreach (int i in list) {
                if (i == value) {
                    return index;
                }
                index++;
            }

            return index;
        }


        public static void Dispose(params IDisposable []closes) {
            if (closes != null && closes.Length>0) {
                foreach(IDisposable close in closes){
                    close.Dispose();
                }
            }
        }

        public static string getClipBoardText() {
            string text = Clipboard.GetText();
            if (string.IsNullOrEmpty(text)) {
                return "";
            }
            return text;
        }


        public static void setRadioButtonCheckedIndex(int index,params RadioButton []buttons) {
            if (index == -1)
            {
                if (buttons.Length > 0) {
                    buttons[0].Checked = true;
                }
            }
            else {
                buttons[index].Checked = true;
            }


        }


        public static int getRadioButtonCheckedIndex(params RadioButton[] buttons) {
            int index = 0;
            foreach (RadioButton button in buttons) {
                if (button.Checked) {
                    return index;
                }
                index++;
            }

            return -1;

        }

        public static string boolean2ShowString(bool isOK)
        {
            return isOK ? "√" : "×";
        }
    }
}
