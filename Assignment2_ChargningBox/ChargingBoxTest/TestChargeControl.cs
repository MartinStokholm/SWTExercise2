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
        //private DoorOpenCloseEventArgs? _receivedEventArgs;
        
        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _uut = new ChargeControl(_usbCharger);
            //_uut.CurrentValueEvent += (o, args) => {
            //    _receivedEventArgs = args;
            //};
        }

        [Test]
        public void ctor_IsConnected() {
            Assert.That(_uut.IsConnected, Is.False);
        }

        [Test]
        public void SetStartCharge_StartChangeSetToTrue_CorrectNewValue() {
            _uut.StartCharge();
            Assert.That(_uut.IsConnected, Is.True);
        }

        [Test]
        public void SetStartCharge_StartChangeSetToFalse_CorrectNewValue() {
            _uut.StartCharge();
            _uut.StopCharge();
            Assert.That(_uut.IsConnected, Is.False);
        }

        //[Test]
        //public void ctor_currentValue() {
        //    Assert.That(_uut.currentValue, Is.EqualTo(0));
        //}
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(23)]
        public void SetStartCharge_ChargeEventSetToNewValue_EventFiredWithCorrectValue(int value ) {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = value });
            Assert.That(_uut.currentValue, Is.EqualTo(value));
        }

        //[TestCase(23)]
        //public void SetDoorState_DoorEventSetToUnlocked_EventFired(int value) {
        //    _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = value });
        //    Assert.That(_uut.currentValue, Is.Not.EqualTo(value));
        //}
        //[Test]
        //public void SetDoorState_DoorEventSetToUnlocked_EventFired() {
        //    _uut.StartCharge();
        //    Assert.That(_uut., Is.Not.Null);
        //}
    }
}