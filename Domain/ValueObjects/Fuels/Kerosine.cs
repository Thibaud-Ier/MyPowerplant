namespace Domain.ValueObjects.Fuels
{
    public class Kerosine(PositiveDoubleValue value) : Fuel
    {
        public override string Name => "Kerosine";

        public override PositiveDoubleValue Value { get; } = value;
    }
}
