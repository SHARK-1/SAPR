using NUnit.Framework;

namespace Guide.UnitTests
{
    class RangeTest
    {
        [TestCase(true, TestName = "Конструктор, максимальное значение")]
        [TestCase(false, TestName = "Конструктор, минимальное значение")]
        public void RangeConstructor_Test(bool isMaxBorder)
        {
            //Arrange
            var expectedValue = isMaxBorder?20:12;

            //Act
            var range = new Range(12, 20);

            //Assert
            if (isMaxBorder)
            {
                Assert.AreEqual(expectedValue, range.Max);
            }
            else
            {
                Assert.AreEqual(expectedValue, range.Min);
            }
        }
        [TestCase(true, TestName = "Максимальное значение")]
        [TestCase(false, TestName = "Минимальное значение")]
        public void RangeMinMax_Test(bool isMaxBorder)
        {
            //Arrange
            var expectedValue = isMaxBorder ? 20 : 12;

            //Act
            var range = new Range(0, 100);
            if (isMaxBorder)
            {
                range.Max = expectedValue;
            }
            else
            {
                range.Min = expectedValue;
            }

            //Assert
            if (isMaxBorder)
            {
                Assert.AreEqual(expectedValue, range.Max);
            }
            else
            {
                Assert.AreEqual(expectedValue, range.Min);
            }
        }
    }
}
