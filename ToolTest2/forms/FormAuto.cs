using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolTest2.Bean;
using ToolTest2.forms;
using ToolTest2.Util;

namespace GS1406.forms
{
    public partial class FormAuto : Form
    {
        SppUtil sp;
        private string BlueToothReceivedData, Msg;
        private int falg = 0, Status = 1, currentFc = 0;//0成功，1超时，2失败
        private SettingBean settingBean;
        private SerialPort serialPort;
        Dictionary<string, SettingBean> settings = new Dictionary<string, SettingBean>();
        List<Boolean> settingsList = new List<bool> { };
        int currentNode = 0;
        Boolean autoFlag = true;

        public FormAuto()
        {
            InitializeComponent();
            loadFile();
        }

        private void buttonDis_Click(object sender, EventArgs e)
        {
            try
            {
                ClearList();
                String dateString = ">DISC";
                sp.sendCommend(dateString);
                textBox1.Text = "";

                Status = 1;
                falg = 0;
                currentNode = 0;
                autoFlag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogCheck dialogCheck = new DialogCheck(settingBean);
            dialogCheck.StartPosition = FormStartPosition.CenterParent;
            DialogResult dialogResult1 = dialogCheck.ShowDialog();
            if (dialogResult1 == DialogResult.OK)
            {
                DialogSetting dialogSetting = new DialogSetting(settingBean, serialPort);
                dialogSetting.StartPosition = FormStartPosition.CenterParent;
                DialogResult dialogResult = dialogSetting.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    sp.closeDataReceived();
                    serialPort = dialogSetting.GetSettingResult();
                    loadFile();
                    sp.SeriaPort1 = serialPort;
                    sp.openDataReceive();
                    falg = 0;
                    setEnableSetting(false);
                }
            }

        }

        private void loadFile()
        {
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                settings = bf.Deserialize(fs) as Dictionary<string, SettingBean>;
                foreach (SettingBean settingBeanItem in settings.Values)
                {
                    this.settingBean = settingBeanItem;
                }
            }
            else
            {
                settingBean = new SettingBean();
                BinaryFormatter bf = new BinaryFormatter();
                if (settings.ContainsKey(settingBean.SoftVersion))
                {
                    //如果有清掉
                    settings.Remove(settingBean.SoftVersion);
                }
                settings.Add(settingBean.SoftVersion, settingBean);
                bf.Serialize(fs, settings);//new  {Name = user.username, Password  = user.password}
            }
            fs.Close();
            checkList();
        }

        public void checkList()
        {
            this.settingsList.Clear();
            //0-获取颜色
            this.settingsList.Add(this.settingBean.IsGetDeviceColor);
            //1-获取硬件版本
            this.settingsList.Add(this.settingBean.IsGetHardVersion);
            //2-获取软件版本
            this.settingsList.Add(this.settingBean.IsGetSoftVersion);
            //3-获取耳机电量
            this.settingsList.Add(this.settingBean.IsGetBatteryLevel);
            //4-获取MFI状态
            this.settingsList.Add(this.settingBean.IsGetMfiStatus);
        }

        public void sendGetCommend()
        {
            if (currentNode >= settingsList.Count)
            {
                autoFlag = false;
                return;
            }

            if (settingsList[currentNode])
            {
                switch (currentNode)
                {
                    case 0:
                        sendGetColor();
                        break;
                    case 1:
                        sendGetHardVersion();
                        break;
                    case 2:
                        sendGetSoftVersion();
                        break;
                    case 3:
                        sendGetBatteryLevel();
                        break;
                    case 4:
                        sendGetMFI();
                        break;
                }
            }
            else
            {
                currentNode += 1;
                if (autoFlag)
                    sendGetCommend();
            }
        }



        private async void buttonGetColor_Click(object sender, EventArgs e)
        {
            sendGetColor();
        }

        private async void sendGetColor()
        {
            ClearList();
            currentFc = 0x10;
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x10;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private async void buttonSetDeviceColor_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                ClearList();
                byte[] dataBytes = new byte[7];
                dataBytes[0] = 0x05;
                dataBytes[1] = 0x5A;
                dataBytes[2] = 0x03;
                dataBytes[3] = 0x00;
                dataBytes[4] = 0x11;
                dataBytes[5] = 0x00;
                dataBytes[6] = (byte)(comboBox1.SelectedItem.ToString().Equals("black") ? 0x01 : 0x02);
                sendMsg("设置设备颜色", dataBytes);

                sp.sendCommend(dataBytes);
            }
            else
            {
                Status = 2;
                Msg = "请选择颜色";
            }
        }

        private async void buttonGetHardVersion_Click(object sender, EventArgs e)
        {
            sendGetHardVersion();
        }

        private async void sendGetHardVersion()
        {
            ClearList();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x12;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private async void buttonSetHardVersion_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxHardVersion.Text != null && textBoxHardVersion.Text.Contains("."))
                {
                    ClearList();
                    byte[] dataBytes = new byte[7];
                    dataBytes[0] = 0x05;
                    dataBytes[1] = 0x5A;
                    dataBytes[2] = 0x03;
                    dataBytes[3] = 0x00;
                    dataBytes[4] = 0x13;
                    dataBytes[5] = 0x00;
                    string[] s = textBoxHardVersion.Text.Split(".");
                    string ss = "0x" + s[0] + s[1];
                    dataBytes[6] = System.Convert.ToByte(ss, 16);
                    sendMsg("设置硬件版本", dataBytes);

                    sp.sendCommend(dataBytes);
                }
                else
                {
                    Status = 2;
                    Msg = "请输入正确硬件版本号";
                }
            }
            catch (Exception ex)
            {
                Status = 2;
                Msg = ex.Message;
            }
        }

        private async void buttonGetSoftVersion_Click(object sender, EventArgs e)
        {
            sendGetSoftVersion();
        }

        private async void sendGetSoftVersion()
        {
            ClearList();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x14;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private async void buttonGetBatteryLevel_Click(object sender, EventArgs e)
        {
            sendGetBatteryLevel();
        }

        private async void sendGetBatteryLevel()
        {
            ClearList();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x15;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private async void buttonGetMFIStatus_Click(object sender, EventArgs e)
        {
            sendGetMFI();
        }

        private async void sendGetMFI()
        {
            ClearList();
            currentFc = 0x16;
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x16;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private async void buttonGetSerialNumber_Click(object sender, EventArgs e)
        {
            sendGetSerialNumber();
        }

        private async void sendGetSerialNumber()
        {
            ClearList();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x17;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private async void buttonSetSerialNumber_Click(object sender, EventArgs e)
        {
            sendSetSerialNumber();

        }

        private async void sendSetSerialNumber()
        {
            //ClearList();
            //string s = "";
            //s = settingBean.Vendor + settingBean.Year + settingBean.Week + settingBean.Family + settingBean.Color + textSerialNumber.Text;
            //if (textSerialNumber.Text.Length != 5)
            //{
            //    Status = 2;
            //    Msg = "序列号错误";
            //    MessageBox.Show("序列号长度异常");
            //    return;
            //}
            //else
            //{
            //    byte[] array = System.Text.Encoding.UTF8.GetBytes(s);
            //    byte[] dataBytes = new byte[6];
            //    dataBytes[0] = 0x05;
            //    dataBytes[1] = 0x5A;
            //    byte[] dataBytes2 = new byte[dataBytes.Length + array.Length];
            //    dataBytes[2] = System.Convert.ToByte(dataBytes2.Length - 4);
            //    dataBytes[3] = 0x00;
            //    dataBytes[4] = 0x18;
            //    dataBytes[5] = 0x00;

            //    Array.Copy(dataBytes, 0, dataBytes2, 0, dataBytes.Length);
            //    Array.Copy(array, 0, dataBytes2, dataBytes.Length, array.Length);
            //    sendMsg("设置序列号", dataBytes2);
            //    await sp.sendCommend(dataBytes2);
            //}

            ClearList();
            string s = "";
            s = textSerialNumber.Text;
            if (textSerialNumber.Text.Length != 14)
            {
                Status = 2;
                Msg = "序列号错误";
                MessageBox.Show("序列号长度异常");
                return;
            }
            else
            {
                byte[] array = System.Text.Encoding.UTF8.GetBytes(s);
                byte[] dataBytes = new byte[6];
                dataBytes[0] = 0x05;
                dataBytes[1] = 0x5A;
                byte[] dataBytes2 = new byte[dataBytes.Length + array.Length];
                dataBytes[2] = System.Convert.ToByte(dataBytes2.Length - 4);
                dataBytes[3] = 0x00;
                dataBytes[4] = 0x18;
                dataBytes[5] = 0x00;

                Array.Copy(dataBytes, 0, dataBytes2, 0, dataBytes.Length);
                Array.Copy(array, 0, dataBytes2, dataBytes.Length, array.Length);
                sendMsg("设置序列号", dataBytes2);
                sp.sendCommend(dataBytes2);
            }
        }



        private async void buttonEnterDutMode_Click(object sender, EventArgs e)
        {
            EnterDutMode();
        }

        private async void EnterDutMode()
        {
            ClearList();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x30;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private async void buttonEnterShipMode_Click(object sender, EventArgs e)
        {
            ClearList();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x31;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);

        }

        private void sendMsg(string s, byte[] datas)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            BlueToothReceivedData += s + "\r\n";
            for (int i = 0; i < datas.Length; i++)
            {
                BlueToothReceivedData += String.Format("date[" + i + "] = " + datas[i] + "\r\n");
            }
        }


        private void timerAuto_Tick(object sender, EventArgs e)
        {

            switch (Status)
            {
                case 0:
                    textBoxStatus.Text = "SUCCESS";
                    textBoxStatus.BackColor = Color.Green;
                    break;
                case 1:
                    textBoxStatus.Text = "";
                    textBoxStatus.BackColor = Color.White;
                    break;
                case 2:
                    textBoxStatus.Text = "FAIL";
                    textBoxStatus.BackColor = Color.Red;
                    break;
            }
            if (falg == 0)
            {
                buttonDis.Enabled = false;
                textBox1.Enabled = true;
                button1.Enabled = true;
                setEnableSetting(false);
                cleerUi();
            }
            else
            {
                buttonDis.Enabled = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
                setEnableSetting(true);
            }
            textBoxList.Text = BlueToothReceivedData;
            textBoxMessage.Text = Msg;
        }

        private void setEnableSetting(bool b)
        {
            buttonGetColor.Enabled = settingBean.IsGetDeviceColor ? b : false;
            buttonSetDeviceColor.Enabled = settingBean.IsSetDeviceColor ? b : false;
            buttonGetHardVersion.Enabled = settingBean.IsGetHardVersion ? b : false;
            buttonSetHardVersion.Enabled = settingBean.IsSetHardVersion ? b : false;
            buttonGetSoftVersion.Enabled = settingBean.IsGetSoftVersion ? b : false;
            buttonGetBatteryLevel.Enabled = settingBean.IsGetBatteryLevel ? b : false;
            buttonGetMFIStatus.Enabled = settingBean.IsGetMfiStatus ? b : false;
            buttonGetSerialNumber.Enabled = settingBean.IsGetSerialNum ? b : false;
            buttonSetSerialNumber.Enabled = settingBean.IsSetSerialNum ? b : false;
            buttonEnterDutMode.Enabled = settingBean.IsEnterDutMode ? b : false;
            buttonEnterShipMode.Enabled = settingBean.IsEnterShipMode ? b : false;
            //buttonGetChannel.Enabled = settingBean.IsGetChannel ? b : false;
            buttonResetMode.Enabled = settingBean.IsResetMode ? b : false;
        }

        private void cleerUi()
        {
            labelColor.Text = "";
            labelColor.BackColor = Color.White;
            labelHardVersion.Text = "";
            textBoxHardVersion.Text = "";
            labelHardVersion.BackColor = Color.White;
            labelSoftVersion.Text = "";
            labelSoftVersion.BackColor = Color.White;
            labelBattertLevel.Text = "";
            labelBattertLevel.BackColor = Color.White;
            labelMfi.Text = "";
            labelMfi.BackColor = Color.White;
            //labelChanel.Text = "";
            labelSerialNumber.Text = "";
            labelSerialNumber.BackColor = Color.White;
            textSerialNumber.Text = "";


        }

        private void ClearList()
        {
            BlueToothReceivedData = "";
            textBoxList.Text = "";
            Msg = "";
            textBoxMessage.Text = "";
        }


        public void dataReceive(string date)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            BlueToothReceivedData += date;
            if (date.Contains("SDP_SEARCH_FAILED"))
            {
                Status = 2;
                Msg = "连接失败";
            }
            if (date.Contains(">SPP_CONNECT"))
            {
                Thread.Sleep(2000);
                Status = 0;
                falg = 1;
                currentNode = 0;
                sendGetCommend();

            }
            if (date.Contains("SppDisconnectInd,spp_disconnect_abnormal_disconnect"))
            {
                Status = 1;
                falg = 0;
                currentNode = 0;
                autoFlag = true;
            }
        }


        public void dataReceive(byte[] data)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            BlueToothReceivedData += "返回结果" + "\r\n";
            for (int i = 0; i < data.Length; i++)
            {
                BlueToothReceivedData += String.Format("date[" + i + "] = " + data[i] + "\r\n");
            }
            if (data[0] == 0x05 && data[1] == 0x5B)
            {
                if (data[6] != 0x00)
                {

                    if (currentFc == 0x10)
                    {
                        labelColor.Invoke(delegate
                        {
                            labelColor.BackColor = Color.Red;
                        });
                    }
                    if (currentFc == 0x12)
                    {
                        labelColor.Invoke(delegate
                        {
                            labelColor.BackColor = Color.Red;
                        });
                    }
                    if (currentFc == 0x14)
                    {
                        labelSoftVersion.Invoke(delegate
                        {
                            labelSoftVersion.BackColor = Color.Red;
                        });
                    }
                    if (currentFc == 0x15)
                    {
                        labelBattertLevel.Invoke(delegate
                        {
                            labelBattertLevel.BackColor = Color.Red;
                        });
                    }
                    if (currentFc == 0x16)
                    {
                        labelMfi.Invoke(delegate
                        {
                            labelMfi.BackColor = Color.Red;
                        });
                    }
                    if (currentFc == 0x17)
                    {
                        labelSerialNumber.Invoke(delegate
                        {
                            labelSerialNumber.BackColor = Color.Red;
                        });
                    }
                    Msg = "指令发送失败";
                    Status = 2;
                    return;
                }
                Status = 0;
                switch (data[4])
                {
                    case 0x10:
                        labelColor.Invoke(delegate
                        {
                            currentNode += 1;
                            if (autoFlag)
                                sendGetCommend();
                            labelColor.BackColor = Color.Green;
                            if (data[7] == 0x01)
                            {
                                labelColor.Text = "black";
                            }
                            else if (data[7] == 0x02)
                            {
                                labelColor.Text = "white";
                            }
                            else
                            {
                                Status = 2;
                                Msg = "获取颜色异常";
                                labelColor.BackColor = Color.Red;
                            }
                        });
                        break;
                    case 0x11:
                        sendGetColor();
                        break;
                    case 0x12:
                        labelHardVersion.Invoke(delegate
                        {
                            currentNode += 1;
                            if (autoFlag)
                                sendGetCommend();
                            int a = data[7] / 16;
                            int b = data[7] % 16;
                            labelHardVersion.Text = a + "." + b;
                            labelHardVersion.BackColor = Color.Green;
                        });
                        break;
                    case 0x13:
                        sendGetHardVersion();
                        break;
                    case 0x14:
                        labelSoftVersion.Invoke(delegate
                        {
                            currentNode += 1;
                            if (autoFlag)
                                sendGetCommend();
                            int a = data[8];
                            int b = data[7] / 16;
                            int c = data[7] % 16;
                            labelSoftVersion.Text = a + "." + b + "." + c;
                            labelSoftVersion.BackColor = Color.Green;
                            if (!labelSoftVersion.Text.Equals(settingBean.SoftVersion))
                            {
                                labelSoftVersion.BackColor = Color.Red;
                                MessageBox.Show("软件版本异常");
                                Msg = "软件版本错误";
                                Status = 2;
                            }
                        });
                        break;
                    case 0x15:
                        labelBattertLevel.Invoke(delegate
                        {
                            currentNode += 1;
                            if (autoFlag)
                                sendGetCommend();
                            labelBattertLevel.Text = data[7].ToString();
                            if (data[7] < int.Parse(settingBean.BatteryValue))
                            {
                                labelBattertLevel.BackColor = Color.Red;
                            }
                            else
                            {
                                labelBattertLevel.BackColor = Color.Green;
                            }
                        });
                        break;
                    case 0x16:
                        labelMfi.Invoke(delegate
                        {
                            currentNode += 1;
                            if (autoFlag)
                                sendGetCommend();
                            if (data[7] == 0x00)
                            {
                                labelMfi.Text = "MFI chip is OK";
                                labelMfi.BackColor = Color.Green;
                            }
                            else
                            {
                                labelMfi.Text = "Fail";
                                labelMfi.BackColor = Color.Red;
                            }
                        });
                        break;
                    case 0x17:
                        labelSerialNumber.Invoke(delegate
                        {
                            int len = 14;
                            byte[] b = new byte[len];
                            string s = "";
                            for (int i = 0; i < len; i++)
                            {
                                b[i] = data[i + 7];
                            }
                            for (int i = 0; i < len; i++)
                            {
                                ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                char[] ascii = aSCIIEncoding.GetChars(b);
                                s += ascii[i];
                            }
                            labelSerialNumber.Text = s;
                            labelSerialNumber.BackColor = Color.Green;
                        });
                        break;
                    case 0x18:
                        sendGetSerialNumber();
                        break;
                    //case 0x19:
                    //    labelChanel.Invoke(delegate
                    //    {
                    //        if (data[7] == 0x01)
                    //        {
                    //            labelChanel.Text = "Left";
                    //        }
                    //        else if (data[7] == 0x02)
                    //        {
                    //            labelChanel.Text = "Right";
                    //        }
                    //        else
                    //        {
                    //            Status = 2;
                    //            Msg = "获取通道异常";
                    //        }
                    //    });
                    //    break;
                    case 0x01:
                        if (data[6] == 0x00)
                        {
                            Status = 0;
                            Msg = "重置成功";
                        }
                        else
                        {
                            Status = 2;
                            Msg = "重置失败";
                        }
                        break;

                }
            }
        }

        public void ReceiveFlag(byte[] data)
        {
            switch (data[4])
            {
                case 0x10:
                    labelColor.Invoke(delegate
                    {

                        Status = 2;
                        Msg = "获取颜色异常";
                        labelColor.BackColor = Color.Red;

                    });
                    break;
                case 0x12:
                    labelHardVersion.Invoke(delegate
                    {
                        Status = 2;
                        Msg = "获取硬件版本异常";
                        labelHardVersion.BackColor = Color.Red;
                    });
                    break;
                case 0x14:
                    labelSoftVersion.Invoke(delegate
                    {
                        Status = 2;
                        Msg = "获取软件版本异常";
                        labelSoftVersion.BackColor = Color.Red;
                    });
                    break;
                case 0x15:
                    labelBattertLevel.Invoke(delegate
                    {
                        Status = 2;
                        Msg = "获取电量异常";
                        labelBattertLevel.BackColor = Color.Red;
                    });
                    break;
                case 0x16:
                    labelMfi.Invoke(delegate
                    {
                        Status = 2;
                        Msg = "获取MFI异常";
                        labelMfi.BackColor = Color.Red;
                    });
                    break;
                case 0x17:
                    labelSerialNumber.Invoke(delegate
                    {
                        Status = 2;
                        Msg = "获取序列号异常";
                        labelSerialNumber.BackColor = Color.Red;
                    });
                    break;

                //case 0x19:
                //    labelChanel.Invoke(delegate
                //    {
                //        if (data[7] == 0x01)
                //        {
                //            labelChanel.Text = "Left";
                //        }
                //        else if (data[7] == 0x02)
                //        {
                //            labelChanel.Text = "Right";
                //        }
                //        else
                //        {
                //            Status = 2;
                //            Msg = "获取通道异常";
                //        }
                //    });
                //    break;
                case 0x32:
                    Status = 2;
                    Msg = "重置失败";
                    break;
            }
            currentNode += 1;
            sendGetCommend();

        }

        private void FormAuto_Enter(object sender, EventArgs e)
        {
            if (falg == 0)
            {
                setEnableSetting(false);
            }
            else
            {
                setEnableSetting(true);
            }
        }

        private void FormAuto_Load(object sender, EventArgs e)
        {
            serialPort = (SerialPort)this.Tag;
            sp = new SppUtil(serialPort);
            sp.openDataReceive();
            sp.receiveDelegateString += dataReceive;
            sp.receiveDelegate += dataReceive;
            sp.receiveDeleteFlag += ReceiveFlag;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void buttonGetChannel_Click(object sender, EventArgs e)
        {
            ClearList();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x19;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private async void buttonResetMode_Click(object sender, EventArgs e)
        {
            ClearList();
            byte[] dataBytes = new byte[8];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x04;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x01;
            dataBytes[5] = 0x11;
            dataBytes[6] = 0x95;
            dataBytes[7] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 12)
            {
                ClearList();
                string dateString = ">SPP_CONN=" + textBox1.Text;
                sp.sendCommend(dateString);
            }
            else
            {
                Status = 2;
                Msg = "请输入正确蓝牙地址码";
            }
        }

        private void textSerialNumber_TextChanged(object sender, EventArgs e)
        {
            if (this.textSerialNumber.TextLength == 14)
            {
                sendSetSerialNumber();
            }
        }
    }
}
