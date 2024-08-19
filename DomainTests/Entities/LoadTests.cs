using Domain.ValueObjects;


namespace DomainTests.Entities
{
    public class LoadTests
    {
        [Fact]
        public void GivenNegativeValueWhenInitLoadThenRaiseException()
        {
            Assert.Throws<InvalidOperationException>(() => new Load(-8));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(4242)]
        public void GivenPositiveValueWhenInitLoadThenLoadValueShouldBeEqualToTheParameter(int value)
        {
            var load = new Load(value);

            Assert.Equal(value, load.Value);
        }
    }
}
