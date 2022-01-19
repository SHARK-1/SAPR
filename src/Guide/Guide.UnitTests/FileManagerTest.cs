using NUnit.Framework;
using System.IO;

namespace Guide.UnitTests
{
    class FileManagerTest
    {
        [TestCase(TestName = "Загрузка параметров, позитив")]
        public void FileManagerGetTest()
        {
            //Setup
            var expectedParameters = new GuideParameters();
            expectedParameters.GuideAngle = 180;
            var a = Directory.GetCurrentDirectory();
            //if(Directory.Exists("TestData"))
            //{
                
            //}
            //Act
            var actualParameters = FileManager.LoadFile(@"TestData\CorrectGuideParameters.json");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedParameters, actualParameters);
            }
            );
        }
    }
}
