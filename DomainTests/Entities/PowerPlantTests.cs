﻿using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

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
            Assert.Throws<InvalidOperationException>(() => new Gasfired(value, new Rate(0.5), new PositiveIntValue(50), new PositiveIntValue(100)));
        }

        [Fact]
        public void GivenMinimumPowerSuperiorThanMaximumPowerWhenInitPowerPlantShouldRaiseAnException()
        {
            Assert.Throws<InvalidOperationException>(() 
                => new Gasfired("Tricastin", new Rate(0.5), new PositiveIntValue(50), new PositiveIntValue(45)));
        }

        [Theory]
        [InlineData("Tricastin", 0.5, 50, 100)]
        [InlineData("Bollène", 0.6, 78, 98)]
        [InlineData("Marcoul", 0.7, 250, 300)]
        public void GivenRightArgumentWhenInitPowerPlantShouldBuildCorrectlyThePowerPlant(string name,
            double efficiency, int minimum, int maximum)
        {
            var powerPlant = new Gasfired(name, new Rate(efficiency), new PositiveIntValue(minimum), new PositiveIntValue(maximum));

            Assert.Equal(name, powerPlant.Name);
            Assert.Equal(efficiency, powerPlant.Efficiency.Value);
            Assert.Equal(minimum, powerPlant.MinimumPower.Value);
            Assert.Equal(maximum, powerPlant.MaximumPower.Value);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(50, 50)]
        [InlineData(100, 100)]
        public void GivenWindWithWindturbineWhenGetEffectiveMinimumPowerShouldReturnTheEffectiveMinimum(int windrate, double expected)
        {
            var powerPlant = new Windturbine("MyEole", new PositiveIntValue(100), new PositiveIntValue(200));

            var result = powerPlant.GetEffectiveMinimumPower(new Wind(new Percent(windrate)));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(50, 100)]
        [InlineData(100, 200)]
        public void GivenWindWithWindturbineWhenGetEffectiveMaximumPowerShouldReturnTheEffectiveMinimum(int windrate, double expected)
        {
            var powerPlant = new Windturbine("MyEole", new PositiveIntValue(100), new PositiveIntValue(200));

            var result = powerPlant.GetEffectiveMaximumPower(new Wind(new Percent(windrate)));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenFuelWithoutWindturbineWhenGetEffectiveMinimumPowerShouldReturnTheMinimumPower()
        {
            var powerPlant = new Gasfired("MyGas", new Rate(0.5), new PositiveIntValue(100), new PositiveIntValue(200));

            var result = powerPlant.GetEffectiveMinimumPower(new Gas(new PositiveDoubleValue(10)));

            Assert.Equal(100, result);
        }

        [Fact]
        public void GivenFuelWithoutWindturbineWhenGetEffectiveMaximumPowerShouldReturnTheMaximumPower()
        {
            var powerPlant = new Turbojet("MyTurbojet", new Rate(0.6), new PositiveIntValue(100), new PositiveIntValue(200));

            var result = powerPlant.GetEffectiveMaximumPower(new Kerosine(new PositiveDoubleValue(20)));

            Assert.Equal(200, result);
        }

        [Theory]
        [InlineData(0.125, 10, 80)]
        [InlineData(0.5, 10, 20)]
        [InlineData(1, 20, 20)]
        public void GivenFuelWithoutWindturbineWhenGetCostByMegaWattOfFuelShouldReturnTheRightPrice(double efficiency, double price, double expected)
        {
            var powerPlant = new Turbojet("MyTurbojet", new Rate(efficiency), new PositiveIntValue(100), new PositiveIntValue(200));
            var kerosine = new Kerosine(new PositiveDoubleValue(price));
            var co2 = new CO2(new PositiveDoubleValue(50));

            var result = powerPlant.GetCostByMegaWattOfFuel(kerosine, co2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0.125, 10, 6, 81.8)]
        [InlineData(0.5, 10, 12, 23.6)]
        [InlineData(1, 20, 18, 25.4)]
        public void GivenFuelWithGasfiredWhenGetCostByMegaWattOfFuelShouldReturnTheRightPriceWithCO2(double efficiency, double priceGas, double priceC02, double expected)
        {
            var powerPlant = new Gasfired("MyGas", new Rate(efficiency), new PositiveIntValue(100), new PositiveIntValue(200));
            var gas = new Gas(new PositiveDoubleValue(priceGas));
            var co2 = new CO2(new PositiveDoubleValue(priceC02));

            var result = powerPlant.GetCostByMegaWattOfFuel(gas, co2);

            Assert.Equal(expected, result, 0.000001);
        }
    }
}
