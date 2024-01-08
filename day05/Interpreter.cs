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

    private List<Mapper> _mappers = new();

    private Model _model;
    private int actualMap;

    public List<long> Seeds { get; private set; }

    public List<Dictionary<long, long>> Dics { get; set; } = new();

    public void GetSeeds(string input)
    {
        // Regex: Matches "seeds: ", then any characters (except new line), optionally ending with a carriage return.
        Seeds = Regex.Match(input, @"seeds: (.*)(\r)?").Groups[1].Value.Split(" ")
            .Select(s => long.Parse(s)).ToList();
    }

    //dictionary<long,long> key = seed (Source) , value = destination
    private long GetMap(Dictionary<long, long> dic, long position)
    {
        //loop until input is empty
        while (_model.GameData.Length > position)
        {
            var input = _model.GameData[position];
            if (input == "") return position;
            var map = input.Split(" ");
            //how to create a a new array with the values of the map in long
            var longs = new long[map.Length];
            for (var i = 0; i < map.Length; i++) longs[i] = long.Parse(map[i]);
            for (long i = 0; i < longs[2]; i++) dic.Add(longs[1] + i, longs[0] + i);
            position++;
        }

        return position;
    }

    public void GetEachMap(Model model)
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
                    var dic = new Dictionary<long, long>();
                    position = GetMap(dic, position + 1);
                    Dics.Add(dic);
                    break;
                }
            }
    }

    public void GetNextMap(Model model)
    {
        _model = model;
        long position = 0;
        if (Dics.Count == 2) Dics[0].Clear();
        //create a list of string with the name of the dictionary
        for (var i = position; i < model.GameData.Length; i++)
        {
            position = i;
            if (model.GameData[i].Contains(List[actualMap]))
            {
                var dic = new Dictionary<long, long>();
                position = GetMap(dic, position + 1);
                Dics.Add(dic);
                break;
            }
        }

        actualMap++;
    }

    public long GetSmallestLocationRef( Model model)
    {
        GetNextMap(model);
        foreach (var seed in Seeds)
            _mappers.Add(new Mapper
            {
                Seed = seed,
                Soil = GetSoil(seed)
            });
        GetNextMap(model);
        foreach (var mapper in _mappers)
            mapper.Fertilizer = Getfertilizer(mapper.Soil);
        GetNextMap(model);
        foreach (var mapper in _mappers)
            mapper.Water = GetWater(mapper.Fertilizer);
        GetNextMap(model);
        foreach (var mapper in _mappers)
            mapper.Light = GetLight(mapper.Water);
        GetNextMap(model);
        foreach (var mapper in _mappers)
            mapper.Temperature = GetTemperature(mapper.Light);
        GetNextMap(model);
        foreach (var mapper in _mappers)
            mapper.Humidity = GetHumidity(mapper.Temperature);
        GetNextMap(model);
        foreach (var mapper in _mappers)
            mapper.Location = GetLocation(mapper.Humidity);

        return _mappers.Min(m => m.Location);
    }

    public long GetSmallestLocation(List<long> seeds)
    {
        long smallestLocation = 0;
        foreach (var seed in seeds)
        {
            var location = GetLocation(GetHumidity(GetTemperature(GetLight(GetWater(Getfertilizer(GetSoil(seed)))))));
            if (smallestLocation == 0 || location < smallestLocation) smallestLocation = location;
        }

        return smallestLocation;
    }

    public long GetSoil(long seed)
    {
        long searchValueFind = 0;
        Dics[0].TryGetValue(seed, out searchValueFind);
        return searchValueFind == 0 ? seed : searchValueFind;
    }

    public long Getfertilizer(long soil)
    {
        long searchValueFind = 0;
        Dics[1].TryGetValue(soil, out searchValueFind);
        return searchValueFind == 0 ? soil : searchValueFind;
    }

    public long GetWater(long fertilizer)
    {
        long searchValueFind = 0;
        Dics[2].TryGetValue(fertilizer, out searchValueFind);
        return searchValueFind == 0 ? fertilizer : searchValueFind;
    }

    public long GetLight(long water)
    {
        long searchValueFind = 0;
        Dics[3].TryGetValue(water, out searchValueFind);
        return searchValueFind == 0 ? water : searchValueFind;
    }

    public long GetTemperature(long light)
    {
        long searchValueFind = 0;
        Dics[4].TryGetValue(light, out searchValueFind);
        return searchValueFind == 0 ? light : searchValueFind;
    }

    public long GetHumidity(long temperature)
    {
        long searchValueFind = 0;
        Dics[5].TryGetValue(temperature, out searchValueFind);
        return searchValueFind == 0 ? temperature : searchValueFind;
    }

    public long GetLocation(long humidity)
    {
        long searchValueFind = 0;
        Dics[6].TryGetValue(humidity, out searchValueFind);
        return searchValueFind == 0 ? humidity : searchValueFind;
    }

    public class Mapper
    {
        public long Seed { get; set; }
        public long Soil { get; set; }
        public long Fertilizer { get; set; }
        public long Water { get; set; }
        public long Light { get; set; }
        public long Temperature { get; set; }
        public long Humidity { get; set; }
        public long Location { get; set; }
    }
}