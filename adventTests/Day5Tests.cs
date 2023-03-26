using advent;
namespace adventTests;
public class Day5Tests
{
    private readonly string _input;
    private readonly string _sampleInput = """
    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
""";
    public Day5Tests()
    {
        _input = File.ReadAllText("Day5Input.txt");
    }

    [Fact]
    public void GetTopOfStacksAfterMoves()
    {
        const string expected = "JDTMRWCQJ";
        var day5 = new Day5(_input);
        var actual = day5.GetTopOfStacksAfterMoves();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetTopOfStacksAfterMovesSecond()
    {
        const string expected = "VHJDDCWRD";
        var day5 = new Day5(_input);
        var actual = day5.GetTopOfStacksAfterMovesSecond();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("    [D]    ", 3)]
    [InlineData("[N] [C]    ", 3)]
    [InlineData("[Z] [M] [P]", 3)]
    [InlineData("[R] [W] [G] [J]     [T] [M]     [V]", 9)]
    public void GenerateStacks(string inputLine, int expectedStackCount)
    {
        var day5 = new Day5("");
        var actual = day5.GenerateStacks(inputLine);
        Assert.Equal(expectedStackCount, actual.Count);
    }

    [Theory]
    [InlineData("    [D]    ", " D ")]
    [InlineData("[N] [C]    ", "NC ")]
    [InlineData("[Z] [M] [P]", "ZMP")]
    [InlineData("[R] [W] [G] [J]     [T] [M]     [V]", "RWGJ TM V")]
    public void ParseBoxes(string inputLine, string expectedBoxes)
    {
        var day5 = new Day5("");
        var boxes = day5.ParseBoxes(inputLine);
        Assert.Equal(expectedBoxes, new string(boxes.ToArray()));
    }

    [Fact]
    public void ParseInitialStacks()
    {
        var day5 = new Day5("");
        var lines = _sampleInput.Split(Environment.NewLine);
        var actual = day5.ParseInitialStacks(lines);
        Assert.Equal(3, actual.Count);
        Assert.Equal(2, actual[0].Count);
        Assert.Equal(3, actual[1].Count);
        Assert.Single(actual[2]);

        Assert.Equal('N', actual[0].Pop());
        Assert.Equal('Z', actual[0].Pop());

        Assert.Equal('D', actual[1].Pop());
        Assert.Equal('C', actual[1].Pop());
        Assert.Equal('M', actual[1].Pop());

        Assert.Equal('P', actual[2].Pop());
    }

    [Theory]
    [InlineData("move 1 from 2 to 1", 1, 2, 1)]
    [InlineData("move 3 from 1 to 3", 3, 1, 3)]
    [InlineData("move 2 from 2 to 1", 2, 2, 1)]
    [InlineData("move 1 from 1 to 2", 1, 1, 2)]
    public void ParseMoveOrder(string inputLine, int expectedNumberOfBoxes, int expectedFromStack, int expectedToStack)
    {
        var day5 = new Day5("");
        var moveOrder = day5.ParseMoveOrder(inputLine);
        Assert.Equal(expectedNumberOfBoxes, moveOrder.NumberOfBoxes);
        Assert.Equal(expectedFromStack, moveOrder.FromStack);
        Assert.Equal(expectedToStack, moveOrder.ToStack);
    }

    [Fact]
    public void ParseMoveOrders()
    {
        var day5 = new Day5("");
        var lines = _sampleInput.Split(Environment.NewLine);
        var moveOrders = day5.ParseMoveOrders(lines);
        Assert.Equal(4, moveOrders.Count);
    }

    [Fact]
    public void GetTopOfStacksAfterMovesSample()
    {
        const string expected = "CMZ";
        var day5 = new Day5(_sampleInput);
        var actual = day5.GetTopOfStacksAfterMoves();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetTopOfStacksAfterMovesSecondSample()
    {
        const string expected = "MCD";
        var day5 = new Day5(_sampleInput);
        var actual = day5.GetTopOfStacksAfterMovesSecond();
        Assert.Equal(expected, actual);
    }
}
