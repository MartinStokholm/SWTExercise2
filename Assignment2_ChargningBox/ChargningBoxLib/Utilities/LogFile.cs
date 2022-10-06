using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargningBoxLib.Interfaces;
using System.IO;

namespace ChargningBoxLib.Utilities
{
    public class LogFile: ILogFile
    {
        
        public LogFile(){
        }

        public void LogDoorLocked(string id)
        {
            //timestamp, id, door locked
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine($"  :Door locked by id: {id}");
                w.WriteLine("-------------------------------");
            }
            
            
        }
        public void LogDoorUnlocked(string id)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine($"  :Door unlocked by id: {id}");
                w.WriteLine ("-------------------------------");
            }
        }
    }

}