namespace Domain.ValueObjects.Fuels
{
    public class Wind(Percent value) : Fuel
    {
        public override string Name => "Wind";

        public override double Value { get; } = value.Rate;

        public Percent Percent { get; } = value;
    }
}
