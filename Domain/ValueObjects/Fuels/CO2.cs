namespace Domain.ValueObjects.Fuels
{
    public class CO2(PositiveDoubleValue value) : Fuel
    {
        public override string Name => "CO2";

        public override PositiveDoubleValue Value { get; } = value;
    }
}
