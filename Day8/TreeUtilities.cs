namespace Day8;

public static class TreeUtilities
{
    public static bool IsVisible(int[,] trees, int row, int col)
    {
        return IsVisibleFromLeft(trees, row, col)
            || IsVisibleFromTop(trees, row, col)
            || IsVisibleFromRight(trees, row, col)
            || IsVisibleFromBottom(trees, row, col);
    }

    private static bool IsVisibleFromLeft(int[,] trees, int row, int col)
    {
        if (col == 0)
        {
            return true;
        }

        for (int i = 0; i < col; i++)
        {
            if (trees[row, i] >= trees[row, col])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleFromTop(int[,] trees, int row, int col)
    {
        if (row == 0)
        {
            return true;
        }

        for (int i = 0; i < row; i++)
        {
            if (trees[i, col] >= trees[row, col])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleFromRight(int[,] trees, int row, int col)
    {
        if (col == trees.GetLength(0) - 1)
        {
            return true;
        }

        for (int i = col + 1; i < trees.GetLength(0); i++)
        {
            if (trees[row, i] >= trees[row, col])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleFromBottom(int[,] trees, int row, int col)
    {
        if (row == trees.GetLength(1) - 1)
        {
            return true;
        }

        for (int i = row + 1; i < trees.GetLength(1); i++)
        {
            if (trees[i, col] >= trees[row, col])
            {
                return false;
            }
        }

        return true;
    }

    public static int GetViewScore(int[,] trees, int row, int col)
    {
        return GetCountOfVisibleTreesToTheLeft(trees, row, col)
            * GetCountOfVisibleTreesAbove(trees, row, col)
            * GetCountOfVisibleTreesToTheRight(trees, row, col)
            * GetCountOfVisibleTreesBelow(trees, row, col);
    }

    private static int GetCountOfVisibleTreesToTheLeft(int[,] trees, int row, int col)
    {
        if (col == 0)
        {
            return 0;
        }

        int count = 0;

        for (int i = col - 1; i >= 0; i--)
        {
            count++;

            if (trees[row, i] >= trees[row, col])
            {
                break;
            }
        }

        return count;
    }

    private static int GetCountOfVisibleTreesAbove(int[,] trees, int row, int col)
    {
        if (row == 0)
        {
            return 0;
        }

        int count = 0;

        for (int i = row - 1; i >= 0; i--)
        {
            count++;

            if (trees[i, col] >= trees[row, col])
            {
                break;
            }
        }

        return count;
    }

    private static int GetCountOfVisibleTreesToTheRight(int[,] trees, int row, int col)
    {
        if (col == trees.GetLength(1) - 1)
        {
            return 0;
        }

        int count = 0;

        for (int i = col + 1; i <= trees.GetLength(1) - 1; i++)
        {
            count++;

            if (trees[row, i] >= trees[row, col])
            {
                break;
            }
        }

        return count;
    }

    private static int GetCountOfVisibleTreesBelow(int[,] trees, int row, int col)
    {
        if (row == trees.GetLength(0) - 1)
        {
            return 0;
        }

        int count = 0;

        for (int i = row + 1; i <= trees.GetLength(0) - 1; i++)
        {
            count++;

            if (trees[i, col] >= trees[row, col])
            {
                break;
            }
        }

        return count;
    }
}
