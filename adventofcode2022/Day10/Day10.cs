using System.Text;
using adventofcode2022.Helpers;

namespace adventofcode2022.Day10;

public class Day10
{
    private readonly IReadInputFile _readInputFile;
    private string[] _commands;

    private int _signalStrength = 0;
    
    public Day10(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        _commands = _readInputFile.GetListOfStringsFromInput(@"Day10\input.txt").ToArray();
        var (cycleCount, x) = (0, 1);
        
        foreach (var command in _commands)
        {
            var splitCommand = command.Split(" ");
            if(splitCommand[0] == "noop") 
                cycleCount = DoCycle(cycleCount, x);
            else
            {
                cycleCount = DoCycle(cycleCount, x);
                cycleCount = DoCycle(cycleCount, x);
                x += int.Parse(splitCommand[1]);
            }
        }
        
        return "Signal strength: " + _signalStrength;
    }

    private int DoCycle(int prevCycle, int x)
    {
        var newCycle = prevCycle + 1;
        if (newCycle % 40 == 20) _signalStrength += x * newCycle;
        return newCycle;
    }
    
    
    public string Part2()
    {
        var line = "........................................";
        var (cycleCount, x) = (0, 1);
        var lines = new string[] { };
        
        foreach (var command in _commands)
        {
            if (cycleCount % 40 == 0)
            {
                lines = lines.Append(line).ToArray();
                line = "........................................";
            }
            var splitCommand = command.Split(" ");
            if(splitCommand[0] == "noop") 
                (cycleCount, line) = DoCyclePart2(cycleCount, x, line);
            else
            {
                (cycleCount, line) = DoCyclePart2(cycleCount, x, line);
                (cycleCount, line) = DoCyclePart2(cycleCount, x, line);
                x += int.Parse(splitCommand[1]);
            }
        }
        
        return String.Join("\n", lines.Append(line).Skip(1));
    }
    
    private (int, string) DoCyclePart2(int prevCycle, int x, string line)
    {
        var (newLine, drawInPos) = (line, prevCycle % 40);
        var (first, second, third) = (x - 1, x, x + 1);
        if (drawInPos == first || drawInPos == second || drawInPos == third)
        {
            StringBuilder sb = new StringBuilder(newLine);
            sb[drawInPos] = '#';
            newLine = sb.ToString();
        }
        
        var newCycle = prevCycle + 1;
        if (newCycle % 40 == 20) _signalStrength += x * newCycle;
        
        return (newCycle, newLine);
    }
}