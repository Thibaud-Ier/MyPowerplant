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

        [Theory]
        [InlineData("Tricastin")]
        [InlineData("Bollène")]
        [InlineData("Marcoul")]
        public void GivenRightArgumentWhenInitPowerPlantShouldBuildCorrectlyThePowerPlant(string value)
        {
            var powerPlant = new PowerPlant(value);

            Assert.Equal(value, powerPlant.Name);
        }
    }
}
