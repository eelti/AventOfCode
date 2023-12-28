using day02;
namespace TestAventOfCode.Day02;

[TestFixture]
public class Part2Test
{
    private static readonly Dictionary<string, int> CubeSet = new Dictionary<string, int>()
    {
        {"red",12},
        {"green",13},
        {"blue",14}
    };
    
    [TestCase(1,"red", 4 ,"green", 2,"blue", 6)]
    [TestCase(2,"red", 1 ,"green", 3,"blue", 4)]
    [TestCase(3,"red", 20 ,"green", 13,"blue", 6)]
    [TestCase(4,"red", 14 ,"green", 3,"blue", 15)]
    [TestCase(5,"red", 6 ,"green", 3,"blue", 2)]
    [Test]
    public void GetMinimumQtyCubePerColor(int gameNumber, string color1, int num1, string color2, int num2, string color3, int num3)
    {
        // Arrange
        Dictionary<string, int> expected = new()
        {
            {color1, num1},
            {color2, num2},
            {color3, num3}
        };
        var cube = new CubeConundrum(Input.GameData, CubeSet );
        cube.ImportInput();
        // Act
        var game = cube.Games.First(w => w.GameNumber == gameNumber);
        var result = cube.GetMinimumCubeForAGame(game);
        //var expected = new Dictionary<string, int>() { { "red", 4 }, { "green", 2 }, { "blue", 6 } };
        // Assert
        CollectionAssert.AreEquivalent(expected, result);
    }    
    [TestCase(1,48)]
    [TestCase(2,12)]
    [TestCase(3,1560)]
    [TestCase(4,630)]
    [TestCase(5,36)]
    [Test]
    public void GetPower(int gameNumber, int expected)
    {
        // Arrange
        var cube = new CubeConundrum(Input.GameData, CubeSet );
        cube.ImportInput();
        // Act
        var game = cube.Games.First(w => w.GameNumber == gameNumber);
        var minimumCubeForAGame = cube.GetMinimumCubeForAGame(game);
        var result = cube.GetPowerOfGame(minimumCubeForAGame);
        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void GetSumPower()
    {
        // Arrange
        var cube = new CubeConundrum(Input.GameData, CubeSet );
        cube.ImportInput();
        // Act
        var result = cube.SumPowerOfAllGame();
        // Assert
        Assert.AreEqual(2286, result);
    }
}