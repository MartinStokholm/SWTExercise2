using NUnit.Framework;
using ChargningBoxLib.Interfaces;
using ChargningBoxLib.Utilities;
using NSubstitute;
using static ChargningBoxLib.Utilities.Door;
using System.Text;
using System.Text.Unicode;

namespace ChargingBox.Test
{
    public class TestLogFile
    {
        private ILogFile _uut;
        private TextWriter _sw;
        //private var mockFileSystem = new Mock<IFileSystem>();
        //private var fs = mockFileSystem.Object;
        //var mockFileSystem = new Mock<IFileSystem>();

        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
            _sw = new StringWriter();
            Console.SetOut(_sw);
        }




        //[Test]
        //public void LogDoorLocked_DoorEventSetToUnlocked_LoggedToFile()
        //{
        //    int id = 23;
        //    //Assert.That(_uut, Is.Not.Null);



        //    using (var stream = new MemoryStream())
        //    using (var writer = new StreamWriter(stream))
        //    {
        //        // _uut.LogDoorLocked(id.ToString(), writer);
        //        _uut.LogDoorLocked(id.ToString());
        //        //var output = _sw.ToString();
        //        string actual = Encoding.UTF8.GetString(stream.ToArray());
        //        Assert.That(actual, Is.EqualTo(a + b + c + d));
        //    }
        //}

        [Test]
        public void LogDoorLocked_FileExits()
        {
            var text = File.ReadAllText(@".\log.txt", Encoding.UTF8);

            Assert.That(text, Is.Not.Null);

        }


        [Test]
        public void LogDoorLocked_SaveToFile_LoadFromFile_CheckValueIsEqual()
        {
            // Save to file
            int id = 23;
            _uut.LogDoorLocked(id.ToString());

            // efsf
            string firstString = $"Log Entry : {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}";
            string secondString = $"  :Door locked by id: {id}";
            string thridString = "-------------------------------";
            string[] actualString = { firstString, secondString, thridString };

            // Load from file
            var list = new List<String>();
            var fileStream = new FileStream(@".\log.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            int length = list.Count;
            string[] lines = { list[length - 3], list[length - 2], list[length - 1] };


            Assert.That(actualString, Is.EqualTo(lines));

        }

        [Test]
        public void LogDoorUnlocked_SaveToFile_LoadFromFile_CheckValueIsEqual()
        {
            // Save to file
            int id = 23;
            _uut.LogDoorUnlocked(id.ToString());

            // efsf
            string firstString = $"Log Entry : {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}";
            string secondString = $"  :Door unlocked by id: {id}";
            string thridString = "-------------------------------";
            string[] actualString = { firstString, secondString, thridString };

            // Load from file
            var list = new List<String>();
            var fileStream = new FileStream(@".\log.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            int length = list.Count;
            string[] lines = { list[length - 3], list[length - 2], list[length - 1] };


            Assert.That(actualString, Is.EqualTo(lines));

        }

    }
}