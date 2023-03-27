namespace advent;
public class Day8
{
    private readonly int[,] _input;

    public Day8(string input)
    {
        _input = CreateMatrix(input);
    }

    private static int[,] CreateMatrix(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var countRows = lines.Length;
        var countCols = lines[0].Length;
        var matrix = new int[countRows, countCols];
        for (var row = 0; row < countRows; row++)
        {
            var line = lines[row];
            for (var col = 0; col < countCols; col++)
            {
                var c = line[col];
                matrix[row, col] = int.Parse(c.ToString());
            }
        }

        return matrix;
    }

    public int CountVisibleTrees()
    {
        var count = 0;
        for (var row = 0; row < _input.GetLength(0); row++)
        {
            for (var col = 0; col < _input.GetLength(1); col++)
            {
                if (IsVisible(row, col))
                {
                    count++;
                }
            }
        }

        return count;
    }

    public int GetHighestScenicScore()
    {
        var list = new List<int>();
        for (var row = 0; row < _input.GetLength(0); row++)
        {
            for (var col = 0; col < _input.GetLength(1); col++)
            {
                var score = GetScenicScore(row, col);
                list.Add(score);
            }
        }

        return list.Max();
    }

    public bool IsHiddenBy(int height, int row, int col)
    {
        var val = _input[row, col];
        if (val >= height)
        {
            return true;
        }
        return false;
    }

#region IsVisible
    public bool IsVisible(int row, int col)
    {
        var fromTop = IsVisibleFromTop(row, col);
        var fromBottom = IsVisibleFromBottom(row, col);
        var fromLeft = IsVisibleFromLeft(row, col);
        var fromRight = IsVisibleFromRight(row, col);

        return fromTop || fromBottom || fromLeft || fromRight;
    }

    public bool IsVisibleFromTop(int row, int col)
    {
        var height = _input[row, col];
        for (var i = 0; i < row; i++)
        {
            if (IsHiddenBy(height, i, col))
            {
                return false;
            }
        }

        return true;
    }

    public bool IsVisibleFromBottom(int row, int col)
    {
        var height = _input[row, col];
        for (var i = _input.GetLength(0) - 1; i > row; i--)
        {
            if (IsHiddenBy(height, i, col))
            {
                return false;
            }
        }

        return true;
    }

    public bool IsVisibleFromLeft(int row, int col)
    {
        var height = _input[row, col];
        for (var i = 0; i < col; i++)
        {
            if (IsHiddenBy(height, row, i))
            {
                return false;
            }
        }

        return true;
    }

    public bool IsVisibleFromRight(int row, int col)
    {
        var height = _input[row, col];
        for (var i = _input.GetLength(1) - 1; i > col; i--)
        {
            if (IsHiddenBy(height, row, i))
            {
                return false;
            }
        }

        return true;
    }
#endregion

#region ScenicScore
    public int GetScenicScore(int row, int col)
    {
        var height = _input[row, col];
        var scoreTop = GetScenicScoreFromTop(height, row, col);
        var scoreBottom = GetScenicScoreFromBottom(height, row, col);
        var scoreLeft = GetScenicScoreFromLeft(height, row, col);
        var scoreRight = GetScenicScoreFromRight(height, row, col);
        var score = scoreTop * scoreBottom * scoreLeft * scoreRight;
        return score;
    }

    public int GetScenicScoreFromTop(int height, int row, int col)
    {
        var score = 0;
        for (var i = row - 1; i >= 0; i--)
        {
            score++;
            if (IsHiddenBy(height, i, col))
            {
                return score;
            }
        }
        return score;
    }

    public int GetScenicScoreFromBottom(int height, int row, int col)
    {
        var score = 0;
        for (var i = row + 1; i < _input.GetLength(0); i++)
        {
            score++;
            if (IsHiddenBy(height, i, col))
            {
                return score;
            }
        }
        return score;
    }

    public int GetScenicScoreFromLeft(int height, int row, int col)
    {
        var score = 0;
        for (var i = col - 1; i >= 0; i--)
        {
            score++;
            if (IsHiddenBy(height, row, i))
            {
                return score;
            }
        }
        return score;
    }

    public int GetScenicScoreFromRight(int height, int row, int col)
    {
        var score = 0;
        for (var i = col + 1; i < _input.GetLength(1); i++)
        {
            score++;
            if (IsHiddenBy(height, row, i))
            {
                return score;
            }
        }
        return score;
    }
#endregion
}
