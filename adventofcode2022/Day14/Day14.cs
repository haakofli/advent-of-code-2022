using System.Text;
using adventofcode2022.Helpers;

namespace adventofcode2022.Day14;

public class Day14
{
    private readonly IReadInputFile _helper;
    
    public Day14(IReadInputFile readInputFile)
    {
        _helper = readInputFile;
    }

    public string Part1()
    {
        var lines = _helper.GetListOfStringsFromInput(@"Day14\input.txt").ToArray();
        var (x1, x2) = (400, 600);
        var (y1, y2) = (0, 165);
        var (startX, startY, map) = CreateRockFormations(lines, x1, x2, y1, y2);
        
        bool isAbyss = false;
        var sandCount = 0;
        while (!isAbyss)
        {
            (isAbyss, map) = SandFall(map, startX, startY);
            sandCount = isAbyss ? sandCount : sandCount + 1;
        }
        
        return sandCount.ToString();
    }

    public string Part2()
    {
        var lines = _helper.GetListOfStringsFromInput(@"Day14\input.txt").ToArray();
        var (x1, x2) = (0, 1000);
        var (y1, y2) = (0, 165);
        var (startX, startY, map) = CreateRockFormations(lines, x1, x2, y1, y2);

        for (int i = 0; i < x2-x1; i++)
        {
            StringBuilder sb = new StringBuilder(map[y2-2]);
            sb[i] = '#';
            map[y2-2] = sb.ToString();
        }
        
        bool isAbyss = false;
        var sandCount = 0;
        while (!isAbyss)
        {
            (isAbyss, map) = SandFall(map, startX, startY);
            sandCount = isAbyss ? sandCount : sandCount + 1;
            if (map[0][500 - x1] != '+') isAbyss = true;
        }
        
        return sandCount.ToString();
    }

    private (bool, string[]) SandFall(string[] map, int posX, int posY)
    {
        bool isAbyss = false;
        if (IsInAbyss(map, posX, posY)) 
            return (true, map);
        if (CanDropOneDown(map, posX, posY)) 
            (isAbyss, map) = SandFall(map, posX, posY + 1);
        else if (CanDropDownLeft(map, posX, posY)) 
            (isAbyss, map) = SandFall(map, posX - 1, posY + 1);
        else if (CanDropDownRight(map, posX, posY))
            (isAbyss, map) = SandFall(map, posX + 1, posY + 1);
        else 
            map[posY] = _helper.ReplaceCharInStringAtIndex(map[posY], posX, 'o');
        
        return (isAbyss, map);
    }
    
    private bool IsInAbyss(string[] map, int posX, int posY) => posY >= map.Length - 1;
    
    private bool CanDropOneDown(string[] map, int posX, int posY) => map[posY + 1][posX] == '.';
    
    private bool CanDropDownLeft(string[] map, int posX, int posY) => map[posY + 1][posX - 1] == '.';

    private bool CanDropDownRight(string[] map, int posX, int posY) => map[posY + 1][posX + 1] == '.';
    
    private (int, int, string[]) CreateRockFormations(string[] lines, int startX, int stopX, int startY, int stopY)
    {
        string[] map = {}; 
        
        for (int i = startY; i < stopY + 1; i++)
        {
            var line = "";
            for (int j = startX; j < stopX + 1; j++) line += ".";
            map = map.Append(line).ToArray();
        }

        foreach (var line in lines)
        {
            var x = line.Split(" -> ");
            
            for (int i = 0; i < x.Length - 1; i++)
            {
                var (y1, y2) = (x[i].Split(","), x[i+1].Split(","));
                var (x1Pos, y1Pos) = (int.Parse(y1[0]) - startX, int.Parse(y1[1]) - startY);
                var (x2Pos, y2Pos) = (int.Parse(y2[0]) - startX, int.Parse(y2[1]) - startY);
                
                if (x1Pos == x2Pos)
                    for (int j = y1Pos > y2Pos ? y2Pos: y1Pos; y1Pos > y2Pos ? j < y1Pos + 1 : j < y2Pos + 1; j++)
                        map[j] = _helper.ReplaceCharInStringAtIndex(map[j], x1Pos, '#');
                else
                    for (int j = x1Pos > x2Pos ? x2Pos: x1Pos; x1Pos > x2Pos ? j < x1Pos + 1 : j < x2Pos + 1; j++)
                        map[y1Pos] = _helper.ReplaceCharInStringAtIndex(map[y1Pos], j, '#');
            }
        }

        map[0] = _helper.ReplaceCharInStringAtIndex(map[0], 500-startX, '+');
        
        return (500-startX, startY, map);
    }
}