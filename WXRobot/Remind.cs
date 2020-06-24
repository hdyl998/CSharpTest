using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalClockPackge
{

    public class DataItem
    {

        public int version;

        public int startX;
        public int startY;

        public int startUp;

        public int startMin;//启动时最小化

        public List<RemindItem> listRemind;//提醒


        public List<StartUpItem> listStartUp;//开机自启动

        public List<QuickMenuItem> listQuickMenu;//快捷菜单

        internal void defaultConfig()
        {
            startX = -1;
            startY = -1;
            startUp = 1;
            startMin = 0;

            listRemind = new List<RemindItem>();
            listStartUp = new List<StartUpItem>();

            listQuickMenu = new List<QuickMenuItem>();
        }

        public void checkNotNull()
        {
            if (listRemind == null)
                listRemind = new List<RemindItem>();
            if (listStartUp == null)
                listStartUp = new List<StartUpItem>();
            if (listQuickMenu == null)
                listQuickMenu = new List<QuickMenuItem>();
        }
    }

    public class UiItem
    {

        //关机
        public int guanjiRadio;
        public int guanjiHour;
        public int guanjiMinute;

        public int guanjiHour2;
        public int guanjiMinute2;

        public int uiBorderStyleIndex = 0;

        public int uiScale = 20;

        public void defaultConfig()
        {
            guanjiMinute = 5;
            uiBorderStyleIndex = 0;//FormBorderStyle.FixedDialog, FormBorderStyle.FixedSingle, FormBorderStyle.FixedToolWindow, FormBorderStyle.None
            uiScale = 20;//最终除以10
        }


    }




    public class DataManager
    {

        private static DataManager intance = new DataManager();

        public bool isChanged = false;


        public void setChanged()
        {
            isChanged = true;
        }


        public static DataManager getInstance()
        {
            return intance;
        }
        DataItem dataItem;

        UiItem uiItem;


        public UiItem getUiItem()
        {
            return uiItem;
        }


        public DataItem getDataItem()
        {
            return dataItem;
        }


        public List<StartUpItem> getStartUpData()
        {
            return dataItem.listStartUp;
        }


        public List<QuickMenuItem> getQuickMenuItems()
        {
            return dataItem.listQuickMenu;
        }


        private DataManager()
        {
            createFromCache();
        }

        public List<RemindItem> getRemindData()
        {
            return dataItem.listRemind;
        }




        public List<RemindItem> handleTime(DateTime dateTime)
        {

            List<RemindItem> list = null;
            foreach (RemindItem item in dataItem.listRemind)
            {
                if (item.isTimeOK(dateTime))
                {
                    if (list == null)
                    {
                        list = new List<RemindItem>();
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public const int DAY = 0;
        public const int WEEK = 1;
        public const int MONTH = 2;
        public const int YEAR = 3;
        public const int HOUR = 10;
        public const int ONCE = 99;
        public const int USER_DEFINE = 100;//自定义

        private void createFromCache()
        {
            string text = IniUtil.getValue(Constants.APP_CONFIG, null);
            LogUtil.Print(text);
            try
            {
                dataItem = Utils.parseObject<DataItem>(text);



                foreach (var vv in dataItem.listRemind)
                {
                    if (vv.periodType >= 0) {
                        switch (vv.periodType) {
                            case DAY:
                                vv._hour = vv.hour+"" ;
                                vv._min = vv.minute + "";
                                break;
                            case WEEK:
                                vv._week = vv.week + "";
                                vv._hour = vv.hour + "";
                                vv._min = vv.minute + "";
                                break;
                            case MONTH:
                                vv._day = vv._day + "";
                                vv._hour = vv.hour + "";
                                vv._min = vv.minute + "";
                                break;
                            case YEAR:
                                vv._month = vv.month + "";
                                vv._day = vv._day + "";
                                vv._hour = vv.hour + "";
                                vv._min = vv.minute + "";
                                break;
                            case HOUR:
                                vv._min = vv.minute + "";
                                break;
                            case ONCE:
                                vv._year = vv.year + "";
                                vv._month = vv.month + "";
                                vv._day = vv._day + "";
                                vv._hour = vv.hour + "";
                                vv._min = vv.minute + "";
                                break;
                        }
                        vv.year = vv.month = vv.week = vv.day = vv.minute = vv.day = 0;
                        vv.periodType = -1;
                        isChanged = true;
                    }
                    vv.buildInfos();
                }
            }
            catch (Exception e)
            {
                LogUtil.Print("ttttt" + e.ToString());
            }
            if (dataItem == null)
            {
                dataItem = new DataItem();
                dataItem.defaultConfig();
            }
            dataItem.checkNotNull();
            string uiText = IniUtil.getValue(Constants.APP_UI_CONFIG, null);

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


        public void saveAll()
        {

            isChanged = false;
            IniUtil.setValue(Constants.APP_CONFIG, Utils.toJSONString(dataItem));
        }


        public void saveUiItem()
        {
            IniUtil.setValue(Constants.APP_UI_CONFIG, Utils.toJSONString(uiItem));
        }


        public void saveIfChanged()
        {

            if (isChanged)
            {
                saveAll();
            }

        }


    }

    public class BaseItem
    {
        public string createTime = DateTime.Now.ToString();//创建时间
        public bool isEnable = true;//是否可用

        public string getEnableString()
        {
            return Utils.boolean2ShowString(isEnable);
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



    public class StartUpItem : BaseItem
    {
        public string path;
        public string appName;


        public string getAppName()
        {
            return appName;
        }

    }

    public class QuickMenuItem : BaseItem
    {
        public string name;
        public string action;
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

    public class WxSendHelper
    {

        public const string EXTRA_FUN_WEATHER = "weather";
        public const string EXTRA_FUN_NEWS = "news";


        private string hookUrl;
        private string cmd;

        private string extra;

        private string[] cmdArray;


        public WxSendHelper(string hookUrl, string extra)
        {
            this.hookUrl = hookUrl;

            this.extra = extra;

            cmdArray = parseExtraData(extra);

            if (cmdArray != null)
            {
                this.cmd = cmdArray[1];
            }

        }


        public string getHookUrl()
        {
            return hookUrl;
        }

        public string getExtra()
        {
            return extra;
        }


        public string[] parseExtraData(string text)
        {
            //":fun,weather,{0:d},{1}"
            if (string.IsNullOrEmpty(text) || !text.StartsWith(":fun"))
            {
                return null;
            }
            return text.Split(',');
        }


        public static string getCommonExtra(string cmd, string extra)
        {

            return string.Format(":fun,{0},{1}", cmd, extra);
        }


        //是否是普通消息
        public bool isNormalMsg()
        {
            return cmdArray == null;
        }




        public bool isWeather()
        {
            return EXTRA_FUN_WEATHER.Equals(cmd);
        }

        public bool isNews()
        {
            return EXTRA_FUN_NEWS.Equals(cmd);
        }


        public int getExtraAsInt(int index)
        {
            return NumberUtil.convertToInt(getExtra(index));
        }

        public string getExtra(int index)
        {
            if (index + 2 >= cmdArray.Length)
            {
                return "";
            }
            return cmdArray[index + 2];
        }



    }


    public class RemindItem : BaseItem
    {



        public int taskType = TaskType.REMIND;





        public string content;//提醒内容
        public string extra;//参数
        public string extra2;//参数2

        public RemindItem()
        {

        }

        //tobedelete
        public int periodType;
        public int hour;//小时 0-23
        public int minute;//分钟 0-59
        public int week;//星期几  Sunday = 0,         Saturday = 6
        public int day;//第几天提醒 1-31
        public int month;//第几月提醒 1-12
        public int year;//仅提醒一次的年
        //tobedelete

        public string _year;
        public string _month;
        public string _week;
        public string _day;
        public string _hour;
        public string _min;


        public string getDateInfo()
        {

            StringBuilder builder = new StringBuilder();
            if (!Utils.isTextEmpty(_year))
            {
                builder.Append(string.Format("{0}年", _year));
            }
            if (!Utils.isTextEmpty(_month))
            {
                builder.Append(string.Format("{0}月", _month));
            }
            if (!Utils.isTextEmpty(_week))
            {
                builder.Append(string.Format("周{0} ", _week));
            }
            if (!Utils.isTextEmpty(_day))
            {
                builder.Append(string.Format("{0}日", _day));
            }
            if (!Utils.isTextEmpty(_hour))
            {
                builder.Append(string.Format("{0}时", _hour));
            }
            if (!Utils.isTextEmpty(_min))
            {
                builder.Append(string.Format("{0}分", _min));
            }
            return builder.ToString();
        }


        [Newtonsoft.Json.JsonIgnore]
        public List<int> mYear;
        [Newtonsoft.Json.JsonIgnore]
        public List<int> mMonth;
        [Newtonsoft.Json.JsonIgnore]
        public List<int> mDay;
        [Newtonsoft.Json.JsonIgnore]
        public List<int> mWeek;
        [Newtonsoft.Json.JsonIgnore]
        public List<int> mHour;

        [Newtonsoft.Json.JsonIgnore]
        public List<int> mMin;



        public void buildInfos()
        {
            mYear = Utils.parseList(_year);
            mMonth = Utils.parseList(_month);
            mDay = Utils.parseList(_day);
            mWeek = Utils.parseList(_week);
            mHour = Utils.parseList(_hour);
            mMin = Utils.parseList(_min);

     
        }




        public string getRemindTypeString()
        {
            return TaskType.type2String(taskType);
        }






        public bool isTimeOK(DateTime dateTime)
        {
            if (!isEnable)
            {
                return false;
            }
            if (mYear.Count != 0)
            {
                if (!mYear.Contains(dateTime.Year))
                {
                    return false;
                }
            }
            if (mMonth.Count != 0)
            {
                if (!mMonth.Contains(dateTime.Month))
                {
                    return false;
                }
            }
            if (mDay.Count != 0)
            {
                //   //1 和 31 之间的一个值。
                if (!mDay.Contains(dateTime.Day))
                {
                    return false;
                }
            }
            if (mWeek.Count != 0)
            {
                //        //Sunday = 0 Saturday = 6
                if (!mWeek.Contains((int)dateTime.DayOfWeek))
                {
                    return false;
                }

            }
            if (mHour.Count != 0)
            {
                if (!mHour.Contains(dateTime.Hour))
                {
                    return false;
                }
            }
            if (mMin.Count != 0)
            {
                if (!mMin.Contains(dateTime.Minute))
                {
                    return false;
                }
            }
            return true;

            //bool result = false;
            //switch (periodType) {
            //    case RemindType.DAY:
            //        result = isHourMinuteSame(dateTime);
            //        break;
            //    case RemindType.WEEK:
            //        int week = (int)dateTime.DayOfWeek;
            //        result =this.week== week && isHourMinuteSame(dateTime);
            //        break;
            //    case RemindType.MONTH:
            //        //1 和 31 之间的一个值。
            //        result = this.day == dateTime.Day && isHourMinuteSame(dateTime);
            //        break;
            //    case RemindType.YEAR:
            //        result = this.month==dateTime.Month && this.day == dateTime.Day && isHourMinuteSame(dateTime);
            //        break;
            //    case RemindType.HOUR:
            //        result = minute== dateTime.Minute;
            //        break;
            //    case RemindType.ONCE:
            //        result =this.year== dateTime.Year&& this.month == dateTime.Month && this.day == dateTime.Day && isHourMinuteSame(dateTime);
            //        break;
            //}
            //return result;
        }



        public string getShowTime()
        {


            //string info = null;

            //info = string.Format("{0}-{1}-{2} {3}:{4} 周{5}", _year, _month, _day, _hour, _min,_week);

            //string.Format("整数{0:D2},小数｛1:F2｝,16进0x{2:X2}",2,3,4);
            return getDateInfo();
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
                    WxSendHelper helper = new WxSendHelper(extra, extra2);
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
                    else if (helper.isNews())
                    {
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

    public static class TaskType
    {
        public const int REMIND = 0;//提醒
        public const int SHUT_DONW = 1;//关机
        public const int OPEN_EXE = 2;//打开程序

        public const int WX_SEND_MSG = 3;//发送消息






        public static Dictionary<int, string> map = new Dictionary<int, string>();

        public static List<int> listType = new List<int>();

        static TaskType()
        {
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


}
