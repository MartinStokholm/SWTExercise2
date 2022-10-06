using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargningBoxLib.Interfaces;

namespace ChargningBoxLib.Controllers
{
    public class ChargeControl: IChargeControl
    {
        public bool IsConnected { get; set; }

        public void StartCharge(){
            Console.WriteLine("Phone is charging");
            
        }
        public void StopCharge(){
            Console.WriteLine("Charging has stopped");

        }
    }
}
