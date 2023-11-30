using Common;

namespace Day8;
public class Parser : IParser<int[,]>
{
    public int[,] Parse(string[] input)
    {
        var rowLength = input.Length;
        var colLength = input[0].Length;

        var trees = new int[rowLength, colLength];

        for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
        {
            for (int colIndex = 0; colIndex < colLength; colIndex++)
            {
                trees[rowIndex, colIndex] = int.Parse(input[rowIndex][colIndex].ToString());
            }
        }

        return trees;
    }
}
