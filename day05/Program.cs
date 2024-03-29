﻿using System.Diagnostics;
using shareKernel;
using TextCopy;

namespace day05;

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

        long solution = 0;
        var gameData =  new Model(@".\input.txt");

        if (part == 1)
        {
            // Arrange
            var interpreter = new Interpreter();
            interpreter.GetSeeds(gameData.GameDataText);

            // Act
            interpreter.GetEachMapV3(gameData);
            interpreter.GetAllMap();
            solution = interpreter.GetSmallestLocationV3();

        }
        else if (part == 2)
        {
            // Arrange
            //create timer to time how it take to the next line
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var interpreter = new InterpreterV2(@".\input.txt");
            stopwatch.Stop();
            //no second
            Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalSeconds} seconds");

            // Act
            /*interpreter.GetEachMapV3(gameData);
            interpreter.GetAllMap();
            solution = interpreter.GetSmallestLocationV3();*/

        }

        new Clipboard().SetText(solution.ToString());
        Console.WriteLine($"The answer is: {solution.ToString()} and is already copied it to the clipboard");
        Console.WriteLine("Press enter to quit");
        Console.ReadLine();
    }
}