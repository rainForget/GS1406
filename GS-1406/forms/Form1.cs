using System.Diagnostics;
using System.Drawing.Design;
using System.IO.Ports;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using GS1406.Util;
using ToolTest2.Bean;
using ToolTest2.forms;
using ToolTest2.Util;

namespace GS_1406
{
    public partial class Form1 : Form
    {
        SppUtil sp;
        private string BlueToothReceivedData, Msg;
        private int Status = 1;//0成功，1超时，2失败
        private int mStatus = 0;
        private int flag = 0;//0-未连接，1-已连接
        private int getNum = 0;//指令接收次数
        private SettingBean settingBean;
        private SerialPort serialPort;
        Dictionary<string, SettingBean> settings = new Dictionary<string, SettingBean>();
        Dictionary<string, string> logList = new Dictionary<string, string>();
        List<Boolean> settingsList = new List<bool> { };
        Boolean autoFlag = true;
        private int currentNode = -1;
        private string bleAdr = "";
        private int year,month,day,hour,minute,second;
        public Form1()
        {
            InitializeComponent();
            loadFile();
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
                if (settings.ContainsKey(settingBean.ProductId))
                {
                    //如果有清掉
                    settings.Remove(settingBean.ProductId);
                }
                settings.Add(settingBean.ProductId, settingBean);
                bf.Serialize(fs, settings);
            }
            fs.Close();
            checkSetting();
        }

        private void checkSetting()
        {
            textBoxScanSN.Enabled = this.settingBean.IsSetSerialNum;
            textBoxScanCaseSN.Enabled = this.settingBean.IsSetCaseSerialNum;
            textBoxProductId.Text = this.settingBean.ProductId;
            textBoxHardVersion.Text = this.settingBean.HardVersion;
            textBoxColor.Text = this.settingBean.Color;

            buttonEnterShipMode.Enabled = this.settingBean.IsEnterShipMode;
            buttonResetMode.Enabled = this.settingBean.IsResetMode;
            buttonSetDeviceColor.Enabled = this.settingBean.IsSetDeviceColor;
            buttonSetHardVersion.Enabled = this.settingBean.IsSetHardVersion;
            checkList();
        }

        public void checkList()
        {
            this.settingsList.Clear();
            this.settingsList.Add(this.settingBean.IsSetDeviceColor);//获取设备颜色
            this.settingsList.Add(this.settingBean.IsSetHardVersion);//获取硬件版本
            this.settingsList.Add(true);//获取软件版本
            this.settingsList.Add(true);//获取电量
            this.settingsList.Add(true);//获取MFI
            this.settingsList.Add(this.settingBean.IsSetSerialNum);//设置设备SN
            //this.settingsList.Add(this.settingBean.IsGetSerialNum);//获取设备SN
            this.settingsList.Add(this.settingBean.IsSetProductId);//设置产品型号
            //this.settingsList.Add(this.settingBean.IsGetProductId);//获取产品型号
            this.settingsList.Add(this.settingBean.IsSetCaseSerialNum);//设置盒子SN
            //this.settingsList.Add(this.settingBean.IsGetCaseSerialNum);//获取盒子SN
            this.settingsList.Add(this.settingBean.IsResetMode);
            this.settingsList.Add(this.settingBean.IsEnterShipMode);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            serialPort = (SerialPort)this.Tag;
            sp = new SppUtil(serialPort);
            sp.openDataReceive();
            sp.receiveDelegateString += dataReceive;
            sp.receiveDelegate += dataReceive;
            sp.receiveDeleteFlag += ReceiveFlag;
            checkSetting();
            if (serialPort.IsOpen)
            {
                disconnect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearList();
            disconnect();
        }

        private void disconnect()
        {
            try
            {

                String dateString = ">DISC";
                sp.sendCommend(dateString);
                Status = 1;
                flag = 0;
                currentNode = -1;
                autoFlag = true;
                mStatus = 0;
                saveLog(DateTime.Now + "");
                saveLog("write  >>   " + dateString);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void ClearList()
        {
            textBoxScanBle.Text = "";
            textBoxScanSN.Text = "";
            textBoxScanCaseSN.Text = "";

            labelStatue.Text = "";
            labelStatue.BackColor = Color.White;
            labelLColor.Text = "";
            labelLColor.BackColor = Color.White;
            labelRColor.Text = "";
            labelRColor.BackColor = Color.White;
            labelLHardVersion.Text = "";
            labelLHardVersion.BackColor = Color.White;
            labelRHardVersion.Text = "";
            labelRHardVersion.BackColor = Color.White;
            labelLSoftVersion.Text = "";
            labelLSoftVersion.BackColor = Color.White;
            labelRSoftVersion.Text = "";
            labelRSoftVersion.BackColor = Color.White;
            labelLBattery.Text = "";
            labelLBattery.BackColor = Color.White;
            labelRBattery.Text = "";
            labelRBattery.BackColor = Color.White;
            labelLMFI.Text = "";
            labelLMFI.BackColor = Color.White;
            labelRMFI.Text = "";
            labelRMFI.BackColor = Color.White;
            labelLSN.Text = "";
            labelLSN.BackColor = Color.White;
            labelRSN.Text = "";
            labelRSN.BackColor = Color.White;
            labelLCaseSN.Text = "";
            labelLCaseSN.BackColor = Color.White;
            labelRCaseSN.Text = "";
            labelRCaseSN.BackColor = Color.White;
            labelLProduct.Text = "";
            labelLProduct.BackColor = Color.White;
            labelRProduct.Text = "";
            labelRProduct.BackColor = Color.White;

        }

        private void clearMsg()
        {
            labelStatue.Invoke(delegate
            {
                labelStatue.Text = "";
                labelStatue.BackColor = Color.White;
            });

        }

        private void textBoxScanBle_TextChanged(object sender, EventArgs e)
        {
            checkConnect();
        }

        private void textBoxScanSN_TextChanged(object sender, EventArgs e)
        {
            checkConnect();
        }

        private void textBoxScanCaseSN_TextChanged(object sender, EventArgs e)
        {
            checkConnect();
        }

        private void checkConnect()
        {
            clearMsg();
            if (textBoxScanBle.Text.Length != 12)
            {
                return;
            }

            if (textBoxScanSN.Enabled && textBoxScanSN.Text.Length != 14)
            {
                return;
            }

            if (textBoxScanCaseSN.Enabled && textBoxScanCaseSN.Text.Length != 15)
            {
                return;
            }

            if (buttonSetHardVersion.Enabled && textBoxHardVersion.Text.Length == 0)
            {
                return;
            }

            if (buttonSetDeviceColor.Enabled && textBoxColor.Text.Length == 0) { return; }
            getTime();
            saveLog(DateTime.Now + "");
            saveLog(textBoxScanBle.Text);
            connect();
        }
        private void getTime()
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            day = DateTime.Now.Day;
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
        }

        private void connect()
        {
            string dateString = ">SPP_CONN=" + textBoxScanBle.Text;
            sp.sendCommend(dateString);
            saveLog(DateTime.Now + "");
            saveLog("write  >>   " + dateString);
        }

        private void sendCommendAuto()
        {
            currentNode += 1;
            Debug.WriteLine(currentNode);

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
                        sendCommendSetColor();
                        break;
                    case 1:
                        sendCommendSetHardVersion();
                        break;
                    case 2:
                        sendCommendGetVersion();
                        break;
                    case 3:
                        sendCommendGetBatteryLevel();
                        break;
                    case 4:
                        sendCommendGetMFI();
                        break;
                    case 5:
                        sendCommendSetSN();
                        break;
                    case 6:
                        sendCommendSetSKU();
                        break;
                    case 7:
                        sendCommendSetCaseSN();
                        break;
                    case 8:
                        if (checkResetStatue())
                        {
                            sendCommendReset();
                        }
                        else
                        {
                            MessageBox.Show("请确认所有指令全部通过");
                        }
                        break;
                    case 9:
                        sendCommendShip();
                        break;
                }
            }
            else
            {
                if (autoFlag)
                {
                    Debug.WriteLine("该功能不获取");
                    sendCommendAuto();
                }
            }
        }

        private async void sendCommendGetColor()
        {
            saveLog(DateTime.Now + "");
            saveLog("获取设备颜色");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x10;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendSetColor()
        {
            saveLog(DateTime.Now + "");
            saveLog("设置设备颜色");
            clearMsg();
            if (textBoxColor.Text != null)
            {
                byte[] dataBytes = new byte[7];
                dataBytes[0] = 0x05;
                dataBytes[1] = 0x5A;
                dataBytes[2] = 0x03;
                dataBytes[3] = 0x00;
                dataBytes[4] = 0x11;
                dataBytes[5] = 0x00;
                dataBytes[6] = (byte)(textBoxColor.Text.Equals("black") ? 0x01 : 0x02);
                sp.sendCommend(dataBytes);
                saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
            }
            else
            {
                Status = 2;
            }
        }

        private async void sendCommendGetHardVersion()
        {
            saveLog(DateTime.Now + "");
            saveLog("获取硬件版本");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x12;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendSetHardVersion()
        {
            clearMsg();
            try
            {
                if (textBoxHardVersion.Text != null && textBoxHardVersion.Text.Contains("."))
                {
                    saveLog(DateTime.Now + "");
                    saveLog("设置硬件版本");
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
                    sp.sendCommend(dataBytes);
                    saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
                }
                else
                {
                    Status = 2;
                }
            }
            catch (Exception ex)
            {
                Status = 2;
            }
        }

        private void sendCommendGetVersion()
        {
            clearMsg();
            saveLog(DateTime.Now + "");
            saveLog("获取软件版本");
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x14;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendGetBatteryLevel()
        {
            saveLog(DateTime.Now + "");
            saveLog("获取设备电量");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x15;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendGetMFI()
        {
            saveLog(DateTime.Now + "");
            saveLog("获取MFI状态");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x16;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendSetSN()
        {
            saveLog(DateTime.Now + "");
            saveLog("设置SN");
            clearMsg();
            string s = "";
            s = textBoxScanSN.Text;
            if (textBoxScanSN.Text.Length != 14)
            {
                Status = 2;
                MessageBox.Show("序列号长度异常" + textBoxScanSN.Text.Length);
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
                sp.sendCommend(dataBytes2);
                saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
            }
        }

        private void sendCommendGetSN()
        {
            saveLog(DateTime.Now + "");
            saveLog("获取SN");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x17;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendSetCaseSN()
        {
            saveLog(DateTime.Now + "");
            saveLog("设置充电盒SN");
            clearMsg();
            string s = "";
            s = textBoxScanCaseSN.Text;
            if (textBoxScanCaseSN.Text.Length != 15)
            {
                Status = 2;
                MessageBox.Show("盒子序列号长度异常" + textBoxScanCaseSN.Text.Length);
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
                dataBytes[4] = 0x1D;
                dataBytes[5] = 0x00;

                Array.Copy(dataBytes, 0, dataBytes2, 0, dataBytes.Length);
                Array.Copy(array, 0, dataBytes2, dataBytes.Length, array.Length);
                sp.sendCommend(dataBytes2);
                saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
            }
        }

        private void sendCommendGetCaseSN()
        {
            saveLog(DateTime.Now + "");
            saveLog("获取充电盒SN");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x1C;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendSetSKU()
        {
            saveLog(DateTime.Now + "");
            saveLog("设置产品型号");
            clearMsg();
            string s = "";
            s = textBoxProductId.Text;

            byte[] array = System.Text.Encoding.UTF8.GetBytes(s);
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            byte[] dataBytes2 = new byte[dataBytes.Length + array.Length];
            dataBytes[2] = System.Convert.ToByte(dataBytes2.Length - 4);
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x1B;
            dataBytes[5] = 0x00;

            Array.Copy(dataBytes, 0, dataBytes2, 0, dataBytes.Length);
            Array.Copy(array, 0, dataBytes2, dataBytes.Length, array.Length);
            sp.sendCommend(dataBytes2);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendGetSKU()
        {
            saveLog(DateTime.Now + "");
            saveLog("获取产品型号");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x1A;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendDut()
        {
            saveLog(DateTime.Now + "");
            saveLog("进入DUT");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x30;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendShip()
        {
            saveLog(DateTime.Now + "");
            saveLog("进入Ship模式");
            Thread.Sleep(3000);
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x31;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendReset()
        {
            saveLog(DateTime.Now + "");
            saveLog("Reset");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x32;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("发送消息  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }


        private void checkCommendAuto()
        {
            sendCommendAuto();
        }

        private void saveLog(string s)
        {
            try
            {
                string adr =year +"/" + month + "/" + day;
                string adrssPass = "",adrssFail = "";
                StreamWriter streamWriter;

                if (!Directory.Exists(adr))
                {
                    Directory.CreateDirectory(adr);
                }
                adrssPass = adr + "/" + textBoxScanBle.Text + "_" + hour + minute + second + "_log_pass.txt";
                adrssFail = adr + "/" + textBoxScanBle.Text + "_" + hour + minute + second + "_log_fail.txt";
                if (mStatus == 1)
                {
                     if (!File.Exists(adrssFail))
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(adrssPass, textBoxScanBle.Text + "_" + hour + minute + second + "_log_fail.txt");
                    }
                    streamWriter = new StreamWriter(adrssFail, true);
                    streamWriter.WriteLine(s);
                    streamWriter.Close();

                }
                else
                {
                    streamWriter = new StreamWriter(adrssPass, true);
                    streamWriter.WriteLine(s);
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("日志存储异常" + ex.Message);
            }
        }





        public void dataReceive(string date)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            BlueToothReceivedData += date;
            saveLog(DateTime.Now + "");
            saveLog("Read >> " + date);

            if (date.Contains("SDP_SEARCH_FAILED"))
            {
                Status = 2;
                saveLog("连接失败");
            }
            if (date.Contains(">SPP_CONNECT"))
            {
                Thread.Sleep(2000);
                Status = 0;
                flag = 1;
                mStatus = 0;
                saveLog("连接成功");
                sendCommendAuto();
            }
            if (date.Contains("SppDisconnectInd,spp_disconnect_abnormal_disconnect"))
            {
                Thread.Sleep(2000);
                Status = 1;
                flag = 0;
                autoFlag = true;
                saveLog( "连接断开");
            }
            if (date.Contains("a_2dp_operation_fail"))
            {
                Status = 2;
                Thread.Sleep(1000);
                disconnect();
            }
        }

        private bool checkDouble(byte[] data)
        {
            if (data[3] + 5 < data.Length && data[data.Length / 2] == 0x05 && data[data.Length / 2 + 1] == 0x5D)
            {
                return true;
            }
            return false;

        }

        public void dataReceive(byte[] data)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            saveLog(DateTime.Now + "");
            BlueToothReceivedData += "返回结果" + "\r\n";
            saveLog("接收消息");
            saveLog(FormateUtil.byteArrayToHexString(data));
            for (int i = 0; i < data.Length; i++)
            {
                BlueToothReceivedData += String.Format("date[" + i + "] = " + data[i] + "\r\n");
            }
            if (data[0] == 0x05 && data[1] == 0x5B || data[0] == 0x05 && data[1] == 0x5B)
            {
                Status = 0;
                switch (data[4])
                {
                    case 0x10:
                        if (data[7] == 0x01)
                        {
                            labelLColor.Invoke(delegate
                            {
                                labelLColor.BackColor = Color.Green;
                                if (data[8] == 0x01)
                                {
                                    labelLColor.Text = "black";
                                }
                                else if (data[8] == 0x02)
                                {
                                    labelLColor.Text = "white";
                                }
                            });
                            if (checkDouble(data))
                            {
                                labelRColor.Invoke(delegate
                                {
                                    labelRColor.BackColor = Color.Green;
                                    if (data[data.Length / 2 + 8] == 0x01)
                                    {
                                        labelRColor.Text = "black";
                                    }
                                    else if (data[data.Length / 2 + 8] == 0x02)
                                    {
                                        labelRColor.Text = "white";
                                    }
                                });
                            }
                            else
                            {
                                labelRColor.Invoke(delegate
                                {
                                    labelRColor.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        }
                        else if (data[7] == 0x02)
                        {
                            labelRColor.Invoke(delegate
                            {
                                labelRColor.BackColor = Color.Green;
                                if (data[8] == 0x01)
                                {
                                    labelRColor.Text = "black";
                                }
                                else if (data[8] == 0x02)
                                {
                                    labelRColor.Text = "white";
                                }
                            });

                            if (checkDouble(data))
                            {
                                labelLColor.Invoke(delegate
                                {
                                    labelLColor.BackColor = Color.Green;
                                    if (data[data.Length / 2 + 8] == 0x01)
                                    {
                                        labelLColor.Text = "black";
                                    }
                                    else if (data[data.Length / 2 + 8] == 0x02)
                                    {
                                        labelLColor.Text = "white";
                                    }
                                });
                            }
                            else
                            {
                                labelLColor.Invoke(delegate
                                {
                                    labelLColor.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        };
                        saveLog("左耳颜色" + (labelLColor.Text.Equals("") ? "获取失败" : labelLColor.Text));
                        saveLog("右耳颜色" + (labelRColor.Text.Equals("") ? "获取失败" : labelRColor.Text));
                        checkCommendAuto();
                        break;
                    case 0x11:
                        sendCommendGetColor();
                        break;
                    case 0x12:
                        if (data[7] == 0x01)
                        {
                            labelLHardVersion.Invoke(delegate
                            {
                                labelLHardVersion.BackColor = Color.Green;
                                int a = data[8] / 16;
                                int b = data[8] % 16;
                                labelLHardVersion.Text = a + "." + b;

                            });
                            if (checkDouble(data))
                            {
                                labelRHardVersion.Invoke(delegate
                                {
                                    labelRHardVersion.BackColor = Color.Green;
                                    int a = data[data.Length / 2 + 8] / 16;
                                    int b = data[data.Length / 2 + 8] % 16;
                                    labelRHardVersion.Text = a + "." + b;
                                });
                            }
                            else
                            {
                                labelRHardVersion.Invoke(delegate
                                {
                                    labelRHardVersion.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        }
                        else if (data[7] == 0x02)
                        {
                            labelRHardVersion.Invoke(delegate
                            {
                                labelRHardVersion.BackColor = Color.Green;
                                int a = data[8] / 16;
                                int b = data[8] % 16;
                                labelRHardVersion.Text = a + "." + b;
                            });
                            if (checkDouble(data))
                            {
                                labelLHardVersion.Invoke(delegate
                                {
                                    labelLHardVersion.BackColor = Color.Green;
                                    int a = data[data.Length / 2 + 8] / 16;
                                    int b = data[data.Length / 2 + 8] % 16;
                                    labelLHardVersion.Text = a + "." + b;
                                });
                            }
                            else
                            {
                                labelLHardVersion.Invoke(delegate
                                {
                                    labelLHardVersion.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        };
                        saveLog("左耳硬件版本" + (labelLHardVersion.Text.Equals("") ? "获取失败" : labelLHardVersion.Text));
                        saveLog("右耳硬件版本" + (labelRHardVersion.Text.Equals("") ? "获取失败" : labelRHardVersion.Text));
                        checkCommendAuto();

                        break;
                    case 0x13:
                        sendCommendGetHardVersion();
                        break;
                    case 0x14:
                        if (data[7] == 0x01)
                        {
                            labelLSoftVersion.Invoke(delegate
                            {
                                int a = data[9];
                                int b = data[8] / 16;
                                int c = data[8] % 16;
                                labelLSoftVersion.Text = a + "." + b + "." + c;
                                labelLSoftVersion.BackColor = Color.Green;
                                if (!labelLSoftVersion.Text.Equals(settingBean.SoftVersion))
                                {
                                    labelLSoftVersion.BackColor = Color.Red;
                                    //MessageBox.Show("软件版本异常");
                                    Status = 2;
                                }
                            });

                            if (checkDouble(data))
                            {
                                labelRSoftVersion.Invoke(delegate
                                {
                                    int a = data[data.Length / 2 + 9];
                                    int b = data[data.Length / 2 + 8] / 16;
                                    int c = data[data.Length / 2 + 8] % 16;
                                    labelRSoftVersion.Text = a + "." + b + "." + c;
                                    labelRSoftVersion.BackColor = Color.Green;
                                    if (!labelRSoftVersion.Text.Equals(settingBean.SoftVersion))
                                    {
                                        labelRSoftVersion.BackColor = Color.Red;
                                        //MessageBox.Show("软件版本异常");
                                        Status = 2;
                                    }
                                });
                            }
                            else
                            {
                                labelRSoftVersion.Invoke(delegate
                                {
                                    labelRSoftVersion.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        }
                        else if (data[7] == 0x02)
                        {
                            labelRSoftVersion.Invoke(delegate
                            {
                                int a = data[9];
                                int b = data[8] / 16;
                                int c = data[8] % 16;
                                labelRSoftVersion.Text = a + "." + b + "." + c;
                                labelRSoftVersion.BackColor = Color.Green;
                                if (!labelRSoftVersion.Text.Equals(settingBean.SoftVersion))
                                {
                                    labelRSoftVersion.BackColor = Color.Red;
                                    //MessageBox.Show("软件版本异常");
                                    Status = 2;
                                }
                            });

                            if (checkDouble(data))
                            {
                                labelLSoftVersion.Invoke(delegate
                                {
                                    int a = data[data.Length / 2 + 9];
                                    int b = data[data.Length / 2 + 8] / 16;
                                    int c = data[data.Length / 2 + 8] % 16;
                                    labelLSoftVersion.Text = a + "." + b + "." + c;
                                    labelLSoftVersion.BackColor = Color.Green;
                                    if (!labelLSoftVersion.Text.Equals(settingBean.SoftVersion))
                                    {
                                        labelLSoftVersion.BackColor = Color.Red;
                                        //MessageBox.Show("软件版本异常");
                                        Status = 2;
                                    }
                                });
                            }
                            else
                            {
                                labelLSoftVersion.Invoke(delegate
                                {
                                    labelLSoftVersion.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        };
                        saveLog("左耳软件版本" + (labelLSoftVersion.Text.Equals("") ? "获取失败" : labelLSoftVersion.Text));
                        saveLog("右耳软件版本" + (labelRSoftVersion.Text.Equals("") ? "获取失败" : labelRSoftVersion.Text));
                        checkCommendAuto();
                        break;
                    case 0x15:
                        if (data[7] == 0x01)
                        {
                            labelLBattery.Invoke(delegate
                            {
                                labelLBattery.Text = data[8].ToString();
                                if (data[8] < int.Parse(settingBean.BatteryValue))
                                {
                                    labelLBattery.BackColor = Color.Red;
                                }
                                else
                                {
                                    labelLBattery.BackColor = Color.Green;
                                }
                            });

                            if (checkDouble(data))
                            {
                                labelRBattery.Invoke(delegate
                                {
                                    labelRBattery.Text = data[data.Length / 2 + 8].ToString();
                                    if (data[data.Length / 2 + 8] < int.Parse(settingBean.BatteryValue))
                                    {
                                        labelRBattery.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        labelRBattery.BackColor = Color.Green;
                                    }
                                });
                            }
                            else
                            {
                                labelRBattery.Invoke(delegate
                                {
                                    labelRBattery.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        }
                        else if (data[7] == 0x02)
                        {
                            labelRBattery.Invoke(delegate
                            {
                                labelRBattery.Text = data[8].ToString();
                                if (data[8] < int.Parse(settingBean.BatteryValue))
                                {
                                    labelRBattery.BackColor = Color.Red;
                                }
                                else
                                {
                                    labelRBattery.BackColor = Color.Green;
                                }
                            });

                            if (checkDouble(data))
                            {
                                labelLBattery.Invoke(delegate
                                {
                                    labelLBattery.Text = data[data.Length / 2 + 8].ToString();
                                    if (data[data.Length / 2 + 8] < int.Parse(settingBean.BatteryValue))
                                    {
                                        labelLBattery.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        labelLBattery.BackColor = Color.Green;
                                    }
                                });
                            }
                            else
                            {
                                labelLBattery.Invoke(delegate
                                {
                                    labelLBattery.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        };
                        saveLog("左耳电量" + (labelLBattery.Text.Equals("") ? "获取失败" : labelLBattery.Text));
                        saveLog("右耳电量" + (labelRBattery.Text.Equals("") ? "获取失败" : labelRBattery.Text));
                        checkCommendAuto();
                        break;
                    case 0x16:
                        if (data[7] == 0x01)
                        {
                            labelLMFI.Invoke(delegate
                            {
                                if (data[8] == 0x00)
                                {
                                    labelLMFI.Text = "Pass";
                                    labelLMFI.BackColor = Color.Green;
                                }
                                else
                                {
                                    labelLMFI.Text = "Fail";
                                    labelLMFI.BackColor = Color.Red;
                                }
                            });

                            if (checkDouble(data))
                            {
                                labelRMFI.Invoke(delegate
                                {
                                    if (data[data.Length / 2 + 8] == 0x00)
                                    {
                                        labelRMFI.Text = "Pass";
                                        labelRMFI.BackColor = Color.Green;
                                    }
                                    else
                                    {
                                        labelRMFI.Text = "Fail";
                                        labelRMFI.BackColor = Color.Red;
                                    }
                                });
                            }
                            else
                            {
                                labelRMFI.Invoke(delegate
                                {
                                    labelRMFI.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        }
                        else if (data[7] == 0x02)
                        {
                            labelRMFI.Invoke(delegate
                            {
                                if (data[8] == 0x00)
                                {
                                    labelRMFI.Text = "Pass";
                                    labelRMFI.BackColor = Color.Green;
                                }
                                else
                                {
                                    labelRMFI.Text = "Fail";
                                    labelRMFI.BackColor = Color.Red;
                                }
                            });

                            if (checkDouble(data))
                            {
                                labelLMFI.Invoke(delegate
                                {
                                    if (data[data.Length / 2 + 8] == 0x00)
                                    {
                                        labelLMFI.Text = "Pass";
                                        labelLMFI.BackColor = Color.Green;
                                    }
                                    else
                                    {
                                        labelLMFI.Text = "Fail";
                                        labelLMFI.BackColor = Color.Red;
                                    }
                                });
                            }
                            else
                            {
                                labelLMFI.Invoke(delegate
                                {
                                    labelLMFI.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        };
                        saveLog("左耳MFI" + (labelLMFI.Text.Equals("") ? "获取失败" : labelLMFI.Text));
                        saveLog("右耳MFI" + (labelRMFI.Text.Equals("") ? "获取失败" : labelRMFI.Text));
                        checkCommendAuto();
                        break;
                    case 0x17:
                        if (data[7] == 0x01)
                        {
                            labelLSN.Invoke(delegate
                            {
                                int len = 14;
                                byte[] b = new byte[len];
                                string s = "";
                                for (int i = 0; i < len; i++)
                                {
                                    b[i] = data[i + 8];
                                }
                                for (int i = 0; i < len; i++)
                                {
                                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                    char[] ascii = aSCIIEncoding.GetChars(b);
                                    s += ascii[i];
                                }
                                labelLSN.Text = s;
                                labelLSN.BackColor = Color.Green;
                            });

                            if (checkDouble(data))
                                {
                                    labelRSN.Invoke(delegate
                                    {
                                        int len = 14;
                                        byte[] b = new byte[len];
                                        string s = "";
                                        for (int i = 0; i < len; i++)
                                        {
                                            b[i] = data[i + data.Length / 2 + 8];
                                        }
                                        for (int i = 0; i < len; i++)
                                        {
                                            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                            char[] ascii = aSCIIEncoding.GetChars(b);
                                            s += ascii[i];
                                        }
                                        labelRSN.Text = s;
                                        labelRSN.BackColor = Color.Green;
                                    });
                            }
                            else
                            {
                                labelRSN.Invoke(delegate
                                    {
                                        labelRSN.BackColor = Color.Red;
                                        Status = 2;
                                    });
                            }
                        }
                        else if (data[7] == 0x02)
                        {
                            labelRSN.Invoke(delegate
                            {
                                int len = 14;
                                byte[] b = new byte[len];
                                string s = "";
                                for (int i = 0; i < len; i++)
                                {
                                    b[i] = data[i + 8];
                                }
                                for (int i = 0; i < len; i++)
                                {
                                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                    char[] ascii = aSCIIEncoding.GetChars(b);
                                    s += ascii[i];
                                }
                                labelRSN.Text = s;
                                labelRSN.BackColor = Color.Green;
                            });

                            if (checkDouble(data))
                                {
                                    labelLSN.Invoke(delegate
                                    {
                                        int len = 14;
                                        byte[] b = new byte[len];
                                        string s = "";
                                        for (int i = 0; i < len; i++)
                                        {
                                            b[i] = data[i + data.Length / 2 + 8];
                                        }
                                        for (int i = 0; i < len; i++)
                                        {
                                            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                            char[] ascii = aSCIIEncoding.GetChars(b);
                                            s += ascii[i];
                                        }
                                        labelLSN.Text = s;
                                        labelLSN.BackColor = Color.Green;
                                    });
                                
                            }
                            else
                            {
                                labelLSN.Invoke(delegate
                                {
                                    labelLSN.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        };
                        saveLog("左耳SN" + (labelLSN.Text.Equals("") ? "获取失败" : labelLSN.Text));
                        saveLog("右耳SN" + (labelRSN.Text.Equals("") ? "获取失败" : labelRSN.Text));
                        checkCommendAuto();

                        break;
                    case 0x18:
                        sendCommendGetSN();
                        break;
                    case 0x1A:
                        if (data[7] == 0x01)
                        {
                            labelLProduct.Invoke(delegate
                            {
                                int len = 10;
                                byte[] b = new byte[len];
                                string s = "";
                                for (int i = 0; i < len; i++)
                                {
                                    b[i] = data[i + 8];
                                }
                                for (int i = 0; i < len; i++)
                                {
                                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                    char[] ascii = aSCIIEncoding.GetChars(b);
                                    s += ascii[i];
                                }
                                labelLProduct.Text = s;
                                labelLProduct.BackColor = Color.Green;
                            });

                            if (checkDouble(data))
                            {
                                labelRProduct.Invoke(delegate
                                {
                                    int len = 10;
                                    byte[] b = new byte[len];
                                    string s = "";
                                    for (int i = 0; i < len; i++)
                                    {
                                        b[i] = data[i + data.Length / 2 + 8];
                                    }
                                    for (int i = 0; i < len; i++)
                                    {
                                        ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                        char[] ascii = aSCIIEncoding.GetChars(b);
                                        s += ascii[i];
                                    }
                                    labelRProduct.Text = s;
                                    labelRProduct.BackColor = Color.Green;
                                });
                            }
                            else
                            {
                                labelRProduct.Invoke(delegate
                                {
                                    labelRProduct.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        }
                        else if (data[7] == 0x02)
                        {
                            labelRProduct.Invoke(delegate
                            {
                                int len = 10;
                                byte[] b = new byte[len];
                                string s = "";
                                for (int i = 0; i < len; i++)
                                {
                                    b[i] = data[i + 8];
                                }
                                for (int i = 0; i < len; i++)
                                {
                                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                    char[] ascii = aSCIIEncoding.GetChars(b);
                                    s += ascii[i];
                                }
                                labelRProduct.Text = s;
                                labelRProduct.BackColor = Color.Green;
                            });

                            if (checkDouble(data))
                            {
                                labelLProduct.Invoke(delegate
                                {
                                    int len = 10;
                                    byte[] b = new byte[len];
                                    string s = "";
                                    for (int i = 0; i < len; i++)
                                    {
                                        b[i] = data[i + data.Length / 2 + 8];
                                    }
                                    for (int i = 0; i < len; i++)
                                    {
                                        ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                        char[] ascii = aSCIIEncoding.GetChars(b);
                                        s += ascii[i];
                                    }
                                    labelLProduct.Text = s;
                                    labelLProduct.BackColor = Color.Green;
                                });
                            }
                            else
                            {
                                labelLProduct.Invoke(delegate
                                {
                                    labelLProduct.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        };
                        saveLog("左耳产品型号" + (labelLProduct.Text.Equals("") ? "获取失败" : labelLProduct.Text));
                        saveLog("右耳产品型号" + (labelRProduct.Text.Equals("") ? "获取失败" : labelRProduct.Text));
                        checkCommendAuto();

                        break;
                    case 0x1B:
                        sendCommendGetSKU();
                        break;
                    case 0x1C:
                        if (data[7] == 0x01)
                        {
                            labelLCaseSN.Invoke(delegate
                            {
                                int len = 15;
                                byte[] b = new byte[len];
                                string s = "";
                                for (int i = 0; i < len; i++)
                                {
                                    b[i] = data[i + 8];
                                }
                                for (int i = 0; i < len; i++)
                                {
                                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                    char[] ascii = aSCIIEncoding.GetChars(b);
                                    s += ascii[i];
                                }
                                labelLCaseSN.Text = s;
                                labelLCaseSN.BackColor = Color.Green;
                            });

                            if (checkDouble(data))
                            {
                                labelRCaseSN.Invoke(delegate
                                {
                                    int len = 15;
                                    byte[] b = new byte[len];
                                    string s = "";
                                    for (int i = 0; i < len; i++)
                                    {
                                        b[i] = data[i + data.Length / 2 + 8];
                                    }
                                    for (int i = 0; i < len; i++)
                                    {
                                        ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                        char[] ascii = aSCIIEncoding.GetChars(b);
                                        s += ascii[i];
                                    }
                                    labelRCaseSN.Text = s;
                                    labelRCaseSN.BackColor = Color.Green;
                                });
                            }
                            else
                            {
                                labelRCaseSN.Invoke(delegate
                                {
                                    labelRCaseSN.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        }
                        else if (data[7] == 0x02)
                        {
                            labelRCaseSN.Invoke(delegate
                            {
                                int len = 15;
                                byte[] b = new byte[len];
                                string s = "";
                                for (int i = 0; i < len; i++)
                                {
                                    b[i] = data[i + 8];
                                }
                                for (int i = 0; i < len; i++)
                                {
                                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                    char[] ascii = aSCIIEncoding.GetChars(b);
                                    s += ascii[i];
                                }
                                labelRCaseSN.Text = s;
                                labelRCaseSN.BackColor = Color.Green;
                            });

                            if (checkDouble(data))
                            {
                                labelLCaseSN.Invoke(delegate
                                {
                                    int len = 15;
                                    byte[] b = new byte[len];
                                    string s = "";
                                    for (int i = 0; i < len; i++)
                                    {
                                        b[i] = data[i + data.Length / 2 + 8];
                                    }
                                    for (int i = 0; i < len; i++)
                                    {
                                        ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                                        char[] ascii = aSCIIEncoding.GetChars(b);
                                        s += ascii[i];
                                    }
                                    labelLCaseSN.Text = s;
                                    labelLCaseSN.BackColor = Color.Green;
                                });
                            }
                            else
                            {
                                labelLCaseSN.Invoke(delegate
                                {
                                    labelLCaseSN.BackColor = Color.Red;
                                    Status = 2;
                                });
                            }
                        };
                        saveLog("左耳充电盒SN" + (labelLCaseSN.Text.Equals("") ? "获取失败" : labelLCaseSN.Text));
                        saveLog("右耳充电盒SN" + (labelRCaseSN.Text.Equals("") ? "获取失败" : labelRCaseSN.Text));
                        checkCommendAuto();
                        break;
                    case 0x1D:
                        sendCommendGetCaseSN();
                        break;
                    case 0x30:
                        break;
                    case 0x31:
                        saveLog("Ship成功");
                        break;
                    case 0x32:
                        saveLog("Reset成功");
                        checkCommendAuto();
                        break;
                }
            }
        }

        public void ReceiveFlag(byte[] data)
        {
            switch (data[4])
            {
                case 0x10:
                    saveLog("获取颜色失败");
                    break;
                case 0x12:
                    saveLog("获取硬件版本失败");
                    break;
                case 0x14:
                    saveLog("获取软件版本失败");
                    break;
                case 0x15:
                    saveLog("获取电量失败");
                    break;
                case 0x16:
                    saveLog("获取MFI失败");
                        break;
                case 0x17:
                    saveLog("获取SN失败");
                    break;
                case 0x1A:
                    saveLog("获取产品型号失败");
                    break;
                case 0x1C:
                    saveLog("获取充电盒SN失败");
                    break;
            }
            mStatus = 1;
            checkCommendAuto();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Status)
            {
                case 0:
                    labelStatue.Text = "SUCCESS";
                    labelStatue.BackColor = Color.Green;
                    break;
                case 1:
                    labelStatue.Text = "";
                    labelStatue.BackColor = Color.White;
                    break;
                case 2:
                    labelStatue.Text = "FAIL";
                    labelStatue.BackColor = Color.Red;
                    mStatus = 1;
                    break;
            }
            if (flag == 0)
            {
                textBoxScanBle.ReadOnly = false;
                textBoxScanSN.ReadOnly = false;
                textBoxScanCaseSN.ReadOnly = false;

                buttonSetDeviceColor.Enabled = false;
                buttonSetHardVersion.Enabled = false;
                buttonResetMode.Enabled = false;
                buttonEnterShipMode.Enabled = false;


            }
            else
            {
                textBoxScanBle.ReadOnly = true;
                textBoxScanSN.ReadOnly = settingBean.IsSetSerialNum;
                textBoxScanCaseSN.ReadOnly = settingBean.IsSetCaseSerialNum;


                buttonSetDeviceColor.Enabled = this.settingBean.IsSetDeviceColor;
                buttonSetHardVersion.Enabled = this.settingBean.IsSetHardVersion;
                buttonResetMode.Enabled = this.settingBean.IsResetMode;
                buttonEnterShipMode.Enabled = this.settingBean.IsEnterShipMode;
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
                    disconnect();
                    flag = 0;
                    Status = 1;
                    currentNode = -1;
                    ClearList();
                }
            }

        }

        private void buttonSetHardVersion_Click(object sender, EventArgs e)
        {
            sendCommendSetHardVersion();
        }

        private void buttonSetDeviceColor_Click(object sender, EventArgs e)
        {
            sendCommendSetColor();
        }

        private void buttonEnterDutMode_Click(object sender, EventArgs e)
        {
            sendCommendDut();
        }

        private void buttonEnterShipMode_Click(object sender, EventArgs e)
        {
            sendCommendShip();
        }

        private void buttonResetMode_Click(object sender, EventArgs e)
        {
            sendCommendReset();
        }

        private bool checkResetStatue()
        {
            if (mStatus != 0)
            {
                return false;
            }
            return true;
        }
    }
}