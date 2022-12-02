namespace adventofcode2022.Helpers;

public interface IReadInputFile
{
    int[] GetInputAsListOfInts(string path);
    IEnumerable<IEnumerable<int>> GetGroupOfInts(string path);
    IEnumerable<string> GetListOfStringsFromInput(string path);
}

public class ReadInputFile : IReadInputFile
{
    private const string BasePath = @"C:\programmering\adventofcode2022\adventofcode2022\";

    public int[] GetInputAsListOfInts(string path)
    {
        var readText = File.ReadAllLines(BasePath + path);
        return readText.Select(int.Parse).ToArray();
    }

    public IEnumerable<IEnumerable<int>> GetGroupOfInts(string path)
    {
        var readText = File.ReadAllLines(BasePath + path);
        var temp = new List<int>();
        var result = new List<List<int>>();

        foreach (string entry in readText)
        {
            if (entry == "")
            {
                result.Add(temp);
                temp = new List<int>();
            }
            else
            {
                temp.Add(Int32.Parse(entry));
            }
        }

        return result;
    }

    public IEnumerable<string> GetListOfStringsFromInput(string path)
    {
        var readText = File.ReadAllLines(BasePath + path);
        return readText;
    }
}