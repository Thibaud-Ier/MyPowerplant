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
            Assert.Throws<InvalidOperationException>(() => new Gasfired(value, new Rate(0.5), new PositiveValue(50), new PositiveValue(100)));
        }

        [Fact]
        public void GivenMinimumPowerSuperiorThanMaximumPowerWhenInitPowerPlantShouldRaiseAnException()
        {
            Assert.Throws<InvalidOperationException>(() 
                => new Gasfired("Tricastin", new Rate(0.5), new PositiveValue(50), new PositiveValue(45)));
        }

        [Theory]
        [InlineData("Tricastin", 0.5, 50, 100)]
        [InlineData("Bollène", 0.6, 78, 98)]
        [InlineData("Marcoul", 0.7, 250, 300)]
        public void GivenRightArgumentWhenInitPowerPlantShouldBuildCorrectlyThePowerPlant(string name,
            double efficiency, int minimum, int maximum)
        {
            var powerPlant = new Gasfired(name, new Rate(efficiency), new PositiveValue(minimum), new PositiveValue(maximum));

            Assert.Equal(name, powerPlant.Name);
            Assert.Equal(efficiency, powerPlant.Efficiency.Value);
            Assert.Equal(minimum, powerPlant.MinimumPower.Value);
            Assert.Equal(maximum, powerPlant.MaximumPower.Value);
        }
    }
}
