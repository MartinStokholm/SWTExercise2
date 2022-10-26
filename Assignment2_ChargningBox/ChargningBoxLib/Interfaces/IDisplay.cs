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
        public void NormalCharging();
        public void FullyCharged();  
        public void OverloadError();
        public void NotConnected();
        public void StopCharge();
        public void StartCharge();

        public string ConnectPhoneString{get;}
        public string ScanRFIDString { get;}
        public string RFIDErrorString { get;}
        public string ChargingBoxBusyString { get;}
        public string PhoneNotDetectedString { get;}
        public string RemovePhoneString { get;}
        public string NormalChargingString { get;}
        public string FullyChargedString { get;}
        public string OverloadErrorString { get;}
        public string NotConnectedString { get;}
        public string StopChargeString { get;}
        
    }

}
