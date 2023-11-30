using Common;
using Day9;

var movements = await InputReader.GetInputAsync<Parser, Movement[]>();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(movements);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(movements);

static void Part1(Movement[] movements)
{
    var tailPositions = new HashSet<Coordinate> { new Coordinate(0, 0) };
    int ropeLength = 2;
    var rope = new Rope(ropeLength);

    foreach (var movement in movements)
    {
        DoRopeMovement(rope, movement, tailPositions);
    }

    Console.WriteLine("The number of unique tail positions is: {0}", tailPositions.Count);
}

static void Part2(Movement[] movements)
{
    var tailPositions = new HashSet<Coordinate> { new Coordinate(0, 0) };
    int ropeLength = 10;
    var rope = new Rope(ropeLength);

    foreach (var movement in movements)
    {
        DoRopeMovement(rope, movement, tailPositions);
    }

    Console.WriteLine("The number of unique tail positions is: {0}", tailPositions.Count);
}

static void DoRopeMovement(Rope rope, Movement movement, HashSet<Coordinate> tailPositions)
{
    for (int i = 0; i < movement.Distance; i++)
    {
        rope.MoveHead(movement.Direction);

        AddUniqueTailPosition(tailPositions, rope.TailPosition);
    }
}

static void AddUniqueTailPosition(HashSet<Coordinate> tailPositions, Coordinate position)
{
    if (!tailPositions.Contains(position))
    {
        tailPositions.Add(position);
    }
}