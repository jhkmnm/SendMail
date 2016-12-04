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
        DAL dal = new DAL();
        ExcelHelper excel;
        int threadCount = 10;
        ThreadManage thm;

        public FormMail()
        {
            InitializeComponent();
            GetSendList();
        }

        private void btnImportFrom_Click(object sender, EventArgs e)
        {
            if (excel == null)
                excel = ExcelHelper.GetInstance();

            var error = new List<ErrorVO>();
            var imports = excel.Import("SendMan", ref error);
            DataVerifier dv = new DataVerifier();

            dv.Check(excel.Status == -1, excel.ReturnMessage ?? string.Empty);

            if (dv.Pass)
            {
                if (error.Count > 0)
                {
                    new FormError(error).ShowDialog();
                }

                if (imports.Count > 0)
                {
                    List<MailFrom> fromList = new List<MailFrom>();
                    imports.ForEach(item =>
                    {
                        var server = item["服务器"].ColumnVaue;
                        var port = item["端口"].ColumnVaue.ToInt32();
                        var username = item["用户名"].ColumnVaue;
                        var password = item["密码"].ColumnVaue;
                        var mail = item["发件箱"].ColumnVaue;

                        fromList.Add(new MailFrom { Server = server, Port = port, UserName = username, PassWord = password, Mail = mail });
                    });

                    dv.Check(dal.AddMailFrom(fromList) == 0, "导入失败");
                }
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

            dv.Check(excel.Status == -1, excel.ReturnMessage ?? string.Empty);

            if (dv.Pass)
            {
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
                pictureBox1.ImageLocation = file.FileName;
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

        private int GetAvg(int total, int count)
        {
            return (int)Math.Ceiling(total / (count * 1.0));
        }        

        private void btnSend_Click(object sender, EventArgs e)
        {
            string subject = txtSubject.Text;
            int tocount = txtMaxToCount.Text.ToInt32(100);    //单次发送数量
            threadCount = txtThread.Text.ToInt32(10);

            DataVerifier dv = new DataVerifier();
            dv.Check(string.IsNullOrWhiteSpace(lblImg.Text), "请上传图片");
            if (dv.Pass)
            {
                var data = (List<SendData>)dataGridView1.DataSource;

                dv.Check(data.Count == 0, "请先导入发件人");
                dv.CheckIfBeforePass(!data.Any(a => a.ToCount > 0), "请先导入收件人");

                if (dv.Pass)
                {
                    thm = new ThreadManage(threadCount, mail_SendResult, subject, tocount, lblImg.Text);

                    thm.AddData(data.Where(a => a.ToCount > 0).ToList());
                    btnSend.Enabled = false;

                    thm.Start();
                    btnSend.Text = "开始发送";
                }
            }
            dv.ShowMsgIfFailed();
        }

        void mail_SendResult(object sender, SendResultEventArgs e)
        {
            if (e.Message == "完成")
            {
                thm.CallBackThread();                
            }

            this.Invoke(new Action(() =>
            {
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
                row.Cells[colMessage.Name].Value = string.Format("{0}{1}{2}", row.Cells[colMessage.Name].Value, Environment.NewLine, e.Message);

                if (e.Message == "完成" && thm.num == 0)
                {
                    btnSend.Enabled = true;
                    btnSend.Text = "发送邮件";
                }
            }));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex] == colMessage)
            {
                var msg = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                new FormMessage(msg).ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dal.DelMailFromAll();
            GetSendList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.DelMailToAll();
            GetSendList();
        }
    }

    public class SendData
    {
        public string SendMail { get; set; }
        public int ToCount { get; set; }
        public MailFrom From { get; set; }
        
        public string Message { get; set; }

        public string Press { get; set; }
    }

    public class ThreadInfo
    {
        /// <summary>
        /// 运行状态 1正在运行，0未运行，-1运行完成
        /// </summary>
        public int Status { get; set; }

        public Thread th { get; set; }
    }

    public class ThreadManage
    {
        List<ThreadInfo> thList = new List<ThreadInfo>();
        int maxNum = 0;
        public int num = 0;
        static object obj = new object();
        private Queue<SendData> SendQueue = new Queue<SendData>();
        EventHandler<SendResultEventArgs> mail_SendResult;
        string subject;
        int tocount;
        string imgPath;

        public ThreadManage(int maxnum, EventHandler<SendResultEventArgs> mail_SendResult, string subject, int tocount, string imgPath)
        {
            maxNum = maxnum;
            this.mail_SendResult = mail_SendResult;
            this.subject = subject;
            this.tocount = tocount;
            this.imgPath = imgPath;
        }

        public void AddData(List<SendData> data)
        {
            data.ForEach(item => {
                if (thList.Count < maxNum)
                {
                    MailObject mail = new MailObject(item.From.Server, item.From.Port.Value, item.From.UserName, item.From.PassWord, subject, item.SendMail, tocount, item.ToCount, imgPath);
                    mail.SendResult += mail_SendResult;
                    Thread th = new Thread(mail.Send);
                    th.Name = item.SendMail;
                    AddThread(th);
                }
                else
                {
                    SendQueue.Enqueue(new SendData()
                    {
                        From = item.From,
                        Message = item.Message,
                        Press = item.Press,
                        SendMail = item.SendMail,
                        ToCount = item.ToCount
                    });
                }
            });
        }

        private void AddThread(Thread th)
        {
            thList.Add(new ThreadInfo { Status = 0, th = th });
        }

        public void CallBackThread()
        {
            foreach (var th in thList)
            {
                if (Thread.CurrentThread == th.th)
                {
                    lock (obj)
                    {
                        th.Status = -1;
                        num--;
                        if (SendQueue.Count > 0)
                        {
                            var item = SendQueue.Dequeue();
                            MailObject mail = new MailObject(item.From.Server, item.From.Port.Value, item.From.UserName, item.From.PassWord, subject, item.SendMail, tocount, item.ToCount, imgPath);
                            mail.SendResult += mail_SendResult;
                            Thread thh = new Thread(mail.Send);
                            AddThread(thh);
                        }
                        Start();
                    }
                    break;
                }
            }
        }

        public void Start()
        {
            foreach (var th in thList)
            {
                if (num == maxNum) break;

                if (th.Status == 0 && th.th.ThreadState == ThreadState.Unstarted)
                {
                    th.th.Start();
                    num++;
                }
            }
        }
    }
}
