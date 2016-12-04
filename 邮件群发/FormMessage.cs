using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 邮件群发
{
    public partial class FormMessage : Form
    {
        public FormMessage(string message)
        {
            InitializeComponent();

            textBox1.Text = message;
        }
    }
}
