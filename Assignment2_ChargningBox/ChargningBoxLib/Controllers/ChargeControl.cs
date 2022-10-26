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
         // Constants
        private const double MaxCurrent = 500.0; // mA
        private const double FullyChargedCurrent = 5; // mA
        private const double NoChargeCurrent = 0.0; // mA
        
        public bool IsConnected { get; set; }

        // Event Variable
        public double currentValue { get; private set; }

        IUsbCharger _usbCharger;

        public ChargeControl(IUsbCharger usbCharger) {
            IsConnected = false;

            // It is the ChargeControl that handle event from USBCharger
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += HandleCurrentEvent;
        }

        private void HandleCurrentEvent(object? sender, CurrentEventArgs e) {
            currentValue = e.Current;
            CurrentStates();
        }
        
        public void StartCharge(){
            //Should it be display that is called here?
            Console.WriteLine("Phone is charging");
            IsConnected = true;
            _usbCharger.StartCharge();
        }
        public void StopCharge(){
            Console.WriteLine("Charging has stopped");
            IsConnected = false;
            _usbCharger.StopCharge();
        }

        private void CurrentStates(){
           
            if (currentValue <= FullyChargedCurrent && currentValue > NoChargeCurrent) {
                FullyCharged();
            }
            else if (currentValue > FullyChargedCurrent && currentValue <= MaxCurrent) {
                NormalCharging();
            }
            else if (currentValue >= MaxCurrent) {
                OverloadError();
            } else {
                NotConnected(); 
            }
        }


        private void NotConnected()
        {
            Console.WriteLine("Phone is not connected");
        }
        
        private void NormalCharging()
        {
            Console.WriteLine("Phone is charging");
        }

        private void FullyCharged()
        {
            Console.WriteLine("Phone is fully charged");
        }    
        
        private void OverloadError()
        {
            Console.WriteLine("Something went wrong. Please, disconnect phone from charging station");
        }

      

    }
}
