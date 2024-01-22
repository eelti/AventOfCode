using System.Text.RegularExpressions;
using shareKernel;

namespace day05;

public class Interpreter
{
    private static readonly List<string> List =
    [
        "seed-to-soil map:", "soil-to-fertilizer map:", "fertilizer-to-water map:", "water-to-light map:",
        "light-to-temperature map:", "temperature-to-humidity map:", "humidity-to-location map:"
    ];

    public readonly List<SeedMapper> _mappers = new();
    public readonly List<Map> Maps = new();

    private Model _model;
    private int actualMap;

    public List<long> Seeds { get; private set; }

    public List<Dictionary<long, long>> Dics { get; set; } = new();

    public void GetSeeds(string input)
    {
        // Regex: Matches "seeds: ", then any characters (except new line), optionally ending with a carriage return.
        Seeds = Regex.Match(input, @"seeds: (.*)(\r)?").Groups[1].Value.Split(" ")
            .Select(s => long.Parse(s)).ToList();
        foreach (var seed in Seeds)
        {
          _mappers.Add(new SeedMapper() { Seed = seed });
        }
    }
    public async void GetSeedsPart2(string input)
    {

        // Regex: Matches "seeds: ", then any characters (except new line), optionally ending with a carriage return.
        var seeds = Regex.Match(input, @"seeds: (.*)(\r)?").Groups[1].Value.Split(" ")
            .Select(s => long.Parse(s)).ToList();
       // Seeds = new();
        //split seeds in batch of 25 and loop in parallel
        /*Seeds.AsParallel()
            .ForAll(seed =>
            {
                for (int j = 0; j < seed + 1; j++)
                {
                    lock (Seeds)
                    {
                        Seeds.Add(seed + j);
                    }
                }
            });*/
        
        for (int i = 0; i < seeds.Count; i++)
        {
            for (int j = 0; j < seeds[i + 1]; j++) _mappers.Add(new SeedMapper() { Seed = seeds[i]+j }); //Seeds.Add(seeds[i]+j);
            i++;
        }
        
        /*
        //How to make this code run faster by running in parallel but make sure is works with long
        //run Async
        
        foreach (var seed in Seeds)
        {
          _mappers.Add(new SeedMapper() { Seed = seed });
        }
        //split seeds in batch of 25 and loop in parallel
        */
        
    }

    public void GetAllMap()
    {
        foreach (var seedMapper in _mappers)
        {
            seedMapper.Soil = GetDestination(List[0], seedMapper.Seed);
            seedMapper.Fertilizer = GetDestination(List[1], seedMapper.Soil);
            seedMapper.Water = GetDestination(List[2], seedMapper.Fertilizer);
            seedMapper.Light = GetDestination(List[3],  seedMapper.Water);
            seedMapper.Temperature = GetDestination(List[4], seedMapper.Light);
            seedMapper.Humidity =GetDestination(List[5], seedMapper.Temperature);
            seedMapper.Location = GetDestination(List[6], seedMapper.Humidity);
        }
    }

   
    private long GetMap(string type, long position)
    {
        //loop until input is empty
        while (_model.GameData.Length > position)
        {
            var input = _model.GameData[position];
            if (input == "") return position;
            var map = input.Split(" ");
            Maps.Add(new Map
            {
                Type = type,
                Source = long.Parse(map[1]),
                Destination = long.Parse(map[0]),
                Duration = long.Parse(map[2])
            });
            position++;
        }

        return position;
    }
    public void GetEachMapV3(Model model)
    {
        _model = model;
        long position = 0;
        //create a list of string with the name of the dictionary
        foreach (var map in List)
            for (var i = position; i < model.GameData.Length; i++)
            {
                position = i;
                if (model.GameData[i].Contains(map))
                {
                    position = GetMap(map, position + 1);
                    break;
                }
            }
    }    
    
    public long GetSmallestLocationV3()
    {
            return _mappers.Min(m => m.Location);
    }

    public long GetDestination(string type, long source)
    {
        var maps = Maps.Where(w => w.Type.Equals(type)).ToList();
        return maps.Where(w => source >= w.Source &
                                              source <= w.Source + w.Duration)
            .Select(s => s.Destination - s.Source + source)
            .DefaultIfEmpty(source).First();
    }

}