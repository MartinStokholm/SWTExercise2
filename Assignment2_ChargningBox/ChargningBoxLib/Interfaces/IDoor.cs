using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChargningBoxLib.Utilities.Door;

namespace ChargningBoxLib.Interfaces
{
    public enum DoorState
    {
        Locked,
        Unlocked
    }

    public class DoorOpenCloseEventArgs : EventArgs
    {
        public DoorState DoorEvent { get; set; }
    }

    public interface IDoor
    {
        public void UnlockDoor();
        public void LockDoor();
        public void SetDoorState(DoorState newDoorState);

        event EventHandler<DoorOpenCloseEventArgs> DoorOpenCloseEvent;

    }
}
