using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalClockPackge
{
   public class GupiaoInfo
    {

        public const string URL = "https://www.legulegu.com/stockdata/marketcap-gdp";


        public static string toSendString(string data) {

            int index = data.IndexOf("data-description");

            WxRobotForm.MarkDownItem mitem = new WxRobotForm.MarkDownItem();

            StringBuilder builder = new StringBuilder();
            builder.Append("股市信息\n");
            if (index != -1)
            {
                //#<
                string temp = data.Substring(index);
                int start = temp.IndexOf('>') + 1;
                int len = temp.IndexOf('<') - start;
                string info = temp.Substring(start, len);
                builder.Append(info);
                builder.Append(string.Format(" [查看]({0})\n", URL));
                builder.Append("巴菲特指标简介--“巴菲特指标”的计算基于美国股市的市值与衡量国民经济发展状况的国民生产总值(GNP)，巴菲特认为，若两者之间的比率处于70 % 至80 % 的区间之内，这时买进股票就会有不错的收益。但如果在这个比例偏高时买进股票，就等于在“玩火”。");

  
                LogUtil.Print(info);
            }
            else {
                builder.Append("[出错啦~请联系开发人员抢修]");
            }
            mitem.markdown.content = builder.ToString();
            return Utils.toJSONString(mitem);
        }
    }
}
