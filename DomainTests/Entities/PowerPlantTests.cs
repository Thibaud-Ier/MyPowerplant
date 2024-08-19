using Domain.Entities;

namespace DomainTests.Entities
{
    public class PowerPlantTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void GivenBadStringValueWhenInitPowerPlantShouldRaiseAnException(string value)
        {
            Assert.Throws<InvalidOperationException>(() => new PowerPlant(value));
        }
    }
}
