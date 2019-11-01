using DigitalClockPackge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DigitalClockPackge
{
    public delegate void OnSuccess(string data);

    public delegate void OnError(string data);
    public class HttpRequest
    {

        NetBuilder builder;

        public HttpRequest(NetBuilder builder) {
            this.builder = builder;
        }


        public void start() {
            Thread task1 = new Thread(() =>
            {
                try
                {
                    string response;
                    if (builder.isGet)
                    {
                        response = HttpGet(builder.url);
                    }
                    else {
                        response = PostHttpUrl(builder.url, builder.postData);
                    }
                    if (builder.success != null) {
                        if (builder.form != null)
                        {
                            builder.form.Invoke((MethodInvoker)(() =>//子线程中操作UI
                            {
                                builder.success.Invoke(response);
                            }));
                        }
                        else
                        {
                            builder.success.Invoke(response);
                        }
                    }
                }
                catch (Exception e) {
                    if (builder.form != null)
                        builder.form.Invoke((MethodInvoker)(() =>//子线程中操作UI
                    {
                        if (builder.error != null)
                        {
                            builder.error.Invoke(e.Message);
                        }
                        else {
                            MessageBox.Show("网络异常:"+e.Message);
                        }
                    }));
                }
            });
            task1.Start();
        }


        public string HttpGet(string serviceAddress)
        {
          
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "text/html; charset=utf-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string result= myStreamReader.ReadToEnd();
            Utils.Dispose(myStreamReader, myResponseStream, response);
            return result;
        }


        public string PostHttpUrl(string uri, string postData)
        {
            //string url = uri + "?" + postData;
            byte[] data = Encoding.UTF8.GetBytes(postData);
            //处理HttpWebRequest访问https有安全证书的问题（ 请求被中止: 未能创建 SSL/TLS 安全通道。）
            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri); //发送地址                                            
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";//提交方式
            request.ContentLength = data.Length;
            //request.
            request.GetRequestStream().Write(data, 0, data.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//获取响应
            Stream stream = response.GetResponseStream();            //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string result = string.Empty;
            using (StreamReader sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }
            return result; // 返回的数据
        }
    }

    public class NetBuilder
    {

        public string url;


        public string postData;
        public Form form;

        public bool isGet;

        public NetBuilder asGet() {
            isGet = true;
            return this;
        }


        public NetBuilder setPostData(string postData)
        {
            this.postData = postData;
            isGet = false;
            return this;
        }

        public static NetBuilder create(Form form)
        {
            NetBuilder builder = new NetBuilder();
            builder.form = form;
            return builder;
        }

        public NetBuilder setUrl(string url)
        {
            this.url = url;
            return this;
        }
        public OnSuccess success;
        public OnError error;

        public void start(OnSuccess success, OnError error)
        {
            this.success = success;
            this.error = error;

            new HttpRequest(this).start();
        }


        public void start(OnSuccess success)
        {
            start(success, null);
        }

    }


}



