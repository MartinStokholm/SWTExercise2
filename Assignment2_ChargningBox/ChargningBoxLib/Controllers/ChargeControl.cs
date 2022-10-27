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
    public class ChargeControl : IChargeControl
    {
        // Constants
        private const double MaxCurrent = 500.0; // mA
        private const double FullyChargedCurrent = 5; // mA
        private const double NoChargeCurrent = 0.0; // mA

        private enum chargeStates
        {
            NoCharge, NormalCharge, FullyCharge, OverloadCharge
        };
        private chargeStates states;
        public bool IsConnected { get; set; }

        // Event Variable
        public double currentValue { get; private set; }
        IDisplay _display;
        IUsbCharger _usbCharger;


        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
            IsConnected = false;
            _display = display;
            // It is the ChargeControl that handle event from USBCharger
            _usbCharger = usbCharger;
            states = chargeStates.NoCharge;
            _usbCharger.CurrentValueEvent += HandleCurrentEvent;
        }

        private void HandleCurrentEvent(object? sender, CurrentEventArgs e)
        {
            currentValue = e.Current;
            CurrentStates();
        }

        public void StartCharge()
        {
            //Should it be display that is called here?
            IsConnected = true;
            _usbCharger.StartCharge();
        }
        public void StopCharge()
        {
            IsConnected = false;
            _usbCharger.StopCharge();
        }

        private void CurrentStates()
        {
            if (checkFullyCharge())
            {
                states = chargeStates.FullyCharge;
                _display.FullyCharged();
                StopCharge();
            }
            else if (checkNormalCharge())
            {
                states = chargeStates.NormalCharge;
                _display.NormalCharging();
            }
            else if (checkOverCharge())
            {
                states = chargeStates.OverloadCharge;
                _display.OverloadError();
                StopCharge();
            }
            else if (checkNoCharge())
            {
                states = chargeStates.NoCharge;
                _display.NotConnected();
            }
        }


        private bool checkFullyCharge()
        {
            return currentValue <= FullyChargedCurrent && currentValue > NoChargeCurrent && states != chargeStates.FullyCharge;
        }

        private bool checkNormalCharge()
        {
            return currentValue > FullyChargedCurrent && currentValue <= MaxCurrent && states != chargeStates.NormalCharge;
        }

        private bool checkOverCharge()
        {
            return currentValue >= MaxCurrent && states != chargeStates.OverloadCharge;
        }

        private bool checkNoCharge()
        {
            return currentValue == NoChargeCurrent && states != chargeStates.NoCharge;
        }



    }
}
