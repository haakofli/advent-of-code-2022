using adventofcode2022.Helpers;

namespace adventofcode2022.Day2;

public class Day2
{
    private readonly IReadInputFile _readInputFile;
    private IEnumerable<string[]> _formattedListOfStrings;

    // A & X = Rock       B & Y = Paper       C & Z = Scissor
    private readonly Dictionary<string, Dictionary<string, int>> _points = new()
    {
        { "A", new() { { "X", 4 }, { "Y", 8 }, { "Z", 3 } } },
        { "B", new() { { "X", 1 }, { "Y", 5 }, { "Z", 9 } } },
        { "C", new() { { "X", 7 }, { "Y", 2 }, { "Z", 6 } } },
    };
    
    // X = Lose      Y = Draw       Z = Win
    private readonly Dictionary<string, Dictionary<string, int>> _pointsPart2 = new()
    {
        { "X", new() { { "A", 3 }, { "B", 1 }, { "C", 2 } } }, 
        { "Y", new() { { "A", 4 }, { "B", 5 }, { "C", 6 } } }, 
        { "Z", new() { { "A", 8 }, { "B", 9 }, { "C", 7 } } }
    };

    public Day2(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }
    
    public string Part1()
    {
        var rawStrings = _readInputFile.GetListOfStringsFromInput(@"Day2\input.txt");
        _formattedListOfStrings = rawStrings.Select(x => x.Split(" ")).ToArray();
        
        var totalScore = _formattedListOfStrings.Sum(stringPair => _points[stringPair[0]][stringPair[1]]);
        return totalScore.ToString();
    }
    

    public string Part2()
    {
        var totalScore = _formattedListOfStrings.Sum(stringPair => _pointsPart2[stringPair[1]][stringPair[0]]);
        return totalScore.ToString();
    }
}