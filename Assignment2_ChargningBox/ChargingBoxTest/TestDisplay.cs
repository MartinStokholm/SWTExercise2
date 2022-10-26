using NUnit.Framework;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using NSubstitute;
using static ChargningBoxLib.Utilities.Door;


namespace ChargingBox.Test
{
    public class TestDisplay
    {
        private IDisplay _uut;
        private StringWriter sw;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
            sw = new StringWriter();
            Console.SetOut(sw);
        }

        [Test]
        public void ConnectPhone_ConsoleWriteLine_ComparesToString()
        {
            _uut.ConnectPhone();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.ConnectPhoneString + "\r\n"));
        }

        [Test]
        public void ScanRFID_ConsoleWriteLine_ComparesToString()
        {
            _uut.ScanRFID();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.ScanRFIDString + "\r\n"));
        }

        [Test]
        public void RFIDError_ConsoleWriteLine_ComparesToString()
        {
            _uut.RFIDError();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.RFIDErrorString + "\r\n"));
        }

        [Test]
        public void ChargingBoxBusy_ConsoleWriteLine_ComparesToString()
        {
            _uut.ChargingBoxBusy();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.ChargingBoxBusyString + "\r\n"));
        }

        [Test]
        public void PhoneNotDetected_ConsoleWriteLine_ComparesToString()
        {
            _uut.PhoneNotDetected();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.PhoneNotDetectedString + "\r\n"));
        }

        [Test]
        public void RemovePhone_ConsoleWriteLine_ComparesToString()
        {
            _uut.RemovePhone();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.RemovePhoneString + "\r\n"));
        }

        [Test]
        public void NormalCharging_ConsoleWriteLine_ComparesToString()
        {
            _uut.NormalCharging();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.NormalChargingString + "\r\n"));
        }

        [Test]
        public void FullyCharged_ConsoleWriteLine_ComparesToString()
        {
            _uut.FullyCharged();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.FullyChargedString + "\r\n"));
        }

        [Test]
        public void OverloadError_ConsoleWriteLine_ComparesToString()
        {
            _uut.OverloadError();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.OverloadErrorString + "\r\n"));
        }

        [Test]
        public void NotConnected_ConsoleWriteLine_ComparesToString()
        {
            _uut.NotConnected();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.NotConnectedString + "\r\n"));
        }

        [Test]
        public void StopCharge()
        {
            _uut.StopCharge();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.StopChargeString + "\r\n"));
        }

        [Test]
        public void StartCharge()
        {
            _uut.StartCharge();
            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(_uut.StartChargeString + "\r\n"));
        }



    }
}