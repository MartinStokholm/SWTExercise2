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
        private DoorState _doorState;
        public void SetDoorState(DoorState newDoorState)
        {
            if (newDoorState != _doorState)
            {
                OnDoorOpenClose(new DoorOpenCloseEventArgs { DoorEvent = newDoorState });
                _doorState = newDoorState;
            }
        }

        protected virtual void OnDoorOpenClose(DoorOpenCloseEventArgs e)
        {
                DoorOpenCloseEvent?.Invoke(this, e);
        }

        public Door()
        {

            _doorState = DoorState.Unlocked;
        }

        public void UnlockDoor() {
            _doorState = DoorState.Unlocked;
        }

        public void LockDoor() {
            _doorState = DoorState.Locked;
        }

    }
}