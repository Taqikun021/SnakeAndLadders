namespace SnakeAndLadders.Board;

public class Obstacle
{
    private readonly int _start;
    private readonly int _end;

    public Obstacle(int start, int end)
    {
        _start = start;
        _end = end;
    }

    public int GetStart() => _start;

    public int GetEnd() => _end;
}