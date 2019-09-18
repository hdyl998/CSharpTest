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

        public void handleTime(DateTime dateTime) {

            List<RemindItem> list1=null;
            foreach (RemindItem item in list) {
                bool isOK=item.handleTime(dateTime);
                if (isOK) { 
                    if (list1 == null) {
                        list1 = new List<RemindItem>();
                    }
                    list1.Add(item);
                }
            }
            if(list1!=null){
                RemindForm dlg = new RemindForm();
                dlg.items = list1;
                dlg.ShowDialog();
            }
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

        public int hour = 12;//小时 0-23
        public int minute = 13;//分钟 0-59
        public int week;//星期几  Sunday = 0,         Saturday = 6
        public int day;//第几天提醒 1-31
        public int month;//第几月提醒 1-12
        public int year;//仅提醒一次的年

        public int remindType = RemindType.DAY;//提醒周期

        public bool isEnable = true;//是否可用

        public bool isHourMinuteSame(DateTime dateTime) {
            return dateTime.Hour == this.hour && dateTime.Minute == this.minute;
        }


        public string getEnableString() {
            return isEnable ? "是" : "否";
        }


        public string content = "提醒内容";//提醒内容

        public long createTime;//创建时间


        public string getShowTime() {
            //string.Format("整数{0:D2},小数｛1:F2｝,16进0x{2:X2}",2,3,4);
            return string.Format("{0:D2}:{1:D2}", hour, minute);
        }


        public string getRemindTypeString() {
            return RemindType.remindType2String(remindType);
        }

        public bool handleTime(DateTime dateTime) {
            if (!isEnable) {
                return false;
            }

            bool result = false;
            switch (remindType) {
                case RemindType.DAY:
                    result = isHourMinuteSame(dateTime);
                    break;
                case RemindType.WEEK:
                    int week = (int)dateTime.DayOfWeek;
                    result =this.week== week && isHourMinuteSame(dateTime);
                    break;
                case RemindType.MONTH:
                    //1 和 31 之间的一个值。
                    result = this.day == dateTime.Day && isHourMinuteSame(dateTime);
                    break;
                case RemindType.YEAR:
                    result = this.month==dateTime.Month && this.day == dateTime.Day && isHourMinuteSame(dateTime);
                    break;
                case RemindType.HOUR:
                    result = minute== dateTime.Minute;
                    break;
                case RemindType.ONCE:
                    result =this.year== dateTime.Year&& this.month == dateTime.Month && this.day == dateTime.Day && isHourMinuteSame(dateTime);
                    break;
            }
            return result;


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
