using day01;

namespace TestAventOfCode;

[TestFixture]
public class Day01Part1Tests
{
    [Test]
    public void Part1_Test()
    {
        var lines = new[]
        {
            "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"
        };

        var expected = 142;
        var actual = Program.Part1(lines);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase("1abc2", 12)]
    [TestCase("pqr3stu8vwx", 38)]
    [TestCase("a1b2c3d4e5f", 15)]
    [TestCase("treb7uchet", 77)]
    public void Part1_Test_EachLine_Test(string line, int expected)
    {
        var actual = Program.Part1(new[] { line });
        Assert.AreEqual(expected, actual);
    }
}