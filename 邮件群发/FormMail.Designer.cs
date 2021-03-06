﻿namespace 邮件群发
{
    partial class FormMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportFrom = new System.Windows.Forms.Button();
            this.btnImportTo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSendMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colToCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtMaxToCount = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAddImg = new System.Windows.Forms.Button();
            this.lblImg = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThread = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(639, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "收件人数量:";
            // 
            // btnImportFrom
            // 
            this.btnImportFrom.Location = new System.Drawing.Point(653, 106);
            this.btnImportFrom.Name = "btnImportFrom";
            this.btnImportFrom.Size = new System.Drawing.Size(75, 23);
            this.btnImportFrom.TabIndex = 2;
            this.btnImportFrom.Text = "导入发件人";
            this.btnImportFrom.UseVisualStyleBackColor = true;
            this.btnImportFrom.Click += new System.EventHandler(this.btnImportFrom_Click);
            // 
            // btnImportTo
            // 
            this.btnImportTo.Location = new System.Drawing.Point(750, 106);
            this.btnImportTo.Name = "btnImportTo";
            this.btnImportTo.Size = new System.Drawing.Size(75, 23);
            this.btnImportTo.TabIndex = 3;
            this.btnImportTo.Text = "导入收件人";
            this.btnImportTo.UseVisualStyleBackColor = true;
            this.btnImportTo.Click += new System.EventHandler(this.btnImportTo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSendMail,
            this.colPress,
            this.colMessage,
            this.colToCount});
            this.dataGridView1.DataSource = this.sendDataBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(622, 642);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colSendMail
            // 
            this.colSendMail.DataPropertyName = "SendMail";
            this.colSendMail.HeaderText = "发件箱";
            this.colSendMail.Name = "colSendMail";
            this.colSendMail.ReadOnly = true;
            this.colSendMail.Width = 150;
            // 
            // colPress
            // 
            this.colPress.DataPropertyName = "Press";
            this.colPress.HeaderText = "进度(已发/总数)";
            this.colPress.Name = "colPress";
            this.colPress.ReadOnly = true;
            this.colPress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPress.Width = 120;
            // 
            // colMessage
            // 
            this.colMessage.DataPropertyName = "Message";
            this.colMessage.HeaderText = "消息";
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            this.colMessage.Width = 300;
            // 
            // colToCount
            // 
            this.colToCount.DataPropertyName = "ToCount";
            this.colToCount.HeaderText = "ToCount";
            this.colToCount.Name = "colToCount";
            this.colToCount.ReadOnly = true;
            this.colToCount.Visible = false;
            // 
            // sendDataBindingSource
            // 
            this.sendDataBindingSource.DataSource = typeof(邮件群发.SendData);
            // 
            // txtMaxToCount
            // 
            this.txtMaxToCount.Location = new System.Drawing.Point(716, 169);
            this.txtMaxToCount.Name = "txtMaxToCount";
            this.txtMaxToCount.Size = new System.Drawing.Size(100, 21);
            this.txtMaxToCount.TabIndex = 5;
            this.txtMaxToCount.Text = "100";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(847, 105);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "发送邮件";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAddImg
            // 
            this.btnAddImg.Location = new System.Drawing.Point(635, 244);
            this.btnAddImg.Name = "btnAddImg";
            this.btnAddImg.Size = new System.Drawing.Size(75, 23);
            this.btnAddImg.TabIndex = 7;
            this.btnAddImg.Text = "添加图片";
            this.btnAddImg.UseVisualStyleBackColor = true;
            this.btnAddImg.Click += new System.EventHandler(this.btnAddImg_Click);
            // 
            // lblImg
            // 
            this.lblImg.AutoSize = true;
            this.lblImg.Location = new System.Drawing.Point(735, 293);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(0, 12);
            this.lblImg.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(632, 273);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 373);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(716, 198);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(216, 21);
            this.txtSubject.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(651, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "邮件主题:";
            // 
            // txtThread
            // 
            this.txtThread.Location = new System.Drawing.Point(716, 139);
            this.txtThread.Name = "txtThread";
            this.txtThread.Size = new System.Drawing.Size(100, 21);
            this.txtThread.TabIndex = 16;
            this.txtThread.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(651, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "线程数量:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(827, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "建议20个以内";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(651, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "发送前请检查发件箱是否开启了POP3的发送方式";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(748, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "清空收件人";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(651, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "清空发件人";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(651, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "发送服务器地址和端口可以在邮箱的设置中查找";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(795, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "将会清空发送记录和收件人";
            // 
            // FormMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 651);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtThread);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblImg);
            this.Controls.Add(this.btnAddImg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMaxToCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnImportTo);
            this.Controls.Add(this.btnImportFrom);
            this.Controls.Add(this.label1);
            this.Name = "FormMail";
            this.Text = "发送邮件";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportFrom;
        private System.Windows.Forms.Button btnImportTo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMaxToCount;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAddImg;
        private System.Windows.Forms.Label lblImg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource sendDataBindingSource;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThread;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSendMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPress;
        private System.Windows.Forms.DataGridViewLinkColumn colMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToCount;
    }
}