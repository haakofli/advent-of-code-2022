using adventofcode2022.Helpers;

namespace adventofcode2022.Day4;

public class Day4
{
    private readonly IReadInputFile _readInputFile;
    private int[][][] _formattedInput;

    public Day4(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        var listOfStrings = _readInputFile.GetListOfStringsFromInput(@"Day4\input.txt").ToArray();
        _formattedInput = listOfStrings.Select(line => 
            line.Split(",").Select(x => x.Split("-")
                .Select(int.Parse).ToArray()).ToArray()).ToArray();

        var occurrences = _formattedInput.Count(pair => 
            (pair[0][0] <= pair[1][0] && pair[0][1] >= pair[1][1]) ||
            (pair[0][0] >= pair[1][0] && pair[0][1] <= pair[1][1]));

        return occurrences.ToString();
    }
    
    public string Part2()
    {
        var occurrences = _formattedInput.Count(pair =>
            (pair[0][0] <= pair[1][0] && pair[0][1] >= pair[1][0]) ||
            (pair[1][0] <= pair[0][0] && pair[1][1] >= pair[0][0]));
        
        return occurrences.ToString();
    }
}