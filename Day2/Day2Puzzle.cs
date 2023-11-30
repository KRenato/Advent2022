using Common;
using Day2.Core;

namespace Day2;

public class Day2Puzzle : IPuzzle
{
    private readonly Lazy<Task<string[]>> _input;

    public Day2Puzzle()
    {
        _input = new Lazy<Task<string[]>>(InputReader.GetInputAsync);
    }

    public string Title => "Day 2";

    public async Task<string> GetPart1OutputAsync()
    {
        var input = await _input.Value;
        var outcomeFinder = new OutcomeFinder();
        var game = new List<Round>();

        foreach (var item in input)
        {
            var round = new Round(outcomeFinder);
            var splitItems = item.Split(' ');
            round.MapToSignals(splitItems[0], splitItems[1]);

            game.Add(round);
        }

        return $"Your total score: {game.Sum(r => r.GetOutcome())}";
    }

    public async Task<string> GetPart2OutputAsync()
    {
        var input = await _input.Value;
        var outcomeFinder = new OutcomeFinder();
        var game = new List<Round>();

        foreach (var item in input)
        {
            var round = new Round(outcomeFinder);
            var splitItems = item.Split(' ');
            round.MapToOutcome(splitItems[0], splitItems[1]);

            game.Add(round);
        }

        return $"Your total score: {game.Sum(r => r.GetOutcome())}";
    }
}
