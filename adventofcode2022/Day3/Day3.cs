using adventofcode2022.Helpers;

namespace adventofcode2022.Day3;

public class Day3
{
    private readonly IReadInputFile _readInputFile;
    private static readonly string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string[] _rawStrings;

    public Day3(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        _rawStrings = _readInputFile.GetListOfStringsFromInput(@"Day3\input.txt").ToArray();
        var stringsSplitInTwo = _rawStrings.Select(line => new[]
            {
                string.Join("", line.Take(line.Length / 2)), 
                string.Join("", line.Skip(line.Length / 2))
            }).ToArray();

        var totalScore = stringsSplitInTwo.Sum(sacks => Letters.IndexOf(sacks[0].First(letter => sacks[1].Contains(letter))) + 1);
        return totalScore.ToString();
    }
    
    public string Part2()
    {
        var stringsSplitInThree = new List<List<string>> { };
        for (int i = 0; i < _rawStrings.Count(); i += 3)
        {
            var group = new List<string> { _rawStrings[i], _rawStrings[i+1], _rawStrings[i+2] };
            stringsSplitInThree.Add(group);
        }

        var totalScore = stringsSplitInThree.Sum(group =>
            Letters.IndexOf(group[0].First(letter => group[1].Contains(letter) && group[2].Contains(letter))) + 1);
        
        return totalScore.ToString();
    }
}