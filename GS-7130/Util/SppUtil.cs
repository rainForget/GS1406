﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms.VisualStyles;
using GS1406.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ToolTest2.Util
{
    public class SppUtil
    {
        public SerialPort SeriaPort1;
        public int flag = 0;
        public System.Timers.Timer timer;
        public byte[] currentData;
        public Boolean ReceiveFlag = false;
        public int failNumber = 0;
        Dictionary<string, string> logList = new Dictionary<string, string>();

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

        /// <summary>
        /// 获取定时任务委托
        /// </summary>
        public delegate void ReceiveDelegateFlag(byte[] bytes );
        /// <summary>
        /// 获取定时任务事件
        /// </summary>
        public event ReceiveDelegateFlag receiveDeleteFlag;

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
                saveLog(DateTime.Now + "");
                saveLog(dateString);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public async Task sendCommend(byte[] dataBytes)
        {
            SeriaPort1.Write(dataBytes, 0, dataBytes.Length);
            saveLog(DateTime.Now + "");
            saveLog("发送指令");
            saveLog(FormateUtil.byteArrayToHexString(dataBytes));
            timer = new System.Timers.Timer(3000);
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Interval = 3000;
            timer.AutoReset = false;
            ReceiveFlag = false;
            currentData = dataBytes;
            timer.Enabled = true;
            timer.Start();
        }

        private  void timer_Tick(object sender, ElapsedEventArgs e)
        {
            if(!ReceiveFlag) {
                if (this.failNumber < 1)
                {
                    this.failNumber += 1;
                    timer.Stop();
                    sendCommend(currentData);
                }
                else
                {
                    receiveDeleteFlag(currentData);
                    timer.Stop();
                    this.failNumber = 0;
                }
                
            }
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
                    if (data[4] == currentData[4])
                    {
                        ReceiveFlag = true;
                        timer.Stop();
                        this.failNumber = 0;

                    }
                    receiveDelegate(data);
                }
            }catch(Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }

        private void saveLog(byte[] bytes)
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
                StreamWriter s = new StreamWriter(adrss, true);
                foreach (byte b in bytes)
                {
                    s.Write(b);
                    //stringWriter.Write(b);
                }
                s.WriteLine();
                s.Close();


                //FileStream fs = new FileStream(adr + "/" + "log.bin", FileMode.OpenOrCreate);

                //foreach (byte b in bytes)
                //{
                //    fs.WriteByte(b);
                //   //stringWriter.Write(b);
                //}
                //fs.Close();
                ////stringWriter.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("日志存储异常" + ex.Message);
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
