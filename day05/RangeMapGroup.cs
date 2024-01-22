namespace day05;

public class RangeMapGroup
{
    private readonly RangeMap[] _maps;

    public RangeMapGroup(RangeMap[] maps)
    {
        _maps = maps.OrderBy(o => o.SourceStart).ToArray();
    }

    public SeedRange[] Map(SeedRange seedRange)
    {
        var result = new List<SeedRange>();
        return result.ToArray();
    }
}