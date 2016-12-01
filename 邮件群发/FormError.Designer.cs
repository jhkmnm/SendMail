namespace 邮件群发
{
    partial class FormError
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            ComponentPro.Net.Mail.SmtpConfig smtpConfig3 = new ComponentPro.Net.Mail.SmtpConfig();
            this.smtp1 = new ComponentPro.Net.Mail.Smtp(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bsDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.col序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col错误信息 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // smtp1
            // 
            this.smtp1.ClientDomain = "shenkai";
            this.smtp1.Config = smtpConfig3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col序号,
            this.col错误信息});
            this.dataGridView1.DataSource = this.bsDataSource;
            this.dataGridView1.Location = new System.Drawing.Point(2, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(394, 591);
            this.dataGridView1.TabIndex = 0;
            // 
            // col序号
            // 
            this.col序号.DataPropertyName = "序号";
            this.col序号.HeaderText = "序号";
            this.col序号.Name = "col序号";
            this.col序号.ReadOnly = true;
            this.col序号.Width = 60;
            // 
            // col错误信息
            // 
            this.col错误信息.DataPropertyName = "错误信息";
            this.col错误信息.HeaderText = "错误信息";
            this.col错误信息.Name = "col错误信息";
            this.col错误信息.ReadOnly = true;
            this.col错误信息.Width = 300;
            // 
            // FormError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 600);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormError";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentPro.Net.Mail.Smtp smtp1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bsDataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn col序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn col错误信息;

    }
}

