using SnakeAndLadders.Board;

namespace SnakeAndLadders;

public class Game
{
    private const int DefaultBoardSize = 100;
    private int _turn;
    private readonly Marker _player;

    public Game(List<Player> players)
    {
        _player = new Marker(players);
        _turn = 0;
    }

    public string GetTurn() => _player.GetPlayerName(_turn);

    private void NextTurn() => _turn = _turn != _player.GetTotalPlayer() - 1 ? _turn + 1 : 0;

    private void MovePosition(int destination) => _player.ChangePlayerPosition(_turn, destination);

    private bool IsPlayerWon() => _player.GetPlayerPosition(_turn) == DefaultBoardSize;
}