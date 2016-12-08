﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 邮件群发
{
    public class DAL
    {
        #region 服务器
        public int AddServer(Server data)
        {
            if (data.ID == 0)
                return DB.Context.Insert<Server>(data);
            else
                return DB.Context.Update(data);
        }

        public List<Server> GetServers()
        {
            return DB.Context.From<Server>().ToList();
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
