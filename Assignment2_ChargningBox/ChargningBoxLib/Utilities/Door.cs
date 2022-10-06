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
        DoorState _doorState;
        enum DoorState
        {
            Locked,
            Unlocked
        }
        
        public Door(){

            _doorState=DoorState.Unlocked;
        }

        public void UnlockDoor()
        {
            _doorState=DoorState.Unlocked;
        }

        public void LockDoor()
        {
            _doorState = DoorState.Locked;
        }
        


        

    }
}