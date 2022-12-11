namespace adventofcode2022.Day11;

public class Monkey
{
    public Monkey(int monkeyNum, long[] startingItems, long testNum, int operationType, int monkeyIfTrue,
        int monkeyIfFalse, int operationNumber = 0)
    {
        MonkeyNum = monkeyNum;
        Items = startingItems;
        DivisibleBy = testNum;
        OperationType = operationType;
        OperationNumber = operationNumber;
        MonkeyNumIfTrue = monkeyIfTrue;
        MonkeyNumIfFalse = monkeyIfFalse;
    }

    public (long, int) Turn()
    {
        InspectCount += 1;
        var worryLevel = DoOperation(Items[0]) / 3;
        ThrowItem();
        if (Test(worryLevel)) return (worryLevel, MonkeyNumIfTrue);
        return (worryLevel, MonkeyNumIfFalse);
    }

    public (long, int) TurnPart2(long factor)
    {
        InspectCount += 1;
        var worryLevel = DoOperation(Items[0]) % factor;
        ThrowItem();
        if (Test(worryLevel)) return (worryLevel, MonkeyNumIfTrue);
        return (worryLevel, MonkeyNumIfFalse);
    }

    private void ThrowItem() => Items = Items.Skip(1).ToArray();
    
    public void ReceiveItem(long worryLevel) => Items = Items.Append(worryLevel).ToArray();

    private long DoOperation(long oldNum)
    {
        if (OperationType == 1) return oldNum * OperationNumber;
        if (OperationType == 2) return oldNum + OperationNumber;
        if (OperationType == 3) return oldNum * oldNum;
        if (OperationType == 4) return oldNum + oldNum;
        return 0;
    }

    private bool Test(long num) => num % DivisibleBy == 0;

    public bool HasMoreItems => Items.Length != 0;
    public int MonkeyNum { get; }
    private long[] Items { get; set; }
    public long DivisibleBy { get; }
    public int InspectCount { get; set; }

    // old * num => 1, old + num => 2, old * old => 3, old + old => 4
    private int OperationType { get; }
    private int OperationNumber { get; }
    private int MonkeyNumIfTrue { get; }
    private int MonkeyNumIfFalse { get; }
}