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


        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
        }
        //Jenkins can't find the file




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
            string[] fakeString = { firstString, secondString, thridString };

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


            Assert.That(fakeString, Is.EqualTo(lines));

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

        [Test]
        public void LogDoorLocked_FileExits()
        {
            // Jenkins need to save file for the creates of the file
            // The file is delete, when test is done, so to load file 
            // we have to create a new beforehand 
            int id = 23;
            _uut.LogDoorUnlocked(id.ToString());
            var text = File.ReadAllText(@".\log.txt", Encoding.UTF8);

            Assert.That(File.Exists(@".\log.txt"));

        }


    }
}