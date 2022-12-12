using adventofcode2022.Helpers;

namespace adventofcode2022.Day9;

public class Day9
{
    private readonly IReadInputFile _helper;
    private string[] _lines;
    
    public Day9(IReadInputFile readInputFile)
    {
        _helper = readInputFile;
    }

    public string Part1()
    {
        _lines = _helper.GetListOfStringsFromInput(@"Day9\input.txt").ToArray();
        var head = new SnakePart();
        head.AddChild(new SnakePart());

        return MoveSnake(head, head.Child!, 800).Sum(x => x.Sum(c => c == '#' ? 1 : 0)).ToString();
    }

    public string Part2()
    {
        var head = new SnakePart();
        SnakePart tail = head;
        for (int i = 0; i < 9; i++)
        {
            var next = new SnakePart();
            tail.AddChild(next);
            tail = next;
        }

        return MoveSnake(head, tail, 800).Sum(x => x.Sum(c => c == '#' ? 1 : 0)).ToString();
    }

    private string[] MoveSnake(SnakePart head, SnakePart tail, int gridSize)
    {
        var coordinates = new string[]{};
        for (int i = 0; i < gridSize; i++) coordinates = coordinates.Append(new string('0', gridSize)).ToArray();
        foreach (var line in _lines)
        {
            var x = line.Split(" ");
            for (int i = 0; i < int.Parse(x[1]); i++)
            {
                head.MoveInit(x[0]);
                coordinates[tail.Y + gridSize/2] = _helper.ReplaceCharInStringAtIndex(coordinates[tail.Y + gridSize/2], tail.X + gridSize/2, '#');
            }
        }

        return coordinates;
    }
}