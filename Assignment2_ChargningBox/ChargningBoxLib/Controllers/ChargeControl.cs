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
        public double currentValue { get; private set; }

        IUsbCharger _usbCharger;

        public void StartCharge(){
            //Should it be display that is called here?
            Console.WriteLine("Phone is charging");
            IsConnected = true;
        }
        public void StopCharge(){
            Console.WriteLine("Charging has stopped");
            IsConnected = false;
        }
        public ChargeControl(IUsbCharger usbCharger) {
            IsConnected = false;

            // It is the ChargeControl that handle event from USBCharger
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += HandleCurrentEvent;
        }

        private void HandleCurrentEvent(object? sender, CurrentEventArgs e) {
            currentValue = e.Current;
        }
    }
}
