using Common;
using Day9;

internal class Parser : IParser<Movement[]>
{
    public Movement[] Parse(string[] input)
    {
        return input
            .Select(ParseItem)
            .ToArray();
    }

    private Movement ParseItem(string input)
    {
        var movement = input.Split(' ');

        var direction = movement[0] switch
        {
            "U" => Direction.Up,
            "D" => Direction.Down,
            "L" => Direction.Left,
            "R" => Direction.Right,
            _ => throw new InvalidOperationException("Invalid direction.")
        };

        return new Movement(direction, int.Parse(movement[1]));
    }
}
