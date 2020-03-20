using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalClockPackge
{
    public class Weather
    {

        public const string TYPE_NOW = "now";

        public const string TYPE_FORECAST = "forecast";

        public const string TYPE_LIFESTYLE = "lifestyle";

        public const string baseUrl = "https://free-api.heweather.net/s6/weather/{0}?location={1}&key=67c725dcec21425b87b9afc6566eb093";



        public static string getUrl(string type,string city) {
            return string.Format(baseUrl,type,city);
        }




        public class WealthNowItem
        {
            public List<HeWeather6Item> HeWeather6;



            public string toSendString()
            {

                WxRobotForm.MessageItem item2 = new WxRobotForm.MessageItem();
                item2.text.content = ToString();

                return Utils.toJSONString(item2);
            }


            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
          
                if (HeWeather6.Count > 0)
                {
                    builder.Append("城市");
                    builder.Append(" ");
                    HeWeather6Item item = HeWeather6[0];
                    builder.Append(item.basic.location);
                    builder.Append("\n");
                    if (item.now != null) {
                        builder.Append("--------实时天气--------");
                        builder.Append("\n");
                        builder.Append(item.now.cond_txt);
                        builder.Append(" ");
                        builder.Append(item.now.tmp);
                        builder.Append("℃");
                        builder.Append("\n");
                        builder.Append(item.now.wind_dir);
                        builder.Append(" ");
                        builder.Append(item.now.wind_sc + "级");
                        builder.Append("\n");
                        builder.Append("湿度 " + item.now.hum + "%");
                        builder.Append("\n");
                    }
                    if (item.lifestyle != null) {
                        builder.Append("--------生活指数--------");
                        builder.Append("\n");
                        string key = "comf：舒适度指数、cw：洗车指数、drsg：穿衣指数、flu：感冒指数、sport：运动指数、trav：旅游指数、uv：紫外线指数、air：空气污染扩散条件指数、ac：空调开启指数、ag：过敏指数、gl：太阳镜指数、mu：化妆指数、airc：晾晒指数、ptfc：交通指数、fsh：钓鱼指数、spi：防晒指数";
                        foreach (HeWeather6Item.LifestyleItem lifeItem in item.lifestyle) {
                            int index=key.IndexOf(lifeItem.type);
                            if (index != -1) {
                                int endIndex = index + lifeItem.type.Length + 1;

                               string end = key.Substring(endIndex);
                                int index2 = end.IndexOf("指数");

                                builder.Append(end.Substring(0, index2+2));
                                builder.Append(" ");
                                builder.Append(lifeItem.brf);
                                builder.Append("\n");
                                builder.Append(lifeItem.txt);
                                builder.Append("\n");
                            }
                        }
                    }
                    if (item.daily_forecast != null) {
                        builder.Append("--------未来天气--------");
                        builder.Append("\n");
                        String[] arrs = {"明天","后天","大后天"};
                        int index1 = 0;
                        foreach (HeWeather6Item.Daily_forecastItem fItem in item.daily_forecast) {
                            if(index1< arrs.Length) {
                                builder.Append(arrs[index1]);
                                builder.Append(" ");
                            }
                            builder.Append(fItem.date);
                            index1++;
                            builder.Append("\n");
                            if (fItem.cond_txt_d.Equals(fItem.cond_txt_n))
                            {
                                builder.Append(fItem.cond_txt_d);
                            }
                            else {
                                builder.Append(fItem.cond_txt_d);
                                builder.Append("/");
                                builder.Append(fItem.cond_txt_n);
                            }
                            builder.Append(" ");
                            builder.Append(fItem.tmp_min);
                            builder.Append("~");
                            builder.Append(fItem.tmp_max);
                            builder.Append("℃");
                            builder.Append("\n");
                            builder.Append(fItem.wind_dir);
                            builder.Append(" ");
                            builder.Append(fItem.wind_sc + "级");
                            builder.Append("\n");
                            builder.Append("湿度 " + fItem.hum + "%");
                            builder.Append("\n");
                            if (NumberUtil.convertToFloat(fItem.pcpn) > 0) {
                                builder.Append("降水量 " + fItem.pcpn + " " + "概率 " + fItem.pop + "%");
                                builder.Append("\n");
                            }
                            builder.Append("-----------------------\n");
                        }
                    }
                }
                else {
                    builder.Append("空数据");
                }

      

                return builder.ToString();
            }

        }
        public class HeWeather6Item
        {
            public String status;
            public BasicItem basic;
            public NowItem now;
            public UpdateItem update;

            public List<LifestyleItem> lifestyle;
            public List<Daily_forecastItem> daily_forecast;



            public class BasicItem
            {
                public String admin_area;
                public String cid;
                public String cnty;
                public String lat;
                public String location;
                public String lon;
                public String parent_city;
                public String tz;
            }
            public class NowItem
            {
                public String cloud;
                public String cond_code;
                public String cond_txt;
                public String fl;
                public String hum;
                public String pcpn;
                public String pres;
                public String tmp;
                public String vis;
                public String wind_deg;
                public String wind_dir;
                public String wind_sc;
                public String wind_spd;
            }
            public class UpdateItem
            {
                public String loc;
                public String utc;
            }

            public  class Daily_forecastItem 
            {
            public String cond_code_d;
            public String cond_code_n;
            public String cond_txt_d;
            public String cond_txt_n;
            public String date;
            public String hum;
            public String mr;
            public String ms;
            public String pcpn;
            public String pop;
            public String pres;
            public String sr;
            public String ss;
            public String tmp_max;
            public String tmp_min;
            public String uv_index;
            public String vis;
            public String wind_deg;
            public String wind_dir;
            public String wind_sc;
            public String wind_spd;
        }

            public class LifestyleItem
            {
            public String brf;
            public String txt;
            public String type;
        }

    }
}
}
