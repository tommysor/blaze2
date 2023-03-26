namespace advent;
public class Day5
{
    public record MoveOrder(int NumberOfBoxes, int FromStack, int ToStack);
    private readonly IList<String> _lines;
    public Day5(string input)
    {
        _lines = input.Split(Environment.NewLine);
    }

    public string GetTopOfStacksAfterMoves()
    {
        var stacks = ParseInitialStacks(_lines);
        var moveOrders = ParseMoveOrders(_lines);
        foreach (var moveOrder in moveOrders)
        {
            MoveBoxes(stacks, moveOrder);
        }

        var result = "";
        foreach (var stack in stacks)
        {
            result += stack.Peek();
        }
        return result;
    }

    public string GetTopOfStacksAfterMovesSecond()
    {
        var stacks = ParseInitialStacks(_lines);
        var moveOrders = ParseMoveOrders(_lines);
        foreach (var moveOrder in moveOrders)
        {
            MoveBoxesSecond(stacks, moveOrder);
        }

        var result = "";
        foreach (var stack in stacks)
        {
            result += stack.Peek();
        }
        return result;
    }

    public List<Stack<char>> GenerateStacks(string inputLine)
    {
        var stacks = new List<Stack<char>>();
        var endOfNextStackIndex = 2;
        for (var i = 0; i < inputLine.Length; i++)
        {
            if (i < endOfNextStackIndex)
            {
                continue;
            }

            var stack = new Stack<char>();
            stacks.Add(stack);
            
            endOfNextStackIndex += 4;
        }
        return stacks;
    }

    public List<char> ParseBoxes(string inputLine)
    {
        var boxes = new List<char>();
        var valueOfNextStackIndex = 1;
        for (var i = 0; i < inputLine.Length; i++)
        {
            if (i < valueOfNextStackIndex)
            {
                continue;
            }

            var stack = new Stack<char>();
            boxes.Add(inputLine[i]);
            
            valueOfNextStackIndex += 4;
        }
        return boxes;
    }

    public List<Stack<char>> ParseInitialStacks(IList<string> input)
    {
        var stacks = GenerateStacks(input[0]);
        var lists = new List<List<char>>();
        foreach(var stack in stacks)
        {
            lists.Add(new List<char>());
        }

        const string stopParseSignal = " 1  ";
        foreach (var line in input)
        {
            if (line.StartsWith(stopParseSignal))
            {
                break;
            }

            var boxes = ParseBoxes(line);
            
            for (var i = 0; i < boxes.Count; i++)
            {
                if (boxes[i] == ' ')
                {
                    continue;
                }

                lists[i].Add(boxes[i]);
            }
        }

        for (var i = 0; i < lists.Count; i++)
        {
            var list = lists[i];
            for (var j = list.Count - 1; j >= 0; j--)
            {
                stacks[i].Push(list[j]);
            }
        }

        return stacks;
    }

    public MoveOrder ParseMoveOrder(string input)
    {
        // "move 1 from 2 to 1"
        var parts = input.Split(' ');
        var numberOfBoxes = int.Parse(parts[1]);
        var fromStack = int.Parse(parts[3]);
        var toStack = int.Parse(parts[5]);
        return new MoveOrder(numberOfBoxes, fromStack, toStack);
    }

    public IList<MoveOrder> ParseMoveOrders(IList<string> input)
    {
        var moveOrders = new List<MoveOrder>();
        const string startParseSignal = "move ";
        foreach (var line in input)
        {
            if (!line.StartsWith(startParseSignal))
            {
                continue;
            }

            moveOrders.Add(ParseMoveOrder(line));
        }

        return moveOrders;
    }

    public void MoveBoxes(List<Stack<char>> stacks, MoveOrder moveOrder)
    {
        var fromStack = stacks[moveOrder.FromStack - 1];
        var toStack = stacks[moveOrder.ToStack - 1];
        for (var i = 0; i < moveOrder.NumberOfBoxes; i++)
        {
            toStack.Push(fromStack.Pop());
        }
    }

    public void MoveBoxesSecond(List<Stack<char>> stacks, MoveOrder moveOrder)
    {
        var fromStack = stacks[moveOrder.FromStack - 1];
        var toStack = stacks[moveOrder.ToStack - 1];
        
        var tmpStack = new Stack<char>();
        for (var i = 0; i < moveOrder.NumberOfBoxes; i++)
        {
            tmpStack.Push(fromStack.Pop());
        }

        while (tmpStack.Count > 0)
        {
            toStack.Push(tmpStack.Pop());
        }
    }
}
