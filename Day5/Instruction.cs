namespace Day5;

public class Instruction
{
    public Instruction(string input)
    {
        var values = input.Split(' ');

        NumberOfBoxes = int.Parse(values[1]);

        FromColumn = int.Parse(values[3]);

        ToColumn = int.Parse(values[5]);
    }

    public int NumberOfBoxes { get; }

    public int FromColumn { get; }

    public int ToColumn { get; }
}
