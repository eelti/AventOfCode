using day03;

namespace TestAventOfCode.Day03;

[TestFixture]
[TestOf(typeof(EngineShematicFactory))]
public class EngineShematicFactoryTest
{
    private string[] _gameData;
    private EngineShematicFactory _engineSchematic;

    [SetUp]
    //how to build the setup for nUnit test
    public void Setup()
    {
        _gameData = new[] {        
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
        _engineSchematic = new EngineShematicFactory(_gameData);
    }
    [Test]
    public void GetNumbersAndPosition()
    {
        var numbers = _engineSchematic.GetNumbers();
        var expected = new List<Number>()
        {
            new (467,0,0),
            new (114,0,5),
            new (35,2,2),
            new (633,2,6),
            new (617,4,0),
            new (58,5,7),
            new (592,6,2),
            new (755,7,6),
            new (664,9,1),
            new (598,9,5)               
        };
        CollectionAssert.AreEquivalent(expected,numbers);
    }
    [Test]
    public void GetSymbolesAndPosition()
    {
        var symbols = _engineSchematic.GetSymbols();
        
        var expected = new List<Symbol>()
        {
            new("*",1,3),
            new("#",3,6),
            new("*",4,3),
            new("+",5,5),
            new("$",8,3),
            new("*",8,5)
        };
        CollectionAssert.AreEquivalent(expected,symbols);
    }

    [Test]
    public void GetListValideNumber()
    {
        var expected = new List<int>()
        {
            467, 35, 633, 617, 592, 755, 664, 598
        };
        _engineSchematic.GetNumbers();
        _engineSchematic.GetSymbols();
        var result = _engineSchematic.GetValidNumbers();

        CollectionAssert.AreEquivalent(expected, result);

    }[Test]
    public void GetGetSumOfAllValidNumber()
    {
        _engineSchematic.GetNumbers();
        _engineSchematic.GetSymbols();
        _engineSchematic.GetValidNumbers();
        var result = _engineSchematic.GetSumOfAllValidNumbers();

        Assert.AreEqual(4361,  result);

    }
}