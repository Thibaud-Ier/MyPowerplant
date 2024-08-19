namespace Domain.ValueObjects.Fuels
{
    public class Gas(PositiveDoubleValue value) : Fuel
    {
        public override string Name => "Gas";

        public override PositiveDoubleValue Value { get; } = value;
    }
}
