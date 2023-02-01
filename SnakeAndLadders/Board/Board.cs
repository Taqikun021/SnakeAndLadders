namespace SnakeAndLadders.Board;

public class Board
{
    public List<Obstacle>? Obstacles { get; set; }

    public Board() => Obstacles = new List<Obstacle>();

    public bool IsThereAnObstacle(int position) => Obstacles!.Exists(o => o.Start == position);

    public Obstacle? GetObstacle(int position) => Obstacles!.Find(o => o.Start == position);
}