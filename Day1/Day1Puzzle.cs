using Common;

namespace PuzzleDay1;

public class Day1Puzzle : IPuzzle
{
    private readonly Lazy<Task<string[]>> _input;

    public Day1Puzzle()
    {
        _input = new Lazy<Task<string[]>>(InputReader.GetInputAsync);
    }

    public string Title => "Day 1";

    public async Task<string> GetPart1OutputAsync()
    {
        var input = await _input.Value; 
        var elves = new List<int>();
        var total = 0;

        foreach (var item in input)
        {
            if (int.TryParse(item, out var value))
            {
                total += value;
                continue;
            }

            elves.Add(total);
            total = 0;
        }

        return $"The elf with the most food has: {elves.Max()}";
    }

    public async Task<string> GetPart2OutputAsync()
    {
        var input = await _input.Value;
        var elves = new List<int>();
        var total = 0;

        foreach (var item in input)
        {
            if (int.TryParse(item, out var value))
            {
                total += value;
                continue;
            }

            elves.Add(total);
            total = 0;
        }

        var top3 = elves.OrderByDescending(i => i)
            .Take(3)
            .Sum(i => i);

        return $"The elf with the most food has: {top3}";
    }
}
