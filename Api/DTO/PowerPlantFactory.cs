using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Fuels;

namespace Api.DTO
{
    public static class PowerPlantFactory
    {
        public static PowerPlant MakePowerPlant(PowerPlantDTO dto)
        {
            return dto.Type switch
            {
                "gasfired" => new Gasfired(dto.Name, new Rate(dto.Efficiency), new PositiveIntValue(dto.Pmin), new PositiveIntValue(dto.Pmax)),
                "turbojet" => new Turbojet(dto.Name, new Rate(dto.Efficiency), new PositiveIntValue(dto.Pmin), new PositiveIntValue(dto.Pmax)),
                "windturbine" => new Windturbine(dto.Name, new PositiveIntValue(dto.Pmin), new PositiveIntValue(dto.Pmax)),
                _ => throw new ArgumentException("PowerPlant"),
            };
        }
    }
}
