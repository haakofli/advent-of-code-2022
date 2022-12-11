namespace adventofcode2022.Day11;

public class Day11
{
    public Monkey[] GetMonkeys() => new[]
    {
        new Monkey(0, new[] { (long)59, 65, 86, 56, 74, 57, 56 }, 3, 1, 3, 6, 17),
        new Monkey(1, new[] { (long)63, 83, 50, 63, 56 }, 13, 2, 3, 0, 2),
        new Monkey(2, new[] { (long)93, 79, 74, 55 }, 2, 2, 0, 1, 1),
        new Monkey(3, new[] { (long)86, 61, 67, 88, 94, 69, 56, 91 }, 11, 2, 6, 7, 7),
        new Monkey(4, new[] { (long)76, 50, 51 }, 19, 3, 2, 5),
        new Monkey(5, new[] { (long)77, 76 }, 17, 2, 2, 1, 8),
        new Monkey(6, new[] { (long)74 }, 5, 1, 4, 7, 2),
        new Monkey(7, new[] { (long)86, 85, 52, 86, 91, 95 }, 7, 2, 4, 5, 6)
    };
    
    public string Part1()
    {
        var monkeys = GetMonkeys();
        
        for (int i = 0; i < 20; i++) Round(monkeys, 1, 0);
        
        var ordered = monkeys.OrderByDescending(x => x.InspectCount).ToArray();
        return $"Monkey Business: {(long)ordered[0].InspectCount * ordered[1].InspectCount}";
    }
    
    public string Part2()
    {
        var monkeys = GetMonkeys();
        
        var factor = monkeys.Aggregate(1, (c, monkey) => c * (int)monkey.DivisibleBy);
        for (int i = 0; i < 10000; i++) Round(monkeys, 2, factor);

        var ordered = monkeys.OrderByDescending(x => x.InspectCount).ToArray();
        return $"Monkey Business: {(long)ordered[0].InspectCount * ordered[1].InspectCount}";
    }

    private void Round(Monkey[] monkeys, int part, int factor)
    {
        foreach (var monkey in monkeys)
            while (monkey.HasMoreItems)
            {
                var (worryLevel, monkeyNum) = part == 1 ? monkey.Turn(): monkey.TurnPart2(factor);
                monkeys.Single(m => m.MonkeyNum == monkeyNum).ReceiveItem(worryLevel);
            }
    }
}