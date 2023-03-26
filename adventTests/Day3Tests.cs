using advent;
namespace adventTests;

public class Day3Tests
{
    private readonly string _input;
    public Day3Tests()
    {
        _input = File.ReadAllText("Day3Input.txt");
    }

    [Fact]
    public void GetTotalPriority()
    {
        const int expectedPriority = 8394;
        var day3 = new Day3(_input);
        var totalPriority = day3.GetTotalPriority();
        Assert.Equal(expectedPriority, totalPriority);
    }

    [Fact]
    public void GetTotalPriorityForBadges()
    {
        const int expectedPriority = 2413;
        var day3 = new Day3(_input);
        var totalPriority = day3.GetTotalPriorityForBadges();
        Assert.Equal(expectedPriority, totalPriority);
    }

    [Theory]
    // 16 (p), 38 (L), 42 (P), 22 (v), 20 (t), and 19 (s)
    [InlineData('a', 1)]
    [InlineData('b', 2)]
    [InlineData('p', 16)]
    [InlineData('L', 38)]
    [InlineData('P', 42)]
    [InlineData('v', 22)]
    [InlineData('t', 20)]
    [InlineData('s', 19)]
    public void GetLetterPriority(char letter, int expected)
    {
        var day3 = new Day3("");
        var letterPriority = day3.GetLetterPriority(letter);
        Assert.Equal(expected, letterPriority);
    }

    [Theory]
    [InlineData("abcdef", "")]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "p")]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "L")]
    [InlineData("PmmdzqPrVvPwwTWBwg", "P")]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "v")]
    [InlineData("ttgJtRGJQctTZtZT", "t")]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", "s")]
    public void GetCommonLetters(string input, string expected)
    {
        var day3 = new Day3("");
        var rucksack = day3.GetRucksackFromInput(input);
        var commonLetters = day3.GetCommonLetters(rucksack);
        Assert.Equal(expected, commonLetters);
    }

    [Fact]
    public void GetGroups3Rucksacks()
    {
        var day3 = new Day3(_input);
        var groups = day3.GetGroups3Rucksacks();
        Assert.Equal(100, groups.Count);

        foreach (var group in groups)
        {
            Assert.Equal(3, group.Count);
        }
    }

    [Fact]
    public void GetCommonInAllStringsFirstExample()
    {
        var day3 = new Day3("");
        var commonLetters = day3.GetCommonInAllStrings("vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg");
        Assert.Equal('r', commonLetters);
    }

    [Fact]
    public void GetCommonInAllStringsSecondExample()
    {
        var day3 = new Day3("");
        var commonLetters = day3.GetCommonInAllStrings("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw");
        Assert.Equal('Z', commonLetters);
    }
}
