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

        // Can find it in the file SWTExercise2\Assignment2_ChargningBox\ChargingBoxSimpleApp\bin\Debug\net6.0
     
        //We can change it if we want to by using the following
        //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public LogFile()
        {
        }

        public void LogDoorLocked(string id)
        {
            //timestamp, id, door locked
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.AutoFlush = true;
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