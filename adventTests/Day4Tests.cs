using advent;
namespace adventTests;

public class Day4Tests
{
    private readonly string _input;
    public Day4Tests()
    {
        _input = File.ReadAllText("Day4Input.txt");
    }

    [Fact]
    public void CountRangeContainsRangeBothWays()
    {
        const int expected = 528;
        var day4 = new Day4(_input);
        var count = day4.CountWhereRangeContainsRangeBothWays();
        Assert.Equal(expected, count);
    }

    [Fact]
    public void CountWhereRangeHasCommonValue()
    {
        const int expected = 881;
        var day4 = new Day4(_input);
        var count = day4.CountWhereRangeHasCommonValue();
        Assert.Equal(expected, count);
    }

    [Theory]
    [InlineData("2-4,6-8", false)]
    [InlineData("2-3,4-5", false)]
    [InlineData("5-7,7-9", false)]
    [InlineData("2-8,3-7", true)]
    [InlineData("6-6,4-6", true)]
    [InlineData("2-6,4-8", false)]
    public void RangeContainsRangeBothWays(string input, bool expected)
    {
        var day4 = new Day4("");
        var range = day4.GetRangeFromInput(input);
        var rangeContainsRangeBothWays = day4.RangeContainsRangeBothWays(range.Item1, range.Item2, range.Item3, range.Item4);
        Assert.Equal(expected, rangeContainsRangeBothWays);
    }

    [Theory]
    [InlineData("2-4,6-8", false)]
    [InlineData("2-3,4-5", false)]
    [InlineData("5-7,7-9", true)]
    [InlineData("7-9,5-7", true)]
    [InlineData("2-8,3-7", true)]
    [InlineData("6-6,4-6", true)]
    [InlineData("2-6,4-8", true)]
    public void RangeHasCommonValue(string input, bool expected)
    {
        var day4 = new Day4("");
        var range = day4.GetRangeFromInput(input);
        var rangeHasCommonValue = day4.RangeHasCommonValue(range.Item1, range.Item2, range.Item3, range.Item4);
        Assert.Equal(expected, rangeHasCommonValue);
    }
}
