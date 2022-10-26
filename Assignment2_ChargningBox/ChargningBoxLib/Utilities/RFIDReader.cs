using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargningBoxLib.Controllers;
using ChargningBoxLib.Interfaces;
namespace ChargningBoxLib.Utilities
{
    public class RFIDReader : IRFIDReader
    {
        public event EventHandler<RfidEventArgs> RfidEvent;

        public void ReadRFID(int id)
        {
            if (id <= 0) { return; }
            OnReadRFID(new RfidEventArgs { RfidDetected = id });
        }

        protected virtual void OnReadRFID(RfidEventArgs e)
        {
            RfidEvent?.Invoke(this, e);
        }

    }
}