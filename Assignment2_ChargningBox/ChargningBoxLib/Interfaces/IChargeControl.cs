using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargningBoxLib.Interfaces
{
    public interface IChargeControl
    {
        bool IsConnected { get; set; }
        void StartCharge();
        void StopCharge();
    }
}
