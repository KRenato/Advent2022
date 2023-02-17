using Common;
using Day3;

var rucksacks = await InputReader.GetInputAsync<Parser, IEnumerable<Rucksack>>();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(rucksacks);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(rucksacks);

static void Part1(IEnumerable<Rucksack> rucksacks)
{
    var totalPriority = rucksacks
        .Select(i => Rucksack.ConvertItemToPriority(i.GetIntersectingItem()))
        .Sum();

    Console.WriteLine("Total priority: {0}", totalPriority);
}

static void Part2(IEnumerable<Rucksack> rucksacks)
{
    var totalPriority = rucksacks
        .Chunk(3)
        .Select(rs => Rucksack.ConvertItemToPriority(GetThreewayIntersection(rs)))
        .Sum();

    Console.WriteLine("Total priority: {0}", totalPriority);
}

static char GetThreewayIntersection(Rucksack[] rucksacks)
{
    var firstIntersection = rucksacks[0].Items.Intersect(rucksacks[1].Items);
    return firstIntersection.Intersect(rucksacks[2].Items).FirstOrDefault();
}