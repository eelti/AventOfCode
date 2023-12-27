using System.Text.RegularExpressions;

namespace day02;

public class CubeConundrum
{
    public string[] _input;
    private readonly Dictionary<string, int> _cubeSet;

    public CubeConundrum(string[] input, Dictionary<string, int> cubeSet)
    {
        _input = input;
        _cubeSet = cubeSet;
        CleanInput();
    }

    public void CleanInput()
    {
        //for each array in _input use regex replace Game [0-999]: 
        _input = _input.Select(s => Regex.Replace(s, @"Game \d+: ", "")).ToArray();
    }

    public List<int> GetPossibleGames()
    {
        var games = new List<int>();
        var gameNumber = 1;
        foreach (var item in _input)
        {
            var isValid = true;
            var sets = item.Split(';');
            foreach (var set in sets)
            {
                var cubes = set.Split(',');
                foreach (var cube in cubes)
                {
                    Regex regex = new Regex(@"(\b[a-zA-Z]+\b)$");
                    Match match = regex.Match(cube);
                    var maxValue = int.Parse(_cubeSet[match.Value].ToString());
                    regex = new Regex(@"\d+");
                    match = regex.Match(cube);
                    var numberOfCube = int.Parse(match.Value);
                    if (numberOfCube > maxValue)
                    {
                        isValid = false;
                        break;
                    }
                }
                if (!isValid) break;
            }
            if(isValid) games.Add(gameNumber);
            gameNumber++;
        }

        return games;
    }
    public int SolveCube()
    {
        var possibleGames = GetPossibleGames();
        var sumAllPossibleGame = 0;
        foreach (var possibleGame in possibleGames)
        {
            sumAllPossibleGame += possibleGame;
        }

        return sumAllPossibleGame;
    }
}