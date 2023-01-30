namespace SnakeAndLadders.Board;

public class Marker
{
    private readonly List<Player> _playersName;
    private readonly List<int> _position;

    public Marker(List<Player> playersName)
    {
        _playersName = playersName;
        _position = new List<int>(_playersName.Count);

        for (var i = 0; i < playersName.Count; i++) _position.Add(0);
    }

    public string GetPlayerName(int turn) => _playersName[turn].GetName();

    public int GetPlayerPosition(int turn) => _position[turn];

    public void ChangePlayerPosition(int turn, int destination) => _position[turn] = destination;

    public int GetTotalPlayer() => _playersName.Count;
    
    public bool IsGameFinished() => _position.TrueForAll(o => o == 100);
}