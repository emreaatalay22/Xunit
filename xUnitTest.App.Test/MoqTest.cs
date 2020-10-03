using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace xUnitTest.App.Test
{
    public class MoqTest
    {
        public Mock<IMoqCalculatorService> myMock { get; set; }
        public MoqCalculator Calculator { get; set; }
        public MoqTest()
        {
            myMock = new Mock<IMoqCalculatorService>();
            this.Calculator = new MoqCalculator(myMock.Object);
        }

        [Theory]
        [InlineData(5, 7, 12)]
        [InlineData(6, 2, 8)]
        public void AddSimpleValueReturnTotal(int a, int b, int exceptedData)
        {
            myMock.Setup(x => x.Add(a, b)).Returns(exceptedData);

            var actualData = Calculator.Add(a, b);

            Assert.Equal(exceptedData, actualData);

            myMock.Verify(x => x.Add(a, b), Times.AtLeast(1));
        }

        [Theory]
        [InlineData(0, 7)]
        public void Exception_ZeroValue_ReturnsException(int a, int b)
        {
            myMock.Setup(x => x.Exception(a, b)).Throws(new Exception("a cannot be zero"));

            var exception = Assert.Throws<Exception>(() => Calculator.Exception(a, b));

            Assert.Equal("a cannot be zero", exception.Message);
        }


        [Theory]
        [InlineData(5, 7)]
        public void Callback_SimpleValue_ReturnsTotal(int a, int b)
        {
            int actualTotal = 0;
            myMock.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Callback<int, int>((x, y) => actualTotal = x + y);

            Calculator.Add(a, b);
            Assert.Equal(12, actualTotal);

            Calculator.Add(10, 30);
            Assert.Equal(40, actualTotal); 
        }
    }
}
