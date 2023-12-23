using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS1406.Util;
using ToolTest2.Bean;
using ToolTest2.forms;
using ToolTest2.Util;

namespace GS_1406.forms
{
    public partial class Form2 : Form
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
        private int year, month, day, hour, minute, second;
        private string bleAdr = "";
        private int earCode = 0x00;
        private bool isDouble = false;
        private string text1 = "", text2 = "";
        public Form2()
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
            checkList();
        }

        public void checkList()
        {
            this.settingsList.Clear();
            this.settingsList.Add(this.settingBean.IsGetDeviceColor);//获取设备颜色
            this.settingsList.Add(this.settingBean.IsGetHardVersion);//获取硬件版本
            this.settingsList.Add(this.settingBean.IsGetSoftVersion);//获取软件版本
            this.settingsList.Add(this.settingBean.IsGetBatteryLevel);//获取电量
            this.settingsList.Add(this.settingBean.IsGetMfiStatus);//获取MFI
            this.settingsList.Add(this.settingBean.IsGetSerialNum);//获取设备SN
            this.settingsList.Add(this.settingBean.IsGetCaseSerialNum);//获取盒子SN
            this.settingsList.Add(this.settingBean.IsGetProductId);//获取产品型号
            isDouble = this.settingBean.IsDouble;
        }

        private void Form2_Load(object sender, EventArgs e)
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
                saveLog(DateTime.Now + "");
                saveLog("write  >>   " + dateString);
                flag = 0;
                currentNode = -1;
                autoFlag = true;
                mStatus = 1;
                bleAdr = "";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void ClearList()
        {
            textBoxScanBle.Text = "";

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
            if (textBoxScanBle.Text.Length == 12)
            {
                bleAdr = textBoxScanBle.Text;
                clearMsg();
                getTime();
                saveLog(DateTime.Now + "");
                saveLog(textBoxScanBle.Text);
                connect();
            }
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
                        sendCommendGetColor();
                        break;
                    case 1:
                        sendCommendGetHardVersion();
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
                        sendCommendGetSN();
                        break;
                    case 6:
                        sendCommendGetSKU();
                        break;
                    case 7:
                        sendCommendGetCaseSN();
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
                string adr = year + "/" + month + "/" + day;
                string adrssPass = "", adrssFail = "";
                StreamWriter streamWriter;

                if (!Directory.Exists(adr))
                {
                    Directory.CreateDirectory(adr);
                }
                adrssPass = adr + "/" + bleAdr + "_" + (hour.ToString().Length == 2 ? hour : "0" + hour) + (minute.ToString().Length == 2 ? minute : "0" + minute) + (second.ToString().Length == 2 ? second : "0" + second) + "_log_pass.txt";
                adrssFail = adr + "/" + bleAdr + "_" + (hour.ToString().Length == 2 ? hour : "0" + hour) + (minute.ToString().Length == 2 ? minute : "0" + minute) + (second.ToString().Length == 2 ? second : "0" + second) + "_log_fail.txt";
                if (mStatus == 1)
                {
                    if (!File.Exists(adrssFail))
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(adrssPass, bleAdr + "_" + (hour.ToString().Length == 2 ? hour : "0" + hour) + (minute.ToString().Length == 2 ? minute : "0" + minute) + (second.ToString().Length == 2 ? second : "0" + second) + "_log_fail.txt");
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
                mStatus = 1;
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
                saveLog("连接断开");
                Status = 1;
                
            }
            if (date.Contains("a_2dp_operation_fail"))
            {
                Status = 2;
                mStatus = 1;
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

        public bool isSingleError(byte bytes)
        {
            if (earCode == 0x00)
            {
                earCode = bytes;
            }
            else if (earCode != bytes)
            {
                Status = 2;

                saveLog("左右耳异常");
                return false;
            }
            return true;
        }

        public void updataUI(int tabInt, byte[] data, bool isTwo)
        {
            switch (tabInt)
            {
                case 0x101:
                    text1 = "";
                    labelLColor.Invoke(delegate
                    {
                        labelLColor.BackColor = Color.Green;
                        if (isTwo ? data[data.Length / 2 + 8] == 0x01 : data[8] == 0x01)
                        {
                            labelLColor.Text = "black";
                        }
                        else if (isTwo ? data[data.Length / 2 + 8] == 0x02 : data[8] == 0x02)
                        {
                            labelLColor.Text = "white";
                        }
                        else
                        {
                            Status = 2;
                            labelLColor.BackColor = Color.Red;
                        }
                    });
                    text1 = labelLColor.Text;
                    break;
                case 0x102:
                    text2 = "";
                    labelRColor.Invoke(delegate
                    {
                        labelRColor.BackColor = Color.Green;
                        if (isTwo ? data[data.Length / 2 + 8] == 0x01 : data[8] == 0x01)
                        {
                            labelRColor.Text = "black";
                        }
                        else if (isTwo ? data[data.Length / 2 + 8] == 0x02 : data[8] == 0x02)
                        {
                            labelRColor.Text = "white";
                        }
                        else
                        {
                            Status = 2;
                            labelRColor.BackColor = Color.Red;
                        }
                    });
                    text2 = labelRColor.Text;
                    break;
                case 0x121:
                    text1 = "";
                    labelLHardVersion.Invoke(delegate
                    {
                        labelLHardVersion.BackColor = Color.Green;
                        int a = isTwo ? data[data.Length / 2 + 8] / 16 : data[8] / 16;
                        int b = isTwo ? data[data.Length / 2 + 8] % 16 : data[8] % 16;
                        labelLHardVersion.Text = a + "." + b;

                    });
                    text1 = labelLHardVersion.Text;
                    break;
                case 0x122:
                    text2 = "";
                    labelRHardVersion.Invoke(delegate
                    {
                        labelRHardVersion.BackColor = Color.Green;
                        int a = isTwo ? data[data.Length / 2 + 8] / 16 : data[8] / 16;
                        int b = isTwo ? data[data.Length / 2 + 8] % 16 : data[8] % 16;
                        labelRHardVersion.Text = a + "." + b;

                    });
                    text2 = labelRHardVersion.Text;
                    break;
                case 0x141:
                    text1 = "";
                    labelLSoftVersion.Invoke(delegate
                    {
                        int a = isTwo ? data[data.Length / 2 + 9] : data[9];
                        int b = isTwo ? data[data.Length / 2 + 8] / 16 : data[8] / 16;
                        int c = isTwo ? data[data.Length / 2 + 8] % 16 : data[8] % 16;
                        labelLSoftVersion.Text = a + "." + b + "." + c;
                        labelLSoftVersion.BackColor = Color.Green;
                        if (!labelLSoftVersion.Text.Equals(settingBean.SoftVersion))
                        {
                            labelLSoftVersion.BackColor = Color.Red;
                            //MessageBox.Show("软件版本异常");
                            Status = 2;
                        }
                    });
                    text1 = labelLSoftVersion.Text;
                    break;
                case 0x142:
                    text2 = "";
                    labelRSoftVersion.Invoke(delegate
                    {
                        int a = isTwo ? data[data.Length / 2 + 9] : data[9];
                        int b = isTwo ? data[data.Length / 2 + 8] / 16 : data[8] / 16;
                        int c = isTwo ? data[data.Length / 2 + 8] % 16 : data[8] % 16;
                        labelRSoftVersion.Text = a + "." + b + "." + c;
                        labelRSoftVersion.BackColor = Color.Green;
                        if (!labelRSoftVersion.Text.Equals(settingBean.SoftVersion))
                        {
                            labelRSoftVersion.BackColor = Color.Red;
                            //MessageBox.Show("软件版本异常");
                            Status = 2;
                        }
                    });
                    text2 = labelRSoftVersion.Text;
                    break;
                case 0x151:
                    text1 = "";
                    labelLBattery.Invoke(delegate
                    {
                        int battey = isTwo ? data[data.Length / 2 + 8] : data[8];
                        labelLBattery.Text = battey.ToString();
                        if(battey < int.Parse(settingBean.BatteryValueMin) || battey > int.Parse(settingBean.BatteryValueMax))
                        {
                            Status = 2;
                            labelLBattery.BackColor = Color.Red;
                        }
                        else
                        {
                            labelLBattery.BackColor = Color.Green;
                        }
                    });
                    text1 = labelLBattery.Text;
                    break;
                case 0x152:
                    text2 = "";
                    labelRBattery.Invoke(delegate
                    {
                        int battey = isTwo ? data[data.Length / 2 + 8] : data[8];
                        labelRBattery.Text = battey.ToString();
                        if (battey < int.Parse(settingBean.BatteryValueMin) || battey > int.Parse(settingBean.BatteryValueMax))
                        {
                            Status = 2;
                            labelRBattery.BackColor = Color.Red;
                        }
                        else
                        {
                            labelRBattery.BackColor = Color.Green;
                        }
                    });
                    text2 = labelRBattery.Text;
                    break;
                case 0x161:
                    text1 = "";
                    labelLMFI.Invoke(delegate
                    {
                        if (isTwo ? data[data.Length / 2 + 8] == 0x00 : data[8] == 0x00)
                        {
                            labelLMFI.Text = "Pass";
                            labelLMFI.BackColor = Color.Green;
                        }
                        else
                        {
                            Status = 2;
                            labelLMFI.Text = "Fail";
                            labelLMFI.BackColor = Color.Red;
                        }
                    });
                    text1 = labelLMFI.Text;
                    break;
                case 0x162:
                    text2 = "";
                    labelRMFI.Invoke(delegate
                    {
                        if (isTwo ? data[data.Length / 2 + 8] == 0x00 : data[8] == 0x00)
                        {
                            labelRMFI.Text = "Pass";
                            labelRMFI.BackColor = Color.Green;
                        }
                        else
                        {
                            Status = 2;
                            labelRMFI.Text = "Fail";
                            labelRMFI.BackColor = Color.Red;
                        }
                    });
                    text2 = labelRMFI.Text;
                    break;
                case 0x171:
                    text1 = "";
                    labelLSN.Invoke(delegate
                    {
                        int len = 14;
                        byte[] b = new byte[len];
                        string s = "";
                        for (int i = 0; i < len; i++)
                        {
                            b[i] = isTwo ? data[data.Length / 2 + i + 8] : data[i + 8];
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
                    text1 = labelLSN.Text;
                    break;
                case 0x172:
                    text2 = "";
                    labelRSN.Invoke(delegate
                    {
                        int len = 14;
                        byte[] b = new byte[len];
                        string s = "";
                        for (int i = 0; i < len; i++)
                        {
                            b[i] = isTwo ? data[data.Length / 2 + i + 8] : data[i + 8];
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
                    text2 = labelRSN.Text;
                    break;
                case 0x1A1:
                    text1 = "";
                    labelLProduct.Invoke(delegate
                    {
                        int len = 10;
                        byte[] b = new byte[len];
                        string s = "";
                        for (int i = 0; i < len; i++)
                        {
                            b[i] = isTwo ? data[data.Length / 2 + i + 8] : data[i + 8];
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
                    text1 = labelLProduct.Text;
                    break;
                case 0x1A2:
                    text2 = "";
                    labelRProduct.Invoke(delegate
                    {
                        int len = 10;
                        byte[] b = new byte[len];
                        string s = "";
                        for (int i = 0; i < len; i++)
                        {
                            b[i] = isTwo ? data[data.Length / 2 + i + 8] : data[i + 8];
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
                    text2 = labelRProduct.Text;
                    break;
                case 0x1C1:
                    text1 = "";
                    labelLCaseSN.Invoke(delegate
                    {
                        int len = 15;
                        byte[] b = new byte[len];
                        string s = "";
                        for (int i = 0; i < len; i++)
                        {
                            b[i] = isTwo ? data[data.Length / 2 + i + 8] : data[i + 8];
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
                    text1 = labelLCaseSN.Text;
                    break;
                case 0x1C2:
                    text2 = "";
                    labelRCaseSN.Invoke(delegate
                    {
                        int len = 15;
                        byte[] b = new byte[len];
                        string s = "";
                        for (int i = 0; i < len; i++)
                        {
                            b[i] = isTwo ? data[data.Length / 2 + i + 8] : data[i + 8];
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
                    text2 = labelRCaseSN.Text;
                    break;
            }

        }

        public void receiveDataCommend(byte[] data, int value1, int value2, string msg1, string msg2)
        {
            if (!isDouble && !checkDouble(data))
            {
                if (!isSingleError(data[7]))
                {
                    MessageBox.Show("左右耳异常");
                    return;
                }
                if (data[7] == 0x01)
                {
                    updataUI(value1, data, false);
                    saveLog(msg1 + (text1.Equals("") ? "获取失败" : text1));
                }
                else
                {
                    updataUI(value2, data, false);
                    saveLog(msg2 + (text2.Equals("") ? "获取失败" : text2));
                }
            }
            else if (isDouble && checkDouble(data))
            {
                if (data[7] == 0x01)
                {
                    updataUI(value1, data, false);
                    updataUI(value2, data, true);
                }
                else
                {
                    updataUI(value1, data, true);
                    updataUI(value2, data, false);
                }
                saveLog(msg1 + (text1.Equals("") ? "获取失败" : text1));
                saveLog(msg2 + (text2.Equals("") ? "获取失败" : text2));
            }
            else
            {
                Status = 2;
                MessageBox.Show("单双耳异常");
                saveLog("单双耳异常");
            }
            if (Status == 0)
                checkCommendAuto();
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
            if (data[0] == 0x05 && data[1] == 0x5B)
            {
                Status = 0;
                switch (data[4])
                {
                    case 0x10:
                        receiveDataCommend(data, 0x101, 0x102, "左耳颜色", "右耳颜色");
                        break;
                    case 0x11:
                        sendCommendGetColor();
                        break;
                    case 0x12:
                        receiveDataCommend(data, 0x121, 0x122, "左耳硬件版本", "右耳硬件版本");
                        break;
                    case 0x13:
                        sendCommendGetHardVersion();
                        break;
                    case 0x14:
                        receiveDataCommend(data, 0x141, 0x142, "左耳软件版本", "右耳软件版本");
                        break;
                    case 0x15:
                        receiveDataCommend(data, 0x151, 0x152, "左耳电量", "右耳电量");
                        break;
                    case 0x16:
                        receiveDataCommend(data, 0x161, 0x162, "左耳MFI Chip check", "右耳MFI Chip check");
                        break;
                    case 0x17:
                        receiveDataCommend(data, 0x171, 0x172, "左耳SN", "右耳SN");
                        break;
                    case 0x18:
                        sendCommendGetSN();
                        break;
                    case 0x1A:
                        receiveDataCommend(data, 0x1A1, 0x1A2, "左耳产品型号", "右耳产品型号");
                        break;
                    case 0x1B:
                        sendCommendGetSKU();
                        break;
                    case 0x1C:
                        receiveDataCommend(data, 0x1C1, 0x1C2, "左耳充电盒SN", "右耳充电盒SN");
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

            }
            else
            {
                textBoxScanBle.ReadOnly = true;
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

