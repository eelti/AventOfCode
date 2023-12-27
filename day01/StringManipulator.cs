namespace day01;

public static class StringManipulator
{
    public static int GetFirstDigit(string s)
    {
        var i = -1;
        foreach (var c in s)
            if (char.IsDigit(c))
            {
                i = int.Parse(c.ToString());
                break;
            }

        return i;
    }

    public static void GetFirstDigitAndIsIndex(string s, Dictionary<int, int> dict, bool isReverse)
    {
        var index = 0;
        foreach (var c in s)
        {
            if (char.IsDigit(c))
            {
                dict.Add(index, int.Parse(c.ToString()));
                return;
            }

            index++;
        }
    }

    public static void GetFirstDigitSpelledOut(string s, Dictionary<int, int> dict, bool isReverse)
    {
        var i = -1;
        var digits = !isReverse
            ? new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }
            : new[] { "orez", "eno", "owt", "eerht", "ruof", "evif", "xis", "neves", "thgie", "enin" };
        var count = 0;
        var allFind = new Dictionary<int, int>();
        foreach (var digit in digits)
        {
            if (s.Contains(digit)) allFind.Add(s.IndexOf(digit), count);
            count++;
        }

        if (allFind.Count > 0)
            dict.Add(allFind.Keys.Min(), allFind[allFind.Keys.Min()]);
    }

    public static string ReverseLine(string line)
    {
        var charArray = line.ToCharArray();
        Array.Reverse(charArray);
        var lineR = new string(charArray);
        return lineR;
    }
}