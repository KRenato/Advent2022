using Common;
using Day8;

var trees = await InputReader.GetInputAsync<Parser, int[,]>();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(trees);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(trees);

static void Part1(int[,] trees)
{
    int visibleTrees = 0;

    for (int i = 0; i < trees.GetLength(0); i++)
    {
        for (int j = 0; j < trees.GetLength(1); j++)
        {
            if (TreeUtilities.IsVisible(trees, i, j))
            {
                visibleTrees++;
            }
        }
    }

    Console.WriteLine("The number of trees visible is: {0}", visibleTrees);
}

static void Part2(int[,] trees)
{
    int maxViewScore = 0;

    for (int i = 0; i < trees.GetLength(0); i++)
    {
        for (int j = 0; j < trees.GetLength(1); j++)
        {
            int viewScore = TreeUtilities.GetViewScore(trees, i, j);
            if (viewScore > maxViewScore)
            {
                maxViewScore = viewScore;
            }
        }
    }

    Console.WriteLine("The highest view score is: {0}", maxViewScore);
}