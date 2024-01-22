using System.Text.RegularExpressions;

namespace day05;

public class InterpreterV2
{
    private const int GroupValue = 7;
    public List<SeedRange> PairsSeeds = new();

    public InterpreterV2(string path)
    {
        using var inputStream = File.OpenRead(path);
        using var reader = new StreamReader(inputStream);

        GetSeedsPart2(reader);
        reader.ReadLine(); // read next line ad is empty

        var mapGroups = new List<RangeMapGroup>();

        for (int i = 0; i < GroupValue; i++)
        {
            var maps = new List<RangeMap>();
            string? line = reader.ReadLine();
            Console.WriteLine($"This is group: {line}");
            while (!string.IsNullOrEmpty(line))
            {
                line = reader.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                var parts = line.Split(' ');
                maps.Add(new RangeMap(long.Parse(parts[0]), long.Parse(parts[1]), long.Parse(parts[2])));
                Console.WriteLine(line);
            }

            var seedRangeGroup = new RangeMapGroup(maps.ToArray());
            mapGroups.Add(seedRangeGroup);
        }

        Console.WriteLine();
    }

    private void GetSeedsPart2(StreamReader input)
    {
        var seeds = Regex.Match(input.ReadLine(), @"seeds: (.*)(\r)?").Groups[1].Value.Split(" ")
            .Select(s => long.Parse(s)).ToArray();
        PairsSeeds = new List<SeedRange>();
        for (int i = 0; i < seeds.Length; i += 2)
        {
            PairsSeeds.Add(new(seeds[i], seeds[i + 1]));
        }
    }
   
}