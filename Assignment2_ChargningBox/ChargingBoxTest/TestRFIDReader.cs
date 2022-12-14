using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using Microsoft.VisualStudio.CodeCoverage;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.Test
{
    public class TestRFIDReader
    {
        private IRFIDReader _uut;
        private RfidEventArgs? _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _uut = new RFIDReader();

            _uut.RfidEvent += (o, args) =>
            {
                _receivedEventArgs = args;
            };
        }


        [Test]
        public void SetReadRFID_RfidDetectedtSetToNewValue_EventFired()
        {
            _uut.ReadRFID(32);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void SetReadRFID_RfidDetectedtSetToNewValue_EventNotFired()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _uut.ReadRFID(-1));
        }

        [TestCase(1)]
        public void SetReadRFID_RfidEventSetToNewValue_CorrectNewRfidReceived(int newRFID)
        {
            _uut.ReadRFID(newRFID);
            Assert.That(_receivedEventArgs.RfidDetected, Is.EqualTo(newRFID));
        }


    }
}