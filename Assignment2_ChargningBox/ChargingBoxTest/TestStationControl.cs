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


namespace UsbSimulator.Test
{
    [TestFixture]
    public class TestStationControl
    {

        private StationControl _uut;
        private IDoor _door;
        private IRFIDReader _reader;

        [SetUp]
        public void Setup() {
            _door = Substitute.For<IDoor>();
            _reader = Substitute.For<IRFIDReader>();
            _uut = new StationControl(new ChargeControl(),
                                      _door,
                                      new LogFile(),
                                      new Display(),
                                      _reader);
        }

        //[Test]
        //public void ctor_IsConnected() {
        //    Assert.That(_uut.Connected, Is.True);
        //}

        [TestCase(DoorState.Unlocked)]
        [TestCase(DoorState.Locked)]
        public void DoorChanged_DifferentArguments_CurrentDoorStateIsCorrect(DoorState doorState) {
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = doorState });
            
            Assert.That(_uut._doorEvent, Is.EqualTo(doorState));
        }

        //[TestCase(true)]
        //[TestCase(false)]
        //public void DoorChanged_sdArguments_CurrentDoorStateIsCorrect(bool doorState) {
        //    _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = doorState });
        //    _reader.Received(1).;

        //}

        //Maybe need logic so we can have negativ RFID TAGS
        [TestCase(-1)]
        [TestCase(3)]
        public void RFIDReaderChanged_DifferentArguments_CurrentRFIDReaderIsCorrect(int rfidTag) {
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = rfidTag });

            Assert.That(_uut._rfidEvent, Is.EqualTo(rfidTag));
        }



    }
}
