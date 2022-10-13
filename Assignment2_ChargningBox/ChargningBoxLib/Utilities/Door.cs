using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargningBoxLib.Interfaces;


namespace ChargningBoxLib.Utilities
{
    public class Door : IDoor 
    {
        public event EventHandler<DoorOpenCloseEventArgs>? DoorOpenCloseEvent;
        
        //Open Close function
        private bool _oldDoorState;
        public void SetDoorState(bool newDoorState)
        {
            if (newDoorState != _oldDoorState)
            {
                OnDoorOpenClose(new DoorOpenCloseEventArgs { DoorOpenClose = newDoorState });
                _oldDoorState = newDoorState;
            }
        }

        protected virtual void OnDoorOpenClose(DoorOpenCloseEventArgs e)
        {
                DoorOpenCloseEvent?.Invoke(this, e);
        }

        DoorState _doorState;

        enum DoorState
        {
            Locked,
            Unlocked
        }

        public Door()
        {

            _doorState = DoorState.Unlocked;
        }

        public void UnlockDoor()
        {
            _doorState = DoorState.Unlocked;
        }

        public void LockDoor()
        {
            _doorState = DoorState.Locked;
        }

    }
}