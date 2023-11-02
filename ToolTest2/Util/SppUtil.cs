using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS1406.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ToolTest2.Util
{
    public class SppUtil
    {
        public SerialPort SeriaPort1;
        public int flag = 0;

        /// <summary>
        /// 获取数据接收委托
        /// </summary>
        public delegate void ReceiveDelegate(byte[] bytes);
        /// <summary>
        /// 获取数据接收事件
        /// </summary>
        public event ReceiveDelegate receiveDelegate;

        /// <summary>
        /// 获取数据接收委托
        /// </summary>
        public delegate void ReceiveDelegateString(string s);
        /// <summary>
        /// 获取数据接收事件
        /// </summary>
        public event ReceiveDelegateString receiveDelegateString;

        public SppUtil(SerialPort serialPort) { 
            this.SeriaPort1 = serialPort;
        }

        public void openDataReceive()
        {
            SeriaPort1.DataReceived += new SerialDataReceivedEventHandler(BlueToothDataReceived);
        }

        public void closeDataReceived()
        {
            SeriaPort1.DataReceived -= new SerialDataReceivedEventHandler(BlueToothDataReceived);
        }


        public void closePort()
        {
            SeriaPort1.Close();
        }

        public void sendCommend(string dateString)
        {
            try
            {
                SeriaPort1.WriteLine(dateString + "\r\n");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public async Task sendCommend(byte[] dataBytes)
        {
            //if (dataBytes[4] == 0x30)
            //{
            //    MessageBox.Show("已发送");
            //}
             SeriaPort1.Write(dataBytes, 0, dataBytes.Length);
        }

        private void BlueToothDataReceived(object o, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(1000);
            string str = SeriaPort1.ReadExisting(); //以字符串方式读

            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            try
            {
                if (data[0] != 5)
                {
                    receiveDelegateString(str);
                }
                else
                {
                    receiveDelegate(data);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }

}
