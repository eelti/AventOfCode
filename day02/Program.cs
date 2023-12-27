using TextCopy;

namespace day02;
public class Program
{
    private static readonly Dictionary<string, int> CubeSet = new Dictionary<string, int>()
    {
        {"red",12},
        {"green",13},
        {"blue",14}
    };
    
    private static void Main()
    {
        var lines = File.ReadAllLines("input.txt");
        var cube = new CubeConundrum(lines, CubeSet );
        // Act
        var result = cube.SolveCube();
        new Clipboard().SetText(result.ToString());
        Console.WriteLine($"The answer is: {result.ToString()} and is already copied it to the clipboard");
        Console.WriteLine("Press enter to quit");
        Console.ReadLine();
    }

}

