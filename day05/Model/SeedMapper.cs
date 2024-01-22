namespace day05
{
    public class SeedMapper
    {
        public Guid Id { get; set; }
        public long Seed { get; set; }
        public long Soil { get; set; }
        public long Fertilizer { get; set; }
        public long Water { get; set; }
        public long Light { get; set; }
        public long Temperature { get; set; }
        public long Humidity { get; set; }
        public long Location { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (SeedMapper) obj;
            return Seed == other.Seed
                   && Soil == other.Soil
                   && Fertilizer == other.Fertilizer
                   && Water == other.Water
                   && Light == other.Light
                   && Temperature == other.Temperature
                   && Humidity == other.Humidity
                   && Location == other.Location;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Seed, Soil, Fertilizer, Water, Light, Temperature, Humidity, Location);
        }
    }
}