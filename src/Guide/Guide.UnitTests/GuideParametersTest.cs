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
        //TODO: https://docs.nunit.org/articles/nunit/writing-tests/attributes/testcase.html

        public void NegativeTest(ParametersEnum parametersEnum, double value)
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
            });
        }

        public void PositiveTest(ParametersEnum parametersEnum, double value)
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
        [TestCase(TestName = "Длинна направляющей, позитив")]
        public void TestSetGuideLength_CurrectValue_ResultCorrectSet()
        {
            PositiveTest(ParametersEnum.GuideLength, 60);
        }
        [TestCase(TestName = "Длинна направляющей меньше положенного")]
        public void TestSetGuideLength_IncurrectValueLess50_ArgumentException()
        {
            NegativeTest(ParametersEnum.GuideLength, 40);
        }
        [TestCase(TestName = "Длинна направляющей больше положенного")]
        public void TestSetGuideLength_IncurrectValueMore150_ArgumentException()
        {
            NegativeTest(ParametersEnum.GuideLength, 1);
        }
        [TestCase(TestName = "Ширину направляющей, позитив")]
        public void TestSetGuideWidth_CurrectValue_ResultCorrectSet()
        {
            PositiveTest(ParametersEnum.GuideWidth, 15);
        }
        [TestCase(TestName = "Ширину направляющей меньше положенного")]
        public void TestSetGuideWidth_IncurrectValueLess10_ArgumentException()
        {
            NegativeTest(ParametersEnum.GuideWidth, 5);
        }
        [TestCase(TestName = "Ширину направляющей больше положенного")]
        public void TestSetGuideWidth_IncurrectValueMore30_ArgumentException()
        {
            NegativeTest(ParametersEnum.GuideWidth, 35);
        }

        [TestCase(TestName = "Толщину направляющей, позитив")]
        public void TestSetGuideDepth_CurrectValue_ResultCorrectSet()
        {
            PositiveTest(ParametersEnum.GuideDepth, 15);
        }
        [TestCase(TestName = "Толщина направляющей меньше положенного")]
        public void TestSetGuideDepth_IncurrectValueLess5_ArgumentException()
        {
            NegativeTest(ParametersEnum.GuideDepth, 1);
        }
        [TestCase(TestName = "Толщина направляющей больше положенного")]
        public void TestSetGuideDepth_IncurrectValueMore20_ArgumentException()
        {
            NegativeTest(ParametersEnum.GuideDepth, 35);
        }

        [TestCase(TestName = "Длинна хода крепления, позитив")]
        public void TestSetAttachmentStrokeLength_CurrectValue_ResultCorrectSet()
        {
            PositiveTest(ParametersEnum.AttachmentStrokeLength, 15);
        }
        [TestCase(TestName = "Длинна хода крепления меньше положенного")]
        public void TestSetAttachmentStrokeLength_IncurrectValueLess15_ArgumentException()
        {
            NegativeTest(ParametersEnum.AttachmentStrokeLength, 1);
        }
        [TestCase(TestName = "Длинна хода крепления больше положенного")]
        public void TestSetAttachmentStrokeLength_IncurrectValueMore90_ArgumentException()
        {
            NegativeTest(ParametersEnum.AttachmentStrokeLength, 91);
        }

        [TestCase(TestName = "Ширина хода крепления, позитив")]
        public void TestSetAttachmentStrokeWidth_CurrectValue_ResultCorrectSet()
        {
            PositiveTest(ParametersEnum.AttachmentStrokeWidth, 4);
        }
        [TestCase(TestName = "Ширина хода крепления меньше положенного")]
        public void TestSetAttachmentStrokeWidth_IncurrectValueLess3_ArgumentException()
        {
            NegativeTest(ParametersEnum.AttachmentStrokeWidth, 1);
        }
        [TestCase(TestName = "Ширина хода крепления больше положенного")]
        public void TestSetAttachmentStrokeWidth_IncurrectValueMore5_ArgumentException()
        {
            NegativeTest(ParametersEnum.AttachmentStrokeWidth, 21);
        }

        [TestCase(TestName = "Диаметр отвестия, позитив")]
        public void TestSetHoleDiameter_CurrectValue_ResultCorrectSet()
        {
            PositiveTest(ParametersEnum.HoleDiameter, 4);
        }
        [TestCase(TestName = "Диаметр отвестия меньше положенного")]
        public void TestSetHoleDiameter_IncurrectValueLess2_ArgumentException()
        {
            NegativeTest(ParametersEnum.HoleDiameter, 1);
        }
        [TestCase(TestName = "Диаметр отвестия больше положенного")]
        public void TestSetHoleDiameter_IncurrectValueMore20_ArgumentException()
        {
            NegativeTest(ParametersEnum.HoleDiameter, 21);
        }

        [TestCase(TestName = "Угол наклона, позитив")]
        public void TestSetGuideAngle_CurrectValue_ResultCorrectSet()
        {
            PositiveTest(ParametersEnum.GuideAngle, 90);
        }
        [TestCase(TestName = "Угол наклона меньше положенного")]
        public void TestSetGuideAngle_IncurrectValueLess65_ArgumentException()
        {
            NegativeTest(ParametersEnum.GuideAngle, 12);
        }
        [TestCase(TestName = "Угол наклона больше положенного")]
        public void TestSetGuideAngle_IncurrectValueMore270_ArgumentException()
        {
            NegativeTest(ParametersEnum.GuideAngle, 275);
        }
    }
}
