using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 邮件群发
{
    public partial class Form1 : Form
    {
        MailObject mail;
        public Form1()
        {
            InitializeComponent();

            mail = new MailObject("smtp.daum.net", 465, "sms2581", "skfmti4835", "测试邮件", "sms2581@hanmail.net", 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            mail.Send();
        }
    }
}
