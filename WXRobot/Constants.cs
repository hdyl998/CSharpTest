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

        public const bool isDebug = true;

        public static string INI_FILE_PATH =  Application.StartupPath+ "/Setting.ini";

        public const string INI_SECTION = "DEFAULT";
        public const string APP_CONFIG = "APP_CONFIG";
        public const string APP_UI_CONFIG = "APP_UI_CONFIG";


    }
}
