using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ToolTest2.Bean
{
    [Serializable]
    public class SettingBean
    {
        //setting
        private Boolean isGetDeviceColor = true;
        private Boolean isSetDeviceColor = true;
        private Boolean isGetHardVersion = true;
        private Boolean isSetHardVersion = true;
        private Boolean isGetSoftVersion = true;
        private Boolean isGetBatteryLevel = true;
        private Boolean isGetMfiStatus = true;
        private Boolean isGetSerialNum = true;
        private Boolean isSetSerialNum = true;
        private Boolean isGetCaseSerialNum = true;
        private Boolean isSetCaseSerialNum = true;
        private Boolean isGetProductId = true;
        private Boolean isSetProductId = true;
        private Boolean isEnterDutMode = true;
        private Boolean isEnterShipMode = true;
        private Boolean isGetChannel = true;
        private Boolean isResetMode = true;
        private string softVersion = "0.3.5";
        private string passWard = "Admin";
        private string portName = "COM3";
        private string batteryValue = "80";
        private string productId = "S2SAW-S749";
        private string color = "black";
        private string hardVersion = "2.0";

     


        public bool IsGetDeviceColor { get => isGetDeviceColor; set => isGetDeviceColor = value; }
        public bool IsSetDeviceColor { get => isSetDeviceColor; set => isSetDeviceColor = value; }
        public bool IsGetHardVersion { get => isGetHardVersion; set => isGetHardVersion = value; }
        public bool IsSetHardVersion { get => isSetHardVersion; set => isSetHardVersion = value; }
        public bool IsGetSoftVersion { get => isGetSoftVersion; set => isGetSoftVersion = value; }
        public bool IsGetBatteryLevel { get => isGetBatteryLevel; set => isGetBatteryLevel = value; }
        public bool IsGetMfiStatus { get => isGetMfiStatus; set => isGetMfiStatus = value; }
        public bool IsGetSerialNum { get => isGetSerialNum; set => isGetSerialNum = value; }
        public bool IsSetSerialNum { get => isSetSerialNum; set => isSetSerialNum = value; }
        public bool IsGetCaseSerialNum { get => isGetCaseSerialNum;set => isGetCaseSerialNum = value; }
        public bool IsSetCaseSerialNum { get => isSetCaseSerialNum;set=> isSetCaseSerialNum = value; }
        public bool IsGetProductId { get => isGetProductId; set => isGetProductId = value; }
        public bool IsSetProductId { get => isSetProductId; set => isSetProductId = value; }
        public bool IsEnterDutMode { get => isEnterDutMode; set => isEnterDutMode = value; }
        public bool IsEnterShipMode { get => isEnterShipMode; set => isEnterShipMode = value; }
        public string SoftVersion { get => softVersion; set => softVersion = value; }
        public string PassWard { get => passWard; set => passWard = value; }
        public string PortName { get => portName; set => portName = value; }
        public bool IsGetChannel { get=> isGetChannel; set => isGetChannel = value; }
        public bool IsResetMode { get => isResetMode; set => isResetMode = value; }
        public string BatteryValue { get => batteryValue; set => batteryValue = value; }
        public string ProductId { get => productId; set => productId = value; }
        public string Color {  get => color; set => color = value;}
        public string HardVersion { get =>hardVersion; set => hardVersion = value; }


    }
}
