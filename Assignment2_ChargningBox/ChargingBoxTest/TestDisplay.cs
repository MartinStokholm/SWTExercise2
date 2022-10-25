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
        
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
 
        }

        //https://www.codeproject.com/Articles/501610/Getting-Console-Output-Within-A-Unit-Test

    }
}