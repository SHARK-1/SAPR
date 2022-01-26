using System.Reflection;
using NUnit.Framework;

using System.IO;

namespace Guide.UnitTests
{

    public class GuideParametersTest
    {
        //TODO: RSDN+
        [TestCase(ParameterNames.GuideLength,60,
            TestName = "Длинна направляющей, позитив")]
        [TestCase(ParameterNames.GuideWidth, 11,
            TestName = "Ширина направляющей, позитив")]
        [TestCase(ParameterNames.GuideDepth, 6,
            TestName = "Толщина направляющей, позитив")]
        [TestCase(ParameterNames.AttachmentStrokeLength, 16,
            TestName = "Длинна хода крепления, позитив")]
        [TestCase(ParameterNames.AttachmentStrokeWidth, 4,
            TestName = "Ширина хода крепления, позитив")]
        [TestCase(ParameterNames.HoleDiameter, 3, 
            TestName = "Диаметр отверстия, позитив")]
        [TestCase(ParameterNames.GuideAngle, 100,
            TestName = "Угол наклона направляющей, позитив")]
        public void TestSet_CorrectValue(
            ParameterNames ParameterNames, double value)
        {
            //Arrange
            var expectedValue = value;
            var parameter = new GuideParameters();

            //Act
            var propertyInfo = typeof(GuideParameters).
                        GetProperty(ParameterNames.ToString());
            propertyInfo.SetValue(parameter, value);

            //Assert
            Assert.AreEqual(expectedValue, propertyInfo.GetValue(parameter));
        }

        //TODO: RSDN+
        [TestCase(ParameterNames.GuideLength, 30, 
            TestName = "Длинна направляющей, меньше положенного, исключение")]
        [TestCase(ParameterNames.GuideLength, 160,
            TestName = "Длинна направляющей, больше положенного, исключение")]
        [TestCase(ParameterNames.GuideWidth, 5, 
            TestName = "Ширина направляющей, меньше положенного, исключение")]
        [TestCase(ParameterNames.GuideWidth, 60, 
            TestName = "Ширина направляющей, больше положенного, исключение")]
        [TestCase(ParameterNames.GuideDepth, 1,
            TestName = "Толщина направляющей, меньше положенного, исключение")]
        [TestCase(ParameterNames.GuideDepth, 60,
            TestName = "Толщина направляющей, больше положенного, исключение")]
        [TestCase(ParameterNames.AttachmentStrokeLength, 1,
            TestName = "Длинна хода крепления, меньше положенного, исключение")]
        [TestCase(ParameterNames.AttachmentStrokeLength, 100, 
            TestName = "Длинна хода крепления, больше положенного, исключение")]
        [TestCase(ParameterNames.AttachmentStrokeWidth, 1, 
            TestName = "Ширина хода крепления, меньше положенного, исключение")]
        [TestCase(ParameterNames.AttachmentStrokeWidth, 60, 
            TestName = "Ширина хода крепления, больше положенного, исключение")]
        [TestCase(ParameterNames.HoleDiameter, 1,
            TestName = "Диаметр отверстия, меньше положенного, исключение")]
        [TestCase(ParameterNames.HoleDiameter, 60,
            TestName = "Диаметр отверстия, больше положенного, исключение")]
        [TestCase(ParameterNames.GuideAngle, 60,
            TestName = "Угол наклона направляющей, меньше положенного, исключение")]
        [TestCase(ParameterNames.GuideAngle, 300,
            TestName = "Угол наклона направляющей, больше положенного, исключение")]
        public void TestSet_IncorrectValue(
            ParameterNames ParameterNames, double value)
        {
            //Arrange
            var expectedValue = value;
            var parameter = new GuideParameters();

            //Assert
            Assert.Throws<TargetInvocationException>(() =>
         {
             //Act
             var propertyInfo = typeof(GuideParameters).
                  GetProperty(ParameterNames.ToString());
             propertyInfo.SetValue(parameter, value);
         });
        }
        /// <summary>
        /// Проверка максимальных минимальных значений параметра 
        /// AttachmentStrokeWidth
        /// </summary>
        /// <param name="maxBorder">True-Максимальное, 
        /// False- Минимальное</param>
        [TestCase(true,
            TestName = "Максимальное значение параметра AttachmentStrokeWidth")]
        [TestCase(false, 
            TestName = "Минимальное значение параметра AttachmentStrokeWidth")]
        public void TestDiapozon_AttachmentStrokeWidth(bool isMaxBorder)
        {
            double guideWidth = 20;
            //Arrange
            var expectedValue = isMaxBorder 
                ? guideWidth * 0.5 
                : guideWidth * 0.3;
            var parameter = new GuideParameters();

            //Act
            parameter.GuideWidth = guideWidth;

            //Assert
            var assertedValue = isMaxBorder
                ? parameter.RangeDictionary[
                    ParameterNames.AttachmentStrokeWidth].Max
                : parameter.RangeDictionary[
                    ParameterNames.AttachmentStrokeWidth].Min;
            Assert.AreEqual(expectedValue, assertedValue);
        }

        [TestCase(TestName = "Минимальное значение параметра " +
            "AttachmentStrokeLenght")]
        public void TestDiapozon_AttachmentStrokeLenght()
        {
            double attachmentStrokeWidth = 5;
            //Arrange
            var expectedValue = 5 * attachmentStrokeWidth;
            var parameter = new GuideParameters();

            //Act
            parameter.AttachmentStrokeLength = 90;
            parameter.AttachmentStrokeWidth = attachmentStrokeWidth;

            //TODO: RSDN+
            //Assert
            Assert.AreEqual(expectedValue, parameter.RangeDictionary[
                ParameterNames.AttachmentStrokeLength].Min);
        }
        [TestCase(true,true, TestName = "Equals с самим собой, позитив")]
        [TestCase(false, true, TestName = "Equals с другими параметрами, позитив")]
        [TestCase(true, false,TestName = "Equals, негатив")]
        public void TestEquals(bool sameParameters, bool equal)
        {
            //Arrange
            var expectedValue = equal;
            var parameter = new GuideParameters();
            var comparisonParameter = new GuideParameters();
            if (!equal) comparisonParameter.GuideLength = 100;

            //Act
            var assertedValue = sameParameters
                ? parameter.Equals(comparisonParameter)
                : parameter.Equals(parameter);

            //Assert
            Assert.AreEqual(expectedValue, assertedValue);
        }
        [TestCase(TestName = "Equals с null")]
        public void TestEqualsWithNull()
        {
            //Arrange
            var expectedValue = false;
            var parameter = new GuideParameters();

            //Act
            var assertedValue = parameter.Equals(null);

            //Assert
            Assert.AreEqual(expectedValue, assertedValue);
        }
    }
}
