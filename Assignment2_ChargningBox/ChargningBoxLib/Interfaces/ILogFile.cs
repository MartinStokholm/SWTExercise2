using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargningBoxLib.Interfaces
{
    public interface ILogFile
    {
        public void LogDoorLocked(string id);
        public void LogDoorUnlocked(string id);
    }
}
