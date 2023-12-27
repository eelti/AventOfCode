using day01;

namespace TestAventOfCode;

[TestFixture]
public class Day01Part2Tests
{
    [Test]
    public void Part1_Test()
    {
        string[] lines =
        {
            "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"
        };

        var expected = 142;
        var actual = Program.Part1(lines);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Part1_Test_EachLine_Test()
    {
        string[] lines =
        {
            "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"
        };

        int[] expectedResults =
        {
            12, 38, 15, 77
        };

        for (var i = 0; i < lines.Length; i++)
        {
            var actualResult = Program.Part1(new[] { lines[i] });
            Assert.AreEqual(expectedResults[i], actualResult);
        }
    }

    [Test]
    public void Part2_Test()
    {
        string[] lines =
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };

        var expectedSum = 281;

        var actualSum = Program.Part2(lines);

        Assert.AreEqual(expectedSum, actualSum);
    }


    [TestCase("eightwothree", 83)]
    [TestCase("two1nine", 29)]
    [TestCase("abcone2threexyz", 13)]
    [TestCase("xtwone3four", 24)]
    [TestCase("4nineeightseven2", 42)]
    [TestCase("zoneight234", 14)]
    [TestCase("7pqrstsixteen", 76)]
    public void Part2_ParametrizedTest(string line, int expectedSum)
    {
        var actualSum = Program.Part2(new[] { line });
        Assert.AreEqual(expectedSum, actualSum);
    }
}