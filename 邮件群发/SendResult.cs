using System;
using System.Collections.Generic;
using System.Text;

namespace 邮件群发
{
    public class SendResultEventArgs :EventArgs
    {
        public string Mail { get; set; }
        public bool Succeed { get; set; }
        public int Count { get; set; }
        public string Message { get; set; }
    }
}
