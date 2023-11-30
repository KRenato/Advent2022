namespace Day9;

internal readonly record struct Coordinate(int X, int Y)
{
    public int XDistance(Coordinate other)
    {
        return X - other.X;
    }

    public int YDistance(Coordinate other)
    {
        return Y - other.Y;
    }
}