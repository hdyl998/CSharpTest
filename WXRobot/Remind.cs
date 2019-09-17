using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXRobot
{

    public class RemindManager {

        private static RemindManager intance=new RemindManager();

        public static RemindManager getInstance() {
            return intance;
        }

        private List<RemindItem> list;

        public RemindManager() {
            createFromCache();
        }

        public List<RemindItem> getList() {
            return list;
        }


        private void createFromCache() {
            list = new List<RemindItem>();

            list.Add(new RemindItem());
            list.Add(new RemindItem());
            list.Add(new RemindItem());
        }

        public void save() {

        }




    }

   public class RemindItem
    {

        public int hour=12;//小时 0-23
        public int minute=13;//分钟 0-59

        public int remindType= RemindType.DAY;//提醒周期

        public bool isEnable = true;//是否可用

        public string getEnableString() {
            return isEnable ? "是" : "否";
        }


        public string content= "提醒内容";//提醒内容

        public long createTime;//创建时间


        public string getShowTime() {
            //string.Format("整数{0:D2},小数｛1:F2｝,16进0x{2:X2}",2,3,4);
            return string.Format("{0:D2}:{1:D2}", hour,minute);
        }


        public string getRemindTypeString() {
            return RemindType.remindType2String(remindType);
        }
    }


    public static class RemindType {


        public const int DAY = 0;
        public const int WEEK = 1;
        public const int MONTH = 2;
        public const int YEAR = 3;
        public const int HOUR = 10;
        public const int ONCE = 99;

        public static Dictionary<int, string> map = null;
        



        public static string remindType2String(int type) {
            if (map == null) {
                map = new Dictionary<int, string>();
                map.Add(DAY,"每天");
                map.Add(WEEK, "每周");
                map.Add(MONTH, "每月");
                map.Add(YEAR, "每年");
                map.Add(ONCE, "仅提醒一次");
            }
            return map[type];
        }

    }
}
