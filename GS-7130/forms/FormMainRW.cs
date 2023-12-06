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
using System.Windows.Forms.VisualStyles;
using GS_7130.Bean;
using GS1406.Util;
using ToolTest2.forms;
using ToolTest2.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GS_7130.forms
{
    public partial class FormMainRW : Form
    {
        SppUtil sp;
        private string BlueToothReceivedData, Msg;
        private int Status = 1;//0成功，1超时，2失败
        private int flag = 0;//0-未连接，1-已连接
        private SettingBean settingBean;
        private SerialPort serialPort;
        Dictionary<string, SettingBean> settings = new Dictionary<string, SettingBean>();
        List<Boolean> settingsList = new List<bool> { };
        Boolean autoFlag = true;
        private int currentNode = -1;
        public FormMainRW()
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
            textBoxProductId.Text = this.settingBean.ProductId;
            textBoxScanSN.Enabled = this.settingBean.IsScanSN;
            checkList();
        }

        public void checkList()
        {
            this.settingsList.Clear();
            //0-设置序列号
            this.settingsList.Add(this.settingBean.IsScanSN);
            //1-获取序列号
            this.settingsList.Add(true);
            //2-获取软件版本
            this.settingsList.Add(true);
            //3-设置设备号
            this.settingsList.Add(true);
            //4-获取设备号
            this.settingsList.Add(true);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            serialPort = (SerialPort)this.Tag;
            sp = new SppUtil(serialPort);
            sp.openDataReceive();
            sp.receiveDelegateString += dataReceive;
            sp.receiveDelegate += dataReceive;
            sp.receiveDeleteFlag += ReceiveFlag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClearList();
                String dateString = ">DISC";
                sp.sendCommend(dateString);
                Status = 1;
                flag = 0;
                currentNode = -1;
                autoFlag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ClearList()
        {
            BlueToothReceivedData = "";
            labelStatue.Text = "";

            textBoxScanBle.Text = "";
            textBoxScanBle.BackColor = Color.White;
            textBoxScanSN.Text = "";
            textBoxScanSN.BackColor = Color.White;
            textBoxSN.Text = "";
            textBoxSN.BackColor = Color.White;
            textBoxReProductId.Text = "";
            textBoxReProductId.BackColor = Color.White;
            textBoxSoftVersion.Text = "";
            textBoxSoftVersion.BackColor = Color.White;
        }

        private void clearMsg()
        {
            labelStatue.Text = "";
            labelStatue.BackColor = Color.White;
        }

        private void textBoxScanBle_TextChanged(object sender, EventArgs e)
        {
            if (textBoxScanBle.Text.Length == 12 && !textBoxScanSN.Enabled)
            {
                string dateString = ">SPP_CONN=" + textBoxScanBle.Text;
                sp.sendCommend(dateString);
            }
        }

        private void textBoxScanSN_TextChanged(object sender, EventArgs e)
        {
            if (textBoxScanBle.Text.Length == 12 && textBoxScanSN.Text.Length == 14)
            {
                string dateString = ">SPP_CONN=" + textBoxScanBle.Text;
                sp.sendCommend(dateString);
            }
        }

        private void sendCommendAuto()
        {
            currentNode += 1;
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
                        sendCommendSetSN();
                        break;
                    case 1:
                        sendCommendGetSN();
                        break;
                    case 2:
                        sendCommendGetVersion();
                        break;
                    case 3:
                        sendCommendSetSKU();
                        break;
                    case 4:
                        sendCommendGetSKU();
                        break;
                }
            }
            else
            {
                if (autoFlag)
                    sendCommendAuto();
            }
        }



        private void sendCommendGetVersion()
        {
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x14;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private void sendCommendSetSN()
        {
            clearMsg();
            string s = "";
            s = textBoxScanSN.Text;

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
        }

        private void sendCommendGetSN()
        {
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x17;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        private void sendCommendSetSKU()
        {
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
        }

        private void sendCommendGetSKU()
        {
            clearMsg();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x1A;
            dataBytes[5] = 0x00;
            sp.sendCommend(dataBytes);
        }

        public void dataReceive(string date)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            BlueToothReceivedData += date;
            saveLog(DateTime.Now + "");
            saveLog(date);
            if (date.Contains("SDP_SEARCH_FAILED"))
            {
                Status = 2;
                Msg = "连接失败";
            }
            if (date.Contains(">SPP_CONNECT"))
            {
                Thread.Sleep(2000);
                Status = 0;
                flag = 1;
              
                sendCommendAuto();
            }
            if (date.Contains("SppDisconnectInd,spp_disconnect_abnormal_disconnect"))
            {
                Thread.Sleep(2000);
                Status = 1;
                flag = 0;
                autoFlag = true;
            }
        }


        public void dataReceive(byte[] data)
        {
            BlueToothReceivedData += DateTime.Now + "\r\n";
            saveLog(DateTime.Now + "");
            BlueToothReceivedData += "返回结果" + "\r\n";
            saveLog("返回结果");
            saveLog(FormateUtil.byteArrayToHexString(data));
            for (int i = 0; i < data.Length; i++)
            {
                BlueToothReceivedData += String.Format("date[" + i + "] = " + data[i] + "\r\n");
            }
            if (data[0] == 0x05 && data[1] == 0x5B)
            {
                if (data[6] != 0x00)
                {
                    if (data[4] == 0x14)
                    {
                        textBoxSoftVersion.Invoke(delegate
                        {
                            textBoxSoftVersion.BackColor = Color.Red;
                        });
                    }

                    if (data[4] == 0x17)
                    {
                        textBoxSN.Invoke(delegate
                        {
                            textBoxSN.BackColor = Color.Red;
                        });
                    }
                    Msg = "指令发送失败";
                    Status = 2;
                    return;
                }
                Status = 0;
                switch (data[4])
                {
                    case 0x14:
                        textBoxSoftVersion.Invoke(delegate
                        {
                            if (autoFlag)
                                sendCommendAuto();
                            //int a = data[8];
                            //int b = data[7] / 16;
                            //int c = data[7] % 16;

                            int a = data[7] / 16;
                            int b = data[7] % 16;
                            int c = data[8] / 16;
                            int d = data[8] % 16;

                            textBoxSoftVersion.Text = a + "." + b + "." + c + "." + d;
                            textBoxSoftVersion.BackColor = Color.Green;
                            if (!textBoxSoftVersion.Text.Equals(settingBean.SoftVersion))
                            {
                                textBoxSoftVersion.BackColor = Color.Red;
                                Status = 2;
                            }
                        });
                        break;

                    case 0x17:
                        textBoxSN.Invoke(delegate
                        {
                            if (autoFlag)
                                sendCommendAuto();
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
                            textBoxSN.Text = s;
                            textBoxSN.BackColor = Color.Green;
                        });
                        break;
                    case 0x18:
                        if (autoFlag)
                            sendCommendAuto();
                        break;
                    case 0x1A:
                        textBoxReProductId.Invoke(delegate
                        {
                            if (autoFlag)
                                sendCommendAuto();
                            int len = 10;
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
                            textBoxReProductId.Text = s;
                            textBoxReProductId.BackColor = Color.Green;
                        });
                        break;
                    case 0x1B:
                        if (autoFlag)
                            sendCommendAuto();
                        break;

                }
            }
        }

        public void ReceiveFlag(byte[] data)
        {
            switch (data[4])
            {

                case 0x14:
                    textBoxSoftVersion.Invoke(delegate
                    {
                        Status = 2;
                        textBoxSoftVersion.BackColor = Color.Red;
                    });
                    break;

                case 0x17:
                    textBoxSN.Invoke(delegate
                    {
                        Status = 2;
                        textBoxSN.BackColor = Color.Red;
                    });
                    break;
                case 0x18:
                    textBoxScanSN.Invoke(delegate
                    {
                        Status = 2;
                        textBoxScanSN.BackColor = Color.Red;
                    });
                    break;

                case 0x1A:
                    textBoxReProductId.Invoke(delegate
                    {
                        Status = 2;
                        textBoxReProductId.BackColor = Color.Red;
                    });
                    break;
                case 0x1B:
                    textBoxProductId.Invoke(delegate
                    {
                        Status = 2;
                        textBoxProductId.BackColor = Color.Red;
                    });
                    break;
            }
            sendCommendAuto();
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
                    break;
            }
            if (flag == 0)
            {
                textBoxScanBle.ReadOnly = false;
                textBoxScanSN.ReadOnly = false;
            }
            else
            {
                textBoxScanBle.ReadOnly = true;
                textBoxScanSN.ReadOnly = settingBean.IsScanSN;
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
                    flag = 0;
                    ClearList();
                }
            }

        }

        private void saveLog(string s)
        {
            try
            {
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                string adr = month + "/" + day;

                if (!Directory.Exists(adr))
                {
                    Directory.CreateDirectory(adr);
                }
                string adrss = adr + "/" + "log.bin";
                StreamWriter streamWriter = new StreamWriter(adrss, true);
                streamWriter.WriteLine(s);
                streamWriter.Close();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("日志存储异常" + ex.Message);
            }
        }

    }
}
