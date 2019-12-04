using System;
using Xunit;

namespace BeerBowlingLeagueTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int expected = 2;

            // Act
            int result = 1;

            // Assert
            Assert.Equal(expected , result);
        }
    }
}
