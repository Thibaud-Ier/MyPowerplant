using Domain.ValueObjects;

namespace DomainTests.ValueObjects
{
    public class RateTests
    {
        [Fact]
        public void GivenNegativeParameterWhenInitRateThenRaiseException()
        {
            Assert.Throws<InvalidOperationException>(() => new Rate(-0.1));
        }

        [Fact]
        public void GivenParameterSuperiorThan1WhenInitRateThenRaiseException()
        {
            Assert.Throws<InvalidOperationException>(() => new Rate(1.1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(0.5)]
        [InlineData(1)]
        public void GivenAParameterBetween0and1WhenInitRateThenValueShouldBeEqualToTheParameter(int value)
        {
            var rate = new Rate(value);

            Assert.Equal(value, rate.Value);
        }
    }
}
