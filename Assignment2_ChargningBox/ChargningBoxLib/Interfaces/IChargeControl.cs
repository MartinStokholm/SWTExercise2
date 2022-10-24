using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargningBoxLib.Interfaces
{
    public interface IChargeControl
    {
        public double currentValue { get; }
        bool IsConnected { get; set; }
        void StartCharge();
        void StopCharge();
    }
}
