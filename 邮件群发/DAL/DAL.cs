using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 邮件群发
{
    public class DAL
    {
        static object obj = new object();

        #region 发送记录
        public bool ExistsHistory(string mail)
        {
            lock (obj)
            {
                if (GetHistory(mail) == null)
                {
                    AddSendHistory(new SendHistory { Mail = mail });
                    return true;
                }
                return false;
            }
        }

        public int AddSendHistory(SendHistory data)
        {
            return DB.Context.Insert<SendHistory>(data);
        }

        public SendHistory GetHistory(string mail)
        {
            return DB.Context.From<SendHistory>()
                .Where(a => a.Mail == mail)
                .ToFirst();
        }

        public int DelHistory()
        {
            return DB.Context.DeleteAll<SendHistory>();
        }
        #endregion

        #region 收件人
        public int AddMailTo(MailTo data)
        {
            return DB.Context.Insert(data);
        }

        public int AddMailTo(List<MailTo> data)
        {
            return DB.Context.Insert(data);
        }

        public List<MailTo> GetMailToList(int pageSize, int pageIndex, int startId)
        {
            return DB.Context.From<MailTo>()
                .Where(a => a.ID >= startId)
                .Page(pageSize, pageIndex)
                .ToList();
        }

        public MailTo GetMail(string mail)
        {
            return DB.Context.From<MailTo>()
                .Where(a => a.Mail == mail).ToFirst();
        }

        public int MailToCount()
        {
            return DB.Context.From<MailTo>().Count();
        }

        public int DelMailToAll()
        {
            return DB.Context.DeleteAll<MailTo>();
        }
        #endregion

        public int AddMailFrom(MailFrom data)
        {
            return DB.Context.Insert(data);
        }

        public int AddMailFrom(List<MailFrom> data)
        {            
            return DB.Context.Insert(data);
        }

        public int DelMailFromAll()
        {
            return DB.Context.DeleteAll<MailFrom>();
        }

        public List<MailFrom> GetMailFromList()
        {
            return DB.Context.From<MailFrom>()
                .ToList();
        }
    }
}
