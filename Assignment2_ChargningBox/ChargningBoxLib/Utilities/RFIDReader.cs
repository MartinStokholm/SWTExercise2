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
        public void ReadRFID(int id)
        {
            //StationControl.RfidDetected(id);
        }

    }
}