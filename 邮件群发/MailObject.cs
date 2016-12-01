using System;
using System.Collections.Generic;
using System.Text;
using ComponentPro.Net;
using ComponentPro.Net.Mail;
using System.Linq;

namespace 邮件群发
{
    public class MailObject
    {
        Smtp client = new Smtp();
        MailMessage mail = new MailMessage();
        int maxToCount = 0;
        int index = 1;
        int maxSendCount = 0;
        string userName, passWord;
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
        public MailObject(string server, int port, string userName, string passWord, string subject, string from, int maxToCount, int maxSendCount)
        {
            this.maxToCount = maxToCount;
            client.Connect(server, port, SslSecurityMode.Implicit);
            mail.Subject = subject;
            this.userName = userName;
            this.passWord = passWord;
            this.maxSendCount = maxSendCount;
            mail.From = from;
        }

        public void Send()
        {
            string to = GetRecipientAddresses();            

            while(!string.IsNullOrEmpty(to) && (maxSendCount - result.Count) >= 0)
            {
                mail.To = to;
                result.Mail = mail.From.ToString();

                try
                {
                    //if (!client.IsAuthenticated)
                    //    client.Authenticate(userName, passWord);
                    //client.Send(mail);
                    System.Threading.Thread.Sleep(500);
                    result.Succeed = true;
                    result.Message = "";
                }
                catch(Exception ex)
                {
                    result.Succeed = false;
                    result.Message = ex.Message;
                    //client.Disconnect();
                }
                finally
                {
                    index++;
                    OnSend(result);
                    to = GetRecipientAddresses();
                }
            }
            
            //client.Disconnect();
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
            var to = dal.GetMailToList(maxToCount, index);
            result.Count += to.Count;
            return string.Join(";", to.Select(a => a.Mail).ToArray());
            //return "sms2581@hanmail.net";
        }
    }
}
