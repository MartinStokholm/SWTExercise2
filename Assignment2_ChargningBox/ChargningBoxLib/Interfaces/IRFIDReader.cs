using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargningBoxLib.Interfaces
{
    public interface IRFIDReader
    {
        void ReadRFID(int id);
    }
}
