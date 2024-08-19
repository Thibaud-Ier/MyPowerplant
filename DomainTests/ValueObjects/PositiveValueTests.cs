using Domain.ValueObjects;

namespace DomainTests.ValueObjects
{
    public class PositiveValueTests
    {
        [Fact]
        public void GivenNegativeParameterWhenInitPositiveValueThenRaiseException()
        {
            Assert.Throws<InvalidOperationException>(() => new PositiveIntValue(-8));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(4242)]
        public void GivenPositiveParameterWhenInitPositiveValueThenValueShouldBeEqualToTheParameter(int value)
        {
            var positiveValue = new PositiveIntValue(value);

            Assert.Equal(value, positiveValue.Value);
        }
    }
}
