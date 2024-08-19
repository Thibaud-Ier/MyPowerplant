using Domain.ValueObjects.Fuels;

namespace DomainTests.ValueObjects.Fuels
{
    public class GasTests
    {
        [Fact]
        public void GivenNegativeValueWhenInitGasThenRaiseException()
        {
            Assert.Throws<InvalidOperationException>(() => new Gas(-8));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(4242)]
        public void GivenPositiveValueWhenInitGasThenGasValueShouldBeEqualToTheParameter(int value)
        {
            var gas = new Gas(value);

            Assert.Equal(value, gas.Value);
        }
    }
}
