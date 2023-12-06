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
using GS_1406;
using GS_1406.forms;
using ToolTest2.Bean;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ToolTest2.forms
{
    public partial class FormStart : Form
    {
        public SerialPort serialPort;
        private SettingBean settingBean;
        Dictionary<string, SettingBean> settings = new Dictionary<string, SettingBean>();
        private int select = 0;
        public FormStart()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox1.Text = comboBox1.SelectedItem.ToString();
            comboBoxMode.SelectedIndex = 0;
            comboBoxMode.Text = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            try
            {
                if (fs.Length > 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    settings = bf.Deserialize(fs) as Dictionary<string, SettingBean>;
                    foreach (SettingBean settingBeanItem in settings.Values)
                    {
                        this.settingBean = settingBeanItem;
                    }

                    serialPort = new SerialPort();
                    serialPort.PortName = this.settingBean.PortName; ; // 端口号
                    serialPort.Encoding = Encoding.GetEncoding("UTF-8");
                    serialPort.BaudRate = 921600; // 写死  串口通信的波特率
                    serialPort.Open(); // 打开串口
                }
                else
                {
                    string[] Ports = SerialPort.GetPortNames();
                    if (Ports.Length > 0)
                    {
                        string s = Ports[0].ToUpper();
                        Regex reg = new Regex("[^COM\\d]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        s = reg.Replace(s, "");
                        serialPort = new SerialPort();
                        serialPort.PortName = s; ; // 端口号
                        serialPort.Encoding = Encoding.GetEncoding("UTF-8");
                        serialPort.BaudRate = 921600; // 写死  串口通信的波特率
                        serialPort.Open(); // 打开串口
                    }
                    else
                    {
                        MessageBox.Show("未识别到端口");
                        fs.Close();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("端口打开失败");
            }
            fs.Close();

            Thread t1 = new Thread(delegate ()
            {
                if (select == 0)
                {
                    Form1 frm = new Form1();
                    frm.Tag = serialPort;
                    frm.ShowDialog();
                }
                else if (select == 1)
                {
                    Form2 frm = new Form2();
                    frm.Tag = serialPort;
                    frm.ShowDialog();
                }
                else if (select == 2)
                {
                    //FormMFI frm = new FormMFI();
                    //frm.Tag = serialPort;
                    //frm.ShowDialog();
                }
            });
            t1.Start();
            Close();

        }

        private void FormStart_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            select = this.comboBoxMode.SelectedIndex;
        }
    }
}
