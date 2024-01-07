using System.Text.RegularExpressions;
using shareKernel;

namespace day05;

public class Interpreter
{
    private Model _model;
    public string[]? Seeds { get; private set; }

    public List<Dictionary<int,int>> Dics { get; set; } = new();
    /*public Dictionary<int, int> Soil { get; set; } = new();
    public Dictionary<int, int> Fertilizer { get; set; } = new();
    public Dictionary<int, int> Water { get; set; } = new();
    public Dictionary<int, int> Light { get; set; } = new();
    public Dictionary<int, int> Temperature { get; set; } = new();
    public Dictionary<int, int> Humidity { get; set; } = new();
    public Dictionary<int, int> Location { get; set; } = new();*/

    public void GetSeeds(string input)
    {
        // Regex: Matches "seeds: ", then any characters (except new line), optionally ending with a carriage return.
        Seeds = Regex.Match(input, @"seeds: (.*)(\r)?").Groups[1].Value.Split(" ");
    }

    //dictionary<int,int> key = seed (Source) , value = destination
    private int GetMap(Dictionary<int, int> dic, int position)
    {
        var input = _model.GameData[position];
        //if input is empty return
        if (input == "") return position;
        var map = input.Split(" ");
        //loop until input is empty
        while (_model.GameData[position++] != "" | _model.GameData.Length > position)
        {
            input = _model.GameData[position];
            if (input == "") return position;
            map = input.Split(" ");
            for (var i = 0; i < int.Parse(map[2]); i++) dic.Add(int.Parse(map[1]) + i, int.Parse(map[0]) + i);
        }
        return position;
    }

    public void GetEachMap(Model model)
    {
        _model = model;
        var position = 0;
        //create a list of string with the name of the dictionary
        var list = new List<string> {"seed-to-soil map:", "soil-to-fertilizer map:", "fertilizer-to-water map:", "water-to-light map:", "light-to-temperature map:", "temperature-to-humidity map:", "humidity-to-location map:"};
        foreach (var map in list)
        {
            for (var i = position; i < model.GameData.Length; i++)
            {
                if (!model.GameData[i].Contains(map)) continue;
                var dic = new Dictionary<int, int>();
                GetMap(dic, position + 1);
                Dics.Add(dic);
            }
        }
    }
}