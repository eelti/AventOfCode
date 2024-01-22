namespace day05;

public record struct SeedRange(long Start, long Length)
{
    public long End => Start + Length - 1;
}