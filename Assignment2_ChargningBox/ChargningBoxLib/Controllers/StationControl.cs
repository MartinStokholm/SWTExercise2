using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Simulators;
//using Ladeskab.Interfaces;

namespace ChargningBoxLib.Controllers
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private ILogFile _logfile;
        private IDisplay _display;

        //private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
        public StationControl(IChargeControl charger, IDoor door, ILogFile logfile, IDisplay display)
        {
            _charger = charger;
            _door = door;
            _state = LadeskabState.Available;
            _logfile = logfile;
            _display = display;
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    Availability(id);
                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    CheckLocked(id);
                    break;
            }
        }


        private void Availability(int id)
        {
            // Check for ladeforbindelse
            if (!IsConnected())
            {
                _display.PhoneNotDetected();
            }
            else
            {
                _charger.StartCharge();
                _door.LockDoor();
                _oldId = id;
                _state = LadeskabState.Locked;
                _logfile.LogDoorLocked(id.ToString());
                _display.ScanRFID();
            }
        }

        private void CheckLocked(int id)
        {
            // Check for correct ID
            if (!CheckId(id))
            {
                _display.RFIDError();
            }
            else
            {
                _charger.StopCharge();
                _door.UnlockDoor();
                _logfile.LogDoorUnlocked(id.ToString());
                _display.RemovePhone();
                _state = LadeskabState.Available;
            }

        }


        // Her mangler de andre trigger handlere

        #region Door funcionality
        private void DoorOpened()
        {

        }

        private void DoorClosed()
        {

        }

        private void LockDoor()
        {

        }
        #endregion

        #region Booleans
        private bool CheckId(int id)
        {
            return id == _oldId;
        }

        private bool IsConnected()
        {
            return _charger.IsConnected;
        }
        #endregion
    }
}
