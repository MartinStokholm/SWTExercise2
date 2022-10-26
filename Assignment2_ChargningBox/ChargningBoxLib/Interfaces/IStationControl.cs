using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargningBoxLib.Interfaces
{
    public interface IStationControl
    {
        public void DoorOpened();
        public void DoorClosed();
        public void RfidDetected(string id);
        public void CheckId(string oldid, string id);
        

    }
}
