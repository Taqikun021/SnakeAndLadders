namespace SnakeAndLadders.Board;

public class Obstacle
{
    public int Start { get; }
    public int End { get; }

    public Obstacle(int start, int end)
    {
        Start = start;
        End = end;
    }
}