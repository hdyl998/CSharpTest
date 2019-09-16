using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXRobot
{
   public static class NumberUtil
    {

        public static int convertToInt(string data) {
            return convertToInt(data,0);
        }

        public static int convertToInt(string data,int defalutValue)
        {
            try
            {
                return int.Parse(data);
            }
            catch (Exception)
            {
                return defalutValue;
            }
        }


        public static float convertToFloat(string data)
        {
            return convertToFloat(data, 0f);

        }

        public static float convertToFloat(string data, float defalutValue)
        {

            try
            {
                return float.Parse(data);
            }
            catch (Exception)
            {
                return defalutValue;
            }
        }

    }
}
