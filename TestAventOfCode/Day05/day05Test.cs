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
    
    //seeds: 79 14 55 13
    
    [Test]
    public void ValidateTheExtractionOfTheSeedsList()
    {
        // Arrange
        var expected = new List<int>() {79, 14, 55, 13};
        var interpreter = new Interpreter();
        
        // Act
        interpreter.GetSeeds(_input);

        // Assert compare the two arrays
        Assert.That(interpreter.Seeds, Is.EqualTo(expected));
        
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
        Assert.That(interpreter.Dics.Count, Is.EqualTo(7));
    }  

    [Test]
    public void GetSmallestLocation()
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);
        var smallestLocation = interpreter.GetSmallestLocation(interpreter.Seeds);

        // Assert compare the two arrays
        Assert.That(smallestLocation, Is.EqualTo(35));
    } 

    [Test]
    public void GetSmallestLocationRef()
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        var smallestLocation = interpreter.GetSmallestLocationRef(model);

        // Assert compare the two arrays
        Assert.That(smallestLocation, Is.EqualTo(35));
    } 
    /*Seed 79, soil 81, fertilizer 81, water 81, light 74, temperature 78, humidity 78, location 82.
Seed 14, soil 14, fertilizer 53, water 49, light 42, temperature 42, humidity 43, location 43.
Seed 55, soil 57, fertilizer 57, water 53, light 46, temperature 82, humidity 82, location 86.
Seed 13, soil 13, fertilizer 52, water 41, light 34, temperature 34, humidity 35, location 35.*/
    [TestCase(79, 81)]
    [TestCase(14, 14)]
    [TestCase(55, 57)]
    [TestCase(13, 13)]
    [Test]
    public void GetSoil(int seed, int soil)
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);
        var smallestLocation = interpreter.GetSoil(seed);

        // Assert compare the two arrays
        Assert.That(smallestLocation, Is.EqualTo(soil));
    }
    
    [TestCase(81, 81)]
    [TestCase(14, 53)]
    [TestCase(57, 57)]
    [TestCase(13, 52)]
    [Test]
    public void GetFertilizer(int soil, int expected)
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);
        var fertilizer = interpreter.Getfertilizer(soil);

        // Assert compare the two arrays
        Assert.That(fertilizer, Is.EqualTo(expected));
    }
    
    [TestCase(81, 81)]
    [TestCase(53, 49)]
    [TestCase(57, 53)]
    [TestCase(52, 41)]
    [Test]
    public void GetWater(int fertilizer, int expected)
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);
        var water = interpreter.GetWater(fertilizer);

        // Assert compare the two arrays
        Assert.That(water, Is.EqualTo(expected));
    }
    
    [TestCase(81, 74)]
    [TestCase(49, 42)]
    [TestCase(53, 46)]
    [TestCase(41, 34)]
    [Test]
    public void GetLight(int water, int expected)
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);
        var light = interpreter.GetLight(water);

        // Assert compare the two arrays
        Assert.That(light, Is.EqualTo(expected));
    }
    

    [TestCase(74, 78)]
    [TestCase(42, 42)]
    [TestCase(46, 82)]
    [TestCase(34, 34)]
    [Test]
    public void GetTemperature(int light, int expected)
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);
        var temperature = interpreter.GetTemperature(light);

        // Assert compare the two arrays
        Assert.That(temperature, Is.EqualTo(expected));
    }
    
    [TestCase(78, 78)]
    [TestCase(42, 43)]
    [TestCase(82, 82)]
    [TestCase(34, 35)]
    [Test]
    public void GetHumidity(int temperature, int expected)
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);
        var humidity = interpreter.GetHumidity(temperature);

        // Assert compare the two arrays
        Assert.That(humidity, Is.EqualTo(expected));
    }
    
    /*Seed 79, soil 81, fertilizer 81, water 81, light 74, temperature 78, humidity 78, location 82.
Seed 14, soil 14, fertilizer 53, water 49, light 42, temperature 42, humidity 43, location 43.
Seed 55, soil 57, fertilizer 57, water 53, light 46, temperature 82, humidity 82, location 86.
Seed 13, soil 13, fertilizer 52, water 41, light 34, temperature 34, humidity 35, location 35.*/
    [TestCase(78, 82)]
    [TestCase(43, 43)]
    [TestCase(82, 86)]
    [TestCase(35, 35)]
    [Test]
    public void GetLocation(int humidity, int expected)
    {
        // Arrange
        var interpreter = new Interpreter();
        interpreter.GetSeeds(_input);
        var model = new Model(@".\Day05\input.txt");

        // Act
        interpreter.GetEachMap(model);
        var location = interpreter.GetLocation(humidity);

        // Assert compare the two arrays
        Assert.That(location, Is.EqualTo(expected));
    }
    
}