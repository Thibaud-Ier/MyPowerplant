using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Domain.DomainServices
{
    public class PowerPlantService(Load load, IEnumerable<Fuel> fuels, IEnumerable<PowerPlant> powerPlants)
    {
        public Load _load = load;

        public readonly Dictionary<string, Fuel> _fuels = fuels.ToDictionary(x => x.Name);

        public readonly Dictionary<string, PowerPlant> _powerPlants = powerPlants.ToDictionary(x => x.Id);

        public IDictionary<string, double> GetMeritOrder()
        {
            return null;
        }
    }
}
