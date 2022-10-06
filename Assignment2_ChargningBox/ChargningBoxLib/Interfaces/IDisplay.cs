using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargningBoxLib.Interfaces
{
    public interface IDisplay
    {
        public void ConnectPhone();
        public void ScanRFID();
        public void RFIDError();
        public void ChargingBoxBusy();
        public void PhoneNotDetected();
        public void RemovePhone();
    }
}
