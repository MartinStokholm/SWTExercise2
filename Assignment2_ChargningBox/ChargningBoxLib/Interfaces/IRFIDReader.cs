using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargningBoxLib.Interfaces
{
     public class RfidDetectedChangedEventArgs : EventArgs
    {
        public int RfidDetected { get; set; }
    }


    public interface IRFIDReader
    {
        void ReadRFID(int id);
        event EventHandler<RfidDetectedChangedEventArgs> RfidDetectedChangedEvent;
    }
}
