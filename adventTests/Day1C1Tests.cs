namespace adventTests;

public class Day1C1Tests
{
    private readonly string _input;

    public Day1C1Tests()
    {
        _input = File.ReadAllText("Day1C1Input.txt");
    }

    [Fact]
    public void Test1()
    {
        var input = _input.Split(Environment.NewLine);
        // var input = _knownInput.Split(Environment.NewLine);
        var list = new List<int>();

        var current = 0;
        // convert each value to int, and sum it to the current value
        // when we hit a blank line, add the current value to the list
        // and reset the current value to 0
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                list.Add(current);
                current = 0;
            }
            else
            {
                current += int.Parse(line);
            }
        }

        if (current > 0)
        {
            list.Add(current);
        }

        var max = list.Max();
        Assert.Equal(66616, max);

        var sumOfTop3 = list.OrderByDescending(x => x).Take(3).Sum();
        Assert.Equal(199172, sumOfTop3);
    }
}