using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalClockPackge
{

    public class DataItem {
        public int startX;
        public int startY;

        public int startUp;

        public int startMin;//启动时最小化

        public List<RemindItem> listRemind;//提醒

        public bool isRemindEnable;


     



        public List<StartUpItem> listStartUp;//开机自启动

        internal void defaultConfig()
        {
            startX = -1;
            startY = -1;
            startUp = 1;
            startMin = 0;
            isRemindEnable = true;
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

        public int uiBorderStyleIndex=0;

        public int uiScale =20;

        public void defaultConfig() {
            guanjiMinute = 5;
            uiBorderStyleIndex = 0;//FormBorderStyle.FixedDialog, FormBorderStyle.FixedSingle, FormBorderStyle.FixedToolWindow, FormBorderStyle.None
            uiScale = 20;//最终除以10
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

            if (!dataItem.isRemindEnable) {
                return null;
            }
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
            return isEnable ? "√" : "×";
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

    public class WxSendHelper {

        public const string EXTRA_FUN_WEATHER = "weather";
        public const string EXTRA_FUN_NEWS = "news";

     
        private string hookUrl;
        private string cmd;

        private string extra;

        private string []cmdArray;


        public WxSendHelper(string hookUrl,string extra) {
            this.hookUrl = hookUrl;

            this.extra = extra;

            cmdArray = parseExtraData(extra);

            if (cmdArray != null) {
                this.cmd =cmdArray[1];
            }

        }


        public string getHookUrl() {
            return hookUrl;
        }

        public string getExtra() {
            return extra;
        }


        public string[] parseExtraData(string text)
        {
            //":fun,weather,{0:d},{1}"
            if (string.IsNullOrEmpty(text) ||!text.StartsWith(":fun"))
            {
                return null;
            }
            return text.Split(',');
        }


        public static string getCommonExtra(string cmd,string extra) {

           return string.Format(":fun,{0},{1}", cmd, extra);
        }


        //是否是普通消息
        public bool isNormalMsg() {
            return cmdArray == null;
        }




        public bool isWeather() {
            return EXTRA_FUN_WEATHER.Equals(cmd);
        }

        public bool isNews() {
            return EXTRA_FUN_NEWS.Equals(cmd);
        }


        public int getExtraAsInt(int index) {
            return NumberUtil.convertToInt(getExtra(index));
        } 

        public string getExtra(int index)
        {
            if (index + 2 >= cmdArray.Length) {
                return "";
            }
            return cmdArray[index + 2];
        }


   
    }


    public class RemindTimeItem {
        public int hour;//小时 0-23
        public int minute;//分钟 0-59
        public int week;//星期几  Sunday = 0,         Saturday = 6
        public int day;//第几天提醒 1-31
        public int month;//第几月提醒 1-12
        public int year;//仅提醒一次的年

        public int periodType = RemindType.DAY;//提醒周期




        public bool isHourMinuteSame(DateTime dateTime)
        {
            return dateTime.Hour == this.hour && dateTime.Minute == this.minute;
        }



        public string getPeriodString()
        {
            return RemindType.type2String(periodType);
        }



  



        public bool isTimeOK(DateTime dateTime)
        {

            bool result = false;
            switch (periodType)
            {
                case RemindType.DAY:
                    result = isHourMinuteSame(dateTime);
                    break;
                case RemindType.WEEK:
                    int week = (int)dateTime.DayOfWeek;
                    result = this.week == week && isHourMinuteSame(dateTime);
                    break;
                case RemindType.MONTH:
                    //1 和 31 之间的一个值。
                    result = this.day == dateTime.Day && isHourMinuteSame(dateTime);
                    break;
                case RemindType.YEAR:
                    result = this.month == dateTime.Month && this.day == dateTime.Day && isHourMinuteSame(dateTime);
                    break;
                case RemindType.HOUR:
                    result = minute == dateTime.Minute;
                    break;
                case RemindType.ONCE:
                    result = this.year == dateTime.Year && this.month == dateTime.Month && this.day == dateTime.Day && isHourMinuteSame(dateTime);
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
                    info = string.Format("{0:D}日 {1:D2}:{2:D2}", day, hour, minute);
                    break;
                case RemindType.YEAR:
                    info = string.Format("{0:D}-{1:D} {2:D2}:{3:D2}", month, day, hour, minute);
                    break;
                case RemindType.HOUR:
                    info = string.Format("{0:D}分", minute);
                    break;
                case RemindType.ONCE:
                    info = string.Format("{0:D}-{1:D}-{2:D} {3:D2}:{4:D2}", year, month, day, hour, minute);
                    break;

            }

            //string.Format("整数{0:D2},小数｛1:F2｝,16进0x{2:X2}",2,3,4);
            return info;
        }
    }


    public class RemindItem : BaseItem
    {

        public List<RemindTimeItem> timeItems = new List<RemindTimeItem>();


        public int taskType = TaskType.REMIND;

        public string content;//提醒内容
        public string extra;//参数
        public string extra2;//参数2

        public RemindItem() {

        }
        public string getPeriodString() {
            if (timeItems.Count == 0) {
                return "无";
            }
            StringBuilder builder = new StringBuilder();
            foreach (var v in timeItems) {
                string data = RemindType.type2String(v.periodType);
                if (!builder.ToString().Contains(data)) {
                    if (builder.Length > 0){
                        builder.Append("\\");
                    }
                    builder.Append(data);
                }
            }
            return builder.ToString() ;
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
                //case TaskType.SHUT_DONW:
                //    //关机
                
                //    return true;
                case TaskType.OPEN_EXE:
                    Utils.runExe(extra);
                    return true;
                case TaskType.WX_SEND_MSG:
                    WxSendHelper helper = new WxSendHelper(extra,extra2);
                    if (helper.isNormalMsg())
                    {
                        NetBuilder.create(null).setUrl(helper.getHookUrl()).setPostData(helper.getExtra()).start(null);
                    }
                    else if (helper.isWeather())
                    {
                        LogUtil.Print("开始获取天气" + helper.getExtra(1));
                        NetBuilder.create(null).asGet().setUrl(helper.getExtra(1)).start((data) =>
                        {
                            LogUtil.Print(data);
                            try
                            {
                                Weather.WealthNowItem item = Utils.parseObject<Weather.WealthNowItem>(data);

                                
                                NetBuilder.create(null).setUrl(helper.getHookUrl()).setPostData(item.toSendString()).start(null);
                            }
                            catch (Exception e)
                            {
                                LogUtil.Print(e.Message);
                            }
                        });
                    }
                    else if (helper.isNews()) {
                        LogUtil.Print("开始获新闻" + News.URL);


                        NetBuilder.create(null).asGet().setUrl(News.URL).start((data) =>
                        {
                            LogUtil.Print(data);
                            try
                            {
                                News.NewsItem item = Utils.parseObject<News.NewsItem>(data);
                                string sendString = item.toSendString(helper.getExtraAsInt(0));
                                NetBuilder.create(null).setUrl(extra).setPostData(sendString).start(null);
                                
                            }
                            catch (Exception e1)
                            {
                                LogUtil.Print(e1.Message);
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
