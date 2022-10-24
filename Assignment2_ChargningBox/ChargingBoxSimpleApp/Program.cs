using ChargningBoxLib.Controllers;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using System;
class Program
    {
        static void Main(string[] args)
        {
				// Assemble your system here from all the classes
            IDoor door = new Door();
            IRFIDReader rfidReader = new RFIDReader();
            StationControl st = new StationControl(new ChargeControl(), door, new LogFile(), new Display(), rfidReader);

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        // Should we take a id for which RFID onlocks the door?
                        door.SetDoorState(DoorState.Unlocked);
                        //door.UnlockDoor();
                        // door.OnDoorOpen();
                        break;

                    case 'C':
                        door.SetDoorState(DoorState.Locked);
                        //door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.ReadRFID(id);
                        //rfidReader.OnRfidRead(id);

                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }

