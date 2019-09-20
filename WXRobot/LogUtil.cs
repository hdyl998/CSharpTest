using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WXRobot
{
   public static class LogUtil
    {

        public static void print(object obj) {
            if (Constants.isDebug) {
                if (obj == null||"".Equals(obj)) {
                    obj = "空对象";
                }

                System.Diagnostics.Debug.WriteLine(obj.ToString());
            }
        }

        public static void showMessageBox(object obj) {
            if (Constants.isDebug)
            {
                MessageBox.Show(obj.ToString());
            }
        }
    }
}
