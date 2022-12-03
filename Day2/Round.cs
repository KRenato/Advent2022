namespace Day2;

public class Round
{
    private readonly OutcomeFinder _outcomeFinder;
    private HandSignal? _opponentsSignal;
    private HandSignal? _yourSignal;

    public Round(OutcomeFinder outcomeFinder)
    {
        _outcomeFinder = outcomeFinder;
    }

    public void MapToSignals(string opponentsSignal, string yourSignal)
    {
        _opponentsSignal = new HandSignal(opponentsSignal);
        _yourSignal = new HandSignal(yourSignal);
    }

    public void MapToOutcome(string opponentsSignal, string yourOutcome)
    {
        _opponentsSignal = new HandSignal(opponentsSignal);

        var outcome = yourOutcome switch
        {
            "X" => Outcome.Lose,
            "Y" => Outcome.Tie,
            "Z" => Outcome.Win,
            _ => throw new InvalidOperationException()
        };

        _yourSignal = new HandSignal(_outcomeFinder.GetHandSignal(_opponentsSignal.Type, outcome));
    }

    public int GetOutcome()
    {
        if (_yourSignal == null || _opponentsSignal == null)
            throw new NullReferenceException();

        var outcome = _outcomeFinder.GetOutcome(_yourSignal.Type, _opponentsSignal.Type);

        return outcome switch
        {
            Outcome.Lose => _yourSignal.PointValue,
            Outcome.Tie => _yourSignal.PointValue + 3,
            Outcome.Win => _yourSignal.PointValue + 6,
            _ => throw new InvalidOperationException("Invalid outcome.")
        };
    }
}