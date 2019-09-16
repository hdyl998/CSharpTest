using Microsoft.Win32;
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
  public static  class Utils
    {

        //注册表名字
        private const string APP_RIGISTER_NAME = "WXRobot";

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
    }
}
