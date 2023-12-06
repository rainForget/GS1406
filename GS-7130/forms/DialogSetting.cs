using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS_7130.Bean;

namespace GS_7130.forms
{
    public partial class DialogSetting : Form
    {
        SettingBean settingBean, settingBean1;
        public SerialPort SerialPort1, SerialPort2;
        string softVersion;
        Dictionary<string, SettingBean> settings = new Dictionary<string, SettingBean>();
        internal DialogSetting(SettingBean set, SerialPort serialPort)
        {
            InitializeComponent();
            this.settingBean1 = new SettingBean();
            this.settingBean = set;
            this.SerialPort1 = serialPort;
            checkStatue();
            try
            {
                string[] Ports = SerialPort.GetPortNames();
                for (int i = 0; i < Ports.Length; i++)
                {
                    string s = Ports[i].ToUpper();
                    Regex reg = new Regex("[^COM\\d]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    s = reg.Replace(s, "");

                    PortList.Items.Add(s);
                }
                if (Ports.Length > 1)
                {
                    PortList.SelectedIndex = 1;
                }
                else
                {
                    PortList.SelectedIndex = 0;
                }
                PortList.Text = PortList.SelectedItem.ToString();
                if (!SerialPort1.PortName.Equals(PortList.Text))
                {
                    PortList.SelectedIndex = PortList.Items.IndexOf(SerialPort1.PortName);
                }
                else
                {
                    SerialPort2 = SerialPort1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("端口异常");
            }
            textBoxPwd.Text = set.PassWard;
        }

        public void checkStatue()
        {
            checkBoxSetSN.Checked = settingBean.IsScanSN;
            textBoxVersion.Text = settingBean.SoftVersion;
            textBoxPwd.Text = settingBean.PassWard;
            textBoxSKU.Text = settingBean.ProductId;
            settingBean1 = settingBean;
        }

        internal SerialPort GetSettingResult()
        {
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            if (settings.ContainsKey(settingBean1.SoftVersion))
            {
                //如果有清掉
                settings.Remove(settingBean1.SoftVersion);
            }
            settings.Add(settingBean1.SoftVersion, settingBean1);
            bf.Serialize(fs, settings);//new  {Name = user.username, Password  = user.password}
            fs.Close();
            return SerialPort2;
        }

        private void checkBoxSetSN_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsScanSN = checkBoxSetSN.Checked;
        }

        private void textBoxVersion_Leave(object sender, EventArgs e)
        {
            if (textBoxVersion.Text.Length > 2 && textBoxVersion.Text.Contains("."))
            {
                settingBean1.SoftVersion = textBoxVersion.Text;
            }
            else
            {
                textBoxVersion.Text = softVersion;
            }
        }

        private void PortList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!PortList.Text.Equals(SerialPort1.PortName))
            {
                SerialPort1.Close();
                SerialPort2 = new SerialPort();
                SerialPort2.PortName = PortList.Text.ToString(); ; // 端口号
                SerialPort2.Encoding = Encoding.GetEncoding("UTF-8");
                SerialPort2.BaudRate = 921600; // 写死  串口通信的波特率
            }
            else
            {
                SerialPort2 = SerialPort1;
            }
            settingBean1.PortName = PortList.Text.ToString();
        }

        private void textBoxPwd_Leave(object sender, EventArgs e)
        {
            settingBean1.PassWard = textBoxPwd.Text;
        }

        private void textBoxSKU_Leave(object sender, EventArgs e)
        {
            if (textBoxSKU.Text.Length == 10)
            {
                settingBean1.ProductId = textBoxSKU.Text;
            }
            else
            {
                MessageBox.Show("请输入正确SKU");
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SerialPort2.IsOpen)
                {
                    SerialPort2.Open();
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                SerialPort2 = SerialPort1;
            }
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
