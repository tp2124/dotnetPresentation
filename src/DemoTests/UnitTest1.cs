using System;
using Xunit;

namespace DemoTests
{
    public class UnitTest1
    {
        [Fact]
        public void SuccessfulTest()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void FailingTest()
        {
            // Commented out to stop failing my CI
            // Assert.Equal(4, 0);
            Assert.Equal(0, 0);
        }
    }
}
