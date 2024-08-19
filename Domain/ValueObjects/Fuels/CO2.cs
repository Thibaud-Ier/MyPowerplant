namespace Domain.ValueObjects.Fuels
{
    public class CO2(PositiveValue value) : Fuel
    {
        public override string Name => "CO2";

        public override double Value { get; } = value.Value;
    }
}
