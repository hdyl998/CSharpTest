using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClockPackge
{
    public  class Constants
    {

        public const bool isDebug = true;

        public static string INI_FILE_PATH =  Application.StartupPath+ "/Setting.ini";

        public const string INI_SECTION = "DEFAULT";
        public const string APP_CONFIG = "APP_CONFIG";
        public const string APP_UI_CONFIG = "APP_UI_CONFIG";


    }
}
