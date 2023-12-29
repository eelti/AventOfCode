using System.Collections;
using System.Text.RegularExpressions;

namespace day03;

public class EngineSchematic(string[] gameData)
{
    private readonly string[] _gameData = gameData;
    private IEnumerable<Number> _numbers;
    private IEnumerable<Symbol> _symbols;
    private List<int> _valideNumbers;
    private List<Tuple<int, int>> _gearsPairs;

    public List<Number> GetNumbers()
    {
        _numbers = _gameData.SelectMany((line, index) =>
            Regex.Matches(line, @"\d+").Select(match => new Number(int.Parse(match.Value), index, match.Index)));
        return _numbers.ToList();
    }

    public List<Symbol> GetSymbols(string pattern)
    {
        _symbols = _gameData.SelectMany((line, index) =>
           // Regex.Matches(line, @"[^\w\s\d\.]").Select(match => new Symbol(match.Value, index, match.Index)));
            Regex.Matches(line, pattern).Select(match => new Symbol(match.Value, index, match.Index)));
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
    public List<Tuple<int, int>> GetGearsPairs()
    {
        _gearsPairs = new List<Tuple<int, int>>();
        foreach (var s in _symbols)
        {
            var canBeBetween = new
                { Start = s.Index - 1, End = s.Index +1 };
            var lineIndexCanBeBetween = new
                { Start = s.RowNumber - 1, End = s.RowNumber + 1 };
            var numbers = _numbers.Where(w => 
                (w.Index >= canBeBetween.Start || w.IndexEnd >= canBeBetween.Start) &
                (w.Index <= canBeBetween.End || w.IndexEnd <= canBeBetween.End) &
                w.RowNumber >= lineIndexCanBeBetween.Start &
                w.RowNumber <= lineIndexCanBeBetween.End
            ).ToList();
            if (numbers.Count != 0 & numbers.Count == 2)
            {
                _gearsPairs.Add(new Tuple<int, int>(numbers.Select(e => e.Value).ToArray()[0],numbers.Select(e => e.Value).ToArray()[1] ));
            }
        }

        return _gearsPairs;
    }

    public int GetSumOfAllValidNumbers()
    {
        return _valideNumbers.Sum();
    }

    public int GetSumOfAllGearRatio()
    {
        var sum = 0;
        foreach (var kp in _gearsPairs)
        {
            sum += (kp.Item1 * kp.Item2);
        }

        return sum;
    }
}