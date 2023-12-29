using System.Text.RegularExpressions;

namespace day02;

public class CubeConundrum
{
    private readonly Dictionary<string, int> _cubeSet;
    private readonly string[] _cubeColor = { "red", "green", "blue" };
    public string[] _input;

    public CubeConundrum(string[] input, Dictionary<string, int> cubeSet)
    {
        _input = input;
        _cubeSet = cubeSet;
        Games = new List<Game>();
        CleanInput();
    }

    public List<Game> Games { get; set; }

    public void ImportInput()
    {
        var gameNumber = 1;
        foreach (var item in _input)
        {
            var game = new Game
            {
                GameNumber = gameNumber++,
                IsValid = true
            };
            var isValid = true;
            var sets = item.Split(';');
            foreach (var set in sets)
            {
                var set1 = new Set();
                var cubes = set.Split(',');
                foreach (var cube in cubes)
                {
                    var regex = new Regex(@"(\b[a-zA-Z]+\b)$");
                    var match = regex.Match(cube);
                    var regexQ = new Regex(@"\d+");
                    var matchQ = regexQ.Match(cube);
                    var maxValue = int.Parse(_cubeSet[match.Value].ToString());
                    var cube1 = new Cube
                    {
                        Color = match.Value,
                        Qty = int.Parse(matchQ.Value)
                    };
                    set1.Cubes.Add(cube1);
                    if (cube1.Qty > maxValue) game.IsValid = false;
                }

                game.Sets.Add(set1);
            }

            Games.Add(game);
        }
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
                    var regex = new Regex(@"(\b[a-zA-Z]+\b)$");
                    var match = regex.Match(cube);
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

            if (isValid) games.Add(gameNumber);
            gameNumber++;
        }

        return games;
    }

    public int SolveCube()
    {
        var possibleGames = GetPossibleGames();
        var sumAllPossibleGame = 0;
        foreach (var possibleGame in possibleGames) sumAllPossibleGame += possibleGame;

        return sumAllPossibleGame;
    }

    public int SolveCube2()
    {
        var possibleGames = Games.Where(g => g.IsValid);

        return possibleGames.Sum(possibleGame => possibleGame.GameNumber);
    }

    public Dictionary<string, int> GetMinimumCubeForAGame(Game game)
    {
        var minimumCube = new Dictionary<string, int>();
        foreach (var item in _cubeColor)
        {
            //var game = Games.First(w => w.GameNumber == gameNumber);
            var set1Cubes = game.Sets.SelectMany(s => s.Cubes)
                .Where(c => c.Color == item)
                .GroupBy(c => c.Color)
                .Select(g => new { Color = g.Key, MaxQty = g.Max(c => c.Qty) });
            var maxQtyCube = set1Cubes.MaxBy(c => c.MaxQty);
            if (maxQtyCube != null) minimumCube.Add(maxQtyCube.Color, maxQtyCube.MaxQty);
        }

        return minimumCube;
    }

    public int GetPowerOfGame(Dictionary<string, int> set)
    {
        return set.Aggregate(1, (current, keyValuePair) => current * keyValuePair.Value);
    }

    public int SumPowerOfAllGame()
    {
        var total = 0;
        foreach (var game in Games)
        {
            var minimumCubeForAGame = GetMinimumCubeForAGame(game);
            var powerOfGame = GetPowerOfGame(minimumCubeForAGame);
            total += powerOfGame;
        }

        return total;
    }
}