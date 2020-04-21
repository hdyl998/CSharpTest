using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DigitalClockPackge.WxRobotForm;

namespace DigitalClockPackge
{
   public class News
    {


        public const string URL = "http://v.juhe.cn/toutiao/index?type=top&key=3dc86b09a2ee2477a5baa80ee70fcdf5";


        public class NewsItem
        {
            public int error_code;
            public String reason;
            public ResultItem result;
        public  class ResultItem
        {
            public String stat;
            public List<DataItem> data;
      
          }
            public class DataItem
            {
                public String author_name;
                public String category;
                public String date;
                public String thumbnail_pic_s;
                public String thumbnail_pic_s02;
                public String thumbnail_pic_s03;
                public String title;
                public String uniquekey;
                public String url;
            }

            public override string ToString()
            {

                StringBuilder builder = new StringBuilder("新闻头条");
                builder.Append("\n\n");
                int count = 1;

                foreach (DataItem obj in result.data) {

                    if (obj.author_name.Contains("网") || obj.author_name.Contains("新闻")) {
                        // 1.[新闻](http://wwww)
                        builder.Append(count);
                        builder.Append(".");
                        builder.Append(obj.title);
                        builder.Append(string.Format(" [查看]({0})", obj.url));
                        builder.Append("\n");
                        count++;

                        if (count == 11)
                        {
                            break;
                        }
                    }
                }

                return builder.ToString();
            }

            public string toSendString(int index) {
                object obj=null;

                switch (index) {
                    case 0:
                        MarkDownItem item = new MarkDownItem();
                        obj = item;

                        item.markdown.content = ToString();
                        break;
                    case 1:
                        PicTextItem item2 = new PicTextItem();
                        obj = item2;

 


                        List<DataItem> listAll = new List<DataItem>();
                        result.data.ForEach((aa)=> {
                            if (aa.author_name.Contains("网") || aa.author_name.Contains("新闻"))
                            {
                                listAll.Add(aa);
                            }
                        });
                        WxRobotForm.NewsItem news = new WxRobotForm.NewsItem();

                        DataItem dateItem= listAll[new Random().Next(listAll.Count)];

                        news.title = dateItem.title;
                        news.description = "新闻头条";
                        news.url = dateItem.url;
                        news.picurl = dateItem.thumbnail_pic_s;

                        item2.news.articles.Add(news);
                        break;
                }
                return Utils.toJSONString(obj);

            }
        }
    }
}
