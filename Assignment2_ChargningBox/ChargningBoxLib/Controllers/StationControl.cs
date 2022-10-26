using ChargningBoxLib.Interfaces;
//using Ladeskab.Interfaces;

namespace ChargningBoxLib.Controllers
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        public enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        public LadeskabState _state { get; private set;}
        private IChargeControl _charger;
        private IDoor _door;
        private ILogFile _logfile;
        private IDisplay _display;
        private IRFIDReader _rfidReader;
        private int _oldId;

        // Event Variables
        public DoorState _doorEvent { get; private set; }
        public int _rfidEvent { get; private set; }


        //private string logFile = "logfile.txt"; 

        // Her mangler constructor
        public StationControl(IChargeControl charger, IDoor door, ILogFile logfile, IDisplay display, IRFIDReader rfidReader)
        {
            door.DoorEvent += HandleDoorOpenCloseEvent;
            _door = door;

            rfidReader.RfidEvent += HandleRfidDetectedEvent;
            _rfidReader = rfidReader;

            _charger = charger;

            _state = LadeskabState.Available;
            _logfile = logfile;
            _display = display;
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected()
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    Availability(_rfidEvent);
                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    CheckLocked(_rfidEvent);
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

        private void CheckOpenClosed()
        {
            if (_doorEvent == DoorState.Unlocked)
            {
                DoorOpened();
                //_state = LadeskabState.DoorOpen;
            }
            else
            {
                DoorClosed();
                //_state = LadeskabState.Available;
            }
        }

        #region Events
        private void HandleDoorOpenCloseEvent(object sender, DoorEventArgs e)
        {
            _doorEvent = e.DoorEvent;
            CheckOpenClosed();
        }

        private void HandleRfidDetectedEvent(object sender, RfidEventArgs e)
        {
            _rfidEvent = e.RfidDetected;
            RfidDetected();
        }
        #endregion


        #region Door funcionality
        private void DoorOpened()
        {
            _display.ConnectPhone();
            _charger.IsConnected = true;
        }

        private void DoorClosed()
        {
            _display.ScanRFID();
            _charger.IsConnected = false;
        }

        private void LockDoor()
        {
            _display.ChargingBoxBusy();
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
