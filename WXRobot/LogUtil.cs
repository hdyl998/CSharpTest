using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClockPackge
{
   public static class LogUtil
    {

        public static void Print(string tag,object obj){
            if (Constants.isDebug)
            {
                if (obj == null || "".Equals(obj))
                {
                    obj = "空对象";
                }
                if (obj is int || obj is string || obj is bool)
                {
                    System.Diagnostics.Debug.WriteLine(tag+" -------- "+obj.ToString());
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(tag + " -------- " + Utils.toJSONString(obj));
                }

            }
        }


        public static void Print(object obj) {
            Print("EmptyTag",obj);
        }

        public static void showMessageBox(object obj) {
            if (Constants.isDebug)
            {
                MessageBox.Show(obj.ToString());
            }
        }
    }
}
