using TextCopy;

namespace day04;

public class Program
{
    private static void Main(string[] args)
    {
        
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
        {
            Deck deck = new();
            deck.LoadCard(Model.GameData);
            // Act
            solution = deck.GetGrandTotal();

        }
        else if (part == 2)
        {
            Deck deck = new();
            deck.LoadCard(Model.GameData);
            // Act
            solution = deck.GetGrandTotalOfWinningsCard();
        }

        new Clipboard().SetText(solution.ToString());
        Console.WriteLine($"The answer is: {solution.ToString()} and is already copied it to the clipboard");
        Console.WriteLine("Press enter to quit");
        Console.ReadLine();
    }
}