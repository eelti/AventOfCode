public class Map
{
    public string Type { get; set; }
    public long Source { get; set; }
    public long Destination { get; set; }
    public long Duration { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var map = (Map)obj;
        return Type == map.Type && Source == map.Source && Destination == map.Destination && Duration == map.Duration;
    }

    // override GetHashCode as well, using the values of the properties to calculate it
    public override int GetHashCode()
    {
        unchecked 
        {
            int hash = 17;
            hash = hash * 31 + (Type != null ? Type.GetHashCode() : 0);
            hash = hash * 31 + Source.GetHashCode();
            hash = hash * 31 + Destination.GetHashCode();
            hash = hash * 31 + Duration.GetHashCode();
            return hash;
        }
    }
}