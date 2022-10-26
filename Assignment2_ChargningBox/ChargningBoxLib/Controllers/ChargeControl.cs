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

        private enum chargeStates {
            NoCharge, NormalCharge, FullyCharge, OverloadCharge
        };
        private chargeStates states;
        public bool IsConnected { get; set; }

        // Event Variable
        public double currentValue { get; private set; }
        IDisplay _display;
        IUsbCharger _usbCharger;

        
        public ChargeControl(IUsbCharger usbCharger, IDisplay display) {
            IsConnected = false;
            _display = display;
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
            IsConnected = true;
            _usbCharger.StartCharge();
        }
        public void StopCharge(){
            IsConnected = false;
            _usbCharger.StopCharge();
        }

        private void CurrentStates(){
           
            if (currentValue <= FullyChargedCurrent && currentValue > NoChargeCurrent ) {
                if (states == chargeStates.FullyCharge) {return;}
                states = chargeStates.FullyCharge;
                _display.FullyCharged();
            }
            else if (currentValue > FullyChargedCurrent && currentValue <= MaxCurrent) {
                if (states == chargeStates.NormalCharge) {return;}
                states = chargeStates.NormalCharge;
                _display.NormalCharging();
            }
            else if (currentValue >= MaxCurrent) {
                if (states == chargeStates.OverloadCharge) {return;}
                states = chargeStates.OverloadCharge;
                _display.OverloadError();
            } else {
                if (states == chargeStates.NoCharge) {return;}
                states = chargeStates.NoCharge;
                _display.NotConnected(); 
            }
        }


        

      

    }
}
