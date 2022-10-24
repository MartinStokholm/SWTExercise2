using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using NUnit.Framework

namespace ChargingBoxTest
{
    public class Tests
    {
        private IDoor _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Door();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Started_Simulate() {
            ManualResetEvent pause = new ManualResetEvent(false);
            bool lastValue = false;

            _uut.DoorOpenCloseEvent += (o, args) => {
                lastValue = args.DoorOpenClose;
                pause.Set();
            };

            // Start
            _uut.SetDoorState(true);

            // Next value should be high
            _uut.SetDoorState(false);

            // Reset event
            pause.Reset();

            // Wait for next tick, should send overloaded value
            pause.WaitOne(300);

            Assert.That(lastValue, Is.EqualTo(false));
        }
    }
}