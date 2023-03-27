using advent;
namespace adventTests;
public class Day8Tests
{
    private readonly string _input;
    private readonly string _inputSample = """
30373
25512
65332
33549
35390
""";

    public Day8Tests()
    {
        _input = File.ReadAllText("Day8Input.txt");
    }

    [Fact]
    public void GetHighestScenicScoreAnswer()
    {
        const int expected = 268800;
        var day8 = new Day8(_input);
        var count = day8.GetHighestScenicScore();
        Assert.Equal(expected, count);
    }

    [Fact]
    public void GetHighestScenicScoreSample()
    {
        const int expected = 8;
        var day8 = new Day8(_inputSample);
        var count = day8.GetHighestScenicScore();
        Assert.Equal(expected, count);
    }

    [Fact]
    public void CountVisibleTreesAnswer()
    {
        const int expected = 1736;
        var day8 = new Day8(_input);
        var count = day8.CountVisibleTrees();
        Assert.Equal(expected, count);
    }

    [Fact]
    public void CountVisibleTreesSample()
    {
        const int expected = 21;
        var day8 = new Day8(_inputSample);
        var count = day8.CountVisibleTrees();
        Assert.Equal(expected, count);
    }

    [Fact]
    public void GetScenicScore()
    {
        const int expected = 1;
        var day8 = new Day8(_inputSample);
        var count = day8.GetScenicScore(1, 1);
        Assert.Equal(expected, count);
    }
}
