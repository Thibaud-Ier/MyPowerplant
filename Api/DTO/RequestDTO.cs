using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Api.DTO
{
    public class RequestDTO
    {
        public int Load { get; set; }

        public required Dictionary<string, double> Fuels { get; set; }

        public required List<PowerPlantDTO> Powerplants { get; set; }

        public Load ToLoad() => new(new PositiveIntValue(Load));

        public List<Fuel> ToFuels => Fuels.Select(x => FuelFactory.MakeFuel(x.Key, x.Value)).ToList();

        public List<PowerPlant> ToPowerPlant() => Powerplants.Select(x => PowerPlantFactory.MakePowerPlant(x)).ToList();
    }
}
