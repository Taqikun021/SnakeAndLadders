using System.Text.Json;
using SnakeAndLadders.Board;

namespace SnakeAndLadders;

public class Test
{
    private static readonly List<Player> Players = new();
    private static readonly List<Step> Steps = new();
    private static readonly Board.Board Board = new();
    
    public static void Main()
    {
        Console.Write("Number of player : ");
        var theNumberOfPlayers = Convert.ToInt32(Console.ReadLine());
        for (var i = 0; i < theNumberOfPlayers; i++) Players.Add(new Player($"Player{i + 1}"));
        List<Obstacle>? source;  
  
        using (var r = new StreamReader("../../../json/obstacles.json"))  
        {  
            var json = r.ReadToEnd();  
            source = JsonSerializer.Deserialize<List<Obstacle>>(json);  
        }

        Board.Obstacles = source;

        while (Players.Count != 1)
        {
            for (var i=0; i <Players.Count; i++)
            {
                Console.WriteLine($"It's {Players[i].Name}'s Turn!");
                var oldIndex = i == Players.Count - 1 ? 0 : i + 1;
                var distance = Players[oldIndex].Position - Players[i].Position;
                var dice = RollTheDice(distance);
                Console.WriteLine($"It's {dice.first} and {dice.second}!");
                var total = dice.first + dice.second;
                var newPosition = Players[i].Position + total;
                CheckTotal(Players[i], newPosition);
                Console.WriteLine("\n");
                //Thread.Sleep(2000);
            }
        }
        Console.WriteLine($"{Players[0].Name} lose!");
        var date = (int) DateTime.Now.Ticks;
        ExportMove(date);
        Console.WriteLine($"The game today has been recorded in File Game-{date}.json");
        Console.WriteLine("--LAST LINE OF THE GAME--");
    }

    private static void ExportMove(int date)
    {
        var jsonString = JsonSerializer.Serialize(Steps, new JsonSerializerOptions { WriteIndented = true});
        using var outputFile = new StreamWriter($"../../../json/Game-{date}.json");
        outputFile.WriteLine(jsonString);
    }

    private static void CheckObs(Player player, int total)
    {
        if (!Board.IsThereAnObstacle(total)) return;
        var obs = Board.GetObstacle(total);
        var status = obs!.Start > obs.End ? "Snake" : "Ladder";
        var expression = status == "Snake" ? "Oops" : "Yeay";
        Console.Write($"{expression}, It's a {status}. ");
        MovePlayer(player, obs.End);
        Console.WriteLine($"{player.Name} just moved from {total} to {obs.End}");
    }

    private static void CheckTotal(Player player, int total)
    {
        switch (total)
        {
            case < 100:
                Console.WriteLine($"{player.Name} move from {player.Position} to {total}");
                MovePlayer(player, total);
                CheckObs(player, player.Position);
                break;
            case 100:
                Console.WriteLine($"{player.Name} WIN!");
                Players.Remove(player);
                break;
            default:
                var newPosition = 100 - (total - 100);
                Console.WriteLine($"Oops! More than 100, {player.Name} move backward from {player.Position} to {newPosition}!");
                MovePlayer(player, newPosition);
                CheckObs(player, player.Position);
                break;
        }
    }

    private static (int first, int second) RollTheDice(int seed) => (Dice.Roll(), Dice.Roll(seed));

    private static void MovePlayer(Player player, int destination)
    {
        RecordMove(player.Name, player.Position, destination);
        player.Position = destination;
    }

    private static void RecordMove(string playerName, int from, int to) => Steps.Add(new Step(playerName, from, to));
}