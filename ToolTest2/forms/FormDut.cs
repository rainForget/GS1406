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
    public partial class FormDut : Form
    {
        SppUtil sp;
        private string BlueToothReceivedData, Msg;
        private int falg = 0, Status = 1;//0成功，1超时，2失败
        private SettingBean settingBean;
        private SerialPort serialPort;
        Dictionary<string, SettingBean> settings = new Dictionary<string, SettingBean>();

        public FormDut()
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
                if (settings.ContainsKey(settingBean.SoftVersion))
                {
                    //如果有清掉
                    settings.Remove(settingBean.SoftVersion);
                }
                settings.Add(settingBean.SoftVersion, settingBean);
                bf.Serialize(fs, settings);//new  {Name = user.username, Password  = user.password}
            }
            fs.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 12)
            {
                ClearList();
                string dateString = ">SPP_CONN=" + textBox1.Text;
                sp.sendCommend(dateString);
            }
        }

        private void FormDut_Load(object sender, EventArgs e)
        {
            serialPort = (SerialPort)this.Tag;
            sp = new SppUtil(serialPort);
            sp.openDataReceive();
            sp.receiveDelegateString += dateReceive;
            sp.receiveDelegate += dateReceive;
        }


        private void ClearList()
        {
            BlueToothReceivedData = "";
            textBoxList.Text = "";
            Msg = "";
            textBoxMessage.Text = "";
            Status = 1;
        }


        public void dateReceive(string date)
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
                Status = 0;
                falg = 1;
                GetMFI();
            }
            if (date.Contains("SppDisconnectInd,spp_disconnect_abnormal_disconnect"))
            {
                Status = 0;
                falg = 0;
            }
        }

        public void dateReceive(byte[] data)
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
                    Msg = "指令发送失败";
                    Status = 2;
                    return;
                }
                Status = 0;
                switch (data[4])
                {
                    case 0x30:
                        if (data[6] == 0x00)
                        {
                            Status = 0;
                            Msg = "进入DUT模式";
                        }
                        else
                        {
                            Status = 2;
                            Msg = "DUT失败";
                        }
                        break;
                    case 0x16:
                        labelMfi.Invoke(delegate
                        {
                            if (data[7] == 0x00)
                            {
                                labelMfi.Text = "MFI chip is OK";
                                labelMfi.BackColor = Color.Green;
                                EnterDutMode();
                            }
                            else
                            {
                                labelMfi.Text = "MFI chip is not OK";
                                labelMfi.BackColor = Color.Red;
                            }
                        });
                        break;
                }
            }
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
            await sp.sendCommend(dataBytes);
        }

        private async void GetMFI()
        {
            ClearList();
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0x05;
            dataBytes[1] = 0x5A;
            dataBytes[2] = 0x02;
            dataBytes[3] = 0x00;
            dataBytes[4] = 0x16;
            dataBytes[5] = 0x00;
            await sp.sendCommend(dataBytes);
        }

        private void timer1_Tick(object sender, EventArgs e)
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
            }
            else
            {
                buttonDis.Enabled = true;
                textBox1.Enabled = false;
            }
            textBoxList.Text = BlueToothReceivedData;
            textBoxMessage.Text = Msg;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
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
                }
            }
        }

        private void buttonDis_Click(object sender, EventArgs e)
        {
            try
            {
                ClearList();
                String dateString = ">DISC";
                sp.sendCommend(dateString);
                falg = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
