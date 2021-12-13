using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Guide.UnitTests
{

    public class GuideParametersTest
    {
        [TestCase(TestName = "Длинна направляющей, позитив")]
        public void TestSetGuideLength_CurrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 60;
            var parameter = new GuideParameters();

            //Act
            parameter.GuideLength = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.GuideLength);
        }

        [TestCase(TestName = "Длинна направляющей меньше положенного")]
        public void TestSetGuideLength_IncurrectValueLess50_ArgumentException()
        {
            //Arrange
            var expectedValue = 40;
            var parameter = new GuideParameters();

            //Assert
            Assert.Throws<Exception>(() =>
            {
                //Act
                parameter.GuideLength = expectedValue;
            });
        }

        [TestCase(TestName = "Длинна направляющей больше положенного")]
        public void TestSetGuideLength_IncurrectValueMore150_ArgumentException()
        {
            //Arrange
            var expectedValue = 160;
            var parameter = new GuideParameters();

            //Assert
            Assert.Throws<Exception>(() =>
            {
                //Act
                parameter.GuideLength = expectedValue;
            });
        }

    }
}
