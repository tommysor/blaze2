using advent;
namespace adventTests;

public class Day2C1Tests
{
    private readonly string _input;

    public Day2C1Tests()
    {
        _input = File.ReadAllText("Day2Input.txt");
    }

    [Fact]
    public void GetTotalScoreMoveMove()
    {
        const int expected = 8890;
        var day2 = new Day2(_input);
        var actual = day2.GetTotalScoreMoveMove();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetTotalScoreMoveResult()
    {
        const int expected = 10238;
        var day2 = new Day2(_input);
        var actual = day2.GetTotalScoreMoveResult();
        Assert.Equal(expected, actual);
    }

    [Theory]
    // your opponent will choose Rock (A), and you need the round to end in a draw (Y), so you also choose Rock. This gives you a score of 1 + 3 = 4
    [InlineData("A Y", 4)]
    // your opponent will choose Paper (B), and you choose Rock so you lose (X) with a score of 1 + 0 = 1
    [InlineData("B X", 1)]
    // you will defeat your opponent's Scissors with Rock for a score of 1 + 6 = 7
    [InlineData("C Z", 7)]
    public void GetTotalScoreMoveResultSingle(string input, int expected)
    {
        var day2 = new Day2(input);
        var actual = day2.GetTotalScoreMoveResult();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Day2.Move.Rock, Day2.Move.Scissors, true)]
    [InlineData(Day2.Move.Paper, Day2.Move.Rock, true)]
    [InlineData(Day2.Move.Scissors, Day2.Move.Paper, true)]
    [InlineData(Day2.Move.Rock, Day2.Move.Paper, false)]
    [InlineData(Day2.Move.Paper, Day2.Move.Scissors, false)]
    [InlineData(Day2.Move.Scissors, Day2.Move.Rock, false)]
    [InlineData(Day2.Move.Rock, Day2.Move.Rock, null)]
    [InlineData(Day2.Move.Paper, Day2.Move.Paper, null)]
    [InlineData(Day2.Move.Scissors, Day2.Move.Scissors, null)]
    public void Won(Day2.Move myMove, Day2.Move opponentMove, bool? expected)
    {
        var day2 = new Day2("");
        var actual = day2.Won(myMove, opponentMove);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, 6)]
    [InlineData(false, 0)]
    [InlineData(null, 3)]
    public void GetScoreForResult(bool? result, int expected)
    {
        var day2 = new Day2("");
        var actual = day2.GetScoreForResult(result);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Day2.Move.Rock, 1)]
    [InlineData(Day2.Move.Paper, 2)]
    [InlineData(Day2.Move.Scissors, 3)]
    public void GetScoreForMove(Day2.Move move, int expected)
    {
        var day2 = new Day2("");
        var actual = day2.GetScoreForMove(move);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Day2.Move.Paper, Day2.Move.Rock, 8)]
    [InlineData(Day2.Move.Paper, Day2.Move.Paper, 5)]
    [InlineData(Day2.Move.Paper, Day2.Move.Scissors, 2)]
    
    [InlineData(Day2.Move.Rock, Day2.Move.Rock, 4)]
    [InlineData(Day2.Move.Rock, Day2.Move.Paper, 1)]
    [InlineData(Day2.Move.Rock, Day2.Move.Scissors, 7)]

    [InlineData(Day2.Move.Scissors, Day2.Move.Rock, 3)]
    [InlineData(Day2.Move.Scissors, Day2.Move.Paper, 9)]
    [InlineData(Day2.Move.Scissors, Day2.Move.Scissors, 6)]    
    public void GetScoreForRound(Day2.Move myMove, Day2.Move opponentMove, int expected)
    {
        var day2 = new Day2("");
        var actual = day2.GetScoreForRound(myMove, opponentMove);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("X", false)]
    [InlineData("Y", null)]
    [InlineData("Z", true)]
    public void GetResultFromInput(string resultInput, bool? expected)
    {
        var day2 = new Day2("");
        var actual = day2.GetResultFromInput(resultInput);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("A X", Day2.Move.Scissors, Day2.Move.Rock)]
    [InlineData("A Y", Day2.Move.Rock, Day2.Move.Rock)]
    [InlineData("A Z", Day2.Move.Paper, Day2.Move.Rock)]
    public void GetRoundFromInputMoveResult(string input, Day2.Move expectedMyMove, Day2.Move expectedOpponentMove)
    {
        var day2 = new Day2("");
        var (actualMyMove, actualOpponentMove) = day2.GetRoundFromInputMoveResult(input);
        Assert.Equal(expectedMyMove, actualMyMove);
        Assert.Equal(expectedOpponentMove, actualOpponentMove);
    }
}
