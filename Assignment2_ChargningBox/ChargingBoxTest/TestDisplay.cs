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
        public void ConnectPhoneDisplay()
        {
            _uut.ConnectPhone();
            var output = sw.ToString();
                        
            Assert.That(output, Is.EqualTo(_uut.ConnectPhone + " \r\n"));
            
        }

        

        //https://www.codeproject.com/Articles/501610/Getting-Console-Output-Within-A-Unit-Test
        //https://makolyte.com/csharp-how-to-unit-test-code-that-reads-and-writes-to-the-console/

    }
}