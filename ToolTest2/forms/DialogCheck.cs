using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolTest2.Bean;

namespace ToolTest2.forms
{
    public partial class DialogCheck : Form
    {
        SettingBean settingBean;
        public DialogCheck(SettingBean settingBean)
        {
            InitializeComponent();
            this.settingBean = settingBean;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxPWD.Text.Equals(settingBean.PassWard))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("密码错误");
                textBoxPWD.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBoxPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(sender, e);
            }
        }
    }
}
