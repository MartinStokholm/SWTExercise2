using NUnit.Framework;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using NSubstitute;
using static ChargningBoxLib.Utilities.Door;
using ChargningBoxLib.Controllers;
using ChargningBoxLib.Simulators;

namespace ChargingBox.Test
{
    public class TestChargeControl
    {
        private IChargeControl _uut;
        private IUsbCharger _usbCharger;


        private IDisplay _display;
        //private DoorOpenCloseEventArgs? _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_usbCharger, _display);
            //_uut.CurrentValueEvent += (o, args) => {
            //    _receivedEventArgs = args;
            //};
        }

        [Test]
        public void ctor_IsConnected()
        {
            Assert.That(_uut.IsConnected, Is.False);
        }

        [Test]
        public void SetStartCharge_StartChangeSetToTrue_CorrectNewValue()
        {
            _uut.StartCharge();
            Assert.That(_uut.IsConnected, Is.True);
        }

        [Test]
        public void SetStartCharge_StartChangeSetToFalse_CorrectNewValue()
        {
            _uut.StartCharge();
            _uut.StopCharge();
            Assert.That(_uut.IsConnected, Is.False);
        }

        [TestCase(5.01)]
        [TestCase(100)]
        [TestCase(500)]
        public void StartChargeNormalCharge_ChargeEventSetToNewValue_EventFiredWithCorrectValue(double value)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = value });
            Assert.That(_uut.currentValue, Is.EqualTo(value));
        }



        [TestCase(500.01)]
        [TestCase(750)]
        public void StartChargeOverCharge_ChargeEventSetToNewValue_EventFiredWithCorrectValue(double value)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = value });
            Assert.That(_uut.currentValue, Is.EqualTo(value));
        }

        [TestCase(0)]
        public void StartChargeNoCharge_ChargeEventSetToNewValue_EventFiredWithCorrectValue(double value)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = value });
            Assert.That(_uut.currentValue, Is.EqualTo(value));
        }

        [TestCase(0.0)]
        public void StartChargeFullyCharge_ChargeEventSetToNewValue_EventFiredWithCorrectValue(double value)
        {
            // Raise event so we are charging
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = 500 });
            // Now we can stop charging 
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = value });
            Assert.That(_uut.currentValue, Is.EqualTo(value));
        }



    }
}