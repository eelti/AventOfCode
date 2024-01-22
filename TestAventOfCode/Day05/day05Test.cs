using day05;
using shareKernel;

namespace TestAventOfCode.Day05;

[TestFixture]
public class day05Test
{
    private string _input;

    [SetUp]
    public void Setup()
    {
        _input = new Model(@".\Day05\input.txt").GameDataText;
        //_seeds = Regex.Match(_input[0], @"seeds: (.*)").Groups[1].Value.Split(" ");
    }
    
// Seed 79, soil 81, fertilizer 81, water 81, light 74, temperature 78, humidity 78, location 82.
// Seed 14, soil 14, fertilizer 53, water 49, light 42, temperature 42, humidity 43, location 43.
// Seed 55, soil 57, fertilizer 57, water 53, light 46, temperature 82, humidity 82, location 86.
// Seed 13, soil 13, fertilizer 52, water 41, light 34, temperature 34, humidity 35, location 35.
    [Test]
    public void ValidateTheExtractionOfTheSeedsList()
    {
        // Arrange
        var expected = new List<int>() {79, 14, 55, 13};
        var interpreter = new Interpreter();
        var seedMappers = new List<SeedMapper>()
        {
            new(){Seed = 79},
            new(){Seed = 14},
            new(){Seed = 55},
            new(){Seed = 13}
        };

        // Act
        interpreter.GetSeeds(_input);

        // Assert compare the two arrays
        Assert.That(interpreter.Seeds, Is.EqualTo(expected));
        CollectionAssert.AreEquivalent(interpreter._mappers, seedMappers);
    }

    [Test]
    public void GetAllMap()
    {
        //Arrange
        var interpreter = new Interpreter();
        var model = new Model(@".\Day05\input.txt");
        var expected = new List<SeedMapper>()
        {
            new(){Seed = 79, Soil = 81, Fertilizer = 81, Water = 81, Light = 74, Temperature = 78, Humidity = 78,Location = 82},
            new(){Seed = 14, Soil = 14, Fertilizer = 53, Water = 49, Light = 42, Temperature = 42, Humidity = 43,Location = 43},
            new(){Seed = 55, Soil = 57, Fertilizer = 57, Water = 53, Light = 46, Temperature = 82, Humidity = 82, Location = 86},
            new(){Seed = 13, Soil = 13, Fertilizer = 52, Water = 41, Light = 34, Temperature = 34, Humidity = 35, Location = 35}
        };
        
        //Act
        interpreter.GetSeeds(_input);
        interpreter.GetEachMapV3(model);
        interpreter.GetAllMap();

        
        //Assert
        CollectionAssert.AreEquivalent(expected, interpreter._mappers);

    }


    [Test]
    public void GetSamllestLocationV3()
    {
        //Arrange
        var interpreter = new Interpreter();
        var model = new Model(@".\Day05\input.txt");
        long expected = 35;
        //Act
        interpreter.GetSeeds(_input);
        interpreter.GetEachMapV3(model);
        interpreter.GetAllMap();
        var actual = interpreter.GetSmallestLocationV3();


        //Assert
        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void GetSamllestLocationPart2()
    {
        //Arrange
        var interpreter = new Interpreter();
        var model = new Model(@".\Day05\input.txt");
        long expected = 46;
        //Act
        interpreter.GetSeedsPart2(_input);
        interpreter.GetEachMapV3(model);
        interpreter.GetAllMap();
        var actual = interpreter.GetSmallestLocationV3();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestGetEachMapV3()
    {
        // Arrange
        var interpreter = new Interpreter();
        var model = new Model(@".\Day05\input.txt");
        // Act
        interpreter.GetEachMapV3(model);
        // Assert compare the two arrays
        CollectionAssert.AreEquivalent(Input.GetMaps(),interpreter.Maps);
    }
    
    
}