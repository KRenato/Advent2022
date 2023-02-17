using Common;
using Day4;

var elfPairs = await InputReader.GetInputAsync<Parser, IEnumerable<(Elf, Elf)>>();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(elfPairs);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(elfPairs);

static void Part1(IEnumerable<(Elf, Elf)> elfPairs)
{
    var countOfOverlaps = elfPairs.Count(ep => ep.Item1.HasFullOverlap(ep.Item2));

    Console.WriteLine("Elves that have full overlap: {0}", countOfOverlaps);
}

static void Part2(IEnumerable<(Elf, Elf)> elfPairs)
{
    var countOfOverlaps = elfPairs.Count(ep => ep.Item1.HasPartialOverlap(ep.Item2));

    Console.WriteLine("Elves that have full overlap: {0}", countOfOverlaps);
}