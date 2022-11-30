using adventofcode2022.Helpers;

namespace adventofcode2022.Day1;

public class Day1
{
    private readonly IReadInputFile _readInputFile;
    
    public Day1(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        var testStrings = _readInputFile.GetInputAsListOfInts(@"Day1\input.txt");
        return testStrings[0].ToString();
    }
    
    public string Part2()
    {
        return "part2 goes here";
    }
}