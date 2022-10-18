using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargningBoxLib.Controllers;
using ChargningBoxLib.Interfaces;
namespace ChargningBoxLib.Utilities
{
    public class RFIDReader: IRFIDReader
    {
        public event EventHandler<RfidDetectedChangedEventArgs> RfidDetectedChangedEvent;

        public void ReadRFID(int id)
        {
            OnReadRFID(new RfidDetectedChangedEventArgs { RfidDetected = id });
            //StationControl.RfidDetected(id);
        }

        protected virtual void OnReadRFID(RfidDetectedChangedEventArgs e) {
            RfidDetectedChangedEvent?.Invoke(this, e);
        }

    }
}