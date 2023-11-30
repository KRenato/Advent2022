namespace Day9;

internal class Rope
{
    private readonly Coordinate[] _segmentPositions;

    public Rope(int length)
    {
        _segmentPositions = new Coordinate[length];
        
        for (int i = 0;  i < length; i++)
        {
            _segmentPositions[i] = new Coordinate(0, 0);
        }
    }

    public Coordinate HeadPosition => _segmentPositions[0];

    public Coordinate TailPosition => _segmentPositions[^1];

    public Coordinate[] SegmentPositions => _segmentPositions;

    public void MoveHead(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                _segmentPositions[0] = new(_segmentPositions[0].X, _segmentPositions[0].Y + 1); ;
                break;
            case Direction.Down:
                _segmentPositions[0] = new(_segmentPositions[0].X, _segmentPositions[0].Y - 1); ;
                break;
            case Direction.Left:
                _segmentPositions[0] = new(_segmentPositions[0].X - 1, _segmentPositions[0].Y); ;
                break;
            case Direction.Right:
                _segmentPositions[0] = new(_segmentPositions[0].X + 1, _segmentPositions[0].Y); ;
                break;
            default:
                throw new InvalidOperationException("Invalid direction.");
        };

        for (int i = 1; i < _segmentPositions.Length; i++)
        {
            MoveRopeSegment(i);
        }
    }

    private void MoveRopeSegment(int segmentIndex)
    {
        var previousSegmentPosition = _segmentPositions[segmentIndex - 1];
        var currentSegmentPosition = _segmentPositions[segmentIndex];

        var xDistance = previousSegmentPosition.XDistance(currentSegmentPosition);
        var yDistance = previousSegmentPosition.YDistance(currentSegmentPosition);

        if (Math.Abs(xDistance) > 1)
        {
            int xMovement = Math.Abs(xDistance) / xDistance;
            int yMovement = yDistance == 0 ? 0 : Math.Abs(yDistance) / yDistance;
            int newX = xMovement + currentSegmentPosition.X;
            int newY = yMovement + currentSegmentPosition.Y;

            _segmentPositions[segmentIndex] = new Coordinate(newX, newY);
        }

        if (Math.Abs(yDistance) > 1)
        {
            int xMovement = xDistance == 0 ? 0 : Math.Abs(xDistance) / xDistance;
            int yMovement = Math.Abs(yDistance) / yDistance;
            int newX = xMovement + currentSegmentPosition.X;
            int newY = yMovement + currentSegmentPosition.Y;

            _segmentPositions[segmentIndex] = new Coordinate(newX, newY);
        }
    }
}
