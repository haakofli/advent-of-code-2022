using adventofcode2022.Helpers;

namespace adventofcode2022.Day8;

public class Day8
{
    private readonly IReadInputFile _readInputFile;
    
    public Day8(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        var rowsOfStrings = _readInputFile.GetListOfStringsFromInput(@"Day8\input.txt").ToArray();
        var count = (rowsOfStrings.Length * 2) + (rowsOfStrings[0].Length * 2) - 4;

        for (int y = 1; y < rowsOfStrings.Length - 1; y++)
            for (int x = 1; x < rowsOfStrings[0].Length - 1; x++)
                if (IsVisible(rowsOfStrings, x, y, int.Parse(rowsOfStrings[y][x].ToString())))
                    count += 1;
        
        return count.ToString();
    }

    private bool IsVisible(string[] strings, int posX, int posY, int height)
    {
        var (right, left, up, down) = (true, true, true, true);
        
        for (int i = 0; i < posX; i++) // check left
            if (int.Parse(strings[posY][i].ToString()) >= height) left = false;

        for (int i = posX + 1; i < strings[0].Length; i++) // check right
            if (int.Parse(strings[posY][i].ToString()) >= height) right = false;
        
        for (int i = 0; i < posY; i++) // check up
            if (int.Parse(strings[i][posX].ToString()) >= height) up = false;
        
        for (int i = posY + 1; i < strings.Length; i++) // check down
            if (int.Parse(strings[i][posX].ToString()) >= height) down = false;

        return up || down || left || right;
    }
    
    public string Part2()
    {
        var rowsOfStrings = _readInputFile.GetListOfStringsFromInput(@"Day8\input.txt").ToArray();
        var highest = 0;

        for (int y = 1; y < rowsOfStrings.Length - 1; y++)
            for (int x = 1; x < rowsOfStrings[0].Length - 1; x++)
            {
                var scenicScore = GetScenicScore(rowsOfStrings, x, y, int.Parse(rowsOfStrings[y][x].ToString()));
                if (scenicScore > highest) highest = scenicScore;
            }

        return highest.ToString();
    }
    
    private int GetScenicScore(string[] strings, int posX, int posY, int height)
    {
        var (right, left, up, down) = (0, 0, 0, 0);
        
        for (int i = posX - 1; i >= 0; i--) // check left
            if (int.Parse(strings[posY][i].ToString()) < height || i == 0) 
                left = posX - i;
            else
            {
                left = posX - i;
                break;
            }

        for (int i = posX + 1; i < strings[0].Length; i++) // check right
            if (int.Parse(strings[posY][i].ToString()) < height)
                right = i - posX;
            else
            {
                right = i - posX;
                break;
            }

        for (int i = posY - 1; i >= 0; i--) // check up
            if (int.Parse(strings[i][posX].ToString()) < height)
                up = posY - i;
            else
            {
                up = posY - i;
                break;
            }
        
        for (int i = posY + 1; i < strings.Length; i++) // check down
            if (int.Parse(strings[i][posX].ToString()) < height)
                down = i - posY;
            else
            {
                down = i - posY; 
                break;
            }

        return up * down * left * right;
    }
}