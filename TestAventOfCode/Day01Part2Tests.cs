using day01;
using NUnit.Framework;

namespace TestAventOfCode
{
    [TestFixture]
    public class Day01Part2Tests
    {
        [Test]
        public void Part1_Test()
        {
            string[] lines = new string[]
            {
                "1abc2","pqr3stu8vwx","a1b2c3d4e5f","treb7uchet"
            };

            int expected = 142;
            int actual = Program.Part1(lines);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Part1_Test_EachLine_Test()
        {
            string[] lines = new string[]
            {
                "1abc2","pqr3stu8vwx","a1b2c3d4e5f","treb7uchet"
            };

            int[] expectedResults = new int[]
            {
                12, 38, 15, 77
            };

            for (int i = 0; i < lines.Length; i++)
            {
                int actualResult = Program.Part1(new string[] { lines[i] });
                Assert.AreEqual(expectedResults[i], actualResult);
            }
        }

        [Test]
        public void Part2_Test()
        {
            string[] lines = new string[]
            {
                "two1nine",
                "eightwothree",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen"
            };

            int expectedSum = 281;

            int actualSum = Program.Part2(lines);

            Assert.AreEqual(expectedSum, actualSum);
        }

       
 [Test]
        public void Part2_ParametrizedTest()
        {
            string[] lines = new string[]
            {
                "eightwothree",
                "two1nine",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen"
            };

            int[] expectedSums = new int[]
            {
                83,
                29,
                13,
                24,
                42,
                14,
                76
            };

            for (int i = 0; i < lines.Length; i++)
            {
                int actualSum = Program.Part2(new string[] { lines[i] });
                Assert.AreEqual(expectedSums[i], actualSum);
            }
        }
    }
}
