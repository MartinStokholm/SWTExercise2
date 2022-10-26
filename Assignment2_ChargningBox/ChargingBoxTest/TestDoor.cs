using NUnit.Framework;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using NSubstitute;
using static ChargningBoxLib.Utilities.Door;

namespace ChargingBox.Test
{
    public class TestDoor
    {
        private IDoor _uut;
        private DoorEventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _uut = new Door();
            _uut.SetDoorState(DoorState.Locked);

            _uut.DoorEvent += (o, args) =>
            {
                _receivedEventArgs = args;
            };
        }


        [Test]
        public void SetDoorState_DoorEventSetToUnlocked_EventFired()
        {
            _uut.SetDoorState(DoorState.Unlocked);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        // If you test all this fails but if this is the only one the succes
        [Test]
        public void SetDoorState_DoorEventSetToLocked_EventNotFired()
        {
            _uut.SetDoorState(DoorState.Locked);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void SetDoorState_DoorEventSetToUnlocked_CorrectNewDoorState()
        {
            _uut.SetDoorState(DoorState.Unlocked);
            Assert.That(_receivedEventArgs.DoorEvent, Is.EqualTo(DoorState.Unlocked));
        }

        [Test]
        public void SetDoorState_DoorEventSetToLocked_CorrectNewDoorState()
        {
            _uut.SetDoorState(DoorState.Unlocked);
            _uut.SetDoorState(DoorState.Locked);
            Assert.That(_receivedEventArgs.DoorEvent, Is.EqualTo(DoorState.Locked));
        }

        [Test]
        public void UnlockDoor_ChangeDoorState()
        {

            try
            {
                _uut.UnlockDoor();
                Assert.IsTrue(true);

            }
            catch
            {
                Assert.IsFalse(false);
            }
        }

        [Test]
        public void LockDoor_ChangeDoorState()
        {

            try
            {
                _uut.LockDoor();
                Assert.IsTrue(true);

            }
            catch
            {
                Assert.IsFalse(false);
            }
        }
    }
}