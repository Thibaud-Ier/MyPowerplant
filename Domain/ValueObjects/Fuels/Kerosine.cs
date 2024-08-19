namespace Domain.ValueObjects.Fuels
{
    public class Kerosine(PositiveValue value) : Fuel
    {
        public override string Name => "Kerosine";

        public override double Value { get; } = value.Value;
    }
}
