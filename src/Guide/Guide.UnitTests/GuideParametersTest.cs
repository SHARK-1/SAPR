using System.Reflection;
using NUnit.Framework;

namespace Guide.UnitTests
{

    public class GuideParametersTest
    {
        [TestCase(ParametersEnum.GuideLength,60, TestName = "Длинна направляющей, позитив")]
        [TestCase(ParametersEnum.GuideWidth, 11, TestName = "Ширина направляющей, позитив")]
        [TestCase(ParametersEnum.GuideDepth, 6, TestName = "Толщина направляющей, позитив")]
        [TestCase(ParametersEnum.AttachmentStrokeLength, 16, TestName = "Длинна хода крепления, позитив")]
        [TestCase(ParametersEnum.AttachmentStrokeWidth, 4, TestName = "Ширина хода крепления, позитив")]
        [TestCase(ParametersEnum.HoleDiameter, 3, TestName = "Диаметр отверстия, позитив")]
        [TestCase(ParametersEnum.GuideAngle, 100, TestName = "Угол наклона направляющей, позитив")]
        public void TestSet_CorrectValue(ParametersEnum parametersEnum, double value)
        {
            //Arrange
            var expectedValue = value;
            var parameter = new GuideParameters();

            //Act
            var propertyInfo = typeof(GuideParameters).
                        GetProperty(parametersEnum.ToString());
            propertyInfo.SetValue(parameter, value);

            //Assert
            Assert.AreEqual(expectedValue, propertyInfo.GetValue(parameter));
        }
        [TestCase(ParametersEnum.GuideLength, 30, TestName = "Длинна направляющей, меньше положенного, исключение")]
        [TestCase(ParametersEnum.GuideLength, 160, TestName = "Длинна направляющей, больше положенного, исключение")]
        [TestCase(ParametersEnum.GuideWidth, 5, TestName = "Ширина направляющей, меньше положенного, исключение")]
        [TestCase(ParametersEnum.GuideWidth, 60, TestName = "Ширина направляющей, больше положенного, исключение")]
        [TestCase(ParametersEnum.GuideDepth, 1, TestName = "Толщина направляющей, меньше положенного, исключение")]
        [TestCase(ParametersEnum.GuideDepth, 60, TestName = "Толщина направляющей, больше положенного, исключение")]
        [TestCase(ParametersEnum.AttachmentStrokeLength, 1, TestName = "Длинна хода крепления, меньше положенного, исключение")]
        [TestCase(ParametersEnum.AttachmentStrokeLength, 100, TestName = "Длинна хода крепления, больше положенного, исключение")]
        [TestCase(ParametersEnum.AttachmentStrokeWidth, 1, TestName = "Ширина хода крепления, меньше положенного, исключение")]
        [TestCase(ParametersEnum.AttachmentStrokeWidth, 60, TestName = "Ширина хода крепления, больше положенного, исключение")]
        [TestCase(ParametersEnum.HoleDiameter, 1, TestName = "Диаметр отверстия, меньше положенного, исключение")]
        [TestCase(ParametersEnum.HoleDiameter, 60, TestName = "Диаметр отверстия, больше положенного, исключение")]
        [TestCase(ParametersEnum.GuideAngle, 60, TestName = "Угол наклона направляющей, меньше положенного, исключение")]
        [TestCase(ParametersEnum.GuideAngle, 300, TestName = "Угол наклона направляющей, больше положенного, исключение")]
        public void TestSet_IncorrectValue(ParametersEnum parametersEnum, double value)
        {
            //Arrange
            var expectedValue = value;
            var parameter = new GuideParameters();

            //Assert
            Assert.Throws<TargetInvocationException>(() =>
         {
             //Act
             var propertyInfo = typeof(GuideParameters).
                  GetProperty(parametersEnum.ToString());
             propertyInfo.SetValue(parameter, value);
         });
        }
        /// <summary>
        /// Проверка максимальных минимальных значений параметра AttachmentStrokeWidth
        /// </summary>
        /// <param name="maxBorder">True-Максимальное, False- Минимальное</param>
        [TestCase(true, TestName = "Максимальное значение параметра AttachmentStrokeWidth")]
        [TestCase(false, TestName = "Минимальное значение параметра AttachmentStrokeWidth")]
        public void TestDiapozon_AttachmentStrokeWidth(bool isMaxBorder)
        {
            double guideWidth = 20;
            //Arrange
            var expectedValue = isMaxBorder ? guideWidth * 0.5 : guideWidth * 0.3;
            var parameter = new GuideParameters();

            //Act
            parameter.GuideWidth = guideWidth;

            //Assert
            if (isMaxBorder)
            {
                Assert.AreEqual(expectedValue, parameter.RangeDictionary[ParametersEnum.AttachmentStrokeWidth].Max);
            }
            else
            {
                Assert.AreEqual(expectedValue, parameter.RangeDictionary[ParametersEnum.AttachmentStrokeWidth].Min);
            }
        }
        [TestCase(TestName = "Минимальное значение параметра AttachmentStrokeLenght")]
        public void TestDiapozon_AttachmentStrokeLenght()
        {
            double attachmentStrokeWidth = 5;
            //Arrange
            var expectedValue = 5 * attachmentStrokeWidth;
            var parameter = new GuideParameters();

            //Act
            parameter.AttachmentStrokeLength = 90;
            parameter.AttachmentStrokeWidth = attachmentStrokeWidth;

            //Assert
            Assert.AreEqual(expectedValue, parameter.RangeDictionary[ParametersEnum.AttachmentStrokeLength].Min);
        }
    }
}
