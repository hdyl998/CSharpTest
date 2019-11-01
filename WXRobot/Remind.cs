﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalClockPackge
{

    public class DataItem {
        public int startX;
        public int startY;

        public int startUp;

        public int startMin;

        public List<RemindItem> listRemind;//提醒

        public List<StartUpItem> listStartUp;//开机自启动

        internal void defaultConfig()
        {
            startX = -1;
            startY = -1;
            startUp = 1;
            startMin = 0;
            listRemind = new List<RemindItem>();
            listStartUp = new List<StartUpItem>();
        }
    }

    public class UiItem{

        //关机
        public int guanjiRadio;
        public int guanjiHour;
        public int guanjiMinute;

        public int guanjiHour2;
        public int guanjiMinute2;


        public void defaultConfig() {
            guanjiMinute = 5;
        }

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

        UiItem uiItem;


        public UiItem getUiItem() {
            return uiItem;
        }


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

            List<RemindItem> list=null;
            foreach (RemindItem item in dataItem.listRemind) {
                if (item.isTimeOK(dateTime)) { 
                    if (list == null) {
                        list = new List<RemindItem>();
                    }
                    list.Add(item);
                }
            }
            return list;
        }
        private void createFromCache() {
            string text = IniUtil.getValue(Constants.APP_CONFIG, null);
            LogUtil.Print(text);
            try
            {
                dataItem = Utils.parseObject<DataItem>(text);
            }
            catch (Exception e) {
                LogUtil.Print(e.ToString());
            }
            if (dataItem == null) {
                dataItem = new DataItem();
                dataItem.defaultConfig();
            }

            string uiText = IniUtil.getValue(Constants.APP_UI_CONFIG,null);

            try
            {
                uiItem = Utils.parseObject<UiItem>(uiText);
            }
            catch (Exception)
            {
            }
            if (uiItem == null)
            {
                uiItem = new UiItem();
                uiItem.defaultConfig();
            }
        }


        public void saveAll() {

            isChanged = false;
            IniUtil.setValue(Constants.APP_CONFIG, Utils.toJSONString(dataItem));
        }


        public void saveUiItem() {
            IniUtil.setValue(Constants.APP_UI_CONFIG, Utils.toJSONString(uiItem));
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
            return appName;
        }
        
    }

    //public class OpenExeRemindItem: RemindItem
    //{

    //    public OpenExeRemindItem()
    //    {

    //        if (this is RemindItem)
    //        {
    //            LogUtil.Print("this is RemindItem" +1 );
    //        }
    //        else {
    //            LogUtil.Print("this is RemindItem" + false);
    //        }


    //        LogUtil.Print("typeof(OpenExeRemindItem)"+ (typeof(OpenExeRemindItem)==GetType()));
    //        LogUtil.Print("typeof(OpenExeRemindItem)2" + (typeof(RemindItem) == GetType()));

    //    }

    //}


    public class RemindItem : BaseItem
    {

        public int hour;//小时 0-23
        public int minute;//分钟 0-59
        public int week;//星期几  Sunday = 0,         Saturday = 6
        public int day;//第几天提醒 1-31
        public int month;//第几月提醒 1-12
        public int year;//仅提醒一次的年

        public int periodType = RemindType.DAY;//提醒周期

        public int taskType = TaskType.REMIND;

        public string content;//提醒内容
        public string extra;//参数
        public string extra2;//参数2

        public RemindItem() {

        }


        public static string[] parseExtraData(string text) {
            //":fun,weather,{0:d},{1}"
            if (!text.StartsWith(":fun")) {
                return null;
            }
            return text.Split(',');
        }



        public bool isHourMinuteSame(DateTime dateTime) {
            return dateTime.Hour == this.hour && dateTime.Minute == this.minute;
        }

   

        public string getPeriodString() {
            return RemindType.type2String(periodType);
        }

        public string getRemindTypeString()
        {
            return TaskType.type2String(taskType);
        }






        public bool isTimeOK(DateTime dateTime) {
            if (!isEnable) {
                return false;
            }

            bool result = false;
            switch (periodType) {
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



        public string getShowTime()
        {


            string info = null;

            switch (periodType)
            {
                case RemindType.DAY:
                case RemindType.USER_DEFINE:
                    info = string.Format("{0:D2}:{1:D2}", hour, minute);
                    break;
                case RemindType.WEEK:
                    info = string.Format("周{0:C} {1:D2}:{2:D2}", Constants.weekString[week], hour, minute);
                    break;
                case RemindType.MONTH:
                    info = string.Format("{0:D}日 {1:D2}:{2:D2}",day, hour, minute);
                    break;
                case RemindType.YEAR:
                    info = string.Format("{0:D}-{1:D} {2:D2}:{3:D2}", month,day, hour, minute);
                    break;
                case RemindType.HOUR:
                    info = string.Format("{0:D}分", minute);
                    break;
                case RemindType.ONCE:
                    info = string.Format("{0:D}-{1:D}-{2:D} {3:D2}:{4:D2}",year, month, day, hour, minute);
                    break;
                   
            }

            //string.Format("整数{0:D2},小数｛1:F2｝,16进0x{2:X2}",2,3,4);
            return info;
        }

        public bool handleWork()
        {
            switch (taskType)
            {
                case TaskType.SHUT_DONW:
                    //关机
                    Utils.runCmd("shutdown -s -t " + 15);
                    return true;
                case TaskType.OPEN_EXE:
                    Utils.runExe(extra);
                    return true;
                case TaskType.WX_SEND_MSG:

                    string []datas=RemindItem.parseExtraData(extra2);
                    if (datas == null)
                    {
                        NetBuilder.create(null).setUrl(extra).setPostData(extra2).start(null);
                    }
                    else {

                        NetBuilder.create(null).asGet().setUrl(datas[3]).start((data) =>
                        {
                            LogUtil.Print(data);
                            try
                            {
                                Weather.WealthNowItem item = Utils.parseObject<Weather.WealthNowItem>(data);

                                WxRobotForm.MessageItem item2 = new WxRobotForm.MessageItem();
                                item2.text.content = item.ToString();
                                NetBuilder.create(null).setUrl(extra).setPostData(Utils.toJSONString(item2)).start(null);
                            }
                            catch (Exception)
                            {
                            }
                        });
                    }


                    return true;
                //case TaskType.WX_SEND_WEATHER_NOW:
                //    NetBuilder.create(null).asGet().setUrl(Weather.getUrl(extra2, Weather.TYPE_NOW)).start((data) =>
                //    {
                //        LogUtil.Print(data);
                //        try
                //        {
                //            Weather.WealthNowItem item = Utils.parseObject<Weather.WealthNowItem>(data);
                //            NetBuilder.create(null).setUrl(extra).setPostData(item.ToString()).start(null);
                //        }
                //        catch (Exception)
                //        {

                //        }
                //    });

                //    break;
                    
            }
            return false;
        }


    }

    public static class TaskType {
        public const int REMIND = 0;//提醒
        public const int SHUT_DONW = 1;//关机
        public const int OPEN_EXE = 2;//打开程序

        public const int WX_SEND_MSG = 3;//发送消息




        public static Dictionary<int, string> map = new Dictionary<int, string>();

        public static List<int> listType = new List<int>();

        static TaskType() {
            listType.Add(TaskType.REMIND);
            listType.Add(TaskType.SHUT_DONW);
            listType.Add(TaskType.OPEN_EXE);
            listType.Add(TaskType.WX_SEND_MSG);


            map.Add(REMIND, "提醒");
            map.Add(SHUT_DONW, "关机");
            map.Add(OPEN_EXE, "执行程序");
            map.Add(WX_SEND_MSG, "发送企业微信消息");

        }


        public static string type2String(int type)
        {
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
        public const int USER_DEFINE = 100;//自定义

        public static Dictionary<int, string> map  = new Dictionary<int, string>(10);


        public static List<int> listPeriod = new List<int>();

        static RemindType() {
            listPeriod.Add(RemindType.DAY);
            listPeriod.Add(RemindType.WEEK);
            listPeriod.Add(RemindType.MONTH);
            listPeriod.Add(RemindType.YEAR);
            listPeriod.Add(RemindType.HOUR);
            listPeriod.Add(RemindType.ONCE);
            //listPeriod.Add(RemindType.USER_DEFINE);

            map.Add(DAY, "每天");
            map.Add(WEEK, "每周");
            map.Add(MONTH, "每月");
            map.Add(YEAR, "每年");
            map.Add(HOUR, "每小时");
            map.Add(ONCE, "仅一次");
            map.Add(USER_DEFINE, "自定义");

        }





        public static string type2String(int type) {
            return map[type];
        }

    }
}
