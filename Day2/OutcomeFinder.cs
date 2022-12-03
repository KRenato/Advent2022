namespace Day2;

public class OutcomeFinder
{
    private readonly Dictionary<HandSignalType, Dictionary<HandSignalType, Outcome>> _outcomes;

    public OutcomeFinder()
    {
        _outcomes = new Dictionary<HandSignalType, Dictionary<HandSignalType, Outcome>>
        {
            {
                HandSignalType.Rock,
                new Dictionary<HandSignalType, Outcome>
                {
                    { HandSignalType.Rock, Outcome.Tie },
                    { HandSignalType.Paper, Outcome.Win },
                    { HandSignalType.Scissors, Outcome.Lose }
                }
            },
            {
                HandSignalType.Paper,
                new Dictionary<HandSignalType, Outcome>
                {
                    { HandSignalType.Rock, Outcome.Lose },
                    { HandSignalType.Paper, Outcome.Tie },
                    { HandSignalType.Scissors, Outcome.Win }
                }
            },
            {
                HandSignalType.Scissors,
                new Dictionary<HandSignalType, Outcome>
                {
                    { HandSignalType.Rock, Outcome.Win },
                    { HandSignalType.Paper, Outcome.Lose },
                    { HandSignalType.Scissors, Outcome.Tie }
                }
            }
        };
    }

    public Outcome GetOutcome(HandSignalType yourSignal, HandSignalType opponentsSignal)
    {
        return _outcomes[opponentsSignal][yourSignal];
    }

    public HandSignalType GetHandSignal(HandSignalType opponentsSignal, Outcome outcome)
    {
        return _outcomes[opponentsSignal]
            .First(kvp => kvp.Value == outcome)
            .Key;
    }
}
