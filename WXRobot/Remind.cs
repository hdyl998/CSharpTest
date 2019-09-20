using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXRobot
{

    public class DataManager {

        private static DataManager intance=new DataManager();

        public static DataManager getInstance() {
            return intance;
        }

        private List<RemindItem> listRemind;

        private List<StartUpItem> listStartUp;//开机自启动


        public List<StartUpItem> getStartUpData()
        {
            return listStartUp;
        }


        private DataManager() {
            createFromCache();
        }

        public List<RemindItem> getRemindData() {
            return listRemind;
        }

        public List<RemindItem> handleTime(DateTime dateTime) {

            List<RemindItem> list1=null;
            foreach (RemindItem item in listRemind) {
                if (item.handleTime(dateTime)) { 
                    if (list1 == null) {
                        list1 = new List<RemindItem>();
                    }
                    list1.Add(item);
                }
            }
            return list1;
        }

        private void createFromCache() {

            string text= IniUtil.getValue(Constants.REMIND_DATA, null);
            listRemind = Utils.parseObject<List<RemindItem>>(text);
            if (listRemind == null) {
                listRemind = new List<RemindItem>();
            }

            string textStartUp = IniUtil.getValue(Constants.STARTUP_DATA, null);
            listStartUp = Utils.parseObject<List<StartUpItem>>(textStartUp);
            if (listStartUp == null)
            {
                listStartUp = new List<StartUpItem>();
            }

        }

        public void saverRemindData() {
            IniUtil.setValue(Constants.REMIND_DATA,Utils.toJSONString(listRemind));
        }

        public void saveStartUpData() {
            IniUtil.setValue(Constants.STARTUP_DATA, Utils.toJSONString(listStartUp));
        }


        public void saveAll() {
            saverRemindData();
            saveStartUpData();
        }


    }

    public class BaseItem {
        public string createTime=DateTime.Now.ToString();//创建时间
        public bool isEnable = true;//是否可用

        public string getEnableString()
        {
            return isEnable ? "是" : "否";
        }
    }


    public class StartUpItem :BaseItem{
        public string path;

        public override string ToString()
        {
            return path;
        }
    }


    public class RemindItem : BaseItem
    {

        public int hour = 12;//小时 0-23
        public int minute = 13;//分钟 0-59
        public int week;//星期几  Sunday = 0,         Saturday = 6
        public int day;//第几天提醒 1-31
        public int month;//第几月提醒 1-12
        public int year;//仅提醒一次的年

        public int remindType = RemindType.DAY;//提醒周期

        public string content = "提醒内容";//提醒内容

        public bool isHourMinuteSame(DateTime dateTime) {
            return dateTime.Hour == this.hour && dateTime.Minute == this.minute;
        }


   




  


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
                map.Add(HOUR, "每小时");
                map.Add(ONCE, "仅提醒一次");
            }
            return map[type];
        }

    }
}
