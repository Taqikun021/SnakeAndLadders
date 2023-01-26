using SnakeAndLadders.Board;

namespace SnakeAndLadders;

public class Game
{
    private readonly Board.Board _board;
    private readonly List<Player> _player;
    private readonly List<int> _position;
    private const int DefaultBoardSize = 100;
    private int _turn;

    public Game(List<Player> players)
    {
        _board = new Board.Board();
        _player = players;
        _position = new List<int>();
        _turn = 0;

        foreach (var _ in players)
        {
            _position.Add(0);
        }

        var obstacle = new List<Obstacle>();
        obstacle.AddRange(new []
        {
            new Obstacle(4, 14),
            new Obstacle(9, 31),
            new Obstacle(16, 6),
            new Obstacle(21, 42),
            new Obstacle(28, 84),
            new Obstacle(33, 11),
            new Obstacle(36, 44),
            new Obstacle(47, 26),
            new Obstacle(51, 67),
            new Obstacle(56, 49),
            new Obstacle(62, 19),
            new Obstacle(64, 60),
            new Obstacle(71, 91),
            new Obstacle(80, 99),
            new Obstacle(87, 24),
            new Obstacle(93, 73),
            new Obstacle(95, 75)
        });
        _board.SetObstacles(obstacle);
    }

    public void StartGame()
    {
        while (!IsGameFinished())
        {
            Console.WriteLine($"It's {_player[_turn]}'s turn. Press <Enter> to run the Dice!");
            if (Console.ReadKey().Key != ConsoleKey.Enter) _position[_turn] = MovePosition();

            if (IsPlayerWon()) Console.WriteLine($"{_player[_turn]} wins the game!");
            NextTurn();
        }
        Console.WriteLine("The Game Has Finished!");
    }

    private void NextTurn()
    {
        _turn = _turn != _position.Count - 1 ? _turn + 1 : 0;
        if (IsPlayerWon()) NextTurn();
    }

    private int MovePosition()
    {
        var dice = Dice.Roll();
        Console.WriteLine($"It's a {dice}!");
        int newPosition;
        if (_position[_turn] > 100)
        {
            newPosition = _position[_turn];
            Console.WriteLine("We can't move.");
        }
        else
        {
            newPosition = dice + _position[_turn];
            Console.WriteLine($"{_player[_turn]} just move from {_position[_turn]} to {newPosition}");
        }

        if (!_board.IsThereAnObstacle(newPosition)) return newPosition;
        var check = IsSnakeOrLadder(newPosition);
        Console.WriteLine($"Oops! There is a {check.varian}");
        newPosition = check.destination;
        Console.WriteLine($"{_player[_turn]} just move from {_position[_turn]} to {newPosition}");

        return newPosition;
    }

    private (string varian, int destination) IsSnakeOrLadder(int position)
    {
        var list = _board.GetObstacles();
        var obs = list.Find(o => o.GetStart() == position);
        return obs!.GetStart() > obs.GetEnd() ? ("Snake", obs.GetEnd()): ("Ladder", obs.GetEnd());
    }

    private bool IsGameFinished() => _position.TrueForAll(o => o == DefaultBoardSize);

    private bool IsPlayerWon() => _position[_turn] == DefaultBoardSize;
}