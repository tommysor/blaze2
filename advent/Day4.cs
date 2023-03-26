namespace advent;
public class Day4
{
    private readonly List<(int, int, int, int)> _ranges = new();
    public Day4(string input)
    {
        var lines = input.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            var range = GetRangeFromInput(line);
            _ranges.Add(range);
        }
    }

    public (int, int, int, int) GetRangeFromInput(string input)
    {
        var split = input.Split(",");
        var part1 = split[0].Split("-");
        var start1 = int.Parse(part1[0]);
        var end1 = int.Parse(part1[1]);
        var part2 = split[1].Split("-");
        var start2 = int.Parse(part2[0]);
        var end2 = int.Parse(part2[1]);
        return (start1, end1, start2, end2);
    }

    public bool RangeContainsRange(int start1, int end1, int start2, int end2)
    {
        return start1 <= start2 && end1 >= end2;
    }

    public bool RangeContainsRangeBothWays(int start1, int end1, int start2, int end2)
    {
        return RangeContainsRange(start1, end1, start2, end2) || RangeContainsRange(start2, end2, start1, end1);
    }

    public int CountWhereRangeContainsRangeBothWays()
    {
        var count = 0;
        foreach (var range in _ranges)
        {
            if (RangeContainsRangeBothWays(range.Item1, range.Item2, range.Item3, range.Item4))
            {
                count++;
            }
        }
        return count;
    }

    public bool RangeHasCommonValue(int start1, int end1, int start2, int end2)
    {
        return start1 <= start2 && end1 >= start2 || start2 <= start1 && end2 >= start1;
    }

    public int CountWhereRangeHasCommonValue()
    {
        var count = 0;
        foreach (var range in _ranges)
        {
            if (RangeHasCommonValue(range.Item1, range.Item2, range.Item3, range.Item4))
            {
                count++;
            }
        }
        return count;
    }
}
