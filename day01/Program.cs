using TextCopy;

namespace day01
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            
            Console.WriteLine("Please choose a part (1 or 2):");
            var v = Console.ReadKey();
            while (v.KeyChar != '1' && v.KeyChar != '2')
            {
                Console.WriteLine("Invalid input. Please choose either 1 or 2:");
                v = Console.ReadKey();
            }
            var part = int.Parse(v.KeyChar.ToString());

            int solution = 0;
            if (part == 1)
            {
                solution = Part1(lines);
            }
            else if (part == 2)
            {
                solution = Part2(lines);
            }
            new Clipboard().SetText(solution.ToString());
            Console.WriteLine($"The answer is: {solution.ToString()} and is already copied it to the clipboard");
            Console.WriteLine("Press enter to quit");
            Console.ReadLine();
        }

        public static int Part1(string[] lines)
        {
            int sum = 0;
            foreach (string line in lines)
            {
                var firstDigit = StringManipulator.GetFirstDigit(line);
                if (firstDigit == -1) continue;

                var lineR = StringManipulator.ReverseLine(line);
                var lastDigit = StringManipulator.GetFirstDigit(lineR);
                if (lastDigit == -1) lastDigit = firstDigit;

                var calibrationNumber = firstDigit * 10 + lastDigit;
                sum += calibrationNumber;
            }
            return sum;
        }

        public static int Part2(string[] lines)
        {
            int sum = 0;
            foreach (string line in lines)
            {
                var dictFirst = new Dictionary<int, int>();
                var dictSec = new Dictionary<int, int>();

                StringManipulator.GetFirstDigitAndIsIndex(line, dictFirst,false);
                StringManipulator.GetFirstDigitSpelledOut(line, dictFirst, false);
                
                var lineR = StringManipulator.ReverseLine(line);
                StringManipulator.GetFirstDigitAndIsIndex(lineR, dictSec, true);
                StringManipulator.GetFirstDigitSpelledOut(lineR, dictSec, true);

                int smallestIndex = dictFirst.Keys.Min();
                int biggestIndex = dictSec.Keys.Min();
                var firstDigit = dictFirst[smallestIndex];
                var lastDigit = dictSec[biggestIndex];

                var calibrationNumber = firstDigit * 10 + lastDigit;
                sum += calibrationNumber;
            }
            return sum;
        }
    }
}
