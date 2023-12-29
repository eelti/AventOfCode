using System.Collections;
using System.Text.RegularExpressions;

namespace day03;

public class EngineShematicFactory(string[] gameData)
{
    private readonly string[] _gameData = gameData;
    private IEnumerable<Number> _numbers;
    private IEnumerable<Symbol> _symbols;
    private List<int> _valideNumbers;

    public void Build()
    {
        //get number of line of gameData
        var numberOfLines = _gameData.Length;
        //get maximum size of a element of the gameData
        var maxSize = _gameData.Max(x => x.Length);
        var symbols = GetSymbols();
        var numbers = GetNumbers();
        // Iterate through each match and print the index and match value
        foreach (var match in symbols)
            Console.WriteLine(
                $"Symbol found at index {match.RowNumber}: and in line position {match.Index}, {match.Value} ");
        // Iterate through each number match and print the index and match value
        foreach (var numberMatch in numbers)
            Console.WriteLine(
                $"Number found at index {numberMatch.RowNumber}: and in line position {numberMatch.Index}, {numberMatch.Value}");
    }

    public List<Number> GetNumbers()
    {
        _numbers = _gameData.SelectMany((line, index) =>
            Regex.Matches(line, @"\d+").Select(match => new Number(int.Parse(match.Value), index, match.Index)));
        return _numbers.ToList();
    }

    public List<Symbol> GetSymbols()
    {
        _symbols = _gameData.SelectMany((line, index) =>
            Regex.Matches(line, @"[^\w\s\d\.]").Select(match => new Symbol(match.Value, index, match.Index)));
        return _symbols.ToList();
    }

    public List<int> GetValidNumbers()
    {
        _valideNumbers = new List<int>();
        foreach (var number in _numbers)
        {
                var canBeBetween = new
                    { Start = number.Index - 1, End = number.Index + number.Value.ToString().Length };
                var lineIndexCanBeBetween = new
                    { Start = number.RowNumber - 1, End = number.RowNumber + 1 };
                
                if (_symbols.Any(w => 
                        w.Index >= canBeBetween.Start &
                        w.Index <= canBeBetween.End &
                        w.RowNumber >= lineIndexCanBeBetween.Start &
                            w.RowNumber <= lineIndexCanBeBetween.End
                        ))
                {
                    _valideNumbers.Add(number.Value);
                }
        }

        return _valideNumbers;
    }

    public int GetSumOfAllValidNumbers()
    {
        return _valideNumbers.Sum();
    }
}