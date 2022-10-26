using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargningBoxLib.Interfaces;


namespace ChargningBoxLib.Utilities
{
    public class Display: IDisplay
    {
              
        public void ConnectPhone(){
            Console.WriteLine(ConnectPhoneString);
        }

        public void ScanRFID(){
            Console.WriteLine(ScanRFIDString);
        }
    
        public void PhoneNotDetected(){
            Console.WriteLine(PhoneNotDetectedString);
        }

        public void ChargingBoxBusy()
        {
            Console.WriteLine(ChargingBoxBusyString);
        }


        public void RFIDError(){
            Console.WriteLine(RFIDErrorString);
        }

        public void RemovePhone(){
            Console.WriteLine(RemovePhoneString);
        }

        public void NotConnected()
        {
            Console.WriteLine(NotConnectedString);
        }
        
        public void NormalCharging()
        {
            Console.WriteLine(NormalChargingString);
        }

        public void FullyCharged()
        {
            Console.WriteLine(FullyChargedString);
        }    
        
        public void OverloadError()
        {
            Console.WriteLine(OverloadErrorString);
        }

        public void StartCharge()
        {
            Console.WriteLine(StartChargeString);
        }
        public void StopCharge()
        {
            Console.WriteLine(StopChargeString);
        }
        public string ConnectPhoneString { get => _connectPhoneString;  }

        public string ScanRFIDString { get => _scanRFIDString; }

        public string RFIDErrorString { get => _rfidErrorString; }

        public string ChargingBoxBusyString { get => _chargingBoxBusyString; }

        public string PhoneNotDetectedString { get => _phoneNotDetectedString; }
        public string RemovePhoneString { get => _removePhoneString; }

        public string NormalChargingString { get => _normalChargingString; }      

        public string FullyChargedString { get => _fullyChargedString; }

        public string OverloadErrorString { get => _overloadErrorString; }

        public string NotConnectedString { get => _notConnectedString; }

        public string StartChargeString { get => _startChargeString; }

        public string StopChargeString { get => _stopChargeString; }

        private string _connectPhoneString = "Connect phone";
        private string _scanRFIDString = "Charging box is closed. Use your RFID tag to open.";
        private string _rfidErrorString = "Wrong RFID tag.";
        private string _chargingBoxBusyString = "Charging Box is not available right now or in use. Try again later.";
        public string _phoneNotDetectedString = "Phone is not connected. Try again.";
        public string _removePhoneString = "Remove phone from charging box and close the door.";
        public string _normalChargingString = "Phone is charging";
        public string _fullyChargedString = "Phone is fully charged";
        public string _overloadErrorString = "Something went wrong. Please, disconnect phone from charging station";
        public string _notConnectedString = "Phone is disconnected";
        public string _stopChargeString = "Charging has stopped"; 
        public string _startChargeString = "Phone is charging";
    }
}
