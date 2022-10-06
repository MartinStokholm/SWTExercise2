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
            Console.WriteLine("Connect phone");
        }

        public void ScanRFID(){
            Console.WriteLine("Charging box is locked and phone is charging. Use your RFID tag to unlock.");
        }
    
        public void PhoneNotDetected(){
            Console.WriteLine("Phone is not connected. Try again.");
        }

        public void ChargingBoxBusy()
        {
            Console.WriteLine("Charging Box is not available right now or in use. Try again later.");
        }


        public void RFIDError(){
            Console.WriteLine("Wrong RFID tag.");
        }

        public void RemovePhone(){
            Console.WriteLine("Remove phone from charging box and close the door.");
        }

    }
}
