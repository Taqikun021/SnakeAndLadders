namespace SnakeAndLadders;

public class Step
{
    public string PlayerName { get; }
    public int From { get; }
    public int To { get; }

    public Step(string playerName, int from, int to)
    {
        PlayerName = playerName;
        From = from;
        To = to;
    }
}