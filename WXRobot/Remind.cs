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

        public RemindType remindType= RemindType.DAY;//提醒周期

        public bool isEnable = true;//是否可用


        public string content= "提醒内容";//提醒内容

        public long createTime;//创建时间


        public string getShowTime() {
            return string.Format("%2d:%2d",hour,minute);
        }
    }


    public enum RemindType {
       DAY=0,WEEK=1,MONTH=2,YEAR=3,HOUR=10,ONCE=99
    }
}
