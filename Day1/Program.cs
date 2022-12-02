using Common;

var input = await InputReader.GetInputAsync();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(input);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(input);

static void Part1(string[] input)
{
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

    Console.WriteLine("The elf with the most food has: {0}", elves.Max());
}

static void Part2(string[] input)
{
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

    Console.WriteLine("The elf with the most food has: {0}", top3);
}