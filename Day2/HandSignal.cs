namespace Day2;

public class HandSignal
{
    public HandSignal(HandSignalType type)
    {
        Type = type;
    }

    public HandSignal(string signal)
    {
        Type = signal switch
        {
            "A" or "X" => HandSignalType.Rock,
            "B" or "Y" => HandSignalType.Paper,
            "C" or "Z" => HandSignalType.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(signal))
        };
    }

    public HandSignalType Type { get; }

    public int PointValue => Type switch
    {
        HandSignalType.Rock => 1,
        HandSignalType.Paper => 2,
        HandSignalType.Scissors => 3,
        _ => throw new InvalidOperationException("Invalid hand signal type.")
    };
}
