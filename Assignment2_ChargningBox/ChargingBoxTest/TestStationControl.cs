using ChargningBoxLib.Controllers;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Simulators;
using ChargningBoxLib.Utilities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChargingBox.Test { 

    [TestFixture]
    public class TestStationControl
    {

        private StationControl _uut;
        private IDoor _door;
        private IRFIDReader _reader;
        private IDisplay _display;
        private ILogFile _logFile;
        private IChargeControl _chargeControl;

        [SetUp]
        public void Setup() {
            _door = Substitute.For<IDoor>();
            _reader = Substitute.For<IRFIDReader>();
            _display = Substitute.For<IDisplay>();
            _logFile = Substitute.For<ILogFile>();
            _chargeControl = Substitute.For<IChargeControl>();
            _uut = new StationControl(_chargeControl,
                                      _door,
                                      _logFile, 
                                      _display,
                                      _reader);
        }

        [TestCase(DoorState.Unlocked)]
        [TestCase(DoorState.Locked)]
        public void DoorChanged_DifferentArguments_CurrentDoorStateIsCorrect(DoorState doorState) {
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = doorState });
            
            Assert.That(_uut._doorEvent, Is.EqualTo(doorState));
        }

        //Maybe need logic so we can have negativ RFID TAGS
        [TestCase(-1)]
        [TestCase(3)]
        public void RFIDReaderChanged_DifferentArguments_CurrentRFIDReaderIsCorrect(int rfidTag) {
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = rfidTag });

            Assert.That(_uut._rfidEvent, Is.EqualTo(rfidTag));
        }

        // Test Fopr Availability change when phone is connected
        [TestCase(DoorState.Unlocked, 23)]
        public void DoorChanged_DifferentArguments_CurrentDoorStateIs(DoorState doorState, int rfidTag) {
            // Open the door
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = doorState });

            //Scan with rfid
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = rfidTag });

            // Check that the door is open and the rfid has been scanned 
            Assert.That(_uut._doorEvent, Is.EqualTo(doorState));
            Assert.That(_uut._rfidEvent, Is.EqualTo(rfidTag));
        }

        // Test Fopr Availability change when phone is connected and CheckLocked
        [TestCase(DoorState.Unlocked, 23)]
        public void DoorChanged_DifferentArguments_CurrentDoorState(DoorState doorState, int rfidTag) {
            // Open the door
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = doorState });

            //Scan with rfid
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = rfidTag });

            // Close the door
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = DoorState.Locked });

            // Try with the rigth rfid
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = rfidTag });

            // Check that the state of the uut is 
            Assert.That(_uut._doorEvent, Is.EqualTo(DoorState.Locked));
            Assert.That(_uut._rfidEvent, Is.EqualTo(rfidTag));
        }

        // Test Fopr Availability change when phone is connected and CheckLocked
        [TestCase(DoorState.Unlocked, 23)]
        public void DoorChanged_DifferentArguments_CurrentDoor(DoorState doorState, int rfidTag) {
            // Open the door
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = doorState });

            //Scan with rfid
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = rfidTag });

            // Close the door
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = DoorState.Locked });
            int wrongTag = 12;
            // Try with the wrong rfid
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = wrongTag });

            // Check that the state of the uut is not changed from lock 
            Assert.That(_uut._doorEvent, Is.EqualTo(DoorState.Locked));
            //Assert.That(_uut._rfidEvent, Is.Not.EqualTo(wrongTag));
        }


        // Don't know maybe the funktion is just keept private
        [Test]
        public void test() {
            _uut.RfidDetected();
        }

    }
}
