using System;
using System.Collections.Generic;
using System.Text;
using ComponentPro.Net;
using ComponentPro.Net.Mail;

namespace 邮件群发
{
    public class MailObject
    {
        Smtp client = new Smtp();
        MailMessage mail = new MailMessage();
        int maxToCount = 0;
        int index = 1;
        string userName, passWord;

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
        public MailObject(string server, int port, string userName, string passWord, string subject, string from, int maxToCount)
        {
            this.maxToCount = maxToCount;
            client.Connect(server, port, SslSecurityMode.Implicit);
            mail.Subject = subject;
            this.userName = userName;
            this.passWord = passWord;
            mail.From = from;
        }

        public void Send()
        {
            string to = GetRecipientAddresses();
            SendResult result = new SendResult();

            while(!string.IsNullOrEmpty(to))
            {
                mail.To = to;

                try
                {
                    if (!client.IsAuthenticated)
                        client.Authenticate(userName, passWord);
                    client.Send(mail);
                    result.Succeed = true;
                    result.Message = "";
                    index = index + maxToCount;
                    to = "";// GetRecipientAddresses();
                }
                catch(Exception ex)
                {
                    result.Succeed = false;
                    result.Message = ex.Message;
                    client.Disconnect();
                }
            }
            //client.Disconnect();
        }

        /// <summary>
        /// 获取收件人地址
        /// </summary>
        /// <returns></returns>
        public string GetRecipientAddresses()
        {
            return "sms2581@hanmail.net";
        }
    }
}
