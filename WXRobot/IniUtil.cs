using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DigitalClockPackge
{

    public static class IniUtil {

        static IniFiles iniFiles = new IniFiles();

        public static void setValue(string key,string value) {
            iniFiles.setValue(key,value);
        }

        public static void setValue(string key, Object value)
        {
            iniFiles.setValue(key, value);
        }

        public static void setValue(string key, bool value)
        {
            iniFiles.setValue(key, value?1:0);
        }


        public static string getValue(string key) {
           return iniFiles.getValue(key);
        }

        public static string getValue(string key,string defalutValue)
        {
            return iniFiles.getValue(key, defalutValue);
        }


        public static int getValueAsInt(string key,int defalutValue)
        {
            return iniFiles.getValueAsInt(key, defalutValue);
        }

        public static int getValueAsInt(string key)
        {
            return iniFiles.getValueAsInt(key);
        }


        public static bool getValueAsBool(string key, bool defalutValue)
        {
            return iniFiles.getValueAsInt(key, defalutValue?1:0)==1;
        }

        public static bool getValueAsBool(string key)
        {
            return iniFiles.getValueAsInt(key)==1;
        }


        public static bool isExistINIFile() {
            return iniFiles.isExistINIFile();
        }
    }


    public class IniFiles
    {
        private string inipath;

        private string Section
        {
            set; get;
        }

        //声明API函数

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary> 
        /// 构造方法 
        /// </summary> 
        /// <param name="INIPath">文件路径</param> 
        public IniFiles(string INIPath)
        {
            inipath = INIPath;
            Section = Constants.INI_SECTION;
        }

        public IniFiles() {

            inipath = Constants.INI_FILE_PATH;
            Section = Constants.INI_SECTION;
        }

        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public void setValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.inipath);
        }

        public void setValue(string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.inipath);
        }

        public void setValue(string Key, Object Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), this.inipath);
        }


        public void setValue(string Section, string Key, Object Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), this.inipath);
        }


        public string getValue(string Key)
        {
            return getValue(Key,"");
        }


        public string getValue(string Key,string defaultValue)
        {
            return getValue(Section, Key, defaultValue);
        }

        public int getValueAsInt(string Key) {
            return getValueAsInt(Section,Key,0);
        }
        public int getValueAsInt(string Key, int defaultVar)
        {
            return getValueAsInt(Section, Key, defaultVar);
        }


        public int getValueAsInt(string Section, string Key,int defaultVar)
        {
            return NumberUtil.convertToInt(getValue(Section, Key, defaultVar.ToString()));
        }

        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public string getValue(string Section, string Key,string defValue)
        {
            if (!isExistINIFile())
            {
                return null;
            }
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, defValue, temp, 500, this.inipath);
            return temp.ToString();
        }
        /// <summary> 
        /// 验证文件是否存在 
        /// </summary> 
        /// <returns>布尔值</returns> 
        public bool isExistINIFile()
        {
            return File.Exists(inipath);
        }
    }
}
