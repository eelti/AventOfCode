using day05;

namespace TestAventOfCode.Day05;

[TestFixture]
public class Day05Part02Test
{
    [Test]
    public void GetPairsSeed()
    {
        //Arrange
        var expected = new List<SeedRange>()
        {
            new SeedRange(79, 14),
            new SeedRange(55, 13)
        };

        //Act
        var interpreterV2 = new InterpreterV2(@".\Day05\input.txt");

        //Assert
        CollectionAssert.AreEqual(expected, interpreterV2.PairsSeeds);
    }
    
    [TestCase(0,92)]
    [TestCase(1,67)]
    [Test]
    public void GetEnd_Test(int index, long expected)
    {
        //Arrange
        
        //Act
        var interpreterV2 = new InterpreterV2(@".\Day05\input.txt");
        var actual = interpreterV2.PairsSeeds[index].End;
        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}