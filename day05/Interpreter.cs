using System.Text.RegularExpressions;
using shareKernel;

namespace day05;

public class Interpreter
{
    private Model _model;
    public List<int> Seeds { get; private set; }

    public List<Dictionary<int, int>> Dics { get; set; } = new();

    public void GetSeeds(string input)
    {
        // Regex: Matches "seeds: ", then any characters (except new line), optionally ending with a carriage return.
        Seeds = Regex.Match(input, @"seeds: (.*)(\r)?").Groups[1].Value.Split(" ")
            .Select(s => int.Parse(s)).ToList();
    }

    //dictionary<int,int> key = seed (Source) , value = destination
    private int GetMap(Dictionary<int, int> dic, int position)
    {
        //loop until input is empty
        while (_model.GameData.Length > position)
        {
            var input = _model.GameData[position];
            if (input == "") return position;
            var map = input.Split(" ");
            for (var i = 0; i < int.Parse(map[2]); i++) dic.Add(int.Parse(map[1]) + i, int.Parse(map[0]) + i);
            position++;
        }

        return position;
    }

    public void GetEachMap(Model model)
    {
        _model = model;
        var position = 0;
        //create a list of string with the name of the dictionary
        var list = new List<string>
        {
            "seed-to-soil map:", "soil-to-fertilizer map:", "fertilizer-to-water map:", "water-to-light map:",
            "light-to-temperature map:", "temperature-to-humidity map:", "humidity-to-location map:"
        };
        foreach (var map in list)
            for (var i = position; i < model.GameData.Length; i++)
            {
                position = i;
                if (model.GameData[i].Contains(map))
                {
                    var dic = new Dictionary<int, int>();
                    position = GetMap(dic, position + 1);
                    Dics.Add(dic);
                    break;
                }
            }
    }

    public int GetSmallestLocation(List<int> seeds)
    {
        var smallestLocation = 0;
        foreach (var seed in seeds)
        {
            var location = GetLocation(GetHumidity(GetTemperature(GetLight(GetWater(Getfertilizer(GetSoil(seed)))))));
            if (smallestLocation == 0 || location < smallestLocation)
            {
                smallestLocation = location;
            }
        }

        return smallestLocation;
    }

    public int GetSoil(int seed)
    {
        var searchValueFind = 0;
        Dics[0].TryGetValue(seed, out searchValueFind);
        return searchValueFind == 0 ? seed : searchValueFind;
    }
    public int Getfertilizer(int soil)
    {
        var searchValueFind = 0;
        Dics[1].TryGetValue(soil, out searchValueFind);
        return searchValueFind == 0 ? soil : searchValueFind;
    }
    public int GetWater(int fertilizer)
    {
        var searchValueFind = 0;
        Dics[2].TryGetValue(fertilizer, out searchValueFind);
        return searchValueFind == 0 ? fertilizer : searchValueFind;
    }
    public int GetLight(int water)
    {
        var searchValueFind = 0;
        Dics[3].TryGetValue(water, out searchValueFind);
        return searchValueFind == 0 ? water : searchValueFind;
    }
    public int GetTemperature(int light)
    {
        var searchValueFind = 0;
        Dics[4].TryGetValue(light, out searchValueFind);
        return searchValueFind == 0 ? light : searchValueFind;
    }
    public int GetHumidity(int temperature)
    {
        var searchValueFind = 0;
        Dics[5].TryGetValue(temperature, out searchValueFind);
        return searchValueFind == 0 ? temperature : searchValueFind;
    }
    public int GetLocation(int humidity)
    {
        var searchValueFind = 0;
        Dics[6].TryGetValue(humidity, out searchValueFind);
        return searchValueFind == 0 ? humidity : searchValueFind;
    }
}