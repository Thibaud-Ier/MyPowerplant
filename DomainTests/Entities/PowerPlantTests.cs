using Domain.Entities;
using Domain.ValueObjects;

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
            Assert.Throws<InvalidOperationException>(() => new Gasfired(value, new Rate(0.5)));
        }

        [Theory]
        [InlineData("Tricastin", 0.5)]
        [InlineData("Bollène", 0.6)]
        [InlineData("Marcoul", 0.7)]
        public void GivenRightArgumentWhenInitPowerPlantShouldBuildCorrectlyThePowerPlant(string value, double efficiency)
        {
            var powerPlant = new Gasfired(value, new Rate(efficiency));

            Assert.Equal(value, powerPlant.Name);
        }
    }
}
