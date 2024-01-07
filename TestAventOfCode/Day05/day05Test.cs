using day05;
using shareKernel;

namespace TestAventOfCode.Day05;

[TestFixture]
public class day05Test
{
    private string _input;
    private string[]? _seeds;

    [SetUp]
    public void Setup()
    {
        _input = new Model(@".\Day05\input.txt").GameDataText;
        //_seeds = Regex.Match(_input[0], @"seeds: (.*)").Groups[1].Value.Split(" ");
    }
    
    //seeds: 79 14 55 13
    
    [Test]
    public void ValidateTheExtractionOfTheSeedsList()
    {
        // Arrange
        var expected = new[] {"79", "14", "55", "13"};
        var interpreter = new Interpreter();
        
        // Act
        interpreter.GetSeeds(_input);
        _seeds = interpreter.Seeds;

        // Assert compare the two arrays
        Assert.That(_seeds, Is.EqualTo(expected));
        
    }
    
    [Test]
    public void ValidateTheExtractionOfTheSeedsList2()
    {
        // Arrange
        var interpreter = new Interpreter();
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);

        // Assert compare the two arrays
        Assert.That(interpreter.Dics[0].Count, Is.EqualTo(79));
        
    }
}