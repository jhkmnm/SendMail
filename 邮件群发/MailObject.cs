using System;
using System.Collections.Generic;
using System.Text;
using ComponentPro.Net;
using ComponentPro.Net.Mail;
using System.Linq;
using System.Drawing;
using System.IO;

namespace 邮件群发
{
    public class MailObject
    {
        Smtp client = new Smtp();
        MailMessage mail = new MailMessage();
        int maxToCount = 0;
        int index = 1;
        int startID = 1;
        int maxSendCount = 0;
        string userName, passWord, server;
        int port;
        DAL dal = new DAL();
        public event EventHandler<SendResultEventArgs> SendResult;
        SendResultEventArgs result = new SendResultEventArgs();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server">邮件服务器</param>
        /// <param name="port">端口</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <param name="subject">主题</param>
        /// <param name="from">发件人</param>
        /// <param name="maxTocount">最大收件人数量</param>
        /// <param name="maxTocount">最大发送数量</param>
        public MailObject(string server, int port, string userName, string passWord, string subject, string from, int maxToCount, int maxSendCount, string imgPath, int startId)
        {
            this.maxToCount = maxToCount;
            this.userName = userName;
            this.passWord = passWord;
            this.maxSendCount = maxSendCount;
            this.server = server;
            this.port = port;
            result.Mail = from;
            this.startID = startId;

            mail.Subject = subject;
            mail.From = from;
            mail.BodyHtml = Img(imgPath);
            mail.Attachments.Add(imgPath);
        }

        private void Init()
        {            
            result.Succeed = true;
            result.Message = string.Format("{1}:第{0}组发送中...", index, DateTime.Now.ToString());
            OnSend(result);
                        
            client.Connect(server, port, SslSecurityMode.Implicit);
            client.Authenticate(userName, passWord);            
        }

        private string Img(string imgfile)
        {
            Bitmap bmp = new Bitmap(imgfile);

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();

            string html = "<BODY style = \"MARGIN: 10px\"><DIV><IMG src=\"data:image/png;base64,{0}\"></IMG></DIV></BODY>";

            return string.Format(html, Convert.ToBase64String(arr));
        }

        public void Send()
        {
            string to = GetRecipientAddresses();

            while(!string.IsNullOrEmpty(to))
            {
                mail.To = to;

                try
                {
                    Init();
                    client.Send(mail);
                    result.Succeed = true;
                    result.Message = string.Format("{2}:第{0}组发送成功{1}", index, Environment.NewLine, DateTime.Now.ToString());
                }
                catch(Exception ex)
                {
                    result.Succeed = false;
                    result.Message = string.Format("{3}:第{0}组发送失败:{1}{2}", index, ex.Message, Environment.NewLine, DateTime.Now.ToString());
                }
                finally
                {
                    client.Disconnect();
                    index++;
                    OnSend(result);
                    to = "";
                    if(maxSendCount - result.Count > 0)
                        to = GetRecipientAddresses();
                }
            }
            result.Succeed = true;
            result.Message = "全部发送完成";
            OnSend(result);
        }

        protected virtual void OnSend(SendResultEventArgs e)
        {
            EventHandler<SendResultEventArgs> handler = SendResult;
            if (handler != null)
            {
                handler(this, e);//触发回调函数
            }
        }

        /// <summary>
        /// 获取收件人地址
        /// </summary>
        /// <returns></returns>
        public string GetRecipientAddresses()
        {
            var count = (maxSendCount - index * maxToCount) > 0 ? maxToCount : (maxSendCount - (index - 1) * maxToCount);

            var to = dal.GetMailToList(maxToCount, index, startID).Take(count).ToList();
            result.Count += to.Count;
            //Console.WriteLine(System.Threading.Thread.CurrentThread.Name +":"+ string.Join(",", to.Select(a => a.ID).ToArray()) + ";Max:"+ maxToCount +";Index:"+index);
            return string.Join(";", to.Select(a => a.Mail).ToArray());
        }
    }
}
