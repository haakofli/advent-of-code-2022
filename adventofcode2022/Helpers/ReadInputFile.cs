namespace adventofcode2022.Helpers;

public interface IReadInputFile
{
    int[] GetInputAsListOfInts(string path);
}

public class ReadInputFile : IReadInputFile
{
    private static readonly string basePath = @"C:\programmering\adventofcode2022\adventofcode2022\";

    public int[] GetInputAsListOfInts(string path)
    {
        var readText = File.ReadAllLines(basePath + path);
        return readText.Select(int.Parse).ToArray();
    }
}