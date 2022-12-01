using adventofcode2022.Helpers;

namespace adventofcode2022.Day1;

public class Day1
{
    private readonly IReadInputFile _readInputFile;
    private IEnumerable<IEnumerable<int>> _groupedListsOfCalories;
    private int[] _sumOfValues;

    public Day1(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        _groupedListsOfCalories = _readInputFile.GetGroupOfInts(@"Day1\input.txt");
        _sumOfValues = _groupedListsOfCalories.Select(group => group.Sum()).ToArray();
        return _sumOfValues.MaxBy(x => x).ToString();
    }
    
    public string Part2()
    {
        var orderByDescending = _sumOfValues.OrderByDescending(x => x);
        var sumOfTopThree = orderByDescending.Take(3).Sum();
        return sumOfTopThree.ToString();
    }
}