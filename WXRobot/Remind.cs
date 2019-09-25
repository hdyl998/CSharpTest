using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXRobot
{

    public class DataItem {
        public int startX;
        public int startY;

        public int startUp;

        public List<RemindItem> listRemind;//提醒

        public List<StartUpItem> listStartUp;//开机自启动

        internal void defaultConfig()
        {
            startX = -1;
            startY = -1;
            startUp = 1;
            listRemind = new List<RemindItem>();
            listStartUp = new List<StartUpItem>();
        }
    }

    public class UiItem{
        public int tabIndex = 0;

        //关机
        public int guanjiRadio = 0;
        public int guanjiIndex0 = 0;
        public int guanjiIndex1 = 5;

        public int guanjiIndex10 = -1;
        public int guanjiIndex11 = -1;
    }




    public class DataManager {

        private static DataManager intance=new DataManager();

        public bool isChanged = false;


        public void setChanged() {
            isChanged = true;
        }


        public static DataManager getInstance() {
            return intance;
        }
        DataItem dataItem;

        public DataItem getDataItem() {
            return dataItem;
        }


        public List<StartUpItem> getStartUpData()
        {
            return dataItem.listStartUp;
        }


        private DataManager() {
            createFromCache();
        }

        public List<RemindItem> getRemindData() {
            return dataItem.listRemind;
        }


    

        public List<RemindItem> handleTime(DateTime dateTime) {

            List<RemindItem> list1=null;
            foreach (RemindItem item in dataItem.listRemind) {
                if (item.handleTime(dateTime)) { 
                    if (list1 == null) {
                        list1 = new List<RemindItem>();
                    }
                    list1.Add(item);
                }
            }

            handShutdown(dateTime);
            return list1;
        }

        private void handShutdown(DateTime dateTime)
        {
            //foreach (ShutdownItem item in getShutdownData())
            //{
            //    if (dateTime.Hour == item.hour && dateTime.Minute == item.minute) {
            //        Utils.runCmd("shutdown -s -t " +10);
            //        break;
            //    }
            //}
        }

        private void createFromCache() {
            string text = IniUtil.getValue(Constants.APP_CONFIG, null);
            try
            {
                dataItem = Utils.parseObject<DataItem>(text);
            }
            catch (Exception) {

            }

  
            if (dataItem == null) {
                dataItem = new DataItem();
                dataItem.defaultConfig();
            }
        }


        public void saveAll() {

            isChanged = false;
            IniUtil.setValue(Constants.APP_CONFIG, Utils.toJSONString(dataItem));
        }


        public void saveIfChanged()
        {

            if (isChanged) {
                saveAll();
            }

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

    public class ShutdownItem : BaseItem
    {
        public int hour;
        public int minute;


        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}", hour, minute);
        }
    }



    public class StartUpItem :BaseItem{
        public string path;
        public string appName;


        public string getAppName() {
            if (appName != null)
            {
                return appName;
            }
            return appName=path.Substring(path.LastIndexOf("/") + 1);
        }
        
    }


    public class RemindItem : BaseItem
    {

        public int hour;//小时 0-23
        public int minute;//分钟 0-59
        public int week;//星期几  Sunday = 0,         Saturday = 6
        public int day;//第几天提醒 1-31
        public int month;//第几月提醒 1-12
        public int year;//仅提醒一次的年

        public int remindType = RemindType.DAY;//提醒周期

        public int taskType = TaskType.REMIND;

        public string content = "提醒内容";//提醒内容
        public string extra;//参数

        public bool isHourMinuteSame(DateTime dateTime) {
            return dateTime.Hour == this.hour && dateTime.Minute == this.minute;
        }

        public string getShowTime() {
            //string.Format("整数{0:D2},小数｛1:F2｝,16进0x{2:X2}",2,3,4);
            return string.Format("{0:D2}:{1:D2}", hour, minute);
        }


        public string getRemindTypeString() {
            return RemindType.type2String(remindType);
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

    public static class TaskType {
        public const int REMIND = 0;//提醒
        public const int SHUT_DONW = 1;//关机
        public const int OPEN_EXE = 2;//打开程序


        public static Dictionary<int, string> map = null;




        public static string type2String(int type)
        {
            if (map == null)
            {
                map = new Dictionary<int, string>();
                map.Add(REMIND, "提醒");
                map.Add(SHUT_DONW, "关机");
                map.Add(OPEN_EXE, "执行程序");
            }
            return map[type];
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
        



        public static string type2String(int type) {
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
