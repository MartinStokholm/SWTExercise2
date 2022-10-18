using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Simulators;

namespace ChargningBoxLib.Controllers
{
    public class ChargeControl: IChargeControl
    {
        public bool IsConnected { get; set; }

        // Event Variable
        public double currentValue;

        public void StartCharge(){
            Console.WriteLine("Phone is charging");
            
        }
        public void StopCharge(){
            Console.WriteLine("Charging has stopped");

        }
        public ChargeControl() {
            IsConnected = false;

            // It is the ChargeControl that handle event from USBCharger
            IUsbCharger usbCharger = new UsbChargerSimulator();
            usbCharger.CurrentValueEvent += HandleCurrentEvent;
        }
        

        private void HandleCurrentEvent(object sender, CurrentEventArgs e) {
            currentValue = e.Current;
        }
    }
}
