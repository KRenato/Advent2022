using Common;
using Day2;
using PuzzleDay1;

bool continueExecuting = true;

var puzzles = new Dictionary<int, IPuzzle>
{
    { 1, new Day1Puzzle() },
    { 2, new Day2Puzzle() }
};

Console.WriteLine("Welcome to Kevin Renato's 2022 Advent of Code solution. Please choose which solution you'd like to view:" + Environment.NewLine);

do
{
    for (int i = 1; i <= puzzles.Count; i++)
    {
        Console.WriteLine($"{i}.) {puzzles[i].Title}");
    }

    Console.WriteLine(Environment.NewLine + "Or press Escape to quit." + Environment.NewLine);
    var key = Console.ReadKey();

    Console.WriteLine(Environment.NewLine);

    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }

    if (!int.TryParse(key.KeyChar.ToString(), out int keyId))
    {
        continue;
    }

    if (!puzzles.TryGetValue(keyId, out IPuzzle? selectedPuzzle))
    {
        continue;
    }

    Console.WriteLine("Part 1:");
    Console.WriteLine(await selectedPuzzle.GetPart1OutputAsync() + Environment.NewLine);

    Console.WriteLine("Part 2:");
    Console.WriteLine(await selectedPuzzle.GetPart2OutputAsync() + Environment.NewLine);

    Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
    Console.WriteLine(Environment.NewLine);
}
while (continueExecuting);
