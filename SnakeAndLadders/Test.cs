namespace SnakeAndLadders;

public class Test
{
    public static void Main()
    {
        Console.WriteLine("Number of player : ");
        var theNumberOfPlayers = Console.Read();
        var players = new List<Player>();
        Console.WriteLine("Player Name :");
        for (var i = 0; i < theNumberOfPlayers; i++)
        {
            var player = new Player(Console.ReadLine() ?? $"Player{i+1}");
            players.Add(player);
        }
    }
}