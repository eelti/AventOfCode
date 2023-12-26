namespace day01
{
    public static class StringManipulator
    {
        public static int GetFirstDigit(string s)
        {
            int i = -1;
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    i = int.Parse(c.ToString());
                    break;
                }
            }

            return i;
        }
        public static void GetFirstDigitAndIsIndex(string s, Dictionary<int, int> dict, bool isReverse)
        {
            var index= 0;
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    dict.Add(index, int.Parse(c.ToString()));
                    return;
                }
                index++;
            }

            return;
        }

        public static void GetFirstDigitSpelledOut(string s, Dictionary<int, int> dict, bool isReverse)
        {
            int i = -1;
            string[] digits = !isReverse ? (new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" })
                : (new string[] { "orez", "eno", "owt", "eerht", "ruof", "evif", "xis", "neves", "thgie", "enin" });
            var count = 0;
            var allFind = new Dictionary<int, int>();
            foreach (string digit in digits)
            {
                if (s.Contains(digit))
                {
                    allFind.Add(s.IndexOf(digit), count);
                }
                count++;
            }
            if (allFind.Count > 0) 
                dict.Add(allFind.Keys.Min(), allFind[allFind.Keys.Min()]);
        }

        public static string ReverseLine(string line)
        {
            char[] charArray = line.ToCharArray();
            Array.Reverse(charArray);
            var lineR = new string(charArray);
            return lineR;
        }
    }
}
