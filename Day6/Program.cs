using Common;

var input = await InputReader.GetInputAsync();
var buffer = input.First();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(buffer);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(buffer);

static void Part1(string buffer)
{
    const int markerLength = 4;

    int markerLocation = 0;

    for (int i = markerLength - 1; i < buffer.Length; i++)
    {
        var chunk = new List<char>();
        for (int j = 0; j < markerLength; j++)
        {
            chunk.Add(buffer[i - j]);
        }

        if (chunk.Distinct().Count() == markerLength)
        {
            markerLocation = i + 1;
            break;
        }
    }

    Console.WriteLine("Marker location: {0}", markerLocation);
}

static void Part2(string buffer)
{
    const int markerLength = 14;

    int markerLocation = 0;

    for (int i = markerLength - 1; i < buffer.Length; i++)
    {
        var chunk = new List<char>();
        for (int j = 0; j < markerLength; j++)
        {
            chunk.Add(buffer[i - j]);
        }

        if (chunk.Distinct().Count() == markerLength)
        {
            markerLocation = i + 1;
            break;
        }
    }

    Console.WriteLine("Marker location: {0}", markerLocation);
}