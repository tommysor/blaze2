using System.Linq;
namespace advent;
public class Day6
{
    private readonly string _input;

    public Day6(string input)
    {
        _input = input;
    }

    public int GetNumberOfCharsBeforeFirstXNonDuplicatedChars(int numberOfCharsToCheck)
    {
        var input = _input.AsSpan();
        for (var i = 0; i < _input.Length - numberOfCharsToCheck; i++)
        {
            var slice = input.Slice(i, numberOfCharsToCheck);
            
            if (slice.ToArray().Distinct().Count() == numberOfCharsToCheck)
            {
                return i + numberOfCharsToCheck;
            }
        }

        return -1;
    }
}
