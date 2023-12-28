using day02;
namespace TestAventOfCode.Day02;

[TestFixture]
public class Part1Test
{
    private static readonly Dictionary<string, int> CubeSet = new Dictionary<string, int>()
    {
        {"red",12},
        {"green",13},
        {"blue",14}
    };
    
    [Test]
    public void GetListOfAllPossibleGames()
    {
        // Arrange
        var expected = new List<int>() { 1, 2, 5 };
        var cube = new CubeConundrum(Input.GameData, CubeSet );
        // Act
        var result = cube.GetPossibleGames();
        // Assert
        Assert.AreEqual(expected, result);
    }   
    [Test]
    public void SumAllPossibleGame()
    {
        // Arrange
        var cube = new CubeConundrum(Input.GameData, CubeSet );
        // Act
        var result = cube.SolveCube();
        // Assert
        Assert.AreEqual(8, result);
    }  
    [Test]
    public void SumAllPossibleGameV2()
    {
        // Arrange
        var cube = new CubeConundrum(Input.GameData, CubeSet );
        cube.ImportInput();
        // Act
        var result = cube.SolveCube2();
        // Assert
        Assert.AreEqual(8, result);
    }
}