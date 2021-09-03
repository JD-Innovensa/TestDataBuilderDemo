using Xunit;

namespace Tests
{
    public class SimpleTest
    {
        public SimpleTest()
        {
        }


        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(5, 2, 7)]
        public void AddNumbersTests(int a, int b, int expectedResult)
        {
            // Act
            var actualResult = AddNumbers(a, b);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }


        [Fact]
        public void AddNumbersTest()
        {
            // Arrange
            var a = 3;
            var b = 7;

            // Act
            var actualResult = AddNumbers(a, b);

            // Assert
            Assert.Equal(10, actualResult);
        }
    }
}