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
        private int Status = 1;//0�ɹ���1��ʱ��2ʧ��
        private int mStatus = 0;
        private int flag = 0;//0-δ���ӣ�1-������
        private int getNum = 0;//ָ����մ���
        private SettingBean settingBean;
        private SerialPort serialPort;
        Dictionary<string, SettingBean> settings = new Dictionary<string, SettingBean>();
        Dictionary<string, string> logList = new Dictionary<string, string>();
        List<Boolean> settingsList = new List<bool> { };
        Boolean autoFlag = true;
        private int currentNode = -1;
        private string bleAdr = "", text1 = "", text2 = "";
        private bool isDouble = false;
        private int earCode = 0x00;
        private int year, month, day, hour, minute, second;
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
                    //��������
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
            isDouble = this.settingBean.IsDouble;
            checkList();
        }

        public void checkList()
        {
            this.settingsList.Clear();
            this.settingsList.Add(this.settingBean.IsSetDeviceColor);//��ȡ�豸��ɫ
            this.settingsList.Add(this.settingBean.IsSetHardVersion);//��ȡӲ���汾
            this.settingsList.Add(true);//��ȡ����汾
            this.settingsList.Add(true);//��ȡ����
            this.settingsList.Add(true);//��ȡMFI
            this.settingsList.Add(this.settingBean.IsSetSerialNum);//�����豸SN
            //this.settingsList.Add(this.settingBean.IsGetSerialNum);//��ȡ�豸SN
            this.settingsList.Add(this.settingBean.IsSetProductId);//���ò�Ʒ�ͺ�
            //this.settingsList.Add(this.settingBean.IsGetProductId);//��ȡ��Ʒ�ͺ�
            this.settingsList.Add(this.settingBean.IsSetCaseSerialNum);//���ú���SN
            //this.settingsList.Add(this.settingBean.IsGetCaseSerialNum);//��ȡ����SN
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
            //if (serialPort.IsOpen)
            //{
            //    disconnect();
            //}
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
            labelLShip.Text = "";
            labelLShip.BackColor = Color.White;
            labelRShip.Text = "";
            labelRShip.BackColor = Color.White;
            labelLReset.Text = "";
            labelLReset.BackColor = Color.White;
            labelRReset.Text = "";
            labelRReset.BackColor = Color.White;

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
            bleAdr = textBoxScanBle.Text;
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
                            MessageBox.Show("��ȷ������ָ��ȫ��ͨ��");
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
                    Debug.WriteLine("�ù��ܲ���ȡ");
                    sendCommendAuto();
                }
            }
        }

        private async void sendCommendGetColor()
        {
            saveLog(DateTime.Now + "");
            saveLog("��ȡ�豸��ɫ");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x10;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendSetColor()
        {
            saveLog(DateTime.Now + "");
            saveLog("�����豸��ɫ");
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
                saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
            }
            else
            {
                Status = 2;
            }
        }

        private async void sendCommendGetHardVersion()
        {
            saveLog(DateTime.Now + "");
            saveLog("��ȡӲ���汾");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x12;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendSetHardVersion()
        {
            clearMsg();
            try
            {
                if (textBoxHardVersion.Text != null && textBoxHardVersion.Text.Contains("."))
                {
                    saveLog(DateTime.Now + "");
                    saveLog("����Ӳ���汾");
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
                    saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
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
            saveLog("��ȡ����汾");
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x14;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendGetBatteryLevel()
        {
            saveLog(DateTime.Now + "");
            saveLog("��ȡ�豸����");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x15;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendGetMFI()
        {
            saveLog(DateTime.Now + "");
            saveLog("��ȡMFI״̬");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x16;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendSetSN()
        {
            saveLog(DateTime.Now + "");
            saveLog("����SN");
            clearMsg();
            string s = "";
            s = textBoxScanSN.Text;
            if (textBoxScanSN.Text.Length != 14)
            {
                Status = 2;
                MessageBox.Show("���кų����쳣" + textBoxScanSN.Text.Length);
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
                saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
            }
        }

        private void sendCommendGetSN()
        {
            saveLog(DateTime.Now + "");
            saveLog("��ȡSN");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x17;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private async void sendCommendSetCaseSN()
        {
            saveLog(DateTime.Now + "");
            saveLog("���ó���SN");
            clearMsg();
            string s = "";
            s = textBoxScanCaseSN.Text;
            if (textBoxScanCaseSN.Text.Length != 15)
            {
                Status = 2;
                MessageBox.Show("�������кų����쳣" + textBoxScanCaseSN.Text.Length);
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
                saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
            }
        }

        private void sendCommendGetCaseSN()
        {
            saveLog(DateTime.Now + "");
            saveLog("��ȡ����SN");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x1C;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendSetSKU()
        {
            saveLog(DateTime.Now + "");
            saveLog("���ò�Ʒ�ͺ�");
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
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendGetSKU()
        {
            saveLog(DateTime.Now + "");
            saveLog("��ȡ��Ʒ�ͺ�");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x1A;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendDut()
        {
            saveLog(DateTime.Now + "");
            saveLog("����DUT");
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x30;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }

        private void sendCommendShip()
        {
            saveLog(DateTime.Now + "");
            saveLog("����Shipģʽ");
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
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
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
            saveLog("������Ϣ  >>   " + FormateUtil.byteArrayToHexString(dataBytes));
        }


        private void checkCommendAuto()
        {
            sendCommendAuto();
        }

        private void updateFileName(string adressOld, string adressNew)
        {
            string adr = year + "/" + month + "/" + day;
            string adressOldAll = adr + "/" + adressOld;
            string adressNewAll = adr + "/" + adressNew;

            if (!File.Exists(adressNew))
            {
                if (File.Exists(adressOldAll))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(adressOldAll,adressNew);
                }
            }
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
                adrssPass =  bleAdr + "_" + (hour.ToString().Length == 2 ? hour : "0" + hour) + (minute.ToString().Length == 2 ? minute : "0" + minute) + (second.ToString().Length == 2 ? second : "0" + second) + "_log_pass.txt";
                adrssFail =  bleAdr + "_" + (hour.ToString().Length == 2 ? hour : "0" + hour) + (minute.ToString().Length == 2 ? minute : "0" + minute) + (second.ToString().Length == 2 ? second : "0" + second) + "_log_fail.txt";
                if (Status != 0 )
                {
                    updateFileName(adrssPass,adrssFail);
                    streamWriter = new StreamWriter(adr + "/" + adrssFail, true);
                    streamWriter.WriteLine(s);
                    streamWriter.Close();

                }
                else
                {
                    updateFileName(adrssFail, adrssPass);
                    streamWriter = new StreamWriter(adr + "/" + adrssPass, true);
                    streamWriter.WriteLine(s);
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("��־�洢�쳣" + ex.Message);
            }
        }


        private void saveLogDate(string date)
        {
            saveLog(DateTime.Now + "");
            saveLog("Read >> " + date);
        }


        public void dataReceive(string date)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            BlueToothReceivedData += date;
            

            if (date.Contains("SDP_SEARCH_FAILED"))
            {
                saveLogDate(date);
                Status = 2;
                mStatus = 1;
                saveLog("����ʧ��");
            }
            if (date.Contains(">SPP_CONNECT"))
            {
                saveLogDate(date);
                Thread.Sleep(2000);
                Status = 0;
                flag = 1;
                mStatus = 0;
                saveLog("���ӳɹ�");
                sendCommendAuto();
            }
            if (date.Contains("SppDisconnectInd,spp_disconnect_abnormal_disconnect"))
            {
                saveLogDate(date);
                Thread.Sleep(2000);
                saveLog("���ӶϿ�");
                Status = 1;
                
            }
            if (date.Contains("a_2dp_operation_fail"))
            {
                saveLog(DateTime.Now + "");
                saveLog("Read >> " + date);
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

                saveLog("���Ҷ��쳣");
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
                            //MessageBox.Show("����汾�쳣");
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
                            //MessageBox.Show("����汾�쳣");
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
                        if (battey < int.Parse(settingBean.BatteryValueMin) || battey>int.Parse(settingBean.BatteryValueMax))
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
                        if(battey < int.Parse(settingBean.BatteryValueMin) || battey > int.Parse(settingBean.BatteryValueMax))
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
                case 0x311:
                    text1 = "";
                    labelLShip.Invoke(delegate
                    {
                        if (isTwo ? data[data.Length / 2 + 6] == 0x00 : data[6] == 0x00)
                        {
                            labelLShip.Text = "Pass";
                            labelLShip.BackColor = Color.Green;
                        }
                        else
                        {
                            Status = 2;
                            labelLShip.Text = "Fail";
                            labelLShip.BackColor = Color.Red;
                        }
                    });
                    text1 = labelLShip.Text;
                    break;
                case 0x312:
                    text2 = "";
                    labelRShip.Invoke(delegate
                    {
                        if (isTwo ? data[data.Length / 2 + 6] == 0x00 : data[6] == 0x00)
                        {
                            labelRShip.Text = "Pass";
                            labelRShip.BackColor = Color.Green;
                        }
                        else
                        {
                            Status = 2;
                            labelRShip.Text = "Fail";
                            labelRShip.BackColor = Color.Red;
                        }
                    });
                    text2 = labelRShip.Text;
                    break;
                case 0x321:
                    text1 = "";
                    labelLReset.Invoke(delegate
                    {
                        if (isTwo ? data[data.Length / 2 + 6] == 0x00 : data[6] == 0x00)
                        {
                            labelLReset.Text = "Pass";
                            labelLReset.BackColor = Color.Green;
                        }
                        else
                        {
                            Status = 2;
                            labelLReset.Text = "Fail";
                            labelLReset.BackColor = Color.Red;
                        }
                    });
                    text1 = labelLReset.Text;
                    break;
                case 0x322:
                    text2 = "";
                    labelRReset.Invoke(delegate
                    {
                        if (isTwo ? data[data.Length / 2 + 6] == 0x00 : data[6] == 0x00)
                        {
                            labelRReset.Text = "Pass";
                            labelRReset.BackColor = Color.Green;
                        }
                        else
                        {
                            Status = 2;
                            labelRReset.Text = "Fail";
                            labelRReset.BackColor = Color.Red;
                        }
                    });
                    text2 = labelRReset.Text;
                    break;
            }

        }

        public void receiveDataCommend(byte[] data, int value1, int value2, string msg1, string msg2)
        {
            if (!isDouble && !checkDouble(data))
            {
                if (!isSingleError(data[7]))
                {
                    MessageBox.Show("���Ҷ��쳣");
                    return;
                }
                if (data[7] == 0x01)
                {
                    updataUI(value1, data, false);
                    saveLog(msg1 + (text1.Equals("") ? "��ȡʧ��" : text1));
                }
                else
                {
                    updataUI(value2, data, false);
                    saveLog(msg2 + (text2.Equals("") ? "��ȡʧ��" : text2));
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
                saveLog(msg1 + (text1.Equals("") ? "��ȡʧ��" : text1));
                saveLog(msg2 + (text2.Equals("") ? "��ȡʧ��" : text2));
            }
            else
            {
                Status = 2;
                MessageBox.Show("��˫�������쳣");
                saveLog("��˫�������쳣");
            }
            if (Status == 0)
                checkCommendAuto();
        }

        public void dataReceive(byte[] data)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            saveLog(DateTime.Now + "");
            BlueToothReceivedData += "���ؽ��" + "\r\n";
            saveLog("������Ϣ");
            saveLog(FormateUtil.byteArrayToHexString(data));
            int flagA = 0, flagB = 0;
            for (int i = 0; i < data.Length; i++)
            {
                BlueToothReceivedData += String.Format("date[" + i + "] = " + data[i] + "\r\n");
                if (data[i] == 0x05 && data[i+1] == 0x5B)
                {
                    flagA = i;                    
                }

                if (data[i] == 0x05 && data[i + 1] == 0x5D)
                {
                    flagB = i;
                }

            }
            
            
            if (data[0] == 0x05 && data[1] == 0x5B)
            {
                Status = 0;
                switch (data[4])
                {
                    case 0x10:
                        receiveDataCommend(data, 0x101, 0x102, "�����ɫ", "�Ҷ���ɫ");
                        break;
                    case 0x11:
                        sendCommendGetColor();
                        break;
                    case 0x12:
                        receiveDataCommend(data, 0x121, 0x122, "���Ӳ���汾", "�Ҷ�Ӳ���汾");
                        break;
                    case 0x13:
                        sendCommendGetHardVersion();
                        break;
                    case 0x14:
                        receiveDataCommend(data, 0x141, 0x142, "�������汾", "�Ҷ�����汾");
                        break;
                    case 0x15:
                        receiveDataCommend(data, 0x151, 0x152, "�������", "�Ҷ�����");
                        break;
                    case 0x16:
                        receiveDataCommend(data, 0x161, 0x162, "���MFI Chip check", "�Ҷ�MFI Chip check");
                        break;
                    case 0x17:
                        receiveDataCommend(data, 0x171, 0x172, "���SN", "�Ҷ�SN");
                        break;
                    case 0x18:
                        sendCommendGetSN();
                        break;
                    case 0x1A:
                        receiveDataCommend(data, 0x1A1, 0x1A2, "�����Ʒ�ͺ�", "�Ҷ���Ʒ�ͺ�");
                        break;
                    case 0x1B:
                        sendCommendGetSKU();
                        break;
                    case 0x1C:
                        receiveDataCommend(data, 0x1C1, 0x1C2, "�������SN", "�Ҷ�����SN");
                        break;
                    case 0x1D:
                        sendCommendGetCaseSN();
                        break;
                    case 0x30:
                        break;
                    case 0x31:
                        receiveDataCommend(data, 0x311, 0x312, "���Ship", "�Ҷ�Ship");
                        break;
                    case 0x32:
                        receiveDataCommend(data, 0x321, 0x322, "���Reset", "�Ҷ�Reset");
                        break;
                }
            }
        }

        public void ReceiveFlag(byte[] data)
        {
            switch (data[4])
            {
                case 0x10:
                    saveLog("��ȡ��ɫʧ��");
                    break;
                case 0x12:
                    saveLog("��ȡӲ���汾ʧ��");
                    break;
                case 0x14:
                    saveLog("��ȡ����汾ʧ��");
                    break;
                case 0x15:
                    saveLog("��ȡ����ʧ��");
                    break;
                case 0x16:
                    saveLog("��ȡMFIʧ��");
                    break;
                case 0x17:
                    saveLog("��ȡSNʧ��");
                    break;
                case 0x1A:
                    saveLog("��ȡ��Ʒ�ͺ�ʧ��");
                    break;
                case 0x1C:
                    saveLog("��ȡ����SNʧ��");
                    break;
            }
            Status = 2;
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