using NUnit.Framework;
using System.IO;

namespace Guide.UnitTests
{
    class FileManagerTest
    {
        [TestCase(TestName = "Загрузка параметров, позитив")]
        public void FileManager_LoadTest_CorrectParameters()
        {
            //Setup
            var expectedParameters = new GuideParameters();
            expectedParameters.GuideAngle = 180;
            //Act
            var actualParameters = FileManager.LoadFile(@"TestData\CorrectGuideParameters.json");

            //Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestCase(@"TestData\CorrectGuideParameters.json", TestName = "Загрузка параметров, исключение")]
        [TestCase(@"TestData\NonExistentParameters.json", TestName = "Загрузка параметров, файл не существует")]
        public void FileManager_LoadTest_Exception(string path)
        {
            //Setup
            var expectedParameters = new GuideParameters();
            //Act
            var actualParameters = FileManager.LoadFile(path);

            //Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }
        [TestCase(TestName = "Сохранение параметров, позитив")]
        public void FileManager_SaveTest_Positive()
        {
            //Setup
            var expectedParameters = new GuideParameters();
            expectedParameters.GuideAngle = 180;
            DirectoryInfo directoryInfo = new DirectoryInfo(@"Output");
            if (directoryInfo.Exists)
            {
                Directory.Delete(@"Output", true);
            }
            //Act
            FileManager.SaveFile(expectedParameters, @"Output");
            //Assert
            var actual = File.ReadAllText(@"Output\GuideParameters.json");
            var expected = File.ReadAllText(@"TestData\CorrectGuideParameters.json");

            Assert.AreEqual(expected, actual);
        }
    }
}
