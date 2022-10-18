using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargningBoxLib.Interfaces
{
    public class DoorOpenCloseEventArgs : EventArgs
    {
        public bool DoorOpenClose { get; set; }
    }

    public interface IDoor
    {
        public void UnlockDoor();
        public void LockDoor();
        public void SetDoorState(bool newDoorState);

        event EventHandler<DoorOpenCloseEventArgs> DoorOpenCloseEvent;

    }
}
