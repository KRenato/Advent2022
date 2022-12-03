using Common;
using Day2;

var input = await InputReader.GetInputAsync();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(input);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(input);

static void Part1(string[] input)
{
    var outcomeFinder = new OutcomeFinder();
    var game = new List<Round>();

    foreach (var item in input)
    {
        var round = new Round(outcomeFinder);
        var splitItems = item.Split(' ');
        round.MapToSignals(splitItems[0], splitItems[1]);

        game.Add(round);
    }

    Console.WriteLine("Your total score: {0}", game.Sum(r => r.GetOutcome()));
}

static void Part2(string[] input)
{
    var outcomeFinder = new OutcomeFinder();
    var game = new List<Round>();

    foreach (var item in input)
    {
        var round = new Round(outcomeFinder);
        var splitItems = item.Split(' ');
        round.MapToOutcome(splitItems[0], splitItems[1]);

        game.Add(round);
    }

    Console.WriteLine("Your total score: {0}", game.Sum(r => r.GetOutcome()));
}