﻿using ChargningBoxLib.Controllers;
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

        // Test Fopr Availability change when phone is connected
        [TestCase(DoorState.Unlocked, 23)]
        public void DoorChanged_DifferentArguments_CurrentDoorStateIs(DoorState doorState, int rfidTag) {
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = doorState });
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = rfidTag });

            
            Assert.That(_uut._doorEvent, Is.EqualTo(doorState));
            Assert.That(_uut._rfidEvent, Is.EqualTo(rfidTag));
        }

        // Test Fopr Availability change when phone is connected and CheckLocked
        [TestCase(DoorState.Unlocked, 23)]
        public void DoorChanged_DifferentArguments_CurrentDoorState(DoorState doorState, int rfidTag) {
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = doorState });
            _reader.RfidDetectedChangedEvent += Raise.EventWith(new RfidDetectedChangedEventArgs { RfidDetected = rfidTag });
            _door.DoorOpenCloseEvent += Raise.EventWith(new DoorOpenCloseEventArgs { DoorEvent = DoorState.Locked });

            Assert.That(_uut._doorEvent, Is.EqualTo(DoorState.Locked));
            Assert.That(_uut._rfidEvent, Is.EqualTo(rfidTag));
        }


        // Don't know maybe the funktion is just keept private
        [Test]
        public void test() {
            _uut.RfidDetected();
        }

    }
}
