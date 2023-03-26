namespace advent;
public class Day3
{
    private readonly List<(string, string)> _rucksacks = new();
    private readonly List<string> _rucksacksRaw = new();

    public Day3(string input)
    {
        var rucksacks = input.Split(Environment.NewLine);
        foreach (var rucksack in rucksacks)
        {
            if (string.IsNullOrWhiteSpace(rucksack))
            {
                continue;
            }
            
            _rucksacksRaw.Add(rucksack);

            var rucksackFromInput = GetRucksackFromInput(rucksack);
            _rucksacks.Add(rucksackFromInput);
        }
    }

    public int GetTotalPriority()
    {
        var totalPriority = 0;
        foreach (var rucksack in _rucksacks)
        {
            var commonLetters = GetCommonLetters(rucksack);
            var priority = GetPriority(commonLetters);
            totalPriority += priority;
        }
        return totalPriority;
    }

    public int GetTotalPriorityForBadges()
    {
        var totalPriority = 0;
        var groups = GetGroups3Rucksacks();
        foreach (var group in groups)
        {
            var r1 = group[0];
            var r2 = group[1];
            var r3 = group[2];
            var commonChar = GetCommonInAllStrings(r1, r2, r3);
            var priority = GetPriority("" + commonChar);
            totalPriority += priority;
        }

        return totalPriority;
    }

    public (string, string) GetRucksackFromInput(string rucksack)
    {
        if (rucksack.Length % 2 != 0) 
            throw new ArgumentException($"Rucksack must be even length. Got: '{rucksack.Length}', for: {rucksack}", nameof(rucksack));
        var splitIndex = rucksack.Length / 2;
        var firstHalf = rucksack.Substring(0, splitIndex);
        var secondHalf = rucksack.Substring(splitIndex);
        return (firstHalf, secondHalf);
    }

    public IList<IList<string>> GetGroups3Rucksacks()
    {
        var groups = new List<IList<string>>();
        var group = new List<string>();
        foreach (var rucksack in _rucksacksRaw)
        {
            group.Add(rucksack);
            if (group.Count == 3)
            {
                groups.Add(group);
                group = new List<string>();
            }
        }
        return groups;
    }

    public char GetCommonInAllStrings(IEnumerable<char> ruck1, IEnumerable<char> ruck2, IEnumerable<char> ruck3)
    {
        var ruck1Unique = ruck1.Distinct().ToArray();
        var ruck2Unique = ruck2.Distinct().ToArray();
        var ruck3Unique = ruck3.Distinct().ToArray();
        var candidateLetters = from r1 in ruck1Unique
            join r2 in ruck2Unique on r1 equals r2
            join r3 in ruck3Unique on r1 equals r3
            select r1;

        var letters = candidateLetters.ToArray();
        if (letters.Length != 1)
        {
            throw new ArgumentException($"Expected 1 letter, got {letters.Length}");
        }
        return letters.First();
    }

    public string GetCommonLetters((string, string) rucksack)
    {
        var commonLetters = new List<char>();
        var firstHalf = rucksack.Item1;
        var secondHalf = rucksack.Item2;
        for (var i = 0; i < firstHalf.Length; i++)
        {
            if (secondHalf.Contains(firstHalf[i]))
            {
                commonLetters.Add(firstHalf[i]);
            }
        }
        var unique = commonLetters.Distinct().ToArray();
        return new string(unique);
    }

    public int GetPriority(string commonLetters)
    {
        var priority = 0;
        foreach (var letter in commonLetters)
        {
            var letterPriority = GetLetterPriority(letter);
            priority += letterPriority;
        }
        return priority;
    }

    public int GetLetterPriority(char letter)
    {
        int a = 'a';
        a -= 1;
        int A = 'A';
        A -= 27;

        if (letter >= a)
        {
            return letter - a;
        }
        else
        {
            return letter - A;
        }
    }
}
