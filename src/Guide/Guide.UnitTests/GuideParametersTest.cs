using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework;
using Microsoft.VisualBasic;

namespace Guide.UnitTests
{

    public class GuideParametersTest
    {
        public void testforallnegativ(ParametersEnum parametersEnum, double value)
        {
            //Arrange
            var expectedValue = value;
            var parameter = new GuideParameters();

            //Assert
            Assert.Throws <TargetInvocationException > (() =>
            {
                //Act
                var propertyInfo = typeof(GuideParameters).
                        GetProperty(parametersEnum.ToString());
                propertyInfo.SetValue(parameter, value);
                parameter.GuideWidth = expectedValue;

                
            });
        }
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
        [TestCase(TestName = "Ширину направляющей, позитив")]
        public void TestSetGuideWidth_CurrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 15;
            var parameter = new GuideParameters();

            //Act
            parameter.GuideWidth = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.GuideWidth);
        }
        [TestCase(TestName = "Толщину направляющей, позитив")]
        public void TestSetGuideDepth_CurrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 15;
            var parameter = new GuideParameters();

            //Act
            parameter.GuideDepth = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.GuideDepth);
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
            testforallnegativ(ParametersEnum.GuideLength, 1);
            ////Arrange
            //var expectedValue = 160;
            //var parameter = new GuideParameters();

            ////Assert
            //Assert.Throws<Exception>(() =>
            //{
            //    //Act
            //    parameter.GuideLength = expectedValue;
            //});
        }

    }
}
