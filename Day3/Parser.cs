using Common;

namespace Day3;

public class Parser : IParser<IEnumerable<Rucksack>>
{
    public IEnumerable<Rucksack> Parse(string[] input)
    {
        return input
            .Select(i => new Rucksack(i))
            .ToList();
    }
}
