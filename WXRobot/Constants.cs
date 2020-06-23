using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClockPackge
{
    public  class Constants
    {

        public static string[] weekString = { "日", "一", "二", "三", "四", "五", "六" };

        public static bool isDebug = "DIGITALCLOCK.EXE".Equals(System.IO.Path.GetFileName(Application.ExecutablePath).ToUpper());

        public static string INI_FILE_PATH =  Application.StartupPath+ "/Setting.ini";

        public const string INI_SECTION = "DEFAULT";
        public const string APP_CONFIG = "APP_CONFIG";
        public const string APP_UI_CONFIG = "APP_UI_CONFIG";


        public const string APP_ROBOT_PATH = "ROBOT_CONFIG";
        public const string APP_WEATHER_CITY = "WEATHER_CITY";
    }
}
