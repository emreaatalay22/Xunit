using Xunit;

namespace xUnitTest.App.Test
{
    public class TheoryTest
    {
        public Calculator calculator { get; set; }
        public TheoryTest()
        {
            calculator = new Calculator();
        }

        [Fact]
        public void AddTest()
        {
            //Arrange
            int a = 5;
            int b = 20;

            //Act
            var total = calculator.Add(a, b);

            //Assert
            Assert.NotEqual<int>(26, total);
        }

        [Theory]
        [InlineData(5, 7, 12)]
        [InlineData(6, 2, 8)]
        public void AddSimpleValueReturnTotal(int a, int b, int exceptedData)
        {
            var actualData = calculator.Add(a, b);

            Assert.Equal(exceptedData, actualData); 
        }


        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(6, 0, 0)]
        public void AddSimpleValueReturnZero(int a, int b, int exceptedData)
        {
            var actualData = calculator.Add(a, b);

            Assert.Equal(exceptedData, actualData);

        }
    }
}
