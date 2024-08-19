using Domain.ValueObjects;

namespace DomainTests.ValueObjects
{
    public class PercentTests
    {
        [Fact]
        public void GivenNegativeParameterWhenInitPercentThenRaiseException()
        {
            Assert.Throws<InvalidOperationException>(() => new Percent(-8));
        }

        [Fact]
        public void GivenParameterSuperiorThan100WhenInitPercentThenRaiseException()
        {
            Assert.Throws<InvalidOperationException>(() => new Percent(118));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void GivenAParameterBetween0and100WhenInitPercentThenValueShouldBeEqualToTheParameterAndTheRateShouldBeRight(int value)
        {
            var percent = new Percent(value);

            Assert.Equal(value, percent.Value);
            Assert.Equal(value / 100.0, percent.Rate);
        }
    }
}
