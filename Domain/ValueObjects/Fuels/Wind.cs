namespace Domain.ValueObjects.Fuels
{
    public class Wind(Percent value) : Fuel
    {
        public override string Name => "Wind";

        public override PositiveDoubleValue Value { get; } = new PositiveDoubleValue(value.Rate.Value);

        public Percent Percent { get; } = value;
    }
}
