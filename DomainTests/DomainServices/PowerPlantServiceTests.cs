using Domain.DomainServices;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace DomainTests.DomainServices
{
    public class PowerPlantServiceTests
    {
        [Fact]
        public void GivenPayLoad3WhenPowerPlantServiceGetMeritOrderThenReturnResponse3()
        {
            var load = new Load(new PositiveIntValue(910));
            var fuels = new List<Fuel>() 
            {
                new Gas(new PositiveDoubleValue(13.4)),
                new Kerosine(new PositiveDoubleValue(50.8)),
                new CO2(new PositiveDoubleValue(20)),
                new Wind(new Percent(60))
            };

            var powerplants = new List<PowerPlant>()
            {
                new Gasfired("gasfiredbig1", new Rate(0.53), new PositiveIntValue(100), new PositiveIntValue(460)),
                new Gasfired("gasfiredbig2", new Rate(0.53), new PositiveIntValue(100), new PositiveIntValue(460)),
                new Gasfired("gasfiredsomewhatsmaller", new Rate(0.37), new PositiveIntValue(40), new PositiveIntValue(210)),
                new Turbojet("tj1", new Rate(0.3), new PositiveIntValue(0), new PositiveIntValue(16)),
                new Windturbine("windpark1", new PositiveIntValue(0), new PositiveIntValue(150)),
                new Windturbine("windpark2", new PositiveIntValue(0), new PositiveIntValue(36)),
            };
            var powerPlantService = new PowerPlantService(load, fuels, powerplants);

            var result = powerPlantService.GetMeritOrder();

            Assert.Equal(90.0, result["windpark1"]);
            Assert.Equal(21.6, result["windpark2"]);
            Assert.Equal(460.0, result["gasfiredbig1"]);
            Assert.Equal(338.4, result["gasfiredbig2"]);
            Assert.Equal(0.0, result["gasfiredsomewhatsmaller"]);
            Assert.Equal(0, result["tj1"]);
        }

    }
}
