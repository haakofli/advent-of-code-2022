using adventofcode2022.Helpers;

namespace adventofcode2022.Day6;

public class Day6
{
    private readonly IReadInputFile _readInputFile;
    private string _rawString;
    
    public Day6(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    private string FindStartOfMessageMarker(int messageLength, char[] characters)
    {
        foreach (var (character, i) in _rawString.Skip(messageLength - 1).Select((value, i) => (value, i)))
        {
            characters = characters.Skip(1).ToArray().Append(character).ToArray();
            
            if (characters.Length ==  characters.Distinct().ToArray().Length)
            {
                return (i+messageLength).ToString();
            }
        }
        
        return "Could not find matching sequences";
    }
    
    public string Part1()
    {
        _rawString = _readInputFile.GetListOfStringsFromInput(@"Day6\input.txt").ToArray()[0];
        var characters = _rawString.Take(4).ToArray();
        return FindStartOfMessageMarker(4, characters);
    }
    
    public string Part2()
    {
        var characters = _rawString.Take(14).ToArray();
        return FindStartOfMessageMarker(14, characters);
    }
}