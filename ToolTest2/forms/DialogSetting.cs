using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using ToolTest2.Bean;

namespace ToolTest2.forms
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
            checkBoxGetColor.Checked = settingBean.IsGetDeviceColor;
            checkBoxSetColor.Checked = settingBean.IsSetDeviceColor;
            checkBoxGetHardVersion.Checked = settingBean.IsGetHardVersion;
            checkBoxSetHardVersion.Checked = settingBean.IsSetHardVersion;
            checkBoxGetSoftVersion.Checked = settingBean.IsGetSoftVersion;
            checkBoxGetBattery.Checked = settingBean.IsGetBatteryLevel;
            checkBoxGetSerialNum.Checked = settingBean.IsGetSerialNum;
            checkBoxSetSerialNum.Checked = settingBean.IsSetSerialNum;
            checkBoxEnterDut.Checked = settingBean.IsEnterDutMode;
            checkBoxEnterShip.Checked = settingBean.IsEnterShipMode;
            checkBoxGetMfi.Checked = settingBean.IsGetMfiStatus;
            textBoxVersion.Text = settingBean.SoftVersion;
            softVersion = settingBean.SoftVersion;
            comboBox1.Text = settingBean.Vendor;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(settingBean.Vendor);
            comboBox2.Text = settingBean.Year;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(settingBean.Year);
            comboBox3.Text = settingBean.Week;
            comboBox3.SelectedIndex = comboBox3.Items.IndexOf(settingBean.Week);
            comboBox4.Text = settingBean.Family;
            comboBox4.SelectedIndex = comboBox4.Items.IndexOf(settingBean.Family);
            comboBox5.Text = settingBean.Color;
            comboBox5.SelectedIndex = comboBox5.Items.IndexOf(settingBean.Color);
            textBox1.Text = settingBean.BatteryValue;
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

        private void checkBoxGetColor_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetDeviceColor = checkBoxGetColor.Checked;
        }

        private void checkBoxSetColor_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsSetDeviceColor = checkBoxSetColor.Checked;
        }

        private void checkBoxGetHardVersion_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetHardVersion = checkBoxGetHardVersion.Checked;
        }

        private void checkBoxSetHardVersion_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsSetHardVersion = checkBoxSetHardVersion.Checked;
        }

        private void checkBoxGetSoftVersion_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetSoftVersion = checkBoxGetSoftVersion.Checked;
        }

        private void checkBoxGetBattery_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetBatteryLevel = checkBoxGetBattery.Checked;
        }

        private void checkBoxGetSerialNum_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetSerialNum = checkBoxGetSerialNum.Checked;
        }

        private void checkBoxSetSerialNum_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsSetSerialNum = checkBoxSetSerialNum.Checked;
        }

        private void checkBoxEnterDut_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsEnterDutMode = checkBoxEnterDut.Checked;
        }

        private void checkBoxEnterShip_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsEnterShipMode = checkBoxEnterShip.Checked;
        }

        private void checkBoxGetMfi_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetMfiStatus = checkBoxGetMfi.Checked;
        }

        private void checkBoxGetChannel_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetChannel = checkBoxGetChannel.Checked;
        }

        private void checkBoxResetMode_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsResetMode = checkBoxResetMode.Checked;
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

        private void PortList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!PortList.Text.Equals(SerialPort1.PortName))
            {
                SerialPort1.Close();
                SerialPort2 = new SerialPort();
                SerialPort2.PortName = PortList.Text.ToString(); ; // 端口号
                SerialPort2.Encoding = Encoding.GetEncoding("UTF-8");
                SerialPort2.BaudRate = 921600; // 写死  串口通信的波特率
                //SerialPort2.BaudRate = 115200; // 写死  串口通信的波特率
            }
            else
            {
                SerialPort2 = SerialPort1;
            }
            settingBean1.PortName = PortList.Text.ToString();
        }

        private void textBoxPwd_TextChanged(object sender, EventArgs e)
        {
            settingBean1.PassWard = textBoxPwd.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingBean1.Vendor = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingBean1.Year = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingBean1.Week = comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingBean1.Family = comboBox4.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingBean1.Color = comboBox5.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            settingBean1.BatteryValue = textBox1.Text;
        }

        private void textBoxVersion_TextChanged(object sender, EventArgs e)
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
    }
}
