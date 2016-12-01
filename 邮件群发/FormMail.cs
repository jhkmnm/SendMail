using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Utilities;

namespace 邮件群发
{
    public partial class FormMail : Form
    {
        string[] fromColumns = { "服务器", "端口", "用户名", "密码", "发件箱" };
        DAL dal = new DAL();
        ExcelHelper excel;
        int threadCount = 10;

        public FormMail()
        {
            InitializeComponent();
        }

        private void btnImportFrom_Click(object sender, EventArgs e)
        {
            if (excel == null)
                excel = ExcelHelper.GetInstance();

            var error = new List<ErrorVO>();
            var imports = excel.Import("SendMan", ref error);
            DataVerifier dv = new DataVerifier();

            if(error.Count > 0)
            {
                new FormError(error).ShowDialog();
            }

            if (imports.Count > 0)
            {
                List<MailFrom> fromList = new List<MailFrom>();
                imports.ForEach(item => {
                    var server = item["服务器"].ColumnVaue;
                    var port = item["端口"].ColumnVaue.ToInt32();
                    var username = item["用户名"].ColumnVaue;
                    var password = item["密码"].ColumnVaue;
                    var mail = item["发件箱"].ColumnVaue;

                    fromList.Add(new MailFrom { Server = server, Port = port, UserName = username, PassWord = password, Mail = mail });
                });
                
                dv.Check(dal.AddMailFrom(fromList) == 0, "导入失败");
            }

            dv.ShowMsgIfFailed();

            GetSendList();
        }

        private void btnImportTo_Click(object sender, EventArgs e)
        {
            if (excel == null)
                excel = ExcelHelper.GetInstance();

            var error = new List<ErrorVO>();
            var imports = excel.Import("ToMan", ref error);            
            DataVerifier dv = new DataVerifier();
            if (error.Count > 0)
            {
                new FormError(error).ShowDialog();
            }

            if (imports.Count > 0)
            {
                List<MailTo> toList = new List<MailTo>();
                imports.ForEach(item =>
                {
                    var mail = item["收件人"].ColumnVaue;

                    toList.Add(new MailTo { Mail = mail });

                    if (toList.Count >= 1000)
                    {
                        dv.Check(dal.AddMailTo(toList) == 0, "导入失败");
                        toList.Clear();
                        if (!dv.Pass)
                            return;
                    }
                });

                if (toList.Count > 0)
                    dv.Check(dal.AddMailTo(toList) == 0, "导入失败");
            }            

            dv.ShowMsgIfFailed();

            GetSendList();
        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog { Title = @"添加图片", Filter = @"图像文件|*.jpg;*.png;*.gif;*.bmp;*.jpeg" };
            if(file.ShowDialog() == DialogResult.OK)
            {
                lblImg.Text = file.FileName;
            }
        }

        private void GetSendList()
        {
            var from = dal.GetMailFromList();
            var tocount = dal.MailToCount();
            var fromcount = from.Count;

            List<SendData> data = new List<SendData>();
            from.ForEach(a => {
                var count = GetAvg(tocount, fromcount);
                data.Add(new SendData { 
                    From = a, 
                    ToCount = count, 
                    SendMail = a.Mail, 
                    Press = string.Format("{0}/{1}", 0, count) });
                tocount = tocount - count;
                fromcount = fromcount - 1;
            });
            
            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<MailTo> mailto = new List<MailTo>();
            for(int i=0;i<100000;i++)
            {
                mailto.Add(new MailTo { Mail = "mail" + i.ToString() });
            }

            dal.AddMailTo(mailto);

            GetSendList();
        }

        private int GetAvg(int total, int count)
        {
            return (int)Math.Ceiling(total / (count * 1.0));
        }        

        private void btnSend_Click(object sender, EventArgs e)
        {
            string subject = "";
            int tocount = 3;

            var data = (List<SendData>)dataGridView1.DataSource;

            data.ForEach(item =>
            {
                if (item.ToCount > 0)
                {
                    MailObject mail = new MailObject(item.From.Server, item.From.Port.Value, item.From.UserName, item.From.PassWord, subject, item.SendMail, tocount, item.ToCount);
                    mail.SendResult += mail_SendResult;
                    Thread th = new Thread(mail.Send);
                    th.Start();
                }
            });
        }

        void mail_SendResult(object sender, SendResultEventArgs e)
        {
            this.Invoke(new Action(() => {
                DataGridViewRow row = null;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells[colSendMail.Name].Value.ToString() == e.Mail)
                    {
                        row = r;
                        break;
                    }
                }

                if (row == null)
                    return;

                row.Cells[colPress.Name].Value = string.Format("{0}/{1}", e.Count, row.Cells[colToCount.Name].Value);
                if(!e.Succeed)
                    row.Cells[colMessage.Name].Value = string.Format("{0}{1}{2}", row.Cells[colMessage.Name].Value, Environment.NewLine, e.Message);
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<MailFrom> mailto = new List<MailFrom>();
            for (int i = 0; i < 100; i++)
            {
                mailto.Add(new MailFrom { Server = "smtp.daum.net", Port = 465, UserName = "username", PassWord = "password", Mail = "mail" + i.ToString() });
            }

            dal.AddMailFrom(mailto);
        }
    }

    public class SendData
    {
        public string SendMail { get; set; }
        public int ToCount { get; set; }
        public MailFrom From { get; set; }
        //public int Index { get; set; }
        public string Message { get; set; }

        public string Press { get; set; }
    }
}
