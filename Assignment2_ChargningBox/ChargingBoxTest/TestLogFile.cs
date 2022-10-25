using NUnit.Framework;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using NSubstitute;
using static ChargningBoxLib.Utilities.Door;

namespace ChargingBox.Test
{
    public class TestLogFile
    {
        private ILogFile _uut;
        
        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
        }

        [Test]
        public void LogDoorLocked_DoorEventSetToUnlocked_LoggedToFile() {
            _uut.LogDoorLocked(23.ToString()); 
            Assert.That(_uut, Is.Not.Null);
        }

        [Test]
        public void LogDoorUnlocked_DoorEventSetToUnlocked_LoggedToFile() {
            _uut.LogDoorUnlocked(23.ToString());
            Assert.That(_uut, Is.Not.Null);
        }


    }
}