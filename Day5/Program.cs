using Common;
using Day5;

var input = await InputReader.GetInputAsync<Parser, InputData>();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(input);

input = await InputReader.GetInputAsync<Parser, InputData>();

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(input);

static void Part1(InputData input)
{
    foreach (var instruction in input.Instructions)
    {
        for (int i = 0; i < instruction.NumberOfBoxes; i++)
        {
            var value = input.Stacks[instruction.FromColumn].Pop();
            input.Stacks[instruction.ToColumn].Push(value);
        }
    }

    Console.Write("The message is: ");

    for (int i = 1; i <= input.Stacks.Count; i++)
    {
        Console.Write(input.Stacks[i].Peek());
    }

    Console.WriteLine();
}

static void Part2(InputData input)
{
    foreach (var instruction in input.Instructions)
    {
        var intermediateStack = new Stack<char>();

        for (int i = 0; i < instruction.NumberOfBoxes; i++)
        {
            var value = input.Stacks[instruction.FromColumn].Pop();
            intermediateStack.Push(value);
        }

        foreach (var box in intermediateStack)
        {
            input.Stacks[instruction.ToColumn].Push(box);
        }
    }

    Console.Write("The message is: ");

    for (int i = 1; i <= input.Stacks.Count; i++)
    {
        Console.Write(input.Stacks[i].Peek());
    }

    Console.WriteLine();
}