using advent;
namespace adventTests;
public class Day6Tests
{
    private readonly string _input;
    public static readonly IEnumerable<object[]> _sampleStartOfPacket = new[]
    {
        new object[]{"mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7},
        new object[]{"bvwbjplbgvbhsrlpgdmjqwftvncz", 5},
        new object[]{"nppdvjthqldpwncqszvftbrmjlhg", 6},
        new object[]{"nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10},
        new object[]{"zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11},
    };

    public static readonly IEnumerable<object[]> _sampleStartOfMessage = new[]
    {
        new object[]{"mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19},
        new object[]{"bvwbjplbgvbhsrlpgdmjqwftvncz", 23},
        new object[]{"nppdvjthqldpwncqszvftbrmjlhg", 23},
        new object[]{"nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29},
        new object[]{"zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26},
    };

    public Day6Tests()
    {
        _input = File.ReadAllText("Day6Input.txt");
    }

    [Fact]
    public void GetNumberOfCharsBeforeFirst4NonDuplicatedCharsAnswer()
    {
        var day6 = new Day6(_input);
        var actual = day6.GetNumberOfCharsBeforeFirstXNonDuplicatedChars(4);
        Assert.Equal(1155, actual);
    }

    [Fact]
    public void GetNumberOfCharsBeforeFirst14NonDuplicatedCharsAnswer()
    {
        var day6 = new Day6(_input);
        var actual = day6.GetNumberOfCharsBeforeFirstXNonDuplicatedChars(14);
        Assert.Equal(2789, actual);
    }

    [Theory]
    [MemberData(nameof(_sampleStartOfPacket))]
    public void GetNumberOfCharsBeforeFirst4NonDuplicatedChars(string input, int expected)
    {
        var day6 = new Day6(input);
        var actual = day6.GetNumberOfCharsBeforeFirstXNonDuplicatedChars(4);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(_sampleStartOfMessage))]
    public void GetNumberOfCharsBeforeFirst14NonDuplicatedChars(string input, int expected)
    {
        var day6 = new Day6(input);
        var actual = day6.GetNumberOfCharsBeforeFirstXNonDuplicatedChars(14);
        Assert.Equal(expected, actual);
    }
}
