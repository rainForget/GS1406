using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_7130.Bean
{
    [Serializable]
    public class SettingBean
    {
        private string productId = "1";
        private string softVersion = "0.3.5";
        private string passWard = "Admin";
        private string portName = "COM3";
        private bool isScanSN = true;


        public string ProductId { get { return productId; } set { productId = value; } }
        public string PassWard { get {  return passWard; } set {  passWard = value; } }
        public string SoftVersion { get { return softVersion;} set { softVersion = value; } }
        public string PortName { get { return portName; } set { portName = value; } }
        public bool IsScanSN { get {  return isScanSN; } set {  isScanSN = value; } }
    }
}
