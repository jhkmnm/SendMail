using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using Utilities.ExcelHelper;

namespace 邮件群发
{
    public partial class FormMail : Form
    {
        string[] fromColumns = { "服务器", "端口", "用户名", "密码", "发件箱" };
        DAL dal = new DAL();

        public FormMail()
        {
            InitializeComponent();
        }

        private void btnImportFrom_Click(object sender, EventArgs e)
        {
            var data = ExcelHelper.GetExcelFile();
            DataVerifier dv = new DataVerifier();
            for(int i=0;i<fromColumns.Length;i++)
            {
                dv.Check(data.Columns.Contains(fromColumns[i]), "请按模板进行导入");
                if (!dv.Pass)
                    break;
            }

            if(dv.Pass)
            {
                List<MailFrom> fromList = new List<MailFrom>();
                foreach(DataRow row in data.Rows)
                {
                    var server = row["服务器"].ToString();
                    var port = row["端口"].ToString().ToInt32();
                    var username = row["用户名"].ToString();
                    var password = row["密码"].ToString();
                    var mail = row["发件箱"].ToString();

                    fromList.Add(new MailFrom { Server = server, Port = port, UserName = username, PassWord = password, Mail = mail });
                }

                dv.Check(dal.AddMailFrom(fromList) == 0, "导入失败");
            }

            dv.ShowMsgIfFailed();
        }

        private void btnImportTo_Click(object sender, EventArgs e)
        {
            var data = ExcelHelper.GetExcelFile();
            DataVerifier dv = new DataVerifier();
            dv.Check(data.Columns.Contains("收件人"), "请按模板进行导入");

            if (dv.Pass)
            {
                List<MailTo> toList = new List<MailTo>();
                foreach (DataRow row in data.Rows)
                {
                    var mail = row["收件人"].ToString();

                    toList.Add(new MailTo { Mail = mail });

                    if(toList.Count >= 1000)
                    {
                        dv.Check(dal.AddMailTo(toList) == 0, "导入失败");
                        toList.Clear();
                        if (!dv.Pass)
                            break;
                    }
                }

                if(toList.Count > 0)
                    dv.Check(dal.AddMailTo(toList) == 0, "导入失败");
            }

            dv.ShowMsgIfFailed();
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

            List<SendData> data = new List<SendData>();
            from.ForEach(a => data.Add(new SendData { From = a, ToCount = tocount, SendMail = a.Mail }));

            sendDataBindingSource.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetSendList();
        }
    }

    partial class SendData
    {
        public string SendMail { get; set; }
        public int ToCount { get; set; }
        public int SendIndex { get; set; }
        public MailFrom From { get; set; }
    }
}
