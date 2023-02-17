using Common;

namespace Day4;

public class Parser : IParser<IEnumerable<(Elf, Elf)>>
{
    public IEnumerable<(Elf, Elf)> Parse(string[] input)
    {
        return input.Select(MapElfPair);
    }

    private static (Elf, Elf) MapElfPair(string elfMap)
    {
        var elves = elfMap.Split(',');

        return (new Elf(elves[0]), new Elf(elves[1]));
    }
}
