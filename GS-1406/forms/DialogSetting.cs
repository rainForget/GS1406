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
        string softVersion, hardVersion;
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
            checkBoxEnterShip.Checked = settingBean.IsEnterShipMode;
            checkBoxGetMfi.Checked = settingBean.IsGetMfiStatus;
            checkBoxGetCaseSN.Checked = settingBean.IsGetCaseSerialNum;
            checkBoxSetCaseSN.Checked = settingBean.IsSetCaseSerialNum;
            checkBoxGetProductId.Checked = settingBean.IsGetProductId;
            checkBoxSetProductId.Checked = settingBean.IsSetProductId;
            checkBoxResetMode.Checked = settingBean.IsResetMode;
            textBoxVersion.Text = settingBean.SoftVersion;
            textBoxHardVersion.Text = settingBean.HardVersion;
            softVersion = settingBean.SoftVersion;
            textBoxBatteryMin.Text = settingBean.BatteryValueMin;
            textBoxBatteryMax.Text = settingBean.BatteryValueMax;
            textBox2.Text = settingBean.ProductId;
            hardVersion = settingBean.HardVersion;
            comboBoxColor.SelectedIndex = comboBoxColor.Items.IndexOf(settingBean.Color);
            rbSingle.Checked = !settingBean.IsDouble;
            rbDouble.Checked = settingBean.IsDouble;


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

        private void checkBoxEnterShip_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsEnterShipMode = checkBoxEnterShip.Checked;
        }

        private void checkBoxGetMfi_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetMfiStatus = checkBoxGetMfi.Checked;
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

        private void checkBoxGetCaseSN_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetCaseSerialNum = checkBoxGetCaseSN.Checked;
        }

        private void checkBoxSetCaseSN_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsSetCaseSerialNum = checkBoxSetCaseSN.Checked;
        }

        private void checkBoxGetProductId_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsGetProductId = checkBoxGetProductId.Checked;
        }

        private void checkBoxSetProductId_CheckedChanged(object sender, EventArgs e)
        {
            settingBean1.IsSetProductId = checkBoxSetProductId.Checked;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            settingBean1.ProductId = textBox2.Text;
        }

        private void textBoxHardVersion_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingBean1.Color = comboBoxColor.Text.ToString();
        }

        private void rbDouble_Click(object sender, EventArgs e)
        {
            if (rbDouble.Checked)
            {
                rbDouble.Checked = true;
                settingBean1.IsDouble = true;
            }
        }

        private void rbSingle_Click(object sender, EventArgs e)
        {
            if (rbSingle.Checked)
            {
                rbSingle.Checked = true;
                settingBean1.IsDouble = false;
            }
        }

        private void textBoxHardVersion_Leave(object sender, EventArgs e)
        {
            if (textBoxHardVersion.Text.Length > 2 && textBoxHardVersion.Text.Contains("."))
            {
                settingBean1.HardVersion = textBoxHardVersion.Text;
            }
            else
            {
                textBoxHardVersion.Text = hardVersion;
            }
        }

        private void textBoxBatteryMin_TextChanged(object sender, EventArgs e)
        {
            settingBean1.BatteryValueMin = textBoxBatteryMin.Text;
        }

        private void textBoxBatteryMax_TextChanged(object sender, EventArgs e)
        {
            settingBean1.BatteryValueMax = textBoxBatteryMax.Text;
        }
    }
}
