using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;
using System.ComponentModel.DataAnnotations;

namespace Domain.DomainServices
{
    public class PowerPlantService(Load load, IEnumerable<Fuel> fuels, IEnumerable<PowerPlant> powerPlants)
    {
        public Load _load = load;

        public readonly Dictionary<string, Fuel> _fuels = fuels.ToDictionary(x => x.Name);

        public readonly Dictionary<string, PowerPlant> _powerPlants = powerPlants.ToDictionary(x => x.Id);

        public IDictionary<string, double> GetMeritOrder()
        {
            
            var orderCost = _powerPlants.OrderBy(x => x.Value.GetCostByMegaWattOfFuel(_fuels[x.Value.TypeFuel.Name]))
                .ThenByDescending(x => x.Value.GetEffectiveMaximumPower(_fuels[x.Value.TypeFuel.Name]))
                .ThenBy(x => x.Value.GetEffectiveMinimumPower(_fuels[x.Value.TypeFuel.Name]))
                .Select(x => x.Key)
                .ToList();
            var result = new Dictionary<string, double>();

            MeridOrderLoop(orderCost, result);

            return result;
        }

        private void MeridOrderLoop(List<string> orderCost, Dictionary<string, double> result)
        {
            var total = 0.0;

            while (orderCost.Count != 0)
            {
                var name = orderCost.First();
                var powerPlant = _powerPlants[name];
                var fuel = _fuels[powerPlant.TypeFuel.Name];
                var consumed = GetConsumed(total, powerPlant, fuel);

                result.Add(name, consumed);
                total += consumed;

                orderCost.Remove(name);
            }
        }

        private double GetConsumed(double total, PowerPlant powerPlant, Fuel fuel)
        {
            var result = 0.0;

            if (total < _load.Value.Value)
            {
                if (total + powerPlant.GetEffectiveMinimumPower(fuel) >= _load.Value.Value)
                {
                    result = powerPlant.GetEffectiveMinimumPower(fuel);
                }
                else if (total + powerPlant.GetEffectiveMaximumPower(fuel) >= _load.Value.Value)
                {
                    result = _load.Value.Value - total;
                }
                else
                {
                    result = powerPlant.GetEffectiveMaximumPower(fuel);
                }
            }

            return result;
        }
    }
}