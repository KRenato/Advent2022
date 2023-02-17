using Common;
using Day7;

var directory = await InputReader.GetInputAsync<Parser, DirectoryTree>();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(directory);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(directory);

static void Part1(DirectoryTree directory)
{
    var flattenedDirectories = directory.Flatten();

    var sum = flattenedDirectories
        .Where(d => d.GetTotalDiskSize() <= 100_000)
        .Sum(d => d.GetTotalDiskSize());

    Console.WriteLine("Total disk size: {0}", sum);
}

static void Part2(DirectoryTree directory)
{
    var totalSize = directory.GetTotalDiskSize();

    var flattenedDirectories = directory.Flatten();

    var deleteSize = flattenedDirectories
        .Where(d => 70_000_000 - totalSize + d.GetTotalDiskSize() >= 30_000_000)
        .OrderBy(d => d.GetTotalDiskSize())
        .First();

    Console.WriteLine("Directory to delete: {0}", deleteSize.GetTotalDiskSize());
}