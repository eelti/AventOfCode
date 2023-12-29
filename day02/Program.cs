using TextCopy;

namespace day02;

public class Program
{
    private static readonly Dictionary<string, int> CubeSet = new()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };

    private static void Main()
    {
        var lines = File.ReadAllLines("input.txt");
        var cube = new CubeConundrum(lines, CubeSet);
        cube.ImportInput();


        Console.WriteLine("Please choose a part (1 or 2):");
        var v = Console.ReadKey();
        while (v.KeyChar != '1' && v.KeyChar != '2')
        {
            Console.WriteLine("Invalid input. Please choose either 1 or 2:");
            v = Console.ReadKey();
        }

        var part = int.Parse(v.KeyChar.ToString());

        var solution = 0;
        if (part == 1)
            solution = cube.SolveCube2();
        else if (part == 2) solution = cube.SumPowerOfAllGame();
        new Clipboard().SetText(solution.ToString());
        Console.WriteLine($"The answer is: {solution.ToString()} and is already copied it to the clipboard");
        Console.WriteLine("Press enter to quit");
        Console.ReadLine();
    }
}