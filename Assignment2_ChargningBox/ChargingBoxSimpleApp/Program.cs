using ChargningBoxLib.Controllers;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Simulators;
using ChargningBoxLib.Utilities;
using System;
class Program
{
    static void Main(string[] args)
    {
        // Assemble your system here from all the classes
        IDoor door = new Door();
        IRFIDReader rfidReader = new RFIDReader();
        IDisplay display = new Display();
        StationControl st = new(new ChargeControl(new UsbChargerSimulator(), display), door, new LogFile(), display, rfidReader);

        bool finish = false;
        do
        {
            string input;
            System.Console.WriteLine("Indtast E, O, C, R: ");
            input = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    door.SetDoorState(DoorState.Unlocked);
                    break;

                case 'C':
                    door.SetDoorState(DoorState.Locked);
                    break;

                case 'R':
                    System.Console.WriteLine("Indtast RFID id: ");
                    string idString = Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.ReadRFID(id);

                    break;

                default:
                    break;
            }

        } while (!finish);
    }
}

