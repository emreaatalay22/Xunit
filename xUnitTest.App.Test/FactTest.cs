using System.Collections.Generic;
using Xunit;

namespace xUnitTest.App.Test
{
    public class FactTest
    {
        [Fact]
        public void AddTest()
        {
            //Arrange
            int a = 5;
            int b = 20;

            var calculator = new Calculator();

            //Act
            var total = calculator.Add(a, b);

            //Assert
            Assert.NotEqual<int>(26, total);
        }
        [Fact]
        public void ContainsTest()
        {
            ////Arrange
            var names = new List<string>() { "Emre", "Fatih", "Hasan" };

            ////Act

            //Assert
            Assert.Contains("Emre", "Emre Atalay");

            Assert.Contains(names, x => x == "Emre");
        }
        [Fact]
        public void TrueAndFalseTest()
        {
            ////Arrange

            ////Act

            //Assert 
            Assert.True(5 > 2);
            Assert.True("".GetType() == typeof(string));
        }

        [Fact]
        public void MatchesTest()
        {
            var regex = "^Emre";

            //Example
            //https://cs.lmu.edu/~ray/notes/regex/

            Assert.Matches(regex, "Emre Atalay");
        }

        [Fact]
        public void StartsEndsWithTest()
        {
            Assert.StartsWith("Emre", "Emre Atalay");

            Assert.EndsWith("Atalay", "Emre Atalay");
        }
        [Fact]
        public void EmptyNotEmptyTest()
        {
            Assert.Empty(new List<int>());
            Assert.NotEmpty(new List<int>() { 1 });
        }
        [Fact]
        public void InRangeTest()
        {
            Assert.InRange(4, 1, 5);
        }

        [Fact]
        public void SingleTest()
        {
            //Only one item 
            Assert.Single(new List<int>() { 1 });

            //Error
            // Assert.Single(new List<int>() { 1, 5 });
        }

        [Fact]
        public void IsTypeIsNotTypeTest()
        {
            Assert.IsType<int>(1);

            //Error
            // Assert.IsType<int>("Emre");
        }

        [Fact]
        public void IsAssignableFromTest()
        {
            Assert.IsAssignableFrom<IEnumerable<int>>(new List<int>());
        }
    }
}
