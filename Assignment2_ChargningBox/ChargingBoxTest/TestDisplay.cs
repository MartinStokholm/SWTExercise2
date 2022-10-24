using NUnit.Framework;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using NSubstitute;
using static ChargningBoxLib.Utilities.Door;

namespace ChargingBoxTest
{
    public class TestDisplay
    {
        private IDisplay _uut;
        
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
 
        }



    }
}