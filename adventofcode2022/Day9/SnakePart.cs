namespace adventofcode2022.Day9;

public class SnakePart
{
    public void MoveInit(string direction)
    {
        if (direction == "R") X += 1;
        if (direction == "L") X -= 1;
        if (direction == "U") Y += 1;
        if (direction == "D") Y -= 1;

        ShouldChildMove();
    }

    private void ShouldChildMove()
    {
        if (HasChild())
        {
            var (xDistance, yDistance) = GetDistanceFromChild();
            
            if ((xDistance == 0 && yDistance == 2) || (xDistance == 2 && yDistance == 0) || 
                (xDistance == 2 && yDistance == 1) || (xDistance == 1 && yDistance == 2) || 
                (xDistance == 2 && yDistance == 2))
            {
                var xDir = X > Child!.X ? 1 : X == Child.X ? 0 : -1;
                var yDir = Y > Child!.Y ? 1 : Y == Child.Y ? 0 : -1;
                Child!.Move(xDir, yDir);
            }
        }
    }
    
    private void Move(int x, int y)
    {
        X += x;
        Y += y;
        ShouldChildMove();
    }
    
    private bool HasChild() => Child != null;
    private (int, int) GetDistanceFromChild() => (Math.Abs(Child!.X - X), Math.Abs(Child.Y - Y));
    public SnakePart? Child { get; private set; }
    public void AddChild(SnakePart snakePart) => Child = snakePart;
    public int X { get; private set; }
    public int Y { get; private set; }
}