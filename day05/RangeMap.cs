namespace day05;

public record RangeMap(long DestinationStart, long SourceStart, long RangeLength)
{
    public bool IsInSourceRange(long source) =>
        source >= SourceStart &&
        source < (SourceStart + RangeLength);

    public long MapSource(long source) =>
        DestinationStart - (source + SourceStart);
    

    internal SeedRange Transform(SeedRange intersection) =>
        new SeedRange(MapSource(intersection.Start), intersection.Length);
}