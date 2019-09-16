using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WXRobot
{
    public  class Constants
    {

        public const bool isDebug = true;

        public static string INI_FILE_PATH =  Application.StartupPath+ "/Setting.ini";

        public const string INI_SECTION = "DEFAULT";
        public const string START_UP = "START_UP";


        public const string START_LOCATION = "START_LOCATION";
    }
}
