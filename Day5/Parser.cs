using Common;

namespace Day5;

public class Parser : IParser<InputData>
{
    public InputData Parse(string[] input)
    {
        var inputData = new InputData();

        foreach (var row in input)
        {
            if (!string.IsNullOrWhiteSpace(row) && row[1] != '1')
            ParseRowIntoData(inputData, row);
        }

        for (int i = 1; i <= inputData.Stacks.Count; i++)
        {
            inputData.Stacks[i] = new Stack<char>(inputData.Stacks[i]);
        }

        return inputData;
    }

    private void ParseRowIntoData(InputData inputData, string row)
    {
        if (row.Contains("move"))
        {
            inputData.Instructions.Add(new Instruction(row));
            return;
        }

        ParseBoxesIntoData(inputData, row);
    }

    private void ParseBoxesIntoData(InputData inputData, string row)
    {
        int i = 1;
        int col = 4 * i - 3;

        while (col < row.Length)
        {
            char value = row[col];
            if (value != ' ')
            {
                if (!inputData.Stacks.ContainsKey(i))
                {
                    inputData.Stacks.Add(i, new Stack<char>());
                }

                inputData.Stacks[i].Push(value);
            }

            i++;
            col = 4 * i - 3;
        }
    }
}
