using adventofcode2022.Helpers;

namespace adventofcode2022.Day5;

public class Day5
{
    private readonly IReadInputFile _readInputFile;

    private string[] _rawStrings;

    public Day5(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        _rawStrings = _readInputFile.GetListOfStringsFromInput(@"Day5\input.txt").ToArray();
        var actions = _rawStrings.Skip(10).ToArray();
        Stack<string>[] listOfStacks = {
            new(new[] { "S", "Z", "P", "D", "L", "B", "F", "C" }),
            new(new[] { "N", "V", "G", "P", "H", "W", "B" }),
            new(new[] { "F", "W", "B", "J", "G" }),
            new(new[] { "G", "J", "N", "F", "L", "W", "C", "S" }),
            new(new[] { "W", "J", "L", "T", "P", "M", "S", "H" }),
            new(new[] { "B", "C", "W", "G", "F", "S" }),
            new(new[] { "H", "T", "P", "M", "Q", "B", "W" }),
            new(new[] { "F", "S", "W", "T" }),
            new(new[] { "N", "C", "R" })
        };
        
        foreach (var line in actions)
        {
            var move = Int32.Parse(line.Split(" ")[1]);
            var from = Int32.Parse(line.Split(" ")[3]) - 1;
            var to = Int32.Parse(line.Split(" ")[5]) - 1;

            for (int i = 0; i < move; i++)
            {
                var charToMove = listOfStacks[from].Pop();
                listOfStacks[to].Push(charToMove);
            }
        }

        return String.Join("", listOfStacks.Select(x => x.Pop()));
    }
    
    public string Part2()
    {
        Stack<string>[] listOfStacks = {
            new(new[] { "S", "Z", "P", "D", "L", "B", "F", "C" }),
            new(new[] { "N", "V", "G", "P", "H", "W", "B" }),
            new(new[] { "F", "W", "B", "J", "G" }),
            new(new[] { "G", "J", "N", "F", "L", "W", "C", "S" }),
            new(new[] { "W", "J", "L", "T", "P", "M", "S", "H" }),
            new(new[] { "B", "C", "W", "G", "F", "S" }),
            new(new[] { "H", "T", "P", "M", "Q", "B", "W" }),
            new(new[] { "F", "S", "W", "T" }),
            new(new[] { "N", "C", "R" })
        };
        var actions = _rawStrings.Skip(10).ToArray();

        foreach (var line in actions)
        {
            var move = Int32.Parse(line.Split(" ")[1]);
            var from = Int32.Parse(line.Split(" ")[3]) - 1;
            var to = Int32.Parse(line.Split(" ")[5]) - 1;

            var tempStack = new Stack<string>();
            
            for (int i = 0; i < move; i++)
            {
                var charToMove = listOfStacks[from].Pop();
                tempStack.Push(charToMove);
            }

            for (int i = 0; i < move; i++)
            {
                var charToMove = tempStack.Pop();
                listOfStacks[to].Push(charToMove);
            }

        }
        
        return String.Join("", listOfStacks.Select(x => x.Pop()));
    }
}