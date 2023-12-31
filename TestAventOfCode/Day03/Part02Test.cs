using day03;

namespace TestAventOfCode.Day03;

[TestFixture]
public class Part02Test
{
    [SetUp]
    //how to build the setup for nUnit test
    public void Setup()
    {
        _gameData = new[]
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };
        _engineSchematic = new EngineSchematic(_gameData);
    }

    private string[] _gameData;
    private EngineSchematic _engineSchematic;

    [Test]
    public void GetSymbolesAndPosition()
    {
        var symbols = _engineSchematic.GetSymbols(@"[\*]");

        var expected = new List<Symbol>
        {
            new("*", 1, 3),
            new("*", 4, 3),
            new("*", 8, 5)
        };
        CollectionAssert.AreEquivalent(expected, symbols);
    }

    [Test]
    public void GetListGearsPairs()
    {
        var expected = new List<Tuple<int, int>>
        {
            Tuple.Create(467, 35), Tuple.Create(755, 598)
        };
        _engineSchematic.GetNumbers();
        _engineSchematic.GetSymbols(@"[\*]");
        var result = _engineSchematic.GetGearsPairs();

        CollectionAssert.AreEquivalent(expected, result);
    }

    [Test]
    public void GetSumOfAllGearRatio()
    {
        _engineSchematic.GetNumbers();
        _engineSchematic.GetSymbols(@"[\*]");
        _engineSchematic.GetGearsPairs();
        var result = _engineSchematic.GetSumOfAllGearRatio();

        Assert.AreEqual(467835, result);
    }
}