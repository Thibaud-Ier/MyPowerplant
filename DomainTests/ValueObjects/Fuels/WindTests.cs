using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace DomainTests.ValueObjects.Fuels
{
    public class WindTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(50)]
        [InlineData(100)]
        public void GivenAPercentWhenInitWindThenValueShouldBeEqualsThePercentRate(int value)
        {
            var percent = new Percent(value);

            var wind = new Wind(percent);

            Assert.Equal(wind.Value, percent.Rate.Value);
            Assert.Equal(wind.Percent, percent);
        }
    }
}
