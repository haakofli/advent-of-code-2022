using adventofcode2022.Helpers;

namespace adventofcode2022.Template;

public class DayX
{
    private readonly IReadInputFile _readInputFile;
    
    public DayX(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        var testStrings = _readInputFile.GetInputAsListOfInts(@"DayX\input.txt");
        return testStrings[0].ToString();
    }
    
    public string Part2()
    {
        return "part2 goes here";
    }
}